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

        public void PopulateListItems(string accessFile, StatusMessageDelegate messageDelegate)
        {
            DataAccess dataAccess = new DataAccess(accessFile);
            try
            {
                dataItems = dataAccess.GetNamesList();
                messageDelegate("Successfully retrieved ML.ML_Names from Microsoft Access Database File:\n" + accessFile);

            }catch(Exception ex)
            {
                messageDelegate("There was an error retrieving data from selected file:\n" + accessFile + "\nExceptionMessage:" + ex.Message);
            }
            
        }
        #endregion


    }

    public delegate void StatusMessageDelegate(string message);
}
