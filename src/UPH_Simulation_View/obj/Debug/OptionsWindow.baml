   M S B A M L   `   `   `  ����N  JUPH_Simulation_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:UPH_Simulation_View.PropertiesUPH_Simulation_View.Properties  5   	   C&clr-namespace:UPH_Simulation_View.UtilUPH_Simulation_View.Util  5   	   S OUPH_Simulation_ViewModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:UPH_Simulation_ViewModel;assembly=UPH_Simulation_ViewModelUPH_Simulation_ViewModel 5   	   9!clr-namespace:UPH_Simulation_ViewUPH_Simulation_View  5	   	   '    !UPH_Simulation_View.OptionsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   :s,clr-namespace:UPH_Simulation_View.Properties     5   	   7util&clr-namespace:UPH_Simulation_View.Util     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   WvmHclr-namespace:UPH_Simulation_ViewModel;assembly=UPH_Simulation_ViewModel     5   	   3local!clr-namespace:UPH_Simulation_View     5	   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Options��5   	   $	��270��6   $	��300��6&   $��Stretch=�5   	    � 	Resources 5      5   /UPH_Simulation_View.Util.EnumToBooleanConverter   
EnumToBool��%   &	          5   
   6&   5      .��5      � -   5        $��
grdOptions��5      $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.7* �6   �� 5      $
��0.5* �6   .+�5   
   �� $��0��6   $��0��6    $��Number of rounds��6-   $��2��6H   �� 5    
   $��0��6   $��1��6    $��Standard time��6-   $��2��6E   �� 5!   
   $��0��6   $��2��6    $��Number of digits��6-   $��2��6H   �� 5"   
   $��0��6   $��3��6    $��Autostacker mode��6-   $��2��6H   �� 5#   
   $��0��6   $��1��6   $
��Left=�6/   $��31��6J   $��25��6U    �� 	MaxLength 5$      �� -  'UPH_Simulation_View.Properties.Settings   Default �� Source# Z  �� Path$ MaxIntLength�.��6b   .��5%      �� $ NumberOfRounds�6   	 �� UpdateSourceTrigger$	 PropertyChanged=�6,   
 �� ValidationRules
 5&      5   /UPH_Simulation_View.Util.IntRangeValidationRule  5'      
   Min$ 2��62   
   Max$ 20��6:   5)      5*      �� 5+   
   $��1��6   $��2��6   $
��Left=�6/   $��31��6J   $��25��5,   a    6   �� # Z $ MaxIntLength�.��6n   .��5-      �� $ StandardTransferTime�6    �� StringFormat$ N2��62   
 5.      8   2UPH_Simulation_View.Util.DoubleRangeValidationRule  5/      
   Min$	 0.1Q�66   
   Max$ 999.0Q�6@   51      52      �� 53   
   $��2��6   $��2��6   $
��Left=�6/   $��31��6J   $��25��54   a    6   �� # Z $ MaxIntLength�.��6n   .��55      �� $ NumberOfDigits�6   $	 PropertyChanged=�6,   
 56        57      $ 1��62   $ 2��6:   59      5:      	� 5;   
   $��3��6   $��1��6#   $	��0,5q�63   $��Check capacity��5<       d� 	IsChecked 5=      �� $ AutostackerMode� �� 	Converter# [  0  *UPH_Simulation_ViewModel.AutostackerModeVM   CheckCapacity �� ConverterParameter# Z 5@      	� 5A   
   $��3��6   $��1��6#   $
��0,15q�63   $��Round robin��5B      $��Bottom=�6,    5C      �� $ AutostackerMode�# [     
RoundRobin# Z 5F      �� 5G   
   -   5        $��btnOk��5G      $��4��5H      $��1��6   $��Ok��5I      $��5q�6     
FlatButton#��[ 5J      ��5K      �� *	OkCommand+5L      5M      5N      