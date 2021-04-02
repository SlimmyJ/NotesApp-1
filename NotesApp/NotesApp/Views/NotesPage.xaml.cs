using NotesApp.Models;
using NotesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        private INoteRepository noteRepository;

        public NotesPage()
        {
            InitializeComponent();
            noteRepository = new NoteRepository();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var notes = GetAllNotes();

            // Bind a list of items to a collectionView
            myNotes.ItemsSource = notes;
        }

        private IEnumerable<Note> GetAllNotes()
        {
            IEnumerable<Note> notes = noteRepository.GetAllNotes();
            return notes;
        }

        private async void myNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the first selected element from a collectionview
            Note note = (Note)e.CurrentSelection.FirstOrDefault();
            await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryPage.ItemId)}={note.Id}");
        }

        private async void AddNoteClicked(object sender, EventArgs e)
        {
            // nameof -> Returns name of object in string format
            // Much, much safer than using "NoteEntryPage" -> A danger to refactoring
            await Shell.Current.GoToAsync(nameof(NoteEntryPage));
        }
    }
}