using StepTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepTracker.ViewModel
{
    public interface IFileService
    {
        void Save(string filename, Person SelectedPerson);

        
    }
}
