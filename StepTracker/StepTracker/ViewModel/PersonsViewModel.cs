
using Newtonsoft.Json;
using StepTracker.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Serialization;

namespace StepTracker.ViewModel
{
    public class PersonsViewModel
    {
        IFileService fileService;
        IDialogService dialogService;

        private RelayCommand exportCommand;
        public RelayCommand ExportCommand
        {
            get
            {
                return exportCommand ??
                  (exportCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, SelectedPerson);
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }


                  }));
                  
            }
        }
        
        


        private Person selectedPerson;

        public ObservableCollection<Person> Persons { get; set; }

        public Person SelectedPerson
        {

            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        

        

        public static ObservableCollection<Person> GetAll()
        {

            var result = new List<Person>();
            string path = Directory.GetCurrentDirectory();

            foreach (var filePath in Directory.GetFiles(path+"/TestData", "*.json"))
            {
                string json = File.ReadAllText(filePath);
                result.AddRange(JsonConvert.DeserializeObject<IEnumerable<Person>>(json));
                
            }
           var sortedList = result.GroupBy(person => person.User)
                                   .Select(group => new Person
                                   {
                                       User = group.Key,
                                       AverageSteps = (int)group.Average(x => x.Steps),
                                       BestResult = group.Max(x => x.Steps),
                                       WorstResult = group.Min(x => x.Steps),
                                       AllSteps = group.Select(x => x.Steps).ToList(),
                                       AllRank = group.Select(x => x.Rank).ToList(),
                                       AllStatus = group.Select(x => x.Status).ToList(),

                                   });
            
            

            var PersonCollection = new ObservableCollection<Person>(sortedList);
            for(int i = 0; i < PersonCollection.Count; i++ )
            {
                PersonCollection[i].SetState();
            }

            return PersonCollection;


        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public PersonsViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            Persons = GetAll();

        }

    }
}


 