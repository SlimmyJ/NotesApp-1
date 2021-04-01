using NotesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }

        private void myToDos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var todos = new List<ToDo>();

            // Create a Note object from each file
            var files = Directory.EnumerateFiles(App.FolderPath, "*.todo.txt");

            foreach (var file in files)
            {
                todos.Add(new ToDo
                {
                    FileName = file,
                    Text = File.ReadAllText(file),
                    DateOfCreation = File.GetCreationTime(file),
                });
            }
                myToDos.ItemsSource = todos;

        }


        private async void AddToDoClicked(object sender, EventArgs e)
        {
            // "nameof" gebruiken om te vermijden dat letterlijk naar klassen verwezen wordt
            await Shell.Current.GoToAsync(nameof(ToDoEntryPage));
        }
    }


}