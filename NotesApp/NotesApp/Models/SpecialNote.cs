using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Models
{
    public class SpecialNote : Note
    {
        public override void ICanBeOverridden()
        {
            base.ICanBeOverridden();
        }
    }
}
