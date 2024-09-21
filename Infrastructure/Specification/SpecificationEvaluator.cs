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

            if (specification.Condition != null)
                query = query.Where(specification.Condition);

            if (specification.Includes.Any())
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }

}
