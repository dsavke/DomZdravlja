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
        private decimal sumaLinije;
        #endregion

        #region Property

        [DisplayName("Šifra detalji računa")]
        [SqlName("DetaljiRacunaID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible]
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

        [DisplayName("Šifra računa")]
        [SqlName("RacunID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyRacun", "RacunID")]
        [ValidatePattern(@"^\d+$")]
      
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

        [DisplayName("Šifra cijene")]
        [SqlName("CijenaID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyCjenovnik", "CijenaID")]
        [ValidatePattern(@"^\d+$")]

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

        [DisplayName("Količina")]
        [SqlName("Kolicina")]
        [GenerateComponent(ComponentType.Tekst)]
        [ValidatePattern(@"^\d+$")]

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

        [DisplayName("Suma linije")]
        [SqlName("SumaLinije")]
        [GenerateComponent(ComponentType.Tekst)]

        public decimal SumaLinije
        {
            get
            {
                return sumaLinije;
            }
            set
            {
                sumaLinije = value;
            }
        }
        #endregion

        #region Kveriji

        public string GetDeleteQuery()
        {
            return @"

                    DELETE FROM [dbo].[DetaljiRacuna]
                          WHERE DetaljiRacunaID = @DetaljiRacunaID
                    ";
        }

        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO [dbo].[DetaljiRacuna]
                               ([RacunID]
                               ,[CijenaID]
                               ,[Kolicina]
                               ,[SumaLinije])
                         VALUES(
                               @RacunID
                               ,@CijenaID
                               ,@Kolicina
                               ,@SumaLinije)
                    ";
        }

        public string GetSelectQuery()
        {
            return @"

                    SELECT [DetaljiRacunaID]
                          ,[RacunID]
                          ,[CijenaID]
                          ,[Kolicina]
                          ,[SumaLinije]
                      FROM [dbo].[DetaljiRacuna]
                    ";
        }

        public string GetUpdateQuery()
        {
            return @"

                    UPDATE [dbo].[DetaljiRacuna]
                       SET [RacunID] = @RacunID
                          ,[CijenaID] = @CijenaID
                          ,[Kolicina] = @Kolicina
                          ,[SumaLinije] = @SumaLinije
                     WHERE DetaljiRacunaID = @DetaljiRacunaID
                    ";
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

            SqlParameter SumaLinije = new SqlParameter("@SumaLinije", System.Data.SqlDbType.Money);
            SumaLinije.Value = sumaLinije;
            list.Add(SumaLinije);

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

            SqlParameter SumaLinije = new SqlParameter("@SumaLinije", System.Data.SqlDbType.Money);
            SumaLinije.Value = sumaLinije;
            list.Add(SumaLinije);

            return list;
        }

        #endregion
    }
}
