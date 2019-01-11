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
    public class PropertyRecepcija:PropertyInterface
    {
        #region Atributi
        private int prijemID;
        private int prijemZaposleniID;
        private int pacijentID;
        private int doktorID;
        private int prioritet;
        private DateTime vrijemePrijema;
        private DateTime vrijemeOtpusta;
        #endregion

        #region Property

        [DisplayName("Šifra prijema")]
        [SqlName("PrijemID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible(Use.Insert)]
        public int PrijemID
        {
            get
            {
                return prijemID;
            }
            set
            {
                prijemID = value;
            }
        }

        [DisplayName("Šifra prijem zaposlenih")]
        [SqlName("PrijemZaposleniID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyZaposleni", "Šifra zaposlenog", Tip.MedicinskaSestra, "Ime", "Prezime", false)]
        [ValidatePattern(@"^\d+$")]

        public int PrijemZaposleniID
        {
            get
            {
                return prijemZaposleniID;
            }
            set
            {
                prijemZaposleniID = value;
            }
        }

        [DisplayName("Šifra pacijenta")]
        [SqlName("PacijentID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyPacijent", "Šifra pacijenta", Tip.Pacijent, "Ime", "Prezime", false)]
        [ValidatePattern(@"^\d+$")]

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
        [ForeignKey("DomZdravlja.PropertyClass.PropertyZaposleni", "Šifra zaposlenog", Tip.Doktori, "Ime", "Prezime", false)]
        [ValidatePattern(@"^\d+$")]

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

        [DisplayName("Prioritet")]
        [SqlName("Prioritet")]
        [ValidatePattern(@"^\d+$")]
        [GenerateComponent(ComponentType.RadioButton)]
        [OpcijeRadioButton("Ima", "Nema", 1, 0)]
        [Editing(Use.Update)]
        public int Prioritet
        {
            get
            {
                return prioritet;
            }
            set
            {
                prioritet = value;
            }
        }

        [DisplayName("Vrijeme prijema")]
        [SqlName("VrijemePrijema")]
        [GenerateComponent(ComponentType.Datum)]

        public DateTime VrijemePrijema
        {
            get
            {
                return vrijemePrijema;
            }
            set
            {
                vrijemePrijema = value;
            }
        }

        [DisplayName("Vrijeme otpusta")]
        [SqlName("VrijemeOtpusta")]
        [GenerateComponent(ComponentType.Datum)]
        [Editing(Use.Update)]
        public DateTime VrijemeOtpusta
        {
            get
            {
                return vrijemeOtpusta;
            }
            set
            {
                vrijemeOtpusta = value;
            }
        }
        #endregion

        #region queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[Recepcija]
                    WHERE PrijemID = @PrijemID
                    ";
        }
        public string GetInsertQuery()
        {
            return @"
                   INSERT INTO [dbo].[Recepcija]
                       ([PrijemZaposleniID]
                       ,[PacijentID]
                       ,[DoktorID]
                       ,[Prioritet]
                       ,[VrijemePrijema]
                       ,[VrijemeOtpusta])
                 VALUES
                       (@PrijemZaposleniID, @PacijentID, @DoktorID, @Prioritet, @VrijemePrijema, @VrijemeOtpusta)
                    ";
        }

        public string GetSelectQuery()
        {
            return @"
                        SELECT[PrijemID]
                          ,[PrijemZaposleniID]
                          ,[PacijentID]
                          ,[DoktorID]
                          ,[Prioritet]
                          ,[VrijemePrijema]
                          ,[VrijemeOtpusta]
                        FROM[dbo].[Recepcija]
                    ";
        }
        public string GetUpdateQuery()
        {
            return @"UPDATE [dbo].[Recepcija]
                   SET [PrijemZaposleniID] = @PrijemZaposleniID
                      ,[PacijentID] = @PacijentID
                      ,[DoktorID] = @DoktorID
                      ,[Prioritet] = @Prioritet
                      ,[VrijemePrijema] = @VrijemePrijema
                      ,[VrijemeOtpusta] = @VrijemeOtpusta
                 WHERE PrijemID = @PrijemID";
        }

        #endregion

        #region Parametri
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@PrijemID", System.Data.SqlDbType.Int);
                parameter.Value = prijemID;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@PrijemZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = prijemZaposleniID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
                parameter.Value = pacijentID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
                parameter.Value = doktorID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prioritet", System.Data.SqlDbType.TinyInt);
                parameter.Value = prioritet;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrijemePrijema", System.Data.SqlDbType.DateTime);
                parameter.Value = vrijemePrijema;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrijemeOtpusta", System.Data.SqlDbType.DateTime);
                parameter.Value = vrijemeOtpusta;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@PrijemID", System.Data.SqlDbType.Int);
                parameter.Value = prijemID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@PrijemZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = prijemZaposleniID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
                parameter.Value = pacijentID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
                parameter.Value = doktorID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prioritet", System.Data.SqlDbType.TinyInt);
                parameter.Value = prioritet;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrijemePrijema", System.Data.SqlDbType.DateTime);
                parameter.Value = vrijemePrijema;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrijemeOtpusta", System.Data.SqlDbType.DateTime);
                parameter.Value = vrijemeOtpusta;
                list.Add(parameter);
            }
            return list;
        }
        #endregion

    }
}
