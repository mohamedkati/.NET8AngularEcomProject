using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Condition { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
        Expression<Func<TEntity, object>> OrderBy { get; }
        Expression<Func<TEntity, object>> OrderByDesc { get; }
        int Take { get; }
        int Skip { get; }
        bool PagingEnabled { get; }

    }
}

