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

namespace UPH_Simulation_View.MainWindowUserControls
{
    /// <summary>
    /// Interaction logic for AssemblyLineConfig.xaml
    /// </summary>
    public partial class AssemblyLineConfig : UserControl
    {
        AssemblyLineVM assemblyLineVM;

        public AssemblyLineConfig()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Header_Loaded);
        }

        private void Header_Loaded(object sender, RoutedEventArgs e)
        {
            this.assemblyLineVM = (AssemblyLineVM)DataContext;
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            AssemblyLineItemWindow window = new AssemblyLineItemWindow();
            assemblyLineVM.Commands.Commands["Add"].Execute(null);
            window.DataContext = assemblyLineVM.Last;
            window.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            AssemblyLineItemWindow window = new AssemblyLineItemWindow();
            window.DataContext = assemblyLineVM.Row;

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
