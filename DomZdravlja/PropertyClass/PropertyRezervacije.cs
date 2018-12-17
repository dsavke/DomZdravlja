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
        [DisplayName("Rezervacija ID")]
        [SqlName("RezervacijaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
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

        [DisplayName("Pacijent ID")]
        [SqlName("PacijentID")]
        [GenerateComponent(ComponentType.Tekst)]
        [ForeignKey("dbo.Pacijent", "PacijentID")]
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

        [DisplayName("Vrijeme rezervacije")]
        [SqlName("VrijemeRezervacije")]
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

        [DisplayName("Doktor ID")]
        [SqlName("DoktorID")]
        [GenerateComponent(ComponentType.Tekst)]
        [ForeignKey("dbo.Zaposleni", "ZaposleniID")]
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
