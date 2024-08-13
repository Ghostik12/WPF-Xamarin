using EmployeeManagement.ViewModels;
using System.Windows;

namespace EmployeeManagement.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        public EmployeeView(IEmployeeViewModel employeeViewModel)
        {
            InitializeComponent();
            DataContext = employeeViewModel;
        }
    }
}
