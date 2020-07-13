using Newtonsoft.Json;
using StepTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace StepTracker.Data
{
    [Serializable]
    public class Person : INotifyPropertyChanged
    {

        private int rank;
        private string user;
        private string status;
        private int steps;
        private int averageSteps;
        private int bestResult;
        private int worstResult;
        private List<int> allSteps;
        private List<string> allStatus;
        private List<int> allRank;
        private List<DayStepPair> stepPairs;
        private bool isNormal;



        [XmlIgnore]
        public bool IsNormal
        {
            get { return isNormal; }
            set
            {
                isNormal = value;
                OnPropertyChanged("IsNormal");
            }
        }
        
        
        public void SetState()
        {
            
            
            var isMaxNotNormal = ((float)this.BestResult / (float)this.AverageSteps - 1 > 0.2);
            var isMinNotNormal = (Math.Abs((float)this.WorstResult / (float)this.AverageSteps - 1) > 0.2);

            if (isMaxNotNormal || isMinNotNormal)
            {
                this.IsNormal = false;
            }
            else
            {
                this.isNormal = true;
            }


            OnPropertyChanged("IsNormal");
        }

        
        public List<DayStepPair> StepPairs
        {
            get { return stepPairs; }
            set
            {
                stepPairs = value;
                OnPropertyChanged("StepPairs");
            }
        }
        public void setPairs(List<int> Steps)
        {
            this.stepPairs = new List<DayStepPair>();
            for (int i =0; i < Steps.Count; i++)
            {
                stepPairs.Add(new DayStepPair(Steps[i], i + 1));
            }
            OnPropertyChanged("StepPairs");
        }
        [XmlIgnore]
        public int Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                OnPropertyChanged("Rank");
            }
        }

        public string User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        [XmlIgnore]
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        [XmlIgnore]
        public int Steps
        {
            get { return steps; }
            set
            {
                steps = value;
                
                OnPropertyChanged("Steps");
            }
        }

        public int AverageSteps
        {
            get { return averageSteps; }
            set
            {
                averageSteps = value;
                OnPropertyChanged("AverageSteps");
            }
        }

        public int BestResult
        {
            get { return bestResult; }
            set
            {
                bestResult = value;
                OnPropertyChanged("BestResult");
            }
        }

        public int WorstResult
        {
            get { return worstResult; }
            set
            {
                worstResult = value;
                OnPropertyChanged("WorstResult");
            }
        }

        [XmlIgnore]
        public List<int> AllSteps
        {
            get { return allSteps; }
            set
            {

                allSteps = value;
                setPairs(value);
                OnPropertyChanged("AllSteps");
            }
        }

        public List<int> AllRank
        {
            get { return allRank; }
            set
            {
                allRank = value;
                OnPropertyChanged("AllRank");
            }
        }

        public List<string> AllStatus
        {
            get { return allStatus; }
            set
            {
                allStatus = value;
                OnPropertyChanged("AllStatus");
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
