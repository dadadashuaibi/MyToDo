using BlankApp1.Models;
using BlankApp1.Services;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.ViewModels
{
    class ToDoViewModel:BindableBase
    {
        private int id;

        public int Id
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

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value;
                RaisePropertyChanged(nameof(Date));
            }
        }

        private ObservableCollection<ToDo> toDoDates;
        public ObservableCollection<ToDo> ToDoDotes
        {
            get { return toDoDates; }
            set
            {
                toDoDates = value;
                RaisePropertyChanged(nameof(ToDoDotes));
            }
        }
       public DelegateCommand AddCommand { get; set;}
        public DelegateCommand ReviseCommand { get; set; }
        public DelegateCommand<int?> DeleteCommand { get; set; }
        private void DeleteTodo(int? obj)
        {
            DataToDo data = new DataToDo();
            
            data.RemoveToDo ((int)obj);
        }
        private void ReviseTodo()
        {
           
            DataToDo data = new DataToDo();
            //data.ReviseToDo(todo);
        }
        private void AddTodo()
        {
            DataToDo data = new DataToDo();
                data.AddToDo(content, Date.ToString("yyyy-MM-dd"));           
        }
        private void GetToDos()
        {
            ToDoDotes = new ObservableCollection<ToDo> { };
            DataToDo data = new DataToDo();
            var item = data.GetToDos();
            foreach (var item1 in item)
            {
                if (item1.Status == 0)
                {
                   DateTime dt1 = DateTime.Now;
                    if (DateTime.Parse(item1.Date) < dt1)
                    {
                        data.IsCompleted(item1.Id);
                    }
                    ToDoDotes.Add(item1);
                }              
            }
        }
        public ToDoViewModel() { 
            GetToDos();
            AddCommand = new DelegateCommand(AddTodo);
            ReviseCommand = new DelegateCommand(ReviseTodo);
            DeleteCommand = new DelegateCommand<int?>(DeleteTodo);
        }
    }
}
