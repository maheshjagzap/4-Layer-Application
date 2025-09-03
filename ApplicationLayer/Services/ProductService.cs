using System.Collections.Generic;
using CoreLayer.Entities;
using CoreLayer.Interfaces;

namespace ApplicationLayer.Services
{
    public class ProductService
    {
        private readonly IProduct _productRepository;

        public ProductService(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();

        }
        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }
        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
