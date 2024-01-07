using BlankApp1.Models;
using BlankApp1.Services;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlankApp1.ViewModels
{
    class ToDoViewModel:BindableBase, INavigationAware
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
            
           string message= data.RemoveToDo ((int)obj);
            Message(message);
        }
        private void ReviseTodo()
        {
           
            DataToDo data = new DataToDo();
            //data.ReviseToDo(todo);
        }
        private void AddTodo()
        {
            DataToDo data = new DataToDo();
               string message= data.AddToDo(content, Date.ToString("yyyy-MM-dd"));
            Message(message);
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
        private void Message(string message)
        {

            MessageBox.Show(message);

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
           
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // 每次导航都创建新的View和ViewModel实例
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
          
        }
    }
}
