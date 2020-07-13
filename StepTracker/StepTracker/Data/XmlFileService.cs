using StepTracker.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StepTracker.ViewModel
{
    public class XmlFileService : IFileService
    {

        public void Save(string filename, Person SelectedPerson)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(Person));

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    formatter.Serialize(fs, SelectedPerson);

                }
        }
        
    }
}
