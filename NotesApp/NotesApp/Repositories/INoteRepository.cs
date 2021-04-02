using NotesApp.Models;
using System.Collections.Generic;

namespace NotesApp.Repositories
{
    public interface INoteRepository
    {
        void DeleteNote(Note note);
        IEnumerable<Note> GetAllNotes();
        Note GetNote(int id);
        void SaveNote(Note note);
    }
}