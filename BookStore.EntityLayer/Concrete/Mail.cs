using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    [NotMapped]
    public class Mail
    {
        public string ToEmail { get; set; }

        public string Subject = "🎉 Aramıza Hoş Geldiniz.. :) BookSaw Aboneliğiniz Başarı İle Tamamlanmıştır!";

        public string Body = @"
        <p>Merhaba,</p>
        <p>BookSaw bültenimize abone olduğunuz için teşekkür ederiz! 🎉 Artık yeni çıkan kitaplardan, özel indirimlerden ve önerilerimizden ilk siz haberdar olacaksınız.</p>
        <p>🔖 Şimdi keşfetmek için sitemizi ziyaret edin.</p>
        <p>Keyifli okumalar dileriz! 📚✨</p>";
    }
}
