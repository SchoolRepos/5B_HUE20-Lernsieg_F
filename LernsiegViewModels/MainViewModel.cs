using System.Collections.ObjectModel;
using LernsiegDatabase;
using LernsiegDatabase.Entities;
using MvvmTools;

namespace LernsiegViewModels;

public class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
    }

    public MainViewModel(LernsiegContext context)
    {
        _context = context;
        context.Schools
            .ToList()
            .ForEach(Schools.Add);
    }

    public ObservableCollection<School> Schools { get; } = new();
    public ObservableCollection<Teacher> Teachers { get; } = new();


    private School? _selectedSchool;
    private readonly LernsiegContext _context = null!;

    public School? SelectedSchool
    {
        get => _selectedSchool;
        set
        {
            _selectedSchool = value;
            NotifyPropertyChanged(nameof(SelectedSchool));
            Teachers.Clear();
            if(value != null)
                _context.Teachers
                    .Where(x => x.School == value)
                    .ToList()
                    .ForEach(Teachers.Add);
        }
    }
    
    
}
