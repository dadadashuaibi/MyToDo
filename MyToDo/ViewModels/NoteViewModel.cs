using BlankApp1.Models;
using BlankApp1.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlankApp1.ViewModels
{
    class NoteViewModel : BindableBase
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value;
            RaisePropertyChanged(nameof(Content));
            }
        }

        private string tittle;

        public string Tittle
        {
            get { return tittle; }
            set
            {
                tittle = value;
                RaisePropertyChanged(nameof(Tittle));
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
        public DelegateCommand<int?> DeletCommand { get; set; }
        private void DeleteNote(int? id)
        {
            DataNote data = new DataNote();
            string message= data.RemoveNote((int)id);
            Message(message);
        }
        private void ReviseNote()
        {
            DataNote data = new DataNote();
            //data.ReviseNote(Note);
        }
        public DelegateCommand AddCommand { get; set; }
        private void AddNote()
        {
            DataNote data = new DataNote();
            Note note = new Note();
            note.Content = content;
            note.Tittle = tittle;
           string message= data.AddNote(note);
            Message(message);

        }
        public NoteViewModel() {
            GetNote();
            AddCommand = new DelegateCommand(AddNote);
            DeletCommand = new DelegateCommand<int?>(DeleteNote);
        }
        private void GetNote()
        {
            Notes = new List<Note> { };
            DataNote data = new DataNote();
            var item = data.GetNote();
            foreach (var item1 in item)
            {
                if (item1.Status == 0)
                {
                    Notes.Add(item1);
                }
               
            }
        }
        private void Message(string message)
        {
           
            MessageBox.Show(message);

        }
    }

}
