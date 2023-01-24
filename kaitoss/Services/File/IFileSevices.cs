namespace kaitoss.Services.File
{
    public interface IFileSevices
    {
        Task<string> UploadImageAsync(IFormFile file);
        Task<string> SaveFile(IFormFile file, string folderName);
    }
}
