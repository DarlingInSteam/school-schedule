using Domain.Entities;using Domain.Repositories;namespace Domain.UseCases;public class DisciplineInteractor{    private readonly IDisciplinesRepository<Discipline> _disciplinesRepository;    public DisciplineInteractor(IDisciplinesRepository<Discipline> disciplinesRepository)    {        _disciplinesRepository = disciplinesRepository;    }        public void AddDiscipline(string disciplineName)    {        bool detected = false;                foreach (var Discipline in _disciplinesRepository.Read().ToArray())        {            if (Discipline.DisciplineName == disciplineName)            {                var message = MessageBox.Avalonia.MessageBoxManager                    .GetMessageBoxStandardWindow("Неправильные данные",                        "Вы неправильно заполинили поле: Такая дисциплина уже существует").Show();                detected = true;                return;            }        }        if (string.IsNullOrWhiteSpace(disciplineName))        {            var message = MessageBox.Avalonia.MessageBoxManager                .GetMessageBoxStandardWindow("Неправильные данные",                    "Вы не заполинили поле: Название дисциплины").Show();        }        else        {            var newDiscipline = new Discipline(disciplineName);            _disciplinesRepository.Add(newDiscipline);        }    }    public void DelDiscipline(Discipline delDiscipline)    {        _disciplinesRepository.Delete(delDiscipline);    }    public List<Discipline> GetDisciplines()    {        var t = _disciplinesRepository.Read();        return t;    }}