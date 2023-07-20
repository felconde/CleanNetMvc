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
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _repository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                product.Update(request.Id,request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _repository.Update(product);
            }
        }
    }
}
