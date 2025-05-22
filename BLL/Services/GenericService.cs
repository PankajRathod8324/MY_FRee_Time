using DAL.Interfaces;
using BLL.Interfaces;

namespace BLL.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _genericRepository;
    public GenericService(IGenericRepository<T> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public List<T> GetAll()
    {
        return _genericRepository.GetAll();
    }



}