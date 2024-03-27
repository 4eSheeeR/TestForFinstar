using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class ExpressionExtensions
    {

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            return Expression.Lambda<Func<T,bool>>(Expression.AndAlso(exp1.Body, Expression.Invoke(exp2, exp1.Parameters[0])), exp1.Parameters[0]);
        }
    }
}
