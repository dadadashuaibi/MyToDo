using BlankApp1.Models;
using BlankApp1.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.ViewModel
{
    internal class TrashViewModel:BindableBase
    {

        public TrashViewModel()
        {
            GetToDoes();
            GetNote();

        }
        private List<ToDo> todoes;
        public List<ToDo> ToDoes
        {
            get { return todoes; }
            set
            {
                todoes = value;
                RaisePropertyChanged(nameof(ToDoes));
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
                if (item1.Status == 1)
                {
                    Notes.Add(item1);
                }              
            }
        }
        private void GetToDoes()
        {
            ToDoes = new List<ToDo> { };
            DataToDo data = new DataToDo();
            var item = data.GetToDos();
            foreach (var item1 in item)
            {
                if (item1.Status==1)
                {
                    ToDoes.Add(item1);
                }
            }
        }
    }
}
