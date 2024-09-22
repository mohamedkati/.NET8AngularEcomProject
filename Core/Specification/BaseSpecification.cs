
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool PagingEnabled { get; private set; }

        public BaseSpecification()
        {

        }
        public Expression<Func<TEntity, bool>> Condition { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new();

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

        public BaseSpecification(Expression<Func<TEntity, bool>> condition)
        {
            this.Condition = condition;
        }

        protected void AddInclude(params Expression<Func<TEntity, object>>[] includesExpression) => Includes.AddRange(includesExpression);

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            this.OrderBy = orderByExpression;
        }
        protected void AddOrderDescBy(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            this.OrderByDesc = orderByDescExpression;
        }
        protected void ApplyPaging(int take, int skip)
        {
            this.Take = take;
            this.Skip = skip;
            PagingEnabled = true;
        }
    }
}
