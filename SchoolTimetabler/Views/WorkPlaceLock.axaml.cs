using Avalonia;using Avalonia.Controls;using Avalonia.Markup.Xaml;using Avalonia.ReactiveUI;using SchoolTimetabler.ViewModels;namespace SchoolTimetabler.Views;public partial class WorkPlaceLock : ReactiveUserControl<LockWorkPlaceViewModel>{    public WorkPlaceLock()    {        InitializeComponent();    }    private void InitializeComponent()    {        AvaloniaXamlLoader.Load(this);    }}