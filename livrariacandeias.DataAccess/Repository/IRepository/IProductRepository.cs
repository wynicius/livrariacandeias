

using System.Linq.Expressions;
using livrariacandeias.DataAccess.Repository.IRepository;
using livrariacandeias.Models;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product obj);
}