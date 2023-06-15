using Sketchpad.ViewModels;

namespace Sketchpad.Views;

public partial class AllNotesPage : ContentPage
{
    public AllNotesPage(NotesViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}