namespace MyBlog.Data.Mappings;
public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasData(new Article()
        {
            Id = Guid.Parse("F90267AB-E120-46A2-A235-3CAD215E7953"),
            Title = "AspNet Core Deneme Makalesi",
            Content = "Günümüzde İnternetin gelişimi birçok alanda değişiklik ve yeniliklerin oluşmasına olanak sağlamıştır. Bu alanlardan biri de hiç şüphesiz Elektronik Ticaret alanı alanıdır. Elektronik Ticaret’in gelişimi ve değişimi internetten sonra büyük ölçüde değiştiren ve geliştiren ise Mobil Dünyadaki gelişmeler ve değişimler olmuştur. Mobil Araçların gelişimi ve yaygınlaşması ile birlikte insanların İnternet’e ve dolayısı ile Elektronik Web Sitelerine ulaşmaları ve alışveriş yapma oranlarında büyük bir artış olmuştur.",
            ViewCount = 15,
            CategoryId = Guid.Parse("AF5FDFE2-A680-4EB9-929E-8270F1AE2849"),
            ImageId = Guid.Parse("F406068B-EC45-4D22-B22E-084B4705D8B5"),
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        },
        new Article() 
        {
            Id = Guid.Parse("0EB19997-5C94-4FCD-A327-FDD99E7B807C"),
            Title = "Yazılım Mimarisi",
            Content = "Bir bina yapılmaya başlamadan önce mimarlar tarafından projenin ön çizimi, tasarımı çizilir. Tıpkı bunun gibi bir yazılım projesinin de yapılmaya başlamadan önce planlanması gerekir. Bu planlamaya “Yazılım Mimarisi” bu planı tasarlayan kişilere de “Yazılım Mimarı” denir. Mimari, yazılım uygulamasının bir donanımın, ağların ve bir işletmenin diğer bileşenleriyle nasıl etkileşime gireceğini ana hatlarıyla anlatan eksiksiz bir tasarım belgeleri seti içerir. Böylelikle yazılım geliştiricilerin izleyeceği yol genel hatları ile belirlenmiş olur.",
            ViewCount = 16,
            CategoryId = Guid.Parse("0EB19997-5C94-4FCD-A327-FDD99E7B807C"),
            ImageId = Guid.Parse("F5A4AAB2-01F0-407B-A20F-6CBD053EFD76"),
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false
        });
    }
}