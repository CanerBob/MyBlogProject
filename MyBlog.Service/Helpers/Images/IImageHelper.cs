namespace MyBlog.Service.Helpers.Images;
public interface IImageHelper
{
    Task<ImageUploadedViewModel> Upload(string name, IFormFile imageFile,ImageType imageTypes, string folderName = null);
    void Delete(string imageName);
}