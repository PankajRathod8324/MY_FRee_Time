using DAL.Interfaces;
using Entities.Models;
using Entities.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class EventRepository : IEventRepository
{
    private readonly PizzaShopContext _context;

    public EventRepository(PizzaShopContext context)
    {
        _context = context;
    }

    public List<Event> GetAllEvents()
    {
        return _context.Events.ToList();
    }

    public Event GetEventById(int id)
    {
        return _context.Events.Find(id)!;
    }

    public void AddEvent(Event eventEntity)
    {
        _context.Events.Add(eventEntity);
    }
    



    public void Save()
    {
        _context.SaveChanges();
    }

}