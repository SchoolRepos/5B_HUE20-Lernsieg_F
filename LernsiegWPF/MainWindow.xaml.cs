using LernsiegDatabase;
using LernsiegViewModels;

namespace LernsiegWPF;

public partial class MainWindow
{
    public MainWindow(LernsiegContext context, MainViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}
