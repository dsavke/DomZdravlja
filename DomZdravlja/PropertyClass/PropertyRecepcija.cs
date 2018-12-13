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

        [DisplayName("Prijem ID")]
        [SqlName("PrijemID")]
        [PrimaryKey]
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

        [DisplayName("Prijem zaposleni ID")]
        [SqlName("PrijemZaposleniID")]
        [ForeignKey("dbo.Zaposleni", "ZaposleniID")]
        public int PrijemZaposlenihID
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

        [DisplayName("Pacijent ID")]
        [SqlName("PacijentID")]
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

        [DisplayName("Doktor ID")]
        [SqlName("DoktorID")]
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

        [DisplayName("Prioritet")]
        [SqlName("Prioritet")]

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
