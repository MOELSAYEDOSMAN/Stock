
namespace Stock.Service.FileModelService
{
    public class FileService : IFIleService
    {
        private readonly IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        
        public async Task<string> UploadFileAsync(IFormFile file, string Src)
        {
            string FileName = Guid.NewGuid().ToString() + ".webp";
            var filepath = Path.Combine(_env.ContentRootPath + System.IO.Path.DirectorySeparatorChar,
                $@"wwwroot/Images/{Src}", FileName);
            using (var steam = System.IO.File.Create(filepath))
            {
                await file.CopyToAsync(steam);
            }
            return $"{Src}/{FileName}";
        }
       
        public async Task<List<string>> UploadFilesAsync(List<IFormFile> files, string src)
        {
            var Srcs=new List<string>();
            foreach(var file in files)
                 Srcs.Add(await UploadFileAsync(file, src));
            return Srcs;
        }
        public async Task<bool> ChangeImgageAsync(string fileSrc,IFormFile file)
        {
            //Cheack File
            if (!await RemoveFileAsync(fileSrc))
                return false;

            var FilePath = Path.Combine(_env.ContentRootPath + System.IO.Path.DirectorySeparatorChar,
                $@"wwwroot/Images/{fileSrc}");

            using (var steam = System.IO.File.Create(FilePath))
            {
                await file.CopyToAsync(steam);
            }
            return true;
        }

        public async Task<bool> RemoveFileAsync(string Src)
        {
            var filepath = Path.Combine(_env.ContentRootPath + System.IO.Path.DirectorySeparatorChar, $@"wwwroot/Images/{Src}");
            if (!CheackFile(filepath))
                return false;

            System.IO.File.Delete(filepath);
            return true;
        }
        
        public async Task<bool> RemoveFilesAsync(List<string> Src)
        {
            foreach (string SrcPath in Src) 
            {
                if (!await RemoveFileAsync(SrcPath))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Cheack If File in Folder
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        bool CheackFile(string src)
        {
            if (System.IO.File.Exists(src))
            {
                return true;
            }
            return false;
        }
        
    }
}
