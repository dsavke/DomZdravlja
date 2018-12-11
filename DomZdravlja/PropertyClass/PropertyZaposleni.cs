using DomZdravlja.AttributeClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.PropertyClass
{
    public class PropertyZaposleni:PropertyInterface
    {
        #region Atributi
        private int zaposleniId;
        private string zvanje;
        private string radnoMjesto;
        private string korisnickoIme;
        private string password;
        private int tipZaposlenog;
        private int osobaId;
        #endregion

        #region Property
        [DisplayName("Zaposleni ID")]
        [SqlName("ZaposleniID")]
        [PrimaryKey]
        public int ZaposleniID
        {
            get
            {
                return zaposleniId;
            }
            set
            {
                zaposleniId = value;
            }
        }
        [DisplayName("Zvanje")]
        [SqlName("Zvanje")]
        public string Zvanje
        {
            get
            {
                return zvanje;
            }
            set
            {
                zvanje = value;
            }
        }
        [DisplayName("Radno mjesto")]
        [SqlName("RadnoMjesto")]
        public string RadnoMjesto
        {
            get
            {
                return radnoMjesto;
            }
            set
            {
                radnoMjesto = value;
            }
        }
        [DisplayName("Korisnicko ime")]
        [SqlName("KorisnickoIme")]
        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }
            set
            {
                korisnickoIme = value;
            }
        }
        [DisplayName("Password")]
        [SqlName("Password")]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        [DisplayName("Tip Zaposlenog")]
        [SqlName("TipZaposlenog")]
        public int TipZaposlenog
        {
            get
            {
                return tipZaposlenog;
            }
            set
            {
                tipZaposlenog = value;
            }
        }
        [DisplayName("Osoba ID")]
        [SqlName("OsobaID")]
        public int OsobaID
        {
            get
            {
                return osobaId;
            }
            set
            {
                osobaId = value;
            }
        }
        #endregion

        #region Query
        public string GetDeleteQuery()
        {
            return @"  DELETE FROM dbo.Zaposleni
                        WHERE ZaposleniID = @zaposleniID
                    ";

        }
        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO dbo.Zaposleni
                       (Zvanje
                       ,RadnoMjesto
                       ,KorisnickoIme
                       ,Password
                       ,TipZaposlenog
                       ,OsobaID)
                    VALUES
                       (@zvanje,@radnoMjesto,@korisnickoIme,@password,@tipZaposlenog,@osobaID)
                    ";
        }

        public string GetSelectQuery()
        {
            return @"
                        SELECT ZaposleniID
                          ,Zvanje
                          ,RadnoMjesto
                          ,KorisnickoIme
                          ,Password
                          ,TipZaposlenog
                          ,OsobaID
                      FROM dbo.Zaposleni
                    ";
        }


        public string GetUpdateQuery()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Parameter
        public List<SqlParameter> GetDeleteParameters()
        {
            throw new NotImplementedException();
        }
        public List<SqlParameter> GetInsertParameters()
        {
            throw new NotImplementedException();
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
