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
    public class PropertyDetaljiRacuna:PropertyInterface
    {
        #region Atributi
        private int detaljiRacunaID;
        private int racunID;
        private int cijenaID;
        private int kolicina;
        #endregion

        #region Property

        [DisplayName("Detalji racuna ID")]
        [SqlName("DetaljiRacunaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        public int DetaljiRacunaID
        {
            get
            {
                return detaljiRacunaID;
            }
            set
            {
                detaljiRacunaID = value;
            }
        }

        [DisplayName("Racun ID")]
        [SqlName("RacunID")]
        [GenerateComponent(ComponentType.Tekst)]
        [ForeignKey("dbo.Racun", "RacunID")]
      
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

        [DisplayName("Cijena ID")]
        [SqlName("CijenaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [ForeignKey("dbo.Cjenovnik", "CjenovnikID")]

        public int CijenaID
        {
            get
            {
                return cijenaID;
            }
            set
            {
                cijenaID = value;
            }
        }

        [DisplayName("Kolicina")]
        [SqlName("Kolicina")]
        [GenerateComponent(ComponentType.Tekst)]

        public int Kolicina
        {
            get
            {
                return kolicina;
            }
            set
            {
                kolicina = value;
            }
        }
        #endregion

        #region Kveriji

        public string GetDeleteQuery()
        {
            return @"USE [Tim4]
                    GO

                    DELETE FROM [dbo].[DetaljiRacuna]
                          WHERE DetaljiRacunaID = @DetaljiRacunaID
                    GO";
        }

        public string GetInsertQuery()
        {
            return @"USE [Tim4]
                    GO

                    INSERT INTO [dbo].[DetaljiRacuna]
                               ([RacunID]
                               ,[CijenaID]
                               ,[Kolicina])
                         VALUES(
                               @RacunID
                               ,@CijenaID
                               ,@Kolicina)
                    GO";
        }

        public string GetSelectQuery()
        {
            return @"USE [Tim4]
                    GO

                    SELECT [DetaljiRacunaID]
                          ,[RacunID]
                          ,[CijenaID]
                          ,[Kolicina]
                      FROM [dbo].[DetaljiRacuna]
                    GO";
        }

        public string GetUpdateQuery()
        {
            return @"USE [Tim4]
                    GO

                    UPDATE [dbo].[DetaljiRacuna]
                       SET [RacunID] = @RacunID
                          ,[CijenaID] = @CijenaID
                          ,[Kolicina] = @Kolicina
                     WHERE DetaljiRacunaID = @DetaljiRacunaID
                    GO";
        }

        #endregion

        #region Parametri

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter DetaljiRacunaID = new SqlParameter("@DetaljiRacunaID", System.Data.SqlDbType.Int);
            DetaljiRacunaID.Value = detaljiRacunaID;
            list.Add(DetaljiRacunaID);

            return list;
        }
        
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter RacunID = new SqlParameter("@RacunID", System.Data.SqlDbType.Int);
            RacunID.Value = racunID;
            list.Add(RacunID);

            SqlParameter CijenaID = new SqlParameter("@CijenaID", System.Data.SqlDbType.Int);
            CijenaID.Value = cijenaID;
            list.Add(CijenaID);

            SqlParameter Kolicina = new SqlParameter("@Kolicina", System.Data.SqlDbType.Int);
            Kolicina.Value = kolicina;
            list.Add(Kolicina);

            return list;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            SqlParameter RacunID = new SqlParameter("@RacunID", System.Data.SqlDbType.Int);
            RacunID.Value = racunID;
            list.Add(RacunID);

            SqlParameter CijenaID = new SqlParameter("@CijenaID", System.Data.SqlDbType.Int);
            CijenaID.Value = cijenaID;
            list.Add(CijenaID);

            SqlParameter Kolicina = new SqlParameter("@Kolicina", System.Data.SqlDbType.Int);
            Kolicina.Value = kolicina;
            list.Add(Kolicina);

            SqlParameter DetaljiRacunaID = new SqlParameter("@DetaljiRacunaID", System.Data.SqlDbType.Int);
            DetaljiRacunaID.Value = detaljiRacunaID;
            list.Add(DetaljiRacunaID);

            return list;
        }

        #endregion
    }
}
