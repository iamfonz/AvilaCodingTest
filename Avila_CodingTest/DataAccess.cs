using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avila_CodingTest
{
    public class DataAccess
    {
        #region Full Props

        private string accessFile;

        public string AccessFile
        {
            get { return accessFile; }
            set { accessFile = value; }
        }
        #endregion


        #region Constructors

        public DataAccess(): this("")
        {
        }
        public DataAccess(string msAccessFile)
        {
            this.accessFile = msAccessFile;
        }
        #endregion


        #region Methods

        public List<string> GetNamesList()
        {
            List<string> namesData = new List<string>();

            var myDataTable = new DataTable();
            using (var connection = new OleDbConnection(this.GetConnectionString()))
            {
                connection.Open();
                var query = "SELECT ML.[ML_Nam] FROM ML";
                var command = new OleDbCommand(query, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                    namesData.Add(reader[0].ToString());

            }

            return namesData;
        }



        private string GetConnectionString()
        {
            return "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + this.accessFile;
        }

        #endregion
    }
}
