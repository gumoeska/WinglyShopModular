using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using WinglyShop.API.Settings;
using WinglyShop.Application.Abstractions.Storage;
using WinglyShop.Application.Products.GetProductImageById;

namespace WinglyShop.API.Services.Storage;

public class FileStorageService : IFileStorageService
{
    private readonly FileStorageSettings _fileStorageSettings;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileStorageService(
        IOptions<FileStorageSettings> fileStorageSettings,
        IWebHostEnvironment webHostEnvironment)
    {
        _fileStorageSettings = fileStorageSettings.Value;
        _webHostEnvironment = webHostEnvironment;
    }

    [Obsolete("Use 'SaveFileAsync'")]
    public async Task<string> SaveFileAsyncOld(IFormFile? file)
    {
        if (file is null)
        {
            return string.Empty;
        }

        // Getting the path to save the uploaded file
        var pathToSave = _fileStorageSettings.UploadsFolderPath;

        // Create the directory if it doesn't exist
        if (!Directory.Exists(pathToSave))
        {
            Directory.CreateDirectory(pathToSave);
        }

        var fileName = Path.GetRandomFileName() + Path.GetExtension(file?.FileName);
        var fullPath = Path.Combine(pathToSave, fileName);

        // Streaming
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file?.CopyToAsync(stream);
        }

        return $"/{pathToSave}/{fileName}";
    }

    public async Task<string> SaveFileAsync(IFormFile? file)
    {
        if (file is null)
        {
            return string.Empty;
        }

        // Getting the path to save the uploaded file
        var pathToSave = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads");

        // Create the directory if it doesn't exist
        if (!Directory.Exists(pathToSave))
        {
            Directory.CreateDirectory(pathToSave);
        }

        var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
        var fullPath = Path.Combine(pathToSave, fileName);

        // Streaming
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Path.Combine(pathToSave, fileName);
    }

    public async Task<FileResponse> GetFile(string filePath)
    {
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        return new FileResponse(fileStream, "application/octet-stream", Path.GetFileName(filePath));
    }

    public string GetFilePath(string fileName)
    {
        return Path.Combine(_fileStorageSettings.UploadsFolderPath, fileName);
    }
}
