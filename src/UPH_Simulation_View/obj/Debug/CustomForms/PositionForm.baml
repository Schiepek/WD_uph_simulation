   M S B A M L   `   `   `  ����N  JUPH_Simulation_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:UPH_Simulation_View.CustomFormsUPH_Simulation_View.CustomForms  5      C&clr-namespace:UPH_Simulation_View.UtilUPH_Simulation_View.Util  5      9!clr-namespace:UPH_Simulation_ViewUPH_Simulation_View  5      2    ,UPH_Simulation_View.CustomForms.PositionForm   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:UPH_Simulation_View.CustomForms     5      7util&clr-namespace:UPH_Simulation_View.Util     5      2view!clr-namespace:UPH_Simulation_View     5        � 	Resources  5
      E   ?UPH_Simulation_View.Util.InvertableBooleanToVisibilityConverter   	BoolToVis4   .UPH_Simulation_View.Util.StateToColorConverter  StateToColor��%:   &	        &	        5   
   66     5   
   6%   5      .��5      � $��20��6   $��60��6   $��1q�6#    ^� InitialShowDelay$ 0��6O    � ToolTip 6.   �� *PositionInfo+.+�5   
   �� $��9(�6   ��6   �� *Rank+y�5      �� *IsCalculated+ �� 	Converter# [   �� ConverterParameter$ Normal���� 5   
   $��Center=�6   $��20��6/   $��20��6;   
���   �y�5      �� *IsTransferZone+# [  $ Inverted����5      `� 5       `� 	Converter# [ 6   .1�5      �� �� 5       �� Path$ DataContext�6p    �� RelativeSource 6   ��  �� Mode$ FindAncestor=�	 �� AncestorType"	 �6�   �� 5      $ State�6   5      5      �� 5   
   $��Center=�6   $��14��6/   $��14��6;   
���   �$��3q�6U   y�5      �� *
IsDualZone+# [  $ Normal��5      �� 5   
   $��Center=�6   $��Center=�6+   $��T��6I   $��9(�6V   y�5       �� *IsTransferZone+# [  $ Normal���� 5!   
   $��Center=�6   $��Center=�6+   
 J� Opacity$	
 0.7Q�6H   $��14��5"      $��14��6   $L��Fpack://application:,,,/UPH_Simulation_View;component/Resources/cog.png��5#      y�5$      �� *
IsWorkZone+# [  $ Normal��� 5%   
   $��Bottom=�6   $��20��6*   $��20��66   
������y�5&      �� *
IsActive+# [  $ Normal��.+�5(      �� 
��� � �$��1q�6)   6?   �� 5)      $��Center=�6   $��Bottom=�61   $��9(�6L   ��5*      �� *CurrentUnit.Number+5+      �� 5,      $
��Left=�6   $��Bottom=�6/   $��9(�6J   $��A��6W   $��0q�5-      $��10��5.   �   $��6��6�   $��1,0,0,1q�6�   y�6   �� *CurrentUnit.IsInAutostacker+# [  $ Normal��5/      � 50       � Points' �    -1 -1���  -1 -1��� 
���   �
���   �y�51      �� *CurrentUnit.HasComponent+# [  $ Normal��52      53      55      56      