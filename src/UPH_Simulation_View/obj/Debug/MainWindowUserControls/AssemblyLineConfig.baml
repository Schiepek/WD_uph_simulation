   M S B A M L   `   `   `  ����N  JUPH_Simulation_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:UPH_Simulation_View.UtilUPH_Simulation_View.Util  5      O,clr-namespace:UPH_Simulation_View.PropertiesUPH_Simulation_View.Properties  5      C    =UPH_Simulation_View.MainWindowUserControls.AssemblyLineConfig   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7util&clr-namespace:UPH_Simulation_View.Util     5      :s,clr-namespace:UPH_Simulation_View.Properties     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��250��5      $��Stretch=�5	        � 	Resources  5         
FlatButton �� BasedOn  styleEditButton �� 
TargetType �� Property �� Value �� UpdateSourceTrigger��%�   &	       7   �� 5   
   8   " ��6O   .�5      ��  � {� 6*   �� *RowIsSelected+$ PropertyChanged=�5      5      .��5      ]� -   5        $��dpnAssemblyLineConfig��5      .+�5   
   � -   5         �Name$ grdName��5   $   $	��Top=�6   $��35��65   .+�5      �� $��Bottom=�6   $��10,0,0,0q�63   $
��Left=�6E   $��32��6`   Name6q   �� 5      -   5         ��Name$ 
txtboxName��5       �� TextWrapping$
 Wrap=�6*   $��
90,10,10,0q�6>   	 �� 	MaxLength	 5      �� -  'UPH_Simulation_View.Properties.Settings
   Default �� Source# Z
  �� Path$ MaxStringLength�.��6h   .��5      ��  �� NotifyOnValidationError . " �� ValidatesOnNotifyDataErrors . $
 Name�6\   $ PropertyChanged=�6h    �� ValidationRules 5      <   6UPH_Simulation_View.Util.StringCharacterValidationRule  5      5      5      5      � 5   
   -   5        $ grdNumberOfUnits��5   $   $	��Top=�6   $��35��6>    � ColumnDefinitions 5      �� 5      $��0* �6#   �� 5       $��0* �6#   �� 5!      .+�5#      �� $��Bottom=�6   $
��Left=�63   $��2��6N   $��16��6^   $��10,0,0,0q�6j   $��60��6|   Nr. of Units6�   �� 5$      -   5        $ txtboxNumber��5$      $
 Wrap=�6,   $��	90,10,0,0q�6@   $��2��6S   $
��Left=�6c   $��31��6~   $��25��5%   a   $	��Top=�6m   	 6   �� # Z
 $ MaxIntLength�.��6�   .��5&      �� $ NumberOfUnits�6   $ PropertyChanged=�6/    5'      5   /UPH_Simulation_View.Util.IntRangeValidationRule  5(      
   Min$ 1��66   
   Max$	 999��6>   5*      5+      5,      � 5-   
   -   5        $ grdTransferTime��5-   $   $	��Top=�6   $��35��6=   .+�5.      �� $��Bottom=�6   $��16��63   $��
10,0,-10,0q�6?   Transfertime6b   �� 5/      -   5        $ txtboxTransfer��5/      $
 Wrap=�6.   $
��Left=�6B   $��45��6]   $��	90,10,0,0q�50   d   	 6   �� # Z
 $ MaxDoubleLength�.��6w   .��51      �� $ TransferTime�6    �� StringFormat$ {0:0.00}��6.    52      8   2UPH_Simulation_View.Util.DoubleRangeValidationRule  53      
   Min$	 0.1Q�69   
   Max$ 999.0Q�6C   55      56      �� 57      $��Set all��6   $��150,10,50,0q�6T   #��[  6i   ��6'   �� *Commands.SetTransferTime+6�   58      � 59   
   -   5        $ 
grdButtons��59      $	��Top=�5:      $��60��5;      $	��Top=�5<       5=      �� 5>      $
��0.7* �6#   �� 5?      $��30 �6#   �� 5@      $��1* �6#   �� 5A      $��30 �6#   �� 5B      $��1* �6#   �� 5C      $��30 �6#   �� 5D      $��1* �6#   �� 5E      $��17 �6#   �� 5F      $��13 �6#   �� 5G      $
��0.7* �6#    � RowDefinitions 5I      �� 5J      $��1* �6    �� 5K      $��30 �6    �� 5L      $��1* �6    .+�5N      �� $��1��6   $��1��6%   #��[ 62   ��5O      �� *Commands.Up+.��5P      F� 
���   �"����    ��[ � � ��[ р�[     	6$   5Q      �� 5R      $��3��6   $��1��6%   #��[ 62   ��5S      �� *Commands.Down+.��5T      F� 
���   �"����        р�[ ��[ � �     	6$   5U      �� 5V      -	   5        $��+��5V      $��5��6!   $��1��61   #��[  6>   $��18(�5W      5X      �� 5Y      $��-��6   $��7��6!   $��1��61   #��[ 6>   $��18(�5Z      $��2��5[   9   ��6   �� *Commands.Delete+69   5\      &   System.Windows.Controls.DataGrid  5]   
   -
   5          Name$ dgAssemblyItems��5`      $��Bottom=�5^      $��
10,0,10,10q�5_         CanUserAddRows .     	RowHeight$ 25Q�5e      
�������$��0q�5g         CanUserSortColumns .     
IsReadOnly .    SelectionMode$ Single=�5j         AutoGenerateColumns .     CanUserResizeColumns .     CanUserReorderColumns .      GridLinesVisibility$
  None=�5n      !   HeadersVisibility$! Column=�5o      ��5a      �� *	ItemVMs+" �� SelectedItem" 5b      �� *Row+$ PropertyChanged=�#   	CellStyle# 5p      �� 5q      *  $System.Windows.Controls.DataGridCell"  6   .�5r      ��  � ��$ 0q�68   �� 5s       �@�FocusVisualStyle 69   Z� 5t        5v      $ �� Color��%,  (��       5w   "   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(�� !     5x   "   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)(�� @     5y   "   * SystemColors.HighlightBrushKey+)�� 5w      $$ #1296DE��6e   �� 5x      $$ White��6i   �� 5y      $$ #1296DE��6T   5z      %   Columns% 5{      0  *System.Windows.Controls.DataGridTextColumn  5|      ,  &System.Windows.Controls.DataGridColumn&   Header$	& Nr.��6%   '   Width5	  /System.Windows.Controls.DataGridLengthConverter$' 30	 62   1
  +System.Windows.Controls.DataGridBoundColumn( 
  Binding( 6=   �� *Number+  5}      $
& Name��6%   $	' 120	 63   ( 6?   �� *Name+  5~      $	& Oto��6&   $' *	 63   ( 6=   �� *
OutToOut+) J� InputBindings) 5�      �� 5�      
* �� Key$* Delete��6   + �� Command+ 6*   �� *Commands.Delete+5�      5�      5�      