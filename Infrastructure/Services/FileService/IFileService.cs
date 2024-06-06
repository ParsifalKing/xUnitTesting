using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.FileService;

public interface IFileService
{
    public Task<string> CreateFile(IFormFile file);
    public bool DeleteFile(string file);

}
