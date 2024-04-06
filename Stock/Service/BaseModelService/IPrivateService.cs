namespace Stock.Service.BaseModelService
{
    public interface IPrivateService<T> where T : class
    {
        /// <summary>
        /// Remove Item in Db
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T input);
        /// <summary>
        /// Add New Value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<T> AddAsync(T input);
        /// <summary>
        /// Edit in Item In Db
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T input);
        Task SaveChangesAsync();
    }
}
