using Emlak.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.DAL.Context
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<EmlakContext>
    {
        protected override void Seed(EmlakContext context)
        {
            var ısıtmaTur = new List<IsitmaTur>()
            {
                new IsitmaTur(){Ad = "Yok"},
                new IsitmaTur(){Ad = "Soba"},
                new IsitmaTur(){Ad = "Doğalgaz"},
                new IsitmaTur(){Ad = "Kat Kaloriferi"},
                new IsitmaTur(){Ad = "Merkezi"},
                new IsitmaTur(){Ad = "Merkezi(Pay Ölçer)"},
                new IsitmaTur(){Ad = "Yerden Isıtma"},
                new IsitmaTur(){Ad = "Klima"},
                new IsitmaTur(){Ad = "Güneş Enerjisi"},


            };
            foreach (var ısıtma in ısıtmaTur)
            {
                context.IsitmaTur.Add(ısıtma);
            }
            context.SaveChanges();

            var ilanTur = new List<IlanTur>()
            {
                new IlanTur(){Ad = "Kiralık"},
                new IlanTur(){Ad = "Satılık"},



            };
            foreach (var ilan in ilanTur)
            {
                context.IlanTur.Add(ilan);
            }
            context.SaveChanges();

            var iller = new List<Il>()
            {
                new Il(){Ad = "Adana"},
                new Il(){Ad = "Ankara"},
                new Il(){Ad = "Antalya"},
                new Il(){Ad = "Afyon"},
                new Il(){Ad = "Amasya"},
                new Il(){Ad = "Erzurum"},
                new Il(){Ad = "Erzincan"},
                new Il(){Ad = "Elazığ"},
                new Il(){Ad = "Eskişehir"},
                new Il(){Ad = "Gaziantep"},
                new Il(){Ad = "Mersin"},
                new Il(){Ad = "İstanbul"},
                new Il(){Ad = "İzmir"},
                new Il(){Ad = "Kars"},
                new Il(){Ad = "Samsun"},
                new Il(){Ad = "Trabzon"},

            };
            foreach (var il in iller)
            {
                context.Il.Add(il);
            }
            context.SaveChanges();
            var ilceler = new List<Ilce>()
            {
                new Ilce(){IlID=1,Ad = "Aladağ"},
                new Ilce(){IlID=1,Ad = "Ceyhan"},
                new Ilce(){IlID=1,Ad = "Çukurova"},
                new Ilce(){IlID=1,Ad = "Feke"},
                new Ilce(){IlID=1,Ad = "Kozan"},
                new Ilce(){IlID=2,Ad = "Akyurt"},
                new Ilce(){IlID=2,Ad = "Altındağ"},
                new Ilce(){IlID=2,Ad = "Kalecik"},
                new Ilce(){IlID=2,Ad = "Kazan"},
                new Ilce(){IlID=2,Ad = "Mamak"},
                new Ilce(){IlID=3,Ad = "Mamak"},
                new Ilce(){IlID=3,Ad = "Akseki"},
                new Ilce(){IlID=3,Ad = "Aksu"},
                new Ilce(){IlID=3,Ad = "Alanya"},
                new Ilce(){IlID=12,Ad = "Adalar"},
                new Ilce(){IlID=12,Ad = "Arnavutköy"},
                new Ilce(){IlID=12,Ad = "Ataşehir"},
                new Ilce(){IlID=12,Ad = "Avcılar"},
                new Ilce(){IlID=12,Ad = "Bağcılar"},
                new Ilce(){IlID=12,Ad = "Başakşehir"},
                new Ilce(){IlID=12,Ad = "Beşiktaş"},
                new Ilce(){IlID=12,Ad = "BBeylikdüzü"},
                new Ilce(){IlID=12,Ad = "Esenler"},
                new Ilce(){IlID=12,Ad = "Esenyurt"},
                new Ilce(){IlID=12,Ad = "Eyup"},
                new Ilce(){IlID=12,Ad = "Fatih"},
                new Ilce(){IlID=12,Ad = "Gaziosmanpaşa"},
                new Ilce(){IlID=12,Ad = "Kartal"},
                new Ilce(){IlID=12,Ad = "Kadıköy"},
                new Ilce(){IlID=12,Ad = "Güngören"},


            };
            foreach (var ilce in ilceler)
            {
                context.Ilce.Add(ilce);
            }
            context.SaveChanges();


            var mahaller = new List<Mahalle>()
            {
                new Mahalle(){IlceID=15,Ad = "Maden"},
                new Mahalle(){IlceID=15,Ad = "Nizam"},
                new Mahalle(){IlceID=16,Ad = "Yunus Emre"},
                new Mahalle(){IlceID=16,Ad = "Boğazköy"},
                new Mahalle(){IlceID=16,Ad = "İstiklal"},
                new Mahalle(){IlceID=17,Ad = "Atatürk"},
                new Mahalle(){IlceID=17,Ad = "FerhatPaşa"},
                new Mahalle(){IlceID=18,Ad = "Ambarlı"},
                new Mahalle(){IlceID=18,Ad = "Cihangir"},
                new Mahalle(){IlceID=19,Ad = "Fatih"},
                new Mahalle(){IlceID=19,Ad = "Yavuz"},
                new Mahalle(){IlceID=20,Ad = "Şahintepe"},
                new Mahalle(){IlceID=20,Ad = "Kayabaşı"},
                new Mahalle(){IlceID=10,Ad = "Cukur"},



            };
            foreach (var mahalle in mahaller)
            {
                context.Mahalle.Add(mahalle);
            }
            context.SaveChanges();
            var musteriler = new List<Musteri>()
            {
                new Musteri(){Ad="Adem",Soyad="Ates",CepTelefonu="05414130126",EvTelefonu="02125689754",AdresAyrinti="Alt sokak Altın Apt No 3:2",IlID=12,IlceID=15,MahalleID=1,Eposta="adem@gmail.com", },
                new Musteri(){Ad="Rıdvan",Soyad="Atmaca",CepTelefonu="05414130127",EvTelefonu="02125689755",AdresAyrinti="Üst sokak Bakır Apt No 4:1",IlID=12,IlceID=19,MahalleID=11,Eposta="rıdvan@gmail.com", },
                new Musteri(){Ad="Irsat",Soyad="Başak",CepTelefonu="05414130128",EvTelefonu="02125689756",AdresAyrinti="Sol sokak Demiz Apt No 5:1",IlID=12,IlceID=18,MahalleID=8,Eposta="ırsat@gmail.com", },
                new Musteri(){Ad="Yusuf",Soyad="Torun",CepTelefonu="05414130129",EvTelefonu="02125689757",AdresAyrinti="Sağ sokak Gümüş Apt No 6:0",IlID=12,IlceID=10,MahalleID=13,Eposta="yusuf@gmail.com", },




            };
            foreach (var musteri in musteriler)
            {
                context.Musteri.Add(musteri);
            }
            context.SaveChanges();

            var ofisler = new List<EmlakOfisi>()
            {
               new EmlakOfisi(){Ad="Emlakci",Yetkili="Ertugrul",AdresAyrinti="a sokak b apt no:1/2",IlID=2,IlceID=10,MahalleID=13,CepTelefonu="05414130125",Fax="05414130125",Eposta="ert@gmail.com",Sifre="01"}




            };
            foreach (var ofis in ofisler)
            {
                context.EmlakOfisi.Add(ofis);
            }
            context.SaveChanges();







            base.Seed(context);
        }
    }
}
