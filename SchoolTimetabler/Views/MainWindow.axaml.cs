using Avalonia.Controls;using Avalonia.ReactiveUI;using ReactiveUI;using SchoolTimetabler.ViewModels;namespace SchoolTimetabler.Views{    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>    {        public MainWindow()        {            InitializeComponent();            // DataContext = new MainWindowViewModel();            this.WhenActivated(disposables => { });        }    }}