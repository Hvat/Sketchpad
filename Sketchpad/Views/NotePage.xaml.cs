using Sketchpad.ViewModels;

namespace Sketchpad.Views;

public partial class NotePage : ContentPage
{
    public NotePage(NoteViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}