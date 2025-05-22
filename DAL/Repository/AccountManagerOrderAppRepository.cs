using System.Data;
using System.Net.Http.Json;
using DAL.Interfaces;
using Dapper;
using Entities.Models;
using Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Npgsql;

namespace DAL.Repository;

public class AccountManagerOrderAppRepository : IAccountManagerOrderAppRepository
{
    private readonly PizzaShopContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IMenuRepository _menuRepository;
    public AccountManagerOrderAppRepository(PizzaShopContext context, IMenuRepository menuRepository, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _menuRepository = menuRepository;
        _httpContextAccessor = httpContextAccessor;
    }




    public List<OrderSectionVM> GetOrderSection()
    {
        var activeTableOrders = _context.Tables
            .Include(t => t.Status)
            .Include(t => t.CustomerTables)
            .ThenInclude(ct => ct.Customer)
            .ToList();

        var tableInfoList = activeTableOrders.Select(table =>
        {
            var activeCT = table.CustomerTables.FirstOrDefault(ct => (bool)ct.Isactive);
            var activeOrder = activeCT != null
                ? _context.Orders.FirstOrDefault(order =>
                    order.CustomerId == activeCT.CustomerId &&
                    order.OrderStatusId == 6)
                : null;

            return new
            {
                Table = table,
                Order = activeOrder
            };
        }).ToList();


        var groupedByOrder = tableInfoList
      .GroupBy(x => x.Order?.CustomerId)
      .SelectMany(group =>
      {
          if (group.Key != null && group.Count() > 1)
          {
              // Multiple tables with same OrderId merge them
              var first = group.First();
              return new List<OrderTableVM>
              {
                new OrderTableVM
                {
                    SectionId = first.Table.SectionId ?? 0,
                    TableId = 0,
                    TableName = string.Join(", ", group.Select(x => x.Table.TableName).Distinct()),
                    Status = string.Join(", ", group.Select(x => x.Table.Status.StatusName).Distinct()),
                    Capacity = group.Sum(x => x.Table.Capacity),
                    OccuipiedTime = first.Order != null ? (DateTime.UtcNow - first.Order.CreatedAt) : TimeSpan.Zero,
                    OrderTable = new List<OrderTableVM>
                    {
                        new OrderTableVM
                        {
                            OrderId = first.Order.OrderId,
                            Order = new List<OrderVM>
                            {
                                new OrderVM
                                {
                                    OrderId = first.Order.OrderId,
                                    OrderAmount = first.Order.TotalAmount,
                                    CustomerId = first.Order.CustomerId,
                                    OccupiedTime = DateTime.UtcNow - first.Order.CreatedAt
                                }
                            }
                        }
                    },
                    CustomerTables = group
                        .SelectMany(x => x.Table.CustomerTables.Where(ct => (bool)ct.Isactive))
                        .Select(ct => new CustomerTable
                        {
                            CustomerId = ct.CustomerId
                        })
                        .Distinct()
                        .ToList()
                }
              };
          }
          else
          {
              // Each table shown separately (either no order or unique order)
              return group.Select(x => new OrderTableVM
              {
                  SectionId = x.Table.SectionId ?? 0,
                  TableId = x.Table.TableId,
                  TableName = x.Table.TableName,
                  Status = x.Table.Status.StatusName,
                  Capacity = x.Table.Capacity,
                  OccuipiedTime = x.Order != null ? (DateTime.UtcNow - x.Order.CreatedAt) : TimeSpan.Zero,
                  OrderTable = x.Order != null ? new List<OrderTableVM>
                  {
                    new OrderTableVM
                    {
                        OrderId = x.Order.OrderId,
                        Order = new List<OrderVM>
                        {
                            new OrderVM
                            {
                                OrderId = x.Order.OrderId,
                                OrderAmount = x.Order.TotalAmount,
                                CustomerId = x.Order.CustomerId,
                                OccupiedTime = DateTime.UtcNow - x.Order.CreatedAt
                            }
                        }
                    }
                  } : new List<OrderTableVM>(),
                  CustomerTables = x.Table.CustomerTables
                      .Where(ct => (bool)ct.Isactive)
                      .Select(ct => new CustomerTable
                      {
                          CustomerId = ct.CustomerId
                      })
                      .ToList()
              });
          }
      })
      .ToList();


        var sectionData = _context.Sections
            .AsEnumerable()
            .Select(section => new OrderSectionVM
            {
                SectionId = section.SectionId,
                SectionName = section.SectionName,
                Available = section.Tables.Count(t => t.Status.StatusName == "Available"),
                Assigned = section.Tables.Count(t => t.Status.StatusName == "Assigned"),
                Running = section.Tables.Count(t => t.Status.StatusName == "Running"),
                Reserved = section.Tables.Count(t => t.Status.StatusName == "Reserved"),
                Table = groupedByOrder
                    .Where(t => t.SectionId == section.SectionId)
                    .ToList()
            }).ToList();


        return sectionData;
    }

