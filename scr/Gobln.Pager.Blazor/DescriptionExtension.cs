using System.Reflection;
using System.ComponentModel;
using System;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace Gobln.Pager.Blazor
{
    public static class DescriptionExtension
    {
        /// <summary>
        /// Gets the description name for the model.
        /// If DescriptionAttribute is not found than will look for DisplayAttribute to get the description from.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="page">The Page instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the description name.</param>
        /// <returns>The description name for the model.</returns>
        public static string DescriptionFor<TModel, TValue>(this Page<TModel> page, Expression<Func<TModel, TValue>> expression)
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

            return m.GetCustomAttribute<DescriptionAttribute>(false)?.Description ?? m.GetCustomAttribute<DisplayAttribute>(false)?.Description;
        }

        /// <summary>
        /// Gets the description name for the model.
        /// If DescriptionAttribute is not found than will look for DisplayAttribute to get the description from.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="pagedList">The PagedList instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the description name.</param>
        /// <returns>The description name for the model.</returns>
        public static string DescriptionFor<TModel, TValue>(this PagedList<TModel> pagedList, Expression<Func<TModel, TValue>> expression)
        {
            if (pagedList == null)
            {
                throw new ArgumentNullException(nameof(pagedList));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var m = (expression.Body as MemberExpression).Member;

            return m.GetCustomAttribute<DescriptionAttribute>(false)?.Description ?? m.GetCustomAttribute<DisplayAttribute>(false)?.Description;
        }
    }
}
