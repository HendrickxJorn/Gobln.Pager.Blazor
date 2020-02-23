using System.Reflection;
using System.ComponentModel;
using System;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace Gobln.Pager.Blazor
{
    public static class DisplayNameExtension
    {
        /// <summary>
        /// Gets the display name for the model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="page">The Page that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the display name.</param>
        /// <returns>The display name for the model.</returns>
        public static string DisplayNameFor<TModel, TValue>(this Page<TModel> page, Expression<Func<TModel, TValue>> expression)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var m = (expression.Body as MemberExpression).Member;

            var value = m.GetCustomAttribute<DisplayAttribute>(false);
            var value2 = m.GetCustomAttribute<DisplayNameAttribute>(false);

            return value?.Name ?? value2?.DisplayName ?? m.Name ?? string.Empty;
        }

        /// <summary>
        /// Gets the display name for the model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="pageList">The PagedList instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the display name.</param>
        /// <returns>The display name for the model.</returns>
        public static string DisplayNameFor<TModel, TValue>(this PagedList<TModel> pageList, Expression<Func<TModel, TValue>> expression)
        {
            if (pageList == null)
            {
                throw new ArgumentNullException(nameof(pageList));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var m = (expression.Body as MemberExpression).Member;

            var value = m.GetCustomAttribute<DisplayAttribute>(false);
            var value2 = m.GetCustomAttribute<DisplayNameAttribute>(false);

            return value?.Name ?? value2?.DisplayName ?? m.Name ?? string.Empty;
        }
    }
}
