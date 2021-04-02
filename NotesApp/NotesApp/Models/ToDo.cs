using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Text { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime Deadline { get; set; }

        public bool CheckCompleted { get; set; }


        public int GradeOfImportance { get; set; }
    }
}
