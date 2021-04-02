using NotesApp.Models;
using NotesApp.Repositories;
using System;
using Xamarin.Forms;

namespace NotesApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteEntryPage : ContentPage
    {
        private INoteRepository noteRepository;

        public int ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public NoteEntryPage()
        {
            InitializeComponent();
            noteRepository = new NoteRepository();
            BindingContext = new Note();
        }

        private void LoadNote(int id)
        {
            BindingContext = noteRepository.GetNote(id);
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = BindingContext as Note;
            note.Date = DateTime.Now;

            if (note != null)
            {
                SaveNote(note);
            }

            // Navigate backwards -> Go back to previous screen
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = BindingContext as Note;
            DeleteNote(note);

            // Navigate backwards -> Go back to previous screen
            await Shell.Current.GoToAsync("..");
        }

        public void SaveNote(Note note)
        {
            noteRepository.SaveNote(note);
        }

        private void DeleteNote(Note note)
        {
            noteRepository.DeleteNote(note);
        }
    }
}