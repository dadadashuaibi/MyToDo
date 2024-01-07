using BlankApp1.Models;
using BlankApp1.Services;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.ViewModels
{
    internal class IndexViewModel:BindableBase,INavigationAware
    {


        public IndexViewModel()
        {
            GetSchedule();
            GetNote();

        }
        private List<ToDo> schedules;
        public List<ToDo> Schedules
        {
            get { return schedules; }
            set
            {
                schedules = value;
                RaisePropertyChanged(nameof(Schedules));
            }
        }
        private List<Note> notes;

        public List<Note> Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                RaisePropertyChanged(nameof(Notes));
            }

        }

        private void GetNote()
        {
            Notes = new List<Note> { };
            DataNote data = new DataNote();
            var item = data.GetNote();
            foreach (var item1 in item)
            {
                Notes.Add(item1);
            }
        }
        private void GetSchedule()
        {
            Schedules = new List<ToDo> { };
            DataToDo data = new DataToDo();
            var item = data.GetToDos();
            foreach (var item1 in item)
            {
                Schedules.Add(item1);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
          
        }
    }
}
