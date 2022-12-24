using System.Collections.Generic;using System.Reactive;using Data.Repositories;using Domain.Entities;using Domain.UseCases;using MessageBox.Avalonia;using ReactiveUI;using ReactiveUI.Fody.Helpers;namespace SchoolTimetabler.ViewModels;public class CreateSchoolProfileViewModel : ViewModelBase, IRoutableViewModel, IScreen{    [Reactive]    public int SelectedIndexTabControll { get; set; }        public CreateSchoolProfileViewModel()    {        GotoUserInfo = ReactiveCommand.CreateFromObservable(            () =>            {                SelectedIndexTabControll = 0;                return Router.Navigate.Execute(                    new UserInformationViewModel());            });        GoToSchoolInfo = ReactiveCommand.CreateFromObservable(            () =>            {                SelectedIndexTabControll = 1;                return Router.Navigate.Execute(                    new SchoolInformationViewModel());            });        GoToСabinetEditingMenu = ReactiveCommand.CreateFromObservable(            () =>            {                SelectedIndexTabControll = 5;                return Router.Navigate.Execute(                    new CabinetEditingMenuViewModel());            });        GoToDisciplineEditingMenu = ReactiveCommand.CreateFromObservable(            () =>            {                SelectedIndexTabControll = 2;                return Router.Navigate.Execute(                    new DisciplineEditingMenuViewModel(this));            });        GoToClassEditingMenu = ReactiveCommand.CreateFromObservable(            () =>            {                SelectedIndexTabControll = 3;                return Router.Navigate.Execute(                    new ClassEditingMenuViewModel(this));            });        GoToTeacherEditingMenu = ReactiveCommand.CreateFromObservable(            () =>            {                SelectedIndexTabControll = 4;                return Router.Navigate.Execute(                    new TeacherEditingMenuViewModel(this));            });    }    public ReactiveCommand<Unit, IRoutableViewModel> GoToClassEditingMenu { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoToDisciplineEditingMenu { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoToTeacherEditingMenu { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoToСabinetEditingMenu { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GotoUserInfo { get; }    public ReactiveCommand<Unit, IRoutableViewModel> GoToSchoolInfo { get; }    public string? UrlPathSegment { get; }    public IScreen HostScreen { get; }    public RoutingState Router { get; } = new();}