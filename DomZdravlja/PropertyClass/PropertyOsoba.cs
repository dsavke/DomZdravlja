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
    public class PropertyOsoba:PropertyInterface
    {
        #region Atributi
        private int osobaID;
        private string ime;
        private string prezime;
        private int jmb;
        private string adresa;
        private string kontakt;
        private char pol;
        private string mjestoRodjenja;
        private DateTime datumRodjenja;
        #endregion


        #region Property
        [DisplayName("Osoba ID")]
        [SqlName("OsobaID")]
        [PrimaryKey]

        public int OsobaID
        {
            get
            {
                return osobaID;
            }
            set
            {
                osobaID = value;
            }
        }

        [DisplayName("Ime")]
        [SqlName("Ime")]

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
            }
        }

        [DisplayName("Prezime")]
        [SqlName("Prezime")]

        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
            }
        }

        [DisplayName("JMB")]
        [SqlName("JMB")]

        public int JMB
        {
            get
            {
                return jmb;
            }
            set
            {
                jmb = value;
            }
        }

        [DisplayName("Adresa")]
        [SqlName("Adresa")]

        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
            }
        }

        [DisplayName("Kontakt")]
        [SqlName("Kontakt")]

        public string Kontakt
        {
            get
            {
                return kontakt;
            }
            set
            {
                kontakt = value;
            }
        }

        [DisplayName("Pol")]
        [SqlName("Pol")]

        public char Pol
        {
            get
            {
                return pol;
            }
            set
            {
                pol = value;
            }
        }

        [DisplayName("Mjesto rodjenja")]
        [SqlName("MjestoRodjenja")]

        public string MjestoRodjenja
        {
            get
            {
                return mjestoRodjenja;
            }
            set
            {
                mjestoRodjenja = value;
            }
        }

        [DisplayName("Datum rodjenja")]
        [SqlName("DatumRodjenja")]

        public DateTime DatumRodjenja
        {
            get
            {
                return datumRodjenja;
            }
            set
            {
                datumRodjenja = value;
            }
        }
        #endregion

        #region Query

        public string GetDeleteQuery()
        {
            return @"  DELETE FROM dbo.Osoba
                        WHERE OsobaID = @OsobaID
                    ";

        }
        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO dbo.Osoba
                       (Ime
                       ,Prezime
                       ,JMB
                       ,Adresa
                       ,Kontakt
                       ,Pol
                       ,MjestoRodjenja
                       ,DatumRodjenja)
                    VALUES
                       (@Ime,@Prezime,@JMB,@Adresa,@Kontakt,@Pol,@MjestoRodjenja,@DatumRodjenja)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Osoba
                       SET [Ime] = @Ime,
                       [Prezime] = @Prezime;
                       [JMB] = @JMB;
                       [Adresa] = @Adresa;
                       [Kontakt] = @Kontakt;
                       [Pol] = @Pol;
                       [MjestoRodjenja] = @MjestoRodjenja;
                       [DatumRodjenja] = @DatumRodjenja;
                   where OsobaID = @OsobaID";
        }

        public string GetSelectQuery()
        {
            return @"
                        SELECT OsobaID
                       ,Ime
                       ,Prezime
                       ,JMB
                       ,Adresa
                       ,Kontakt
                       ,Pol
                       ,MjestoRodjenja
                       ,DatumRodjenja
                      FROM dbo.Osoba
                    ";
        }


        #endregion

        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter OsobaID = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
            OsobaID.Value = osobaID;
            list.Add(OsobaID);

            return list;
        }       

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter Ime = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
            Ime.Value = ime;
            list.Add(Ime);

            SqlParameter Prezime = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
            Prezime.Value = prezime;
            list.Add(Prezime);

            SqlParameter JMB = new SqlParameter("@JMB", System.Data.SqlDbType.NVarChar);
            JMB.Value = jmb;
            list.Add(JMB);

            SqlParameter Adresa = new SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar);
            Adresa.Value = adresa;
            list.Add(Adresa);

            SqlParameter Kontakt = new SqlParameter("@Kontakt", System.Data.SqlDbType.NVarChar);
            Kontakt.Value = kontakt;
            list.Add(Kontakt);

            SqlParameter Pol = new SqlParameter("@Pol", System.Data.SqlDbType.NChar);
            Pol.Value = pol;
            list.Add(Pol);

            SqlParameter MjestoRodjenja = new SqlParameter("@MjestoRodjenja", System.Data.SqlDbType.NVarChar);
            MjestoRodjenja.Value = mjestoRodjenja;
            list.Add(MjestoRodjenja);

            SqlParameter DatumRodjenja = new SqlParameter("@DatumRodjenja", System.Data.SqlDbType.Date);
            DatumRodjenja.Value = datumRodjenja;
            list.Add(DatumRodjenja);

            return list;
        }       
       
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter OsobaID = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
            OsobaID.Value = osobaID;
            list.Add(OsobaID);

            SqlParameter Ime = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
            Ime.Value = ime;
            list.Add(Ime);

            SqlParameter Prezime = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
            Prezime.Value = prezime;
            list.Add(Prezime);

            SqlParameter JMB = new SqlParameter("@JMB", System.Data.SqlDbType.NVarChar);
            JMB.Value = jmb;
            list.Add(JMB);

            SqlParameter Adresa = new SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar);
            Adresa.Value = adresa;
            list.Add(Adresa);

            SqlParameter Kontakt = new SqlParameter("@Kontakt", System.Data.SqlDbType.NVarChar);
            Kontakt.Value = kontakt;
            list.Add(Kontakt);

            SqlParameter Pol = new SqlParameter("@Pol", System.Data.SqlDbType.NChar);
            Pol.Value = pol;
            list.Add(Pol);

            SqlParameter MjestoRodjenja = new SqlParameter("@MjestoRodjenja", System.Data.SqlDbType.NVarChar);
            MjestoRodjenja.Value = mjestoRodjenja;
            list.Add(MjestoRodjenja);

            SqlParameter DatumRodjenja = new SqlParameter("@DatumRodjenja", System.Data.SqlDbType.Date);
            DatumRodjenja.Value = datumRodjenja;
            list.Add(DatumRodjenja);

            return list;
        }
    
        #endregion
    }
}
