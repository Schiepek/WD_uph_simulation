using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UPH_Simulation_ViewModel;

namespace UPH_Simulation_View.CustomForms
{
    /// <summary>
    /// Interaction logic for AssemblyLineItemVMForm.xaml
    /// </summary>
    public partial class AssemblyLineItemForm : UserControl
    {
        AssemblyLineVM assemblyLineVM;
        AssemblyLineItemVM assemblyLineItemVM;

        public AssemblyLineItemForm()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Control_Loaded);            
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            this.assemblyLineVM = (AssemblyLineVM)Application.Current.MainWindow.DataContext;
            this.assemblyLineItemVM = (AssemblyLineItemVM)DataContext;
        }

        private void Item_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount < 2)
            {
                SelectOrDeselectAssemblyLineItem();
            }
            else
            {
                OpenNewAssemblyLineItemWindow();
            }           
        }

        private void SelectOrDeselectAssemblyLineItem()
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && assemblyLineItemVM.IsSelected)
            {
                assemblyLineVM.Row = null;
            }
            else
            {
                assemblyLineVM.Row = assemblyLineItemVM;
            }
        }

        private void OpenNewAssemblyLineItemWindow()
        {
            AssemblyLineItemWindow window = new AssemblyLineItemWindow();
            window.DataContext = assemblyLineItemVM;

            //Catch exception in case Property is in an invalid state
            try
            {
                window.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                window.Show();
            }
        }
    }
}
