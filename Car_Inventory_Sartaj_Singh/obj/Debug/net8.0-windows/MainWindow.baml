   M S B A M L   `   `   `  ����  Car Inventory     CarInventoryApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Car Inventory��5   	   $	��506��6   $	��346��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]   $��Times New Roman)�6s   $��14(�6�   .��5      � $��0,0,0,0q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   $��Center=�69   $��0,0,0,0q�6T   .+�5      �� $��0q�6   .+�5      �� $��Make:��6   �� 5      -   5        $��	comboMake��5      $��90��6,    � ToolTip$ Select car manufacturer��67   5      �� 5      $��0q�6   .+�5      �� $��Model:��6   �� 5      -   5        $��txtModel��5      $��90��6*   $ Enter car model��65   5      �� 5!      $��0q�6   .+�5"      �� $��Colour:��6   �� 5#      -   5        $��	txtColour��5#      $��90��6+   $ Enter car colour��66   5$      �� 5&      $��0q�6   .+�5'      �� $��Year:��6   �� 5(      -   5        $��	comboYear��5(      $��90��6,   $  Select year of manufacture��67   5)      �� 5+      $��0q�6   .+�5,      �� $��Price:��6   �� 5-      -   5        $��txtPrice��5-      $��90��6*   $ Enter car price��65   5.      �� 50      $��0q�6   .+�51      �� -   5        $��	NewStatus��51      $	��New��6,   $ Check if the car is new��6:   52      53      &   System.Windows.Controls.DataGrid  56   
   -   5        $��dataGridCars��56      $��1��6'      AutoGenerateColumns$ False��64   $��0,5,0,19q�6P      Columns 57      4  .System.Windows.Controls.DataGridCheckBoxColumn  58      ,  &System.Windows.Controls.DataGridColumn	   Header$		 New��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	NewStatus+6T   0  *System.Windows.Controls.DataGridTextColumn  59      $	 ID��6%   $
 50 6Z    61   �� *IdentificationNumber+6Z     5:      $
	 Make��6%   $
 50 6L    63   �� *Make+6L     5;      $	 Model��6%   $
 50 6N    64   �� *Model+6N     5<      $
	 Year��6%   $
 50 6L    63   �� *Year+6L     5=      $	 Price��6%   $
 50 6N    64   �� *Price+6N   5?      �� 5B   
   -   5        $��
lblMessage��5B      $��2��6"   $��Center=�6/   �� 5E   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5F      �� -	   5        $��btnEnter��5F      $��Enter��6%   $��75��65   $��10q�6W   �� 5G      -
   5        $��btnReset��5G      $��Reset��6%   $��75��65   $��10q�6W   �� 5H      -   5        $��btnExit��5H      $
��Exit��6$   $��75��63   $��10q�6T   5I      5J      5K      