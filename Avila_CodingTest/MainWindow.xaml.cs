using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Avila_CodingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Props  

        public MainViewModel mainViewModel { get; set; }

        #endregion

        public MainWindow()
        {
            mainViewModel = new MainViewModel();
            InitializeComponent();
        }




        #region Events

        private void btn_openDb_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Microsoft Access Database|*.mdb;*.accdb|All Files (*.*) | *.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Open Access Database File";

            if (openFileDialog.ShowDialog() == true)
            {

                //check for selected files.
                if (openFileDialog.FileName != null || openFileDialog.FileNames != null)
                {
                    //check if an Access file is selected
                    if (openFileDialog.FileNames.Length == 1 & openFileDialog.SafeFileName.Contains(".mdb"))
                    {
                        mainViewModel.PopulateListItems(openFileDialog.FileName, DisplayStatusMessage);

                        //make sure items are populated before updating GUI
                        if(mainViewModel.DataItems.Count > 0)
                        {
                            lstbx_Names.ItemsSource = mainViewModel.DataItems;
                            lbl_dbConnection.Content = "Viewing ML.[ML_Name]\nFrom DB: " + openFileDialog.FileName;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Wrong file type selected. Please select a Microsoft Access Database file ( .mdb, .accdb", "Wrong File Type Selected");
                    }

                }

            }
        }
        #endregion

        private void DisplayStatusMessage(string message)
        {
            MessageBox.Show(message, "Status Message");
        }
    }
}
