using System.Collections.Generic;
using CoreLayer.Entities;

namespace CoreLayer.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
