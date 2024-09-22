using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
        public ProductWithTypesAndBrandsSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }

        public ProductWithTypesAndBrandsSpecification(ProductSpecParams specParams) :
            base(x =>
                (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
                (!specParams.BrandId.HasValue || x.ProductBrandId == specParams.BrandId) &&
                (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId)
            )
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
            ApplyPaging(specParams.PageSize, specParams.PageSize * (specParams.PageIndex - 1));

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderDescBy(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                };
            }
            else
                AddOrderBy(p => p.Name);
        }
    }
}
