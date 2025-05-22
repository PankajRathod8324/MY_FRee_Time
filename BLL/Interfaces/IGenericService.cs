using System.Threading.Tasks;
using Entities.Models;
using Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using X.PagedList;

namespace  BLL.Interfaces;

public interface IGenericService<T> where T : class
{
    List<T> GetAll();
}