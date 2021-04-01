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
    public partial class ToDoEntryPage : ContentPage
    {
        public ToDoEntryPage()
        {
            InitializeComponent();
            BindingContext = new ToDo();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todo = BindingContext as ToDo;

            if (todo != null)
            {
                if (string.IsNullOrWhiteSpace(todo.FileName))
                {
                    string _fileName = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.todo.txt");
                    File.WriteAllText(_fileName, title.Text);
                }
                else
                {
                    // Update existing file
                    File.WriteAllText(todo.FileName, title.Text);
                }
            }

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todo = BindingContext as ToDo;

            if (todo != null)
            {
                if (File.Exists(todo.FileName))
                {
                    File.Delete(todo.FileName);
                }
            }

            // Navigate backwards -> Go back to previous screen
            await Shell.Current.GoToAsync("..");


        }
    }
}