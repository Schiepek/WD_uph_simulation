using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {

        AssemblyLineVM assemblyLineVM;

        public Header()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Header_Loaded);
        }

        private void Header_Loaded(object sender, RoutedEventArgs e)
        {
            this.assemblyLineVM = (AssemblyLineVM)DataContext;
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.XML";
            Nullable<bool> result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                try
                {
                    assemblyLineVM.Commands.Commands["Load"].Execute(dlg.FileName);
                    assemblyLineVM.Filepath = dlg.FileName;
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.Message, "Error in Xml File", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveAsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML Files (*.xml)|*.XML";
            Nullable<bool> result = dlg.ShowDialog();

            if (result.HasValue && result.Value)
            {
                try
                {
                    assemblyLineVM.Commands.Commands["SaveAs"].Execute(dlg.FileName);
                    assemblyLineVM.Filepath = dlg.FileName;
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.Message, "Error while saving", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OptionsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.DataContext = assemblyLineVM.ConfigVM;
            optionsWindow.Show();
        }

        private void ProceedOneTimeStep_Click(object sender, RoutedEventArgs e)
        {
            CatchAlgorithmException(() => assemblyLineVM.Commands.Commands["ProceedOneTimeStep"].Execute(null));
        }

        private void ProceedOneSecond_Click(object sender, RoutedEventArgs e)
        {
            CatchAlgorithmException(() => assemblyLineVM.Commands.Commands["ProceedOneSecond"].Execute(null));
        }

        private void ProceedOneRound_Click(object sender, RoutedEventArgs e)
        {
            CatchAlgorithmException(() => assemblyLineVM.Commands.Commands["ProceedOneRound"].Execute(null));
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            CatchAlgorithmException(() => assemblyLineVM.Commands.Commands["Calculate"].Execute(null));
        }

        private void Ranking_Click(object sender, RoutedEventArgs e)
        {


            MessageBox.Show(assemblyLineVM.WaitingTimeInfo, "Waitingtime Ranking");
        }

        private void CatchAlgorithmException(Action a)
        {
            if (UPH_Simulation_View.Properties.Settings.Default.Debug)
            {
                a.Invoke();
            } else
            {
                try
                {
                    a.Invoke();
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.Message, "Assemblyline validation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
