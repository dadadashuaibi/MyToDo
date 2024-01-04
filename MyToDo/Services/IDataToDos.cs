using BlankApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    internal interface IDataToDos
    {
        List<ToDo> GetToDos();
        string  AddToDo(string Content,string Date);
        string RemoveToDo(int id);
        string ReviseToDo(ToDo todo);
        void IsCompleted(int id);
    }
}
