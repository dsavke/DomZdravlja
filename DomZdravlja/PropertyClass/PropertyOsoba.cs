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
                       set[Ime]=@Ime,
                       [Prezime]=@Prezime;
                       [JMB]=@JMB;
                       [Adresa]=@Adresa;
                       [Kontakt]=@Kontakt;
                       [Pol]=@Pol;
                       [MjestoRodjenja]=@MjestoRodjenja;
                       [DatumRodjenja]=@DatumRodjenja;
                   where @OsobaID=Osoba.OsobaID";
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
