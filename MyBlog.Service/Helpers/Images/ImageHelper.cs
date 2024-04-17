namespace MyBlog.Service.Helpers.Images;
public class ImageHelper : IImageHelper
{
    private readonly IWebHostEnvironment env;
    private readonly string wwwroot;
    private const string imgFolder = "images";
    private const string articleImagesFolder = "article-images";
    private const string userImagesFolder = "user-images";

    public ImageHelper(IWebHostEnvironment env)
    {
        this.env = env;
        wwwroot = env.WebRootPath;
    }
    private string ReplaceInvalidChars(string fileName)
    {
        return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
    }

    public async Task<ImageUploadedViewModel> Upload(string name, IFormFile imageFile, ImageType imageTypes, string folderName = null)
    {
        folderName ??= imageTypes == ImageType.User ? userImagesFolder : articleImagesFolder;

        if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
            Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");

        string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
        string fileExtensions = Path.GetExtension(imageFile.FileName);

        name = ReplaceInvalidChars(name);

        DateTime dateTime = DateTime.Now;

        string newFileName = $"{name}_{dateTime.Microsecond}{fileExtensions}";
        var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);

        await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
        await imageFile.CopyToAsync(stream);
        await stream.FlushAsync();

        string message = imageTypes == ImageType.User
            ? $"{newFileName} isimli kullanıcı resmi eklendi."
            : $"{newFileName} isimli makale resmi eklendi";
        return new ImageUploadedViewModel
        {
            FullName = $"{folderName}/{newFileName}"
        };
    }
    public void Delete(string imageName)
    {
        var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{imageName}");
        if(File.Exists(fileToDelete))
            File.Delete(fileToDelete);
    }
}