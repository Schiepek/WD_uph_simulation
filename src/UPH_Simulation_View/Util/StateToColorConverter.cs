using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using UPH_Simulation_ViewModel;

namespace UPH_Simulation_View.Util
{
    public class StateToColorConverter : IMultiValueConverter
    {
        private PositionVM positionVM;
        private AssemblyLineVM assemblyLineVM;
        private PositionStateVM state;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            positionVM = (PositionVM)values[0];
            assemblyLineVM = (AssemblyLineVM)values[1];
            state = (PositionStateVM)values[2];

            if (state == PositionStateVM.FINISHED)
            {
                DetermineWaitingTimeColor();
            }

            Color color = DetermineColorByState();

            return new SolidColorBrush(color);
        }

        private Color DetermineColorByState()
        {
            switch (state)
            {
                case PositionStateVM.BUFFER:
                    return Color.FromRgb(255, 235, 59);
                case PositionStateVM.WORK:
                    return Color.FromRgb(76,175,80);
                case PositionStateVM.WAIT:
                    return Color.FromRgb(231, 75, 60);
                case PositionStateVM.FINISHED:
                    return DetermineWaitingTimeColor();
            }
            return Colors.White;
        }

        private Color DetermineWaitingTimeColor()
        {
            double min = assemblyLineVM.MinWaitingTime;
            double max = assemblyLineVM.MaxWaitingTime;
            double number = positionVM.WaitingTime;

            if(number < 0.01)
            {
                return Colors.White;
            } else
            {
                double range = (max - min) / 2;
                number -= max - range;
                double factor = 255 / range;
                double red = number < 0 ? number * factor : 255;
                double green = number > 0 ? (range - number) * factor : 255;
                return Color.FromRgb((byte)red, (byte)green, 0);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
