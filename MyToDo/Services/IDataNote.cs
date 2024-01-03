using BlankApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    internal interface IDataNote
    {
        List<Note> GetNote();
        void AddNote(Note note);
        void RemoveNote(int id);
        void ReviseNote(Note note);
    }
}
