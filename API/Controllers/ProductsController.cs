using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructue.Data;
using Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepositoryAsync<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepositoryAsync<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            this._mapper = mapper;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetProducts()
        //{
        //    var spec = new ProductWithTypesAndBrandsSpecification();
        //    return Ok(await _productRepository.GetAllWithSpec(spec));
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            return Ok(await _productRepository.GetEntityWithSpec(spec));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(specParams);
            var countSpec = new ProductWithFiltersForCountSpecification(specParams);

            var data = _mapper.Map<IReadOnlyList<GetProductDto>>(await _productRepository.GetAllWithSpec(spec));

            var totalItems = await _productRepository.CountAsync(countSpec);

            return Ok(new PaginationResult<GetProductDto>(totalItems, specParams.PageSize, specParams.PageIndex, data));
        }

        //[HttpGet("brands")]
        //public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        //{
        //    return Ok(await _productRepository.GetProductBrandsAsync());
        //}

        //[HttpGet("types")]
        //public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        //{
        //    return Ok(await _productRepository.GetProductTypesAsync());
        //}
    }
}