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

namespace UPH_Simulation_View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new AssemblyLineVM();
            this.KeyDown += new KeyEventHandler(Delete_KeyDown);
            this.Closed += CloseAllWindows;
        }

        private void Delete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                AssemblyLineVM assemblyLineVM = (AssemblyLineVM)DataContext;
                if(assemblyLineVM.Row != null)
                {
                    assemblyLineVM.Commands.Commands["Delete"].Execute(null);
                }
            }
        }

        private void CloseAllWindows(object sender, EventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                window.Close();
            }
        }
    }
}
