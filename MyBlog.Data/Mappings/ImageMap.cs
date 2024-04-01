namespace MyBlog.Data.Mappings;
public class ImageMap : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasData(new Image 
        {
        Id = Guid.Parse("F406068B-EC45-4D22-B22E-084B4705D8B5"),
        FileName = "/images/test",
        FileType = "jpeg",
        CreatedBy = "Admin Test",
        CreatedDate = DateTime.Now,
        IsDeleted = false,
        },
        new Image() 
        {
            Id = Guid.Parse("F5A4AAB2-01F0-407B-A20F-6CBD053EFD76"),
            FileName = "/images/test",
            FileType = "png",
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        });
    }
}