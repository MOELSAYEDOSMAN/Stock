namespace Stock.Service.FileModelService
{
    public interface IFIleService
    {
        /// <summary>
        /// Upload One File
        /// </summary>
        /// <param name="file"></param>
        /// <param name="Src"></param>
        /// <returns></returns>
        Task<string> UploadFileAsync(IFormFile file, string Src);
        /// <summary>
        /// Upload Multi Files
        /// </summary>
        /// <param name="files"></param>
        /// <param name="src"></param>
        /// <returns></returns>
        Task<List<string>> UploadFilesAsync(List<IFormFile> files, string src);
        /// <summary>
        /// Delete And Add New Image
        /// </summary>
        /// <param name="fileSrc"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<bool> ChangeImgageAsync(string fileSrc, IFormFile file);
        /// <summary>
        /// Remove One File
        /// </summary>
        /// <param name="Src"></param>
        /// <returns></returns>
        Task<bool> RemoveFileAsync(string Src);
        /// <summary>
        /// Remove Multi Files
        /// </summary>
        /// <param name="Src"></param>
        /// <returns></returns>
        Task<bool> RemoveFilesAsync(List<string> Src);

    }
}
