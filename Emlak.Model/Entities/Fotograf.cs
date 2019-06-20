using Emlak.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Entities
{
    [Table("Fotograflar")]
    public class Fotograf : BaseEntity<int>
    {
        public byte[] Resim { get; set; } // Resimleri Byte olarak kaydediyoruz
        public int KonutID { get; set; }
        [ForeignKey("KonutID")]
        public virtual Konut Konut { get; set; }


        //Resimlerin tabloda gösterilmemesi icin kullanıyoruz
        [NotMapped]
        public string Base64String
        {
            get
            {
                var base64Str = string.Empty;
                if (Resim != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        int offset = 78;
                        ms.Write(Resim, offset, Resim.Length - offset);
                        var bmp = new System.Drawing.Bitmap(ms);
                        using (var jpegms = new MemoryStream())
                        {
                            bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            base64Str = Convert.ToBase64String(jpegms.ToArray());
                        }
                    }
                }
                return base64Str;
            }

        }
    }
}
