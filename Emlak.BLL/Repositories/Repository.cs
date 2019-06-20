using Emlak.DAL.Context;
using Emlak.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.BLL.Repositories
{
    public class KonutRepository : RepositoryBase<Konut, int>
    {
    }
    public class MusteriRepository : RepositoryBase<Musteri, int>
    {
    }
    public class EmlakOfisiRepository : RepositoryBase<EmlakOfisi, int>
    {
        public bool Login(string yetkili, string sifre)
        {
            db = new EmlakContext();
            EmlakOfisi eO = db.EmlakOfisi.Where(x => x.Yetkili == yetkili && x.Sifre == sifre).FirstOrDefault();
            if (eO != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public EmlakOfisi YetkiliGetir(string yetkili)
        {
            db = new EmlakContext();
            return db.EmlakOfisi.Where(x => x.Yetkili == yetkili).FirstOrDefault();
        }


    }
    public class FotografRepository : RepositoryBase<Fotograf, int>
    {

    }
    public class IlRepository : RepositoryBase<Il, int>
    {
    }
    public class IlceRepository : RepositoryBase<Ilce, int>
    {
        public List<Ilce> IlceGetir(int id)
        {
            db = new EmlakContext();
            return db.Ilce.Where(x => x.Il.ID == id).ToList();
        }
    }
    public class MahalleRepository : RepositoryBase<Mahalle, int>
    {
        public List<Mahalle> MahalleGetir(int id)
        {
            db = new EmlakContext();
            return db.Mahalle.Where(x => x.Ilce.ID == id).ToList();
        }
    }
    public class IlanTurRepository : RepositoryBase<IlanTur, int>
    {
    }
    public class IsitmaTurRepository : RepositoryBase<IsitmaTur, int>
    {
    }

}
