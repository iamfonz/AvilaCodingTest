using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avila_CodingTest
{
    public class MainViewModel 
    {

        #region Props and Fields

        private List<string> dataItems;


        public List<string> DataItems
        {
            get { return dataItems; }
            set { dataItems = value; }
        }

        #endregion



        #region Constructors

        public MainViewModel()
        {
            dataItems = new List<string>();
        }

        #endregion


        #region  Methods

        public void PopulateListItems(string accessFile)
        {
            DataAccess dataAccess = new DataAccess(accessFile);
            DataItems = dataAccess.GetNamesList();
        }
        #endregion


    }
}
