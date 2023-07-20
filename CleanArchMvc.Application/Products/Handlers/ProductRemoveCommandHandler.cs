using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    internal class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _repository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);
            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found");
            }
            else
            {
                var result = await _repository.Remove(product);
                return result;
            }
        }
    }
}
