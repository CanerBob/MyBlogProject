namespace BlogProjectWeb.Uı.ResultMessages;
public static class Messages
{
    public static class Article 
    {
        public static string Add(string articleTitle) 
        {
            return $"{articleTitle} Başlıklı Makale Başarılı Bir Şekilde Eklenmiştir!";
        }
        public static string Update(string articleTitle)
        {
            return $"{articleTitle} Başlıklı Makale Başarılı Bir Şekilde Güncellenmiştir!";
        }
        public static string Delete(string articleTitle)
        {
            return $"{articleTitle} Başlıklı Makale Başarılı Bir Şekilde Silinmiştir!";
        }
    }
    public static class Category
    {
        public static string Add(string categoryName)
        {
            return $"{categoryName} Başlıklı Kategori Başarılı Bir Şekilde Eklenmiştir!";
        }
        public static string Update(string categoryName)
        {
            return $"{categoryName} Başlıklı Kategori Başarılı Bir Şekilde Güncellenmiştir!";
        }
        public static string Delete(string categoryName)
        {
            return $"{categoryName} Başlıklı Kategori Başarılı Bir Şekilde Silinmiştir!";
        }
    }
}
