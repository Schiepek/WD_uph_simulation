   M S B A M L   `   `   `  ����N  JUPH_Simulation_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:UPH_Simulation_View.PropertiesUPH_Simulation_View.Properties  5   	   C&clr-namespace:UPH_Simulation_View.UtilUPH_Simulation_View.Util  5   	   S OUPH_Simulation_ViewModel, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:UPH_Simulation_ViewModel;assembly=UPH_Simulation_ViewModelUPH_Simulation_ViewModel 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	   9!clr-namespace:UPH_Simulation_ViewUPH_Simulation_View  5
   	   0    *UPH_Simulation_View.AssemblyLineItemWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   :s,clr-namespace:UPH_Simulation_View.Properties     5   	   7util&clr-namespace:UPH_Simulation_View.Util     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   WvmHclr-namespace:UPH_Simulation_ViewModel;assembly=UPH_Simulation_ViewModel     5   	   7core&clr-namespace:System;assembly=mscorlib     5	   	   3local!clr-namespace:UPH_Simulation_View     5
   	   -   5          � Title$  AssemblyLineItemWindow��5   	   $	��500��5   	   $	��300��6   $	��800��6&   $	��600��5   	   $	��600��6    � 
ResizeMode$ 	CanResize=�5   	    � 	Resources 5         PositionTypeEnum S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� Type-  'UPH_Simulation_ViewModel.PositionTypeVM  
FlatButton �� BasedOn  styleEditButton �� 
TargetType	 �� Property
 �� Value �� UpdateSourceTriggerE   ?UPH_Simulation_View.Util.InvertableBooleanToVisibilityConverter  	BoolToVis��%  &	        &	 [     7  &	 �     S� 5   
   $ 	GetValues��66   "  6M    5      M� 5      "  6   5      �� 5   
   8   " ��6O   .�5      �� 	 � {�
 6*   �� *RowIsSelected+$ PropertyChanged=�5        5   
   66   5      .��5      ]� -   5        $��spnAssemblyLineConfig��5      .+�5   
   � -   5         �Name$ grdName��5      $	��Top=�5       $��30��5!       � ColumnDefinitions 5"      �� 5#      $	��300 �6#   �� 5$      $	��100 �6#   �� 5%      $	��100 �6#   �� 5&      $��50 �6#   .+�5(      �� -   5         ��Name$ 
txtboxName��5(   &   $��0��6    �� TextWrapping$
 Wrap=�6:   $��
10,10,10,0q�5)       �� 	MaxLength 5*      �� -  'UPH_Simulation_View.Properties.Settings   Default �� Source# Z  �� Path$ MaxStringLength�.��6k   .��5+      �� $
 Name�6   $ PropertyChanged=�6&    �� ValidationRules 5,      <   6UPH_Simulation_View.Util.StringCharacterValidationRule  5-      5/      50      �� 51      -   5        $��checkBoxAutostacker��51      $��
10,10,10,0q�62   $��1��6F   $��Autostacker��6V    d� 	IsChecked 52      �� *IsAutostacker+$ PropertyChanged=�53      �� 54      $��2��6   $��0,5,0,0q�6$   $��Capacity��65   $��Right=�6H   6f   �� 55      -   5        $ txtboxCapacity��55   &   $��3��6   $
 Wrap=�6>   $��	5,10,10,0q�56       57      �� # Z $ MaxIntLength�{�58      ��  �� ElementName$ checkBoxAutostacker��$ 	IsChecked�.��6`   .��59      �� $ Capacity�6   $ PropertyChanged=�6*    5:      5   /UPH_Simulation_View.Util.IntRangeValidationRule  5;      
   Min$ 2��66   
   Max$ 99��6>   5=      5>      5?      � 5@   
   -   5        $ 
