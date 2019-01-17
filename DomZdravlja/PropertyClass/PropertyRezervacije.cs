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
    public class PropertyRezervacije:PropertyInterface
    {
        #region Atributi
        private int rezervacijaID;
        private int pacijentID;
        private DateTime vrijemeRezervacije;
        private DateTime termin;
        private int doktorID;
        #endregion

        #region Property
        [DisplayName("Šifra rezervacije")]
        [SqlName("RezervacijaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible(Use.Insert)]
        public int RezervacijaID
        {
            get
            {
                return rezervacijaID;
            }
            set
            {
                rezervacijaID = value;
            }
        }

        [DisplayName("Šifra pacijenta")]
        [SqlName("PacijentID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyPacijent", "Šifra pacijenta", Tip.Pacijent, "Ime", "Prezime", false)]
        [ValidatePattern(@"^\d+$")]
        [Editing(Use.Insert)]
        public int PacijentID
        {
            get
            {
                return pacijentID;
            }
            set
            {
                pacijentID = value;
            }
        }

        [DisplayName("Šifra doktora")]
        [SqlName("DoktorID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyZaposleni", "Šifra doktora", Tip.Doktori, "Ime", "Prezime", false)]
        [ValidatePattern(@"^\d+$")]
        [Editing(Use.Insert)]
        public int DoktorID
        {
            get
            {
                return doktorID;
            }
            set
            {
                doktorID = value;
            }
        }

        [DisplayName("Vrijeme rezervacije")]
        [SqlName("VrijemeRezervacije")]
        [Editing(Use.Insert)]
        [GenerateComponent(ComponentType.Datum)]
        
        public DateTime VrijemeRezervacije
        {
            get
            {
                return vrijemeRezervacije;
            }
            set
            {
                vrijemeRezervacije = value;
            }
        }

        [DisplayName("Termin")]
        [SqlName("Termin")]
        [GenerateComponent(ComponentType.Datum)]
        [Editing(Use.InsertAndUpdate)]
        public DateTime Termin
        {
            get
            {
                return termin;
            }
            set
            {
                termin = value;
            }
        }
        #endregion

        #region queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[Rezervacije]
                     WHERE RezervacijaID = @RezervacijaID
                    ";
        }
        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO [dbo].[Rezervacije]
                       ([PacijentID]
                       ,[VrijemeRezervacije]
                       ,[Termin]
                       ,[DoktorID])
                     VALUES
                       (@PacijentID, @VrijemeRezervacije, @Termin, @DoktorID)
                    ";
        }
        public string GetUpdateQuery()
        {
            return @"UPDATE [dbo].[Rezervacije]
                       SET [PacijentID] = @PacijentID
                          ,[VrijemeRezervacije] = @VrijemeRezervacije
                          ,[Termin] = @Termin
                          ,[DoktorID] = @DoktorID
                     WHERE RezervacijaID = @RezervacijaID";
        }

        public string GetSelectQuery()
        {
            return @"SELECT [RezervacijaID]
                      ,[PacijentID]
                      ,[VrijemeRezervacije]
                      ,[Termin]
                      ,[DoktorID]
                 FROM [dbo].[Rezervacije]
                 WHERE [Termin] > GETDATE()
                    ";
        }
        #endregion

        #region Parametri
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@RezervacijaID", System.Data.SqlDbType.Int);
                parameter.Value = rezervacijaID;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
                parameter.Value = pacijentID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrijemeRezervacije", System.Data.SqlDbType.DateTime);
                parameter.Value = vrijemeRezervacije;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Termin", System.Data.SqlDbType.DateTime);
                parameter.Value = termin;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
                parameter.Value = doktorID;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@RezervacijaID", System.Data.SqlDbType.Int);
                parameter.Value = rezervacijaID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
                parameter.Value = pacijentID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrijemeRezervacije", System.Data.SqlDbType.DateTime);
                parameter.Value = vrijemeRezervacije;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Termin", System.Data.SqlDbType.DateTime);
                parameter.Value = termin;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
                parameter.Value = doktorID;
                list.Add(parameter);
            }
            return list;
        }
        #endregion
    }
}
