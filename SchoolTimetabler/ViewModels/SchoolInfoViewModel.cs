using System.Collections.Generic;using System.Collections.ObjectModel;using Avalonia.Collections;using Data.Repositories;using Data.Repository;using Domain.Entities;using Domain.UseCases;using ReactiveUI;namespace SchoolTimetabler.ViewModels;public class SchoolInfoViewModel : ViewModelBase, IRoutableViewModel, IScreen{    private string? _countClasses;    private string? _countTeacher;    private AvaloniaList<string> _disciplinesName;    private string? _fullName;    private string? _fullNameDirector;    private bool _isVisibleCabinets;    private bool _isVisiBleClsses;    private bool _isVisibleDataGridTeachers;    private bool _isVisiBleDiscipline;    private bool _isVisiBleTeachers;    private string? _post;    private string? _schoolNumber;    private int _selectedIndexComboBox;    private int _selectedIndexComboBoxTeachers;    private readonly SchoolInfoInteractor _schoolInfoInteractor;    private readonly CabinetInteractor _cabinetInteractor;    private readonly ClassInteractor _classInteractor;    private readonly DisciplineInteractor _disciplineInteractor;    private readonly TeacherInteractor _teacherInteractor;    private readonly UserInteractor _userInteractor;    public SchoolInfoViewModel(MainWindowViewModel mainWindowViewModel)    {        _schoolInfoInteractor = new SchoolInfoInteractor(SchoolRepository.GetInstance());        _userInteractor = new UserInteractor(UserRepository.GetInstance());        _classInteractor = new ClassInteractor(ClassesRepository.GetInstance());        _disciplineInteractor = new DisciplineInteractor(DisciplineRepository.GetInstance());        _teacherInteractor = new TeacherInteractor(TeacherRepository.GetInstance());        _cabinetInteractor = new CabinetInteractor(CabinetsRepository.GetInstance());        TeachersName = new ObservableCollection<string>();        Teachers = new ObservableCollection<Teacher>(_teacherInteractor.GetTeachers());        Classes = new ObservableCollection<Class>(_classInteractor.GetClasses());        Disciplines = new ObservableCollection<Discipline>(_disciplineInteractor.GetDisciplines());        _disciplinesName = new AvaloniaList<string>();        Cabinets = new ObservableCollection<Cabinet>(_cabinetInteractor.GetCabinets());        Post = _userInteractor.UserGet().Post;        FullName = _userInteractor.UserGet().FullName;        SchoolNumber = _schoolInfoInteractor.SchoolInfoGet().SchoolNumber;        FullNameDirector = _schoolInfoInteractor.SchoolInfoGet().FullNameDirector;        CountClasses = _schoolInfoInteractor.SchoolInfoGet().CountClasses;        CountTeacher = _schoolInfoInteractor.SchoolInfoGet().CountTeachers;        if (Teachers.Count != 0)        {            TeachersName.Clear();            foreach (var t in Teachers) TeachersName.Add(t.TeacherFullName);            DisciplinesName.Clear();            var buf = new List<string>();            buf = _teacherInteractor.GetTeacherDisciplines(_selectedIndexComboBoxTeachers);            foreach (var t in buf) DisciplinesName.Add(t);        }    }    public ObservableCollection<Class> Classes { get; }    public ObservableCollection<Cabinet> Cabinets { get; }    public ObservableCollection<Discipline> Disciplines { get; }    public ObservableCollection<Teacher> Teachers { get; }    public ObservableCollection<string> TeachersName { get; set; }    public AvaloniaList<string> DisciplinesName    {        get => _disciplinesName;        set => this.RaiseAndSetIfChanged(ref _disciplinesName, value);    }    public bool IsVisibleCabinets    {        set => this.RaiseAndSetIfChanged(ref _isVisibleCabinets, value);        get => _isVisibleCabinets;    }    public bool IsVisibleClasses    {        set => this.RaiseAndSetIfChanged(ref _isVisiBleClsses, value);        get => _isVisiBleClsses;    }    public bool IsVisibleDataGridTeachers    {        set => this.RaiseAndSetIfChanged(ref _isVisibleDataGridTeachers, value);        get => _isVisibleDataGridTeachers;    }    public bool IsVisibleDiscipline    {        set => this.RaiseAndSetIfChanged(ref _isVisiBleDiscipline, value);        get => _isVisiBleDiscipline;    }    public int SelectedIndexComboBoxTeachers    {        set        {            this.RaiseAndSetIfChanged(ref _selectedIndexComboBoxTeachers, value);            IsVisibleDataGridTeachers = false;            OutputTeacher();        }        get => _selectedIndexComboBoxTeachers;    }    public bool IsVisibleTeachers    {        set => this.RaiseAndSetIfChanged(ref _isVisiBleTeachers, value);        get => _isVisiBleTeachers;    }    public string? SchoolNumber    {        get => _schoolNumber;        set => this.RaiseAndSetIfChanged(ref _schoolNumber, value);    }    public string? Post    {        get => _post;        set => this.RaiseAndSetIfChanged(ref _post, value);    }    public string? FullName    {        get => _fullName;        set => this.RaiseAndSetIfChanged(ref _fullName, value);    }    public string? FullNameDirector    {        get => _fullNameDirector;        set => this.RaiseAndSetIfChanged(ref _fullNameDirector, value);    }    public string? CountClasses    {        get => _countClasses;        set => this.RaiseAndSetIfChanged(ref _countClasses, value);    }    public string? CountTeacher    {        get => _countTeacher;        set => this.RaiseAndSetIfChanged(ref _countTeacher, value);    }    public string? UrlPathSegment { get; }    public IScreen HostScreen { get; }    public RoutingState Router { get; }    private void OutputTeacher()    {        DisciplinesName.Clear();        var buf = new List<string>();        buf = _teacherInteractor.GetTeacherDisciplines(_selectedIndexComboBoxTeachers);        foreach (var t in buf) DisciplinesName.Add(t);        IsVisibleDataGridTeachers = true;    }    public void OutputTeachers()    {        TeachersName.Clear();        foreach (var t in Teachers) TeachersName.Add(t.TeacherFullName);        IsVisibleTeachers = true;        IsVisibleDiscipline = false;        IsVisibleClasses = false;        IsVisibleCabinets = false;    }    public void OutputCabinets()    {        IsVisibleDiscipline = false;        IsVisibleDataGridTeachers = false;        IsVisibleTeachers = false;        IsVisibleClasses = false;        IsVisibleCabinets = false;        IsVisibleCabinets = true;    }    public void OutputClasses()    {        IsVisibleDiscipline = false;        IsVisibleDataGridTeachers = false;        IsVisibleTeachers = false;        IsVisibleCabinets = false;        IsVisibleClasses = true;    }    public void OutputDisciplines()    {        IsVisibleClasses = false;        IsVisibleDataGridTeachers = false;        IsVisibleTeachers = false;        IsVisibleCabinets = false;        IsVisibleDiscipline = true;    }}