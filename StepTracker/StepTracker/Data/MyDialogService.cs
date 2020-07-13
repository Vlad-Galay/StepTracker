using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StepTracker.ViewModel
{
    public class MyDialogService : IDialogService
    {
        
        public string FilePath { get; set; }
       


        public bool SaveFileDialog()
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = ".xml";
                if (saveFileDialog.ShowDialog() == true)
                {
                    FilePath = saveFileDialog.FileName;
                    return true;
                }
                return false;
            }

            public void ShowMessage(string message)
            {
                MessageBox.Show(message);
            }
        
    }
}

