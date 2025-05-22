using System.Threading.Tasks;
using Entities.Models;
using Entities.ViewModel;

namespace DAL.Interfaces;

public interface IGenericRepository<T> where T : class
{
    List<T> GetAll();
}