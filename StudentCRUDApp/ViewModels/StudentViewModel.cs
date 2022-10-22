using StudentCRUDApp.DataStore;
using StudentCRUDApp.Models;
using StudentCRUDApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace StudentCRUDApp.ViewModels
{
    public class StudentViewModel:BaseViewModel
    {
        private ObservableCollection<Student> _student;

        private readonly IStudentRepository _studentRepository;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Student> Student
        {
            get => _student;
            set
            {
                _student = value;
                OnPropertyChanged("Student");
            }
        }

        public StudentViewModel(IStudentRepository studentRepository, INavigationService navigationService)
        {
            _studentRepository = studentRepository;
            _navigationService = navigationService;

            LoadCommand = new Command(OnLoadCommand);
            AddCommand = new Command(OnAddCommand);
            PieSelectedCommand = new Command<Student>(OnStudentSelectedCommand);

            Student = new ObservableCollection<Student>();

            MessagingCenter.Subscribe<StudentDetailViewModel, Student>
                (this, MessageNames.PieChangedMessage, OnPieChanged);
        }

        public ICommand LoadCommand { get; }
        public ICommand PieSelectedCommand { get; }
        public ICommand AddCommand { get; }

        public async void OnLoadCommand()
        {
            Student = new ObservableCollection<Student>(await _studentRepository.GetAllStudentAsync(false));
        }

        private void OnStudentSelectedCommand(Student student)
        {
            _navigationService.NavigateTo("StudentDetailView", student);
        }

        private void OnAddCommand()
        {
            _navigationService.NavigateTo("StudentDetailView");
        }

        private async void OnStudentChanged(StudentDetailViewModel sender, Student student)
        {
            Student = new ObservableCollection<Student>(await _studentRepository.GetAllStudentAsync( true));
        }
    }
}

