
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
        public BaseSpecification()
        {
            
        }
        public Expression<Func<TEntity, bool>> Condition { get; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new();

        public BaseSpecification(Expression<Func<TEntity, bool>> condition)
        {
            this.Condition = condition;
        }

        protected void AddInclude(params Expression<Func<TEntity, object>>[] includesExpression) => Includes.AddRange(includesExpression);
    }
}
