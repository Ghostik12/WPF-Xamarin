using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string Name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }
        private EmployeeRepository _employeeRepository;
        private string _filter;
        private ObservableCollection<Employee> _employees;

        public EmployeeViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            FillListView();
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

    }
}
