using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UPH_Simulation_View.Util;
using UPH_Simulation_ViewModel;

namespace UPH_Simulation_View
{
    /// <summary>
    /// Interaction logic for AssemblyLineItemWindow.xaml
    /// </summary>
    public partial class AssemblyLineItemWindow : Window
    {
        public ICommand OkCommand
        {
            get;
            internal set;
        }


        public AssemblyLineItemWindow()
        {
            InitializeComponent();
            btnOk.DataContext = this;
            OkCommand = new RelayCommand((parameter) => Close(), AssemblyLineItemWindowIsValid);
        }

        void CloseAssemblyLineItemWindow(object sender, CancelEventArgs e)
        {
            dgAssemblyItems.CancelEdit();
            dgAssemblyItems.CommitEdit();
        }

        private bool AssemblyLineItemWindowIsValid(object obj)
        {
            return GridIsValid() && TextBoxNameIsValid();
        }

        private bool GridIsValid()
        {
            if (dgAssemblyItems.ItemsSource != null)
            {
                return !(from c in (from object i in dgAssemblyItems.ItemsSource
                                          select dgAssemblyItems.ItemContainerGenerator.ContainerFromItem(i))
                               where c != null
                               select Validation.GetHasError(c))
                                    .FirstOrDefault(x => x);
            }
            return true;
        }

        private bool TextBoxNameIsValid()
        {
            var result = Validation.GetErrors(txtboxName);
            return result.Count == 0;
        }

        private void checkBoxAutostacker_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
