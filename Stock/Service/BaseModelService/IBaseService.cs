using System.Linq.Expressions;

namespace Stock.Service.BaseModelService
{
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Get Specifi Value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetAsync(Guid id);
        /// <summary>
        /// Get Table 
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetListAsync();
        /// <summary>
        /// Serch in Table With Condation
        /// or To Get Specifi Value
        /// </summary>
        /// <param name="condation"></param>
        /// <param name="inculde"></param>
        /// <param name="AsTraking"></param>
        /// <returns></returns>
        Task<T?> FindByAsync(Expression<Func<T, bool>> condation, string[]? inculde = null,bool AsTraking=false);
        /// <summary>
        /// Serch In Table Where There is More than One Value
        /// </summary>
        /// <param name="condation"></param>
        /// <param name="inculde"></param>
        /// <param name="AsTraking"></param>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> condation, string[]? inculde = null, bool AsTraking = false, Expression<Func<T, object>>? OrderBy = null);
        /// <summary>
        ///  Get Table Count
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync();
        

    }
}
