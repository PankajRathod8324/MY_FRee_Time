using System.Threading.Tasks;
using Entities.Models;
using Entities.ViewModel;

namespace DAL.Interfaces;

public interface IEventRepository
{
    List<Event> GetAllEvents();
    Event GetEventById(int id);
    void AddEvent(Event eventEntity);
}