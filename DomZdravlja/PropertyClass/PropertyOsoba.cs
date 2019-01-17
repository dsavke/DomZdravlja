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
    public class PropertyOsoba : PropertyInterface
    {
        #region Atributi
        private int osobaID;
        private string ime;
        private string prezime;
        private string jmb;
        private string adresa = string.Empty;
        private string kontakt;
        private string pol;
        private string mjestoRodjenja;
        private DateTime datumRodjenja;
        private int zivotniStatus;
        #endregion

        #region Property
        [DisplayName("Šifra osobe")]
        [SqlName("OsobaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible(Use.Insert)]
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
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"(?!^.*[A-Z]{2,}.*$)^[A-Za-z\s\p{L}-]+$")]
        [MainSearch(null)]
        [Editing(Use.Insert)]
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
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"(?!^.*[A-Z]{2,}.*$)^[A-Za-z\s((\-)?)\p{L}-]+$")]
        [MainSearch(null)]
        [Editing(Use.Insert)]
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
        [ValidatePattern(@"^[A-Za-z0-9]{5,13}$")]
        [GenerateComponent(ComponentType.Tekst)]
        [MainSearch(null)]
        [Editing(Use.InsertAndUpdate)]
        public string JMB
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
        [ValidatePattern(@"(?!^.*[A-Z]{2,}.*$)^[A-Za-z0-9\s((\-)?)\/\.\p{L}-]*$")]
        [Editing(Use.InsertAndUpdate)]
        [GenerateComponent(ComponentType.Tekst)]
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
        [GenerateComponent(ComponentType.Tekst)]
        [Editing(Use.InsertAndUpdate)]
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
        [GenerateComponent(ComponentType.RadioButton)]
        [OpcijeRadioButton("Muško", "Žensko", 'M', 'Ž')]
        [ValidatePattern(@"^[A-Z]{1}$")]
        [Editing(Use.Insert)]
        public string Pol
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

        [DisplayName("Mjesto rođenja")]
        [SqlName("MjestoRodjenja")]
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"(?!^.*[A-Z]{2,}.*$)^[A-Za-z\s((\-)?)]*$")]
        [Editing(Use.Insert)]
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

        [DisplayName("Datum rođenja")]
        [SqlName("DatumRodjenja")]
        [GenerateComponent(ComponentType.Datum)]
        [Editing(Use.Insert)]
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

        [DisplayName("Životni status")]
        [SqlName("ZivotniStatus")]
        [GenerateComponent(ComponentType.RadioButton)]
        [OpcijeRadioButton("Živ", "Mrtav", 1, 0)]
        [Invisible(Use.Insert)]
        [Editing(Use.Update)]
        public int ZivotniStatus
        {
            get
            {
                return zivotniStatus;
            }
            set
            {
                zivotniStatus = value;
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
                       ,DatumRodjenja
                       ,ZivotniStatus)
                    VALUES
                       (@Ime,@Prezime,@JMB,@Adresa,@Kontakt,@Pol,@MjestoRodjenja,@DatumRodjenja,@ZivotniStatus)
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Osoba
                       SET [Ime] = @Ime,
                       [Prezime] = @Prezime,
                       [JMB] = @JMB,
                       [Adresa] = @Adresa,
                       [Kontakt] = @Kontakt,
                       [Pol] = @Pol,
                       [MjestoRodjenja] = @MjestoRodjenja,
                       [DatumRodjenja] = @DatumRodjenja,
                       [ZivotniStatus] = @ZivotniStatus
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
                       ,ZivotniStatus
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

            SqlParameter ZivotniStatus = new SqlParameter("@ZivotniStatus", System.Data.SqlDbType.TinyInt);
            ZivotniStatus.Value = zivotniStatus;
            list.Add(ZivotniStatus);

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

            SqlParameter ZivotniStatus = new SqlParameter("@ZivotniStatus", System.Data.SqlDbType.TinyInt);
            ZivotniStatus.Value = zivotniStatus;
            list.Add(ZivotniStatus);

            return list;
        }
    
        #endregion
    }
}
