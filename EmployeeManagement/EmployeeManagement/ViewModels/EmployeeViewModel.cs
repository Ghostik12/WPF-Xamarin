using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeViewModel
    {
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
            }
        }

        private void FillListView()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                _employees = new ObservableCollection<Employee>(
                  _employeeRepository.GetAll().Where(v => v.FirstName.Contains(_filter)));
            }
            else
                _employees = new ObservableCollection<Employee>(
                  _employeeRepository.GetAll());
        }

    }
}
