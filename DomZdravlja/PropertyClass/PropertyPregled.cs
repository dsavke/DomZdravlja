﻿using DomZdravlja.AttributeClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomZdravlja.PropertyClass
{
    public class PropertyPregled:PropertyInterface
    {
        #region Atributi
        private int pregledID;
        private int doktorID;
        private int pacijentID;
        private int dijagnozaID;
        #endregion

        #region Property
        [DisplayName("Šifra pregleda")]
        [SqlName("PregledID")]
        [GenerateComponent(ComponentType.Tekst)]
        [PrimaryKey]
        [Invisible]
        [MainSearch(null)]
        public int PregledID
        {
            get
            {
                return pregledID;
            }
            set
            {
                pregledID = value;
            }
        }

        [DisplayName("Šifra doktora")]
        [SqlName("DoktorID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyZaposleni", "Sifra zaposleni", Tip.Doktori, "Ime", "Prezime", false)]
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

        [DisplayName("Šifra pacijenta")]
        [SqlName("PacijentID")]
        [GenerateComponent(ComponentType.Lookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyPacijent", "Sifra pacijenta", Tip.Pacijent, "Ime", "Prezime", false)]
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

        [DisplayName("Šifra dijagnoze")]
        [SqlName("DijagnozaID")]
        [GenerateComponent(ComponentType.InsertLookup)]
        [ForeignKey("DomZdravlja.PropertyClass.PropertyDijagnoza", "Sifra dijagnoze", Tip.Dijagnoze, "Opis", "", true)]
        [ValidatePattern(@"^\d+$")]

        public int DijagnozaID
        {
            get
            {
                return dijagnozaID;
            }
            set
            {
                dijagnozaID = value;
            }
        }
        #endregion

        #region Queries
        public string GetDeleteQuery()
        {
            return @"
                    DELETE FROM [dbo].[Pregled]
                    WHERE PregledID = @PregledID
                    ";
        }
        public string GetInsertQuery()
        {
            return @"
                  INSERT INTO [dbo].[Pregled]
                           ([DoktorID]
                           ,[PacijentID]
                           ,[DijagnozaID])
                     VALUES
                           (@DoktorID, @PacijentID, @DijagnozaID)
                    ";
        }

        public string GetSelectQuery()
        {
            return @"
                  SELECT [PregledID]
                      ,[DoktorID]
                      ,[PacijentID]
                      ,[DijagnozaID]
                  FROM [dbo].[Pregled]
                    ";
        }
        public string GetUpdateQuery()
        {
            return @"
                        UPDATE [dbo].[Pregled]
                           SET [DoktorID] = @DoktorID
                              ,[PacijentID] = @PacijentID
                              ,[DijagnozaID] = @DijagnozaID
                         WHERE   WHERE PregledID = @PregledID";
        }
        #endregion

        #region Parametri
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@PregledID", System.Data.SqlDbType.Int);
                parameter.Value = pregledID;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
                parameter.Value = doktorID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
                parameter.Value = pacijentID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DijagnozaID", System.Data.SqlDbType.Int);
                parameter.Value = dijagnozaID;
                list.Add(parameter);
            }
            return list;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@PregledID", System.Data.SqlDbType.Int);
                parameter.Value = pregledID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DoktorID", System.Data.SqlDbType.Int);
                parameter.Value = doktorID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@PacijentID", System.Data.SqlDbType.Int);
                parameter.Value = pacijentID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DijagnozaID", System.Data.SqlDbType.Int);
                parameter.Value = dijagnozaID;
                list.Add(parameter);
            }
            return list;
        }
        #endregion



    }
}
