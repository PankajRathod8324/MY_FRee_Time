using DAL.Interfaces;
using Entities.Models;
using Entities.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly PizzaShopContext _context;

    private readonly DbSet<T> _dbset;

    public GenericRepository(PizzaShopContext context)
    {
        _context = context;
        _dbset = context.Set<T>();
    }

    public List<T> GetAll()
    {
        return _dbset.ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

}