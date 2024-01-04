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
        string AddNote(Note note);
        string RemoveNote(int id);
        string ReviseNote(Note note);
    }
}
