using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged, IEmployeesViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IEmployeeRepository _employeeRepository;

        protected void OnPropertyChanged([CallerMemberName] string Name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }
        private ObservableCollection<Employee> _employees;

        public EmployeeViewModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            FillListView();
            FillFilterMessage();
        }

        public ObservableCollection<Employee> Employees 
        { 
            get 
            { 
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private string _filter;
        public string Filter
        {
            get
            {
                return _filter;
            }
            set
            {
                _filter = value;
                FillListView();
                FillFilterMessage();
            }
        }

        private string _filterMessage;
        public string FilterMessage
        {
            get
            {
                return _filterMessage;
            }
            set
            {
                _filterMessage = value;
                OnPropertyChanged();
            }
        }

        private void FillListView()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                Employees = new ObservableCollection<Employee>(
                    _employeeRepository.GetAll()
                    .Where(v => v.FirstName.Contains(_filter)));
            }
            else
                Employees = new ObservableCollection<Employee>(
                  _employeeRepository.GetAll());
        }

        private void FillFilterMessage()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                FilterMessage = "По вашему запросу найдено: " + Employees.Count().ToString();
            }
            else
            {
                FilterMessage = "Введите данные для поиска";
            }
        }
    }
}
