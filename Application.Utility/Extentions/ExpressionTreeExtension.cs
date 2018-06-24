using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Utility.Extentions
{
    public static class ExpressionTreeExtension
    {       
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> predicate)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(predicate.Body), predicate.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, right.Body), left.Parameters);
        }
    }
}