    public List<CustomerTable> GetTablesByCustomerId(int customerId)
    {
        return _context.CustomerTables.Where(c => c.CustomerId == customerId).ToList();
    }

    public List<CustomerTable> GetTablesByActiveCustomerId(int customerId)
    {
        return _context.CustomerTables.Where(c => c.CustomerId == customerId && c.Isactive == true).ToList();
    }

    public List<OrderTax> GetOrderTaxesByOrderId(int OrderId)
    {
        var orderTaxes = _context.OrderTaxes
            .Include(ot => ot.Tax)
            .Where(ot => ot.OrderId == OrderId && ot.Tax.IsEnabled == true && ot.Tax.IsDefault == true).ToList();

        return orderTaxes;
    }

    public List<OrderTax> GetOrderTaxesDefaultByOrderId(int OrderId)
    {
        var orderTaxes = _context.OrderTaxes
           .Include(ot => ot.Tax)
           .Where(ot => ot.OrderId == OrderId && ot.Tax.IsEnabled == true && ot.Tax.IsDefault == false).ToList();

        return orderTaxes;
    }

    // check customer that is associated with orderid or not 
    public bool IsCustomerAssociatedWithOrder(int customerId, int orderId)
    {
        if (orderId != 0)
        {
            var order = _context.Orders
           .Include(o => o.Customer)
           .FirstOrDefault(o => o.OrderId == orderId && o.CustomerId == customerId && o.OrderStatusId != 4 && o.OrderStatusId != 3);
            if (order != null)
            {
                return true; // Customer is associated with the order
            }
            var customerTable = _context.CustomerTables
          .Include(ct => ct.Table)
          .FirstOrDefault(ct => ct.CustomerId == customerId && ct.Isactive == true);
            if (customerTable != null)
            {
                return true; // Customer is associated with the order
            }
        }
        else
        {
            var customerTable = _context.CustomerTables
          .Include(ct => ct.Table)
          .FirstOrDefault(ct => ct.CustomerId == customerId && ct.Isactive == true);
            if (customerTable != null)
            {
                return true; // Customer is associated with the order
            }
        }
        return false;
    }

    public OrderItem GetOrderItem(int orderId, int itemId)
    {
        var orderItem = _context.OrderItems
            .Include(oi => oi.OrderModifiers)
            .FirstOrDefault(oi => oi.OrderId == orderId && oi.ItemId == itemId);

        return orderItem;
    }
    public int GetCustomerIDByName(string email)
    {
        var userId = (from user in _context.Customers
                      where user.Email == email
                      select user.CustomerId).FirstOrDefault();
        return userId;
    }

    public List<WaitingListVM> GetAllWaitingListCustomer(int sectionId)
    {
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        var waitingListData = _context.WaitingLists
            .Where(sectionId == 0 ? temp => temp.IsDeleted == false : temp => temp.SectionId == sectionId && temp.IsDeleted == false)
            .Select(temp => new WaitingListVM
            {
                SectionId = temp.SectionId,
                Name = temp.Name,
                WaitingListId = temp.WaitingListId,
                Email = temp.Email,
                NoOfPerson = temp.NoOfPerson,
                Phone = temp.Phone,
                CreatedAt = TimeZoneInfo.ConvertTimeFromUtc((DateTime)temp.CreatedAt, timeZone),
                Duration = DateTime.Now - TimeZoneInfo.ConvertTimeFromUtc((DateTime)temp.CreatedAt, timeZone),
            }).ToList();
        return waitingListData;
    }

