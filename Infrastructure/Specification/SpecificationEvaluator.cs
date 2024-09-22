using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specification
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> queryInpyt, ISpecification<TEntity> specification)
        {
            var query = queryInpyt;

            if (specification.Condition is not null)
                query = query.Where(specification.Condition);

            if (specification.OrderBy is not null)
                query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDesc is not null)
                query = query.OrderByDescending(specification.OrderByDesc);
            
            if(specification.PagingEnabled)
                query = query.Skip(specification.Skip).Take(specification.Take);

            if (specification.Includes.Any())
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }

}
