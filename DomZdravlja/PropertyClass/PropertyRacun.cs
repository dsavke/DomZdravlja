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
    public class PropertyRacun:PropertyInterface
    {
        #region Atributi
        private int racunID;
        private DateTime vrijemeIzdavanja;
        private int zaposleniID;
        private decimal popust;
        private int pacijentID;
        #endregion

        #region Property
        [DisplayName("Racun ID")]
        [SqlName("RacunID")]
        [PrimaryKey]
        public int RacunID
        {
            get
            {
                return racunID;
            }
            set
            {
                racunID = value;
            }
        }

        [DisplayName("Vrijeme izdavanja")]
        [SqlName("VrijemeIzdavanja")]
       
        public DateTime VrijemeIzdavanja
        {
            get
            {
                return vrijemeIzdavanja;
            }
            set
            {
                vrijemeIzdavanja = value;
            }
        }

        [DisplayName("Zaposleni ID")]
        [SqlName("ZaposleniID")]
        [ForeignKey("dbo.Zaposleni", "ZaposleniID")]
        public int ZaposleniID
        {
            get
            {
                return zaposleniID;
            }
            set
            {
                zaposleniID = value;
            }
        }

        [DisplayName("Popust")]
        [SqlName("Popust")]

        public decimal Popust
        {
            get
            {
                return popust;
            }
            set
            {
                popust = value;
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
        #endregion

        #region queries
        public string GetDeleteQuery()
        {
            return @"
                     DELETE FROM [dbo].[Racun]
                        WHERE RacunID = @RacunID
                    ";
        }
        public string GetSelectQuery()
        {
            return @"
                  SELECT [RacunID]
                      ,[VrijemeIzdavanja]
                      ,[ZaposleniID]
                      ,[Popust]
                      ,[PacijentID]
                  FROM [dbo].[Racun]
                    ";
        }
        public string GetUpdateQuery()
        {
            return @"
                        UPDATE [dbo].[Racun]
                           SET [VrijemeIzdavanja] = @VrijemeIzdavanja
                              ,[ZaposleniID] = @ZaposleniID
                              ,[Popust] = @Popust
                              ,[PacijentID] = @PacijentID
                         WHERE RacunID = @RacunID";
        }
        public string GetInsertQuery()
        {
            return @"
                   INSERT INTO [dbo].[Racun]
                       ([VrijemeIzdavanja]
                       ,[ZaposleniID]
                       ,[Popust]
                       ,[PacijentID])
                   VALUES
                        (@VrijemeIzdavanja, @ZaposleniID, @Popust, @PacijentID)";
        }
        #endregion

        #region Parameteri
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@RacunID", System.Data.SqlDbType.Int);
                parameter.Value = racunID;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@VrijemeIzdavanja", System.Data.SqlDbType.DateTime);
                parameter.Value = vrijemeIzdavanja;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = zaposleniID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Popust", System.Data.SqlDbType.Decimal);
                parameter.Value = popust;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
                parameter.Value = pacijentID;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@RacunID", System.Data.SqlDbType.Int);
                parameter.Value = racunID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrijemeIzdavanja", System.Data.SqlDbType.DateTime);
                parameter.Value = vrijemeIzdavanja;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = zaposleniID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Popust", System.Data.SqlDbType.Decimal);
                parameter.Value = popust;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
                parameter.Value = pacijentID;
                list.Add(parameter);
            }
            return list;
        }
        #endregion
    }
}
