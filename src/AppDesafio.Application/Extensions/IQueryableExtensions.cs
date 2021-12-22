using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDesafio.Application
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// FirstOrDefault asíncrono.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> query) where T : class
        {
            return EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query);
        }

        /// <summary>
        /// SingleOrDefault asíncrono.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static Task<T> SingleOrDefaultAsync<T>(this IQueryable<T> query) where T : class
        {
            return EntityFrameworkQueryableExtensions.SingleOrDefaultAsync(query);
        }

        /// <summary>
        /// Count asíncrono.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static Task<int> CountAsync<T>(this IQueryable<T> query) where T : class
        {
            return EntityFrameworkQueryableExtensions.CountAsync(query);
        }

        /// <summary>
        /// ToListAsync asíncrono.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> query) where T : class
        {
            return await EntityFrameworkQueryableExtensions.ToListAsync(query).ConfigureAwait(false);
        }

        /// <summary>
        /// ToList asíncrono.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static async Task<List<TResult>> ToListAsync<T, TResult>(this IQueryable<T> query, Func<T, TResult> selector) where T : class where TResult : class
        {
            List<T> list = await EntityFrameworkQueryableExtensions.ToListAsync(query).ConfigureAwait(false);
            return list.Select(selector).ToList();
        }
    }
}
