using Microsoft.AspNetCore.Http;
using WinglyShop.Application.Products.GetProductImageById;

namespace WinglyShop.Infrastructure.Abstractions.Storage;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(IFormFile file);
    Task<FileResponse> GetFile(string filePath);
    string GetFilePath(string fileName);
}
