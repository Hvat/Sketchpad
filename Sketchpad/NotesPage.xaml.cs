using Sketchpad.ViewModel;

namespace Sketchpad;

public partial class NotesPage : ContentPage
{
	public NotesPage(NotesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