    public WaitingListVM GetWaitingData(int waitingId)
    {
        var waitingData = _context.WaitingLists.Where(waiting => waiting.WaitingListId == waitingId && waiting.IsDeleted == false).FirstOrDefault();
        if (waitingData == null)
        {
            return null;
        }
        var waitingvm = new WaitingListVM
        {
            SectionId = waitingData.SectionId,
            Name = waitingData.Name,
            WaitingListId = waitingData.WaitingListId,
            Email = waitingData.Email,
            NoOfPerson = waitingData.NoOfPerson,
            Phone = waitingData.Phone,
            IsDeleted = (bool)waitingData.IsDeleted
        };
        return waitingvm;
    }

    public WaitingListVM GetWaitingDataByEmail(string email)
    {
        var waitingData = _context.Customers.Where(waiting => waiting.Email == email).FirstOrDefault();
        if (email == null)
        {
            return null;
        }
        var waitingvm = new WaitingListVM
        {
            SectionId = _context.Tables.Where(t => t.TableId == waitingData.TableId).FirstOrDefault().SectionId ?? 0,
            Name = waitingData.Name,
            Email = waitingData.Email,
            NoOfPerson = (int)waitingData.Noofperson,
            Phone = waitingData.Phone,
        };

        return waitingvm;
    }
    public WaitingList GetWaitingListBySectionId(int sectionId)
    {
        var waitingList = _context.WaitingLists
            .Where(w => w.SectionId == sectionId && w.IsDeleted == false)
            .ToList();

        return waitingList.FirstOrDefault();
    }

    public Customer IsCustomer(string email)
    {
        return _context.Customers.FirstOrDefault(c => c.Email == email);
    }

    public Customer GetCustomer(int customerId)
    {
        return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
    }

    public WaitingList IsInWaitingList(string email)
    {
        return _context.WaitingLists.FirstOrDefault(c => c.Email == email && c.IsDeleted == false);
    }

    public void AddInWaitingList(WaitingList customerTable)
    {
        _context.WaitingLists.Add(customerTable);
        Save();
    }

    public void DeleteCustomerFromWaitingList(string email)
    {
        var existingItem = _context.WaitingLists.Where(m => m.Email == email).ToList();
        foreach (var user in existingItem)
        {
            user.IsDeleted = true;

        }
        Save();
    }

    public List<OrderVM> GetOrderCategoryItem(int categoryId, string? status)
    {
        // return _context.Set<OrderVM>().ToList();
        var connectionString = "Server=localhost; Database=PizzaShop; Username=postgres; password=tatva123; Timezone=Asia/Kolkata;"; // Replace with your actual connection string
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        string jsonResult;
        using (var cmd = new NpgsqlCommand("SELECT public.get_kot_details_by_category(@p_category_id, @p_status);", connection, transaction))
        {
            cmd.Parameters.AddWithValue("p_category_id", categoryId);
            cmd.Parameters.AddWithValue("p_status", (object?)status ?? DBNull.Value);
            jsonResult = cmd.ExecuteScalar()?.ToString();
        }
        var orderVMs = new List<OrderVM>();
        if (!string.IsNullOrEmpty(jsonResult))
        {
            orderVMs = JsonConvert.DeserializeObject<List<OrderVM>>(jsonResult);
        }
        transaction.Commit();

        return orderVMs.Count > 0 ? orderVMs : new List<OrderVM>();
    }
    public bool PrepareItem(List<PrepareItemVM> prepareItems)
    {
        var json = JsonConvert.SerializeObject(prepareItems);
        _context.Database.ExecuteSqlRaw("CALL prepare_items({0}::jsonb)", json);
        return true;
    }

