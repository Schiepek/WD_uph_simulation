   M S B A M L   `   `   `  ����  UPH_Simulation_View7    1UPH_Simulation_View.MainWindowUserControls.Header   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $��Stretch=�5        � 	Resources  5	       �� 
TargetType �� Property �� Value��%|   '��       �� 5
   
   " ��6   .�5      ��  � ��$ Center=�62   �� 5       � ��
 �����6+   5      5      .��5      �� .+�5   
   o� .@�5      m� $��_File��6   .@�5      m� $
��_New��6    m� Command 6)   �� *Commands.New+m� 5      -   5        $��_Open...��5      6-   m� 5      $��_Save��6    6*   �� *Commands.Save+m� 5      -   5        $��_Save as...��5      60   m� 5      -   5        $��_Exit��5      6*   5      m� 5      -   5        $��_Options��5      6)   5      ]� 5   
   $��70��5      ���#1296DE.+�5       �� $��	10,0,60,0q�5!      $
��Left=�5"      $��UPH Simulation��5#      $
��Left=�5$      $��Center=�6-   $��Segoe UI Light)�5%      $��25(�6-   $
��Bold"�6;   
�������5&      �� 5'      -   5        $��30,5,5,5q�5'      $��30��6(   $��30��64   $
��Left=�6?      
FlatButton#��[  5(      .��5*      �  � Points �   ��� �9� @KL ��5,      �� 5-       �� Color$ Black��6*   5/      50      �� 51      -   5        $��5q�51      $��30��6    $��30��6,   $
��Left=�67   #��[  52      .��54      � ? �   ��� �9� @KL �9� �s@KL �9� ��� �9� @KL ��56      �� 57      $ Black��6*   59      5:      �� 5;      -   5        $��5q�5;      $��30��6    $��30��6,   $
��Left=�67   #��[  5<      .��5>      � K �	   ��� �9� @KL �9�  |�  |�  |� ��� �9� ��� �9� @KL ��5@      �� 5A      $ Black��6*   5C      5D      �� 5E      $��	  Reset  ��6   $��5q�6)   #��[  64   $��30��6X   $
��Left=�6d   ��6   �� *Commands.Reset+6�   �� 5F      -   5        $��  Calculate  ��5F      $��5q�6-   #��[  68   $��30��6\   6�   � 5G      -	   5        $��TimeGrid��5G      $��20,0,5,0q�6#   $��60��65   .+�5H      �� $��Time (s)��6   $��0,8,0,38q�6,   6@   �� 5I      $��Segoe UI Light)�6C   $��20(�6_   $
��Bold"�6m   $��0,10,0,0q�6   ��6   �� *Time+ �� StringFormat$ N2��6�   5J      � 5K      -
   5        $��	RoundGrid��5K      $��10,0,5,0q�6$   .+�5L      �� $��Round��6   $��0,8,0,38q�6)   6=   �� 5M      $��Segoe UI Light)�63   $��20(�6O   $
��Bold"�6]   $��0,10,0,0q�6o   ��6   �� *Round+6�   5N      � 5P      $��Right=�6   $��Right=�5Q      $	��270��5R       � ColumnDefinitions 5S      �� 5T      $
��2.5* �6'   �� 5U      $��1* �6'   �� 5V      $
��0.1* �6'   �� 5W      $
��0.9* �6'   	 � RowDefinitions	 5Y      �� 5Z      $��3* �6$   �� 5[      $	��16* �6$   �� 5\      $��16 �6$   �� 5]      $	��16* �6$   �� 5^      $	��16* �6$   �� 5_      $��3* �6$   .+�5b      �� -   5        #��[  5b      $��0,0,15,0q�6=   $��0��6O   $��2��6_   $��2��6l   $��Waitingtime Ranking��6}   5c      �� 5f      $��1��6   $��1��6,   $��Right=�69   $��	Cycletime��6U   6i   �� 5g      $��1��6   $��2��6,   $��Right=�69   $��
Out to out��6U   6i   �� 5h      $��1��6   $��3��6,   $��Right=�69   $	��Uph��6U   6b   �� 5i      $��1��6   $��4��6,   $��Right=�69   $��	Oto Range��6U   6h   �� 5j      $��3��6   $��1��6,   ��69   �� *ResultVM.CycleTime+$ {0:N2}��6w   �� 5k      $��3��6   $��2��6,   ��69   �� *ResultVM.AutoOut+$ {0:N2}��6t   �� 5l      $��3��6   $��3��6,   ��69   �� *ResultVM.UnitsPerHour+$ {0:N2}��6y   �� 5m      $��3��6   $��4��6,   ��69   �� *ResultVM.AutoOutRange+$ {0:N2}��6y   5n      5o      �� 5p   
   $��5��6   $��Stretch=�6   ���#EF5E1F6O   5q      5r      