grdButtons��5@      $	��Top=�5A      $��60��5B      $	��Top=�5C       5D      �� 5E      $��20 �6#   �� 5F      $��30 �6#   �� 5G      $��17 �6#   �� 5H      $��30 �6#   �� 5I      $��17 �6#   �� 5J      $��30 �6#   �� 5K      $��17 �6#   �� 5L      $��30 �6#   �� 5M      $��* �6#    � RowDefinitions 5O      �� 5P      $��1* �6    �� 5Q      $��30 �6    �� 5R      $��1* �6    .+�5T      �� $��1��6   $��1��6%   #��[ 5U      ��5V      �� *Commands.Up+.��5W      F� 
���   �"����    ��[ � � ��[ р�[     	6$   5X      �� 5Y      $��3��6   $��1��6%   #��[ 5Z      ��5[      �� *Commands.Down+.��5\      F� 
���   �"����        р�[ ��[ � �     	6$   5]      �� 5^      $��+��6   $��5��6"   $��1��62   $��18(�6?   #��[ 5_      ��5`      �� *Commands.Add+�� 5a      $��-��6   $��7��6!   $��1��61   $��18(�6>   #��[ 5b      ��5c      �� *Commands.Delete+5d      � 5f   
   -   5        $ grdOk��5f      $��50��6   $��Bottom=�5g      .+�5h      �� -	   5         ��Name$ btnOk��5h      $��Ok��6$   $��522,10,10,10q�61   #��[ 5i      ��5j      �� *	OkCommand+5k      &   System.Windows.Controls.DataGrid  5l   
   -
   5          Name$ dgAssemblyItems��5o      $��	10,0,10,0q�5m      $��Stretch=�5n         CanUserAddRows .     	RowHeight$ 25Q�5r         SelectionMode$ Single=�5s         CanUserSortColumns .      AutoGenerateColumns  .  !   CanUserResizeColumns! .  "   CanUserReorderColumns" .  #   HeadersVisibility$# Column=�5y      
�������$��0q�5{      $   GridLinesVisibility$
$ None=�5|      ��5p      �� *PositionVMs+% �� SelectedItem% 5x      �� *Row+ 5}      *  $System.Windows.Controls.DataGridCell& �� Color��%}  '        (�� G     5�   "   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(�� h     5�   "   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)(�� �     5�   "   * SystemColors.HighlightBrushKey+)�� 5~      "  6   .�5      �� 	 � ��$
 0q�68   5�      �� 5�      $& #1296DE��6e   �� 5�      $& White��6i   �� 5�      $& #1296DE��6T   5�      '   RowStyle' 5�      �� 5�      )	  #System.Windows.Controls.DataGridRow" 	 6   ( �� Triggers( 5�      �� 5�      ) �� Binding) 6&   �� *IsTransferZone+* �� Value	* False6I   .a�5�      �� 	 � ��
 �#B0DCF46;   5�      �� 5�      ) 6&   �� *IsTransferZone+* True6I   .a�5�      �� 	 �@J�Opacity$	
 0.8Q�68   �� 5�      	 � ��$
 12(�69   �� 5�      	 � ��$
 20��67   5�      5�      +   Columns+ 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ,  &System.Windows.Controls.DataGridColumn,   
IsReadOnly, . -   Header$	- Nr.��67   .   Width5  /System.Windows.Controls.DataGridLengthConverter$. 30 6D   1  +System.Windows.Controls.DataGridBoundColumn/   Binding/ 6O   �� *Number+$ PropertyChanged=�
  5�      $
- Name��6%   $	. 140 63   0   EditingElementStyle0 5�      �� 5�      " ��6    .�5�      �� 	 �@��	MaxLength
 6:   �� # Z $ MaxStringLength�5�      / 5�      �� 5�      $
 Name�6"   $ PropertyChanged=�6.    5�      <   6UPH_Simulation_View.Util.MinStringLengthValidationRule  5�   "   
1   Min$1 1Q�6F     5�   "   5�      5�      4  .System.Windows.Controls.DataGridComboBoxColumn  5�      $
- Type��6*   $	. 100 68   2   ItemsSource2 5�   .   �� # [  3   SelectedItemBinding3 5�   .   �� *Type+$ PropertyChanged=�
  5�      $
- Time��6%   $. 45 63   / 5�      �� 5�      $
 Time�6"   4 �� StringFormat$4 N2��6.    5�      8   2UPH_Simulation_View.Util.DoubleRangeValidationRule  5�   "   
5   Min$	5 0.1Q�6B   
6   Max$6 999.0Q�6L   5�      5�      
  5�      $- Lazytime��6%   $. 60 67   / 5�      �� 5�      $ LazyTime�6"   $4 N2��62    5�        5�   "   $	5 0.1Q�6B   $6 999.0Q�6L   5�      7   	CellStyle7 5�      �� 5�      "  6    .�5�      �� 	 � {�
 6:   �� *
IsDualZone+5�      5�      
  5�      $- 	Operation��6%   $. * 68   / 5�      �� 5�      $ 	Operation�6"   $ PropertyChanged=�63    5�        5�   "   $1 1Q�6F     5�   "   5�      7 5�      �� 5�      "  6    .�5�      �� 	 � {�
 6:   �� *
IsDualZone+5�      0 5�      �� 5�      " ��6    .�5�      �� 	 �@��	MaxLength
 6:   �� # Z $ MaxStringLength�5�      5�      8 J� InputBindings8 5�      �� 5�      
9 �� Key$9 Delete��6   : �� Command: 6*   �� *Commands.Delete+5�      5�      5�      