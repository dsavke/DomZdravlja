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
        private string tipZaposlenog;
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
        public string TipZaposlenog
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
        [ForeignKey("dbo.Osoba", "OsobaID")]
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
                        WHERE ZaposleniID = @ZaposleniID
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
                       (@Zvanje,@RadnoMjesto,@KorisnickoIme,@Password,@TipZaposlenog,@OsobaID)
                    ";
        }
        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Zapolseni
                       set[Zvanje]=@Zvanje,
                       [RadnoMjesto]=@RadnoMjesto,
                       [KorisnickoIme]=@KorisnickoIme,
                       [Password]=@Password,
                       [TipZaposlenog]=@TipZaposlenog,
                       [OsobaID]=@OsobaID,
                   where ZaposleniID=@ZaposleniID";
        }

        public string GetSelectQuery()
        {
            return @"
                        SELECT ZaposleniID
                          ,isnull(Zvanje, '') as Zvanje
                          ,RadnoMjesto
                          ,isnull(KorisnickoIme, '') as KorisnickoIme
                          ,isnull(Password, '') as Password
                          ,TipZaposlenog
                          ,OsobaID
                      FROM dbo.Zaposleni
                    ";
        }


       
        #endregion

        #region Parameter
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = zaposleniId;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Zvanje", System.Data.SqlDbType.NVarChar);
                parameter.Value = zvanje;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@RadnoMjesto", System.Data.SqlDbType.NVarChar);
                parameter.Value = radnoMjesto;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@KorisnickoIme", System.Data.SqlDbType.NVarChar);
                parameter.Value = korisnickoIme;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Password", System.Data.SqlDbType.NVarChar);
                parameter.Value = password;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@TipZaposlenog", System.Data.SqlDbType.NVarChar);
                parameter.Value = tipZaposlenog;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
                parameter.Value = osobaId;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = zaposleniId;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Zvanje", System.Data.SqlDbType.NVarChar);
                parameter.Value = zvanje;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@RadnoMjesto", System.Data.SqlDbType.NVarChar);
                parameter.Value = radnoMjesto;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@KorisnickoIme", System.Data.SqlDbType.NVarChar);
                parameter.Value = korisnickoIme;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Password", System.Data.SqlDbType.NVarChar);
                parameter.Value = password;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@TipZaposlenog", System.Data.SqlDbType.NVarChar);
                parameter.Value = tipZaposlenog;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
                parameter.Value = osobaId;
                list.Add(parameter);
            }
            return list;
        }
        #endregion
    }
}
