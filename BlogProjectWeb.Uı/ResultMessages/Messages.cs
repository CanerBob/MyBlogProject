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
}