    public List<MenuCategoryVM> GetFavouriteItems()
    {
        string useremail = _httpContextAccessor.HttpContext.Request.Cookies["Email"];
        var user = _context.Users.FirstOrDefault(u => u.Email == useremail);
        var favouriteItems = _context.Favourites
            .Where(f => f.UserId == user.UserId)
            .Select(f => f.ItemId)
            .ToList();

        var menuItems = _context.MenuItems
            .Where(m => favouriteItems.Contains(m.ItemId))
            .ToList();

        var itemvm = menuItems.Select(item => new MenuCategoryVM
        {
            ItemId = item.ItemId,
            ItemName = item.ItemName,
            UnitId = item.UnitId,
            CategoryId = item.CategoryId,
            ItemtypeId = item.ItemtypeId,
            Rate = item.Rate,
            Quantity = item.Quantity,
            IsAvailable = (bool)item.IsAvailable,
            TaxDefault = item.TaxDefault,
            TaxPercentage = item.TaxPercentage,
            ShortCode = item.ShortCode,
            Description = item.Description,
            ItemPhoto = item.CategoryPhoto,
            IsFavourite = _menuRepository.IsItemFavourite(item.ItemId, user.UserId) ? true : false,
        }).ToList();

        return itemvm;
    }

    public bool AddToFavouriteItem(Favourite favouriteItem)
    {
        var existingItem = _context.Favourites.FirstOrDefault(m => m.ItemId == favouriteItem.ItemId && m.UserId == favouriteItem.UserId);
        if (existingItem == null)
        {
            _context.Favourites.Add(favouriteItem);
            Save();
            return true;
        }
        else
        {
            _context.Favourites.Remove(existingItem);
            Save();
            return false;
        }
    }

    public bool DeleteWaitingToken(int waitingId)
    {
        var waitingList = _context.WaitingLists.FirstOrDefault(w => w.WaitingListId == waitingId);
        if (waitingList != null)
        {
            waitingList.IsDeleted = true;
            Save();
            return true;
        }
        return false;
    }

    public bool EditCustomer(Customer customerdata)
    {
        Save();
        return true;
    }

    public void UpdateWaitingList(WaitingListVM waitingList)
    {
        var existingItem = _context.WaitingLists.FirstOrDefault(m => m.WaitingListId == waitingList.WaitingListId);
        if (existingItem != null)
        {
            existingItem.Name = waitingList.Name;
            existingItem.NoOfPerson = waitingList.NoOfPerson;
            existingItem.Phone = waitingList.Phone;
            existingItem.Email = waitingList.Email;
            existingItem.SectionId = (int)waitingList.SectionId;
            Save();
        }
    }

    public Order GetOrderItemById(int orderId)
    {
        var orderItem = _context.Orders
            .Include(oi => oi.OrderItems)
            .ThenInclude(oi => oi.OrderModifiers)
            .FirstOrDefault(oi => oi.OrderId == orderId);

        return orderItem;
    }

    public void DeleteOrderItem(int OrderItemId)
    {
        var orderItem = _context.OrderItems.FirstOrDefault(x => x.OrderItemId == OrderItemId);
        if (orderItem != null)
        {
            _context.OrderItems.Remove(orderItem);
            Save();
        }
    }

    public void DeleteOrderModifier(int OrderModifierId)
    {
        var orderModifier = _context.OrderModifiers.FirstOrDefault(x => x.OrderModifierId == OrderModifierId);
        if (orderModifier != null)
        {
            _context.OrderModifiers.Remove(orderModifier);
            Save();
        }
    }

    public void DeleteOrderTax(int OrderTaxId)
    {
        var orderTax = _context.OrderTaxes.FirstOrDefault(x => x.OrderTaxId == OrderTaxId);
        if (orderTax != null)
        {
            _context.OrderTaxes.Remove(orderTax);
            Save();
        }
    }

    public void UpdateCustomerTableStatus(int tableId)
    {
        var customerTable = _context.CustomerTables.FirstOrDefault(x => x.TableId == tableId);
        if (customerTable != null)
        {
            customerTable.Isactive = false;
            _context.CustomerTables.Update(customerTable);
            Save();
        }
    }

    public void AddReview(Review review)
    {
        _context.Reviews.Add(review);
        Save();
    }

    public void AddOrderTable(OrderTable orderTable)
    {
        _context.OrderTables.Add(orderTable);
        Save();
    }
    public void Save()
    {
        _context.SaveChanges();
    }
}