   M S B A M L   `   `   `  ����Q  MTicTacToe_Sartaj_Singh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TicTacToe_Sartaj_SinghTicTacToe_Sartaj_Singh  5   	   '    !TicTacToe_Sartaj_Singh.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:TicTacToe_Sartaj_Singh     5   	     � Title$  Tic Tac Toe��5   	   $	��450��6   $	��423��6*    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��	20,10,0,0q�6a   .+�5      �� $��X Player��6   $��60��6'   �� 5      -   5        $��PlayerXName��5      $	��100��6)   $��5,0,20,0q�65    � ToolTip$ Enter Player X name��6G   �� 5      $��O Player��6   $��60��6'   �� 5      -   5        $��PlayerOName��5      $	��100��6)   $ Enter Player O name��65   5      �� 5   
   $ 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��	20,50,0,0q�6a   .+�5      �� -   5        $ ��ChooseStartingPlayerButton��5      $��Choose Starting Player��67   $	��150��6X   $��0,0,20,0q�6d   $  Choose who starts the game��6v   6�   �� 5      $��Current Player��6   �� 5      -   5        $��CurrentPlayerLabel��5      $��X��6.   $
��Bold"�6:   $��30��6L   $��Center=�6W   5      � 5   
   $
��Left=�6   $	��Top=�6*   $	��250��6B   $	��250��6N   $��
20,120,0,0q�6[    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6     � ColumnDefinitions 5!      �� 5"      $��* �6#   �� 5#      $��* �6#   �� 5$      $��* �6#   .+�5(      �� -   5        $
��Btn1��5(      $��0��6!   $��0��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   �� 5)      -   5        $
��Btn2��5)      $��0��6!   $��1��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   �� 5*      -   5        $
��Btn3��5*      $��0��6!   $��2��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   �� 5,      -   5        $
��Btn4��5,      $��1��6!   $��0��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   �� 5-      -	   5        $
��Btn5��5-      $��1��6!   $��1��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   �� 5.      -
   5        $
��Btn6��5.      $��1��6!   $��2��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   �� 50      -   5        $
��Btn7��50      $��2��6!   $��0��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   �� 51      -   5        $
��Btn8��51      $��2��6!   $��1��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   �� 52      -   5        $
��Btn9��52      $��2��6!   $��2��6.   $��24(�6>   ���	#FFB9B7B7$ Click to play��6c   6{   54      �� 57   
   $ Vertical=�6   $��Right=�6,   $	��Top=�6H   $��
0,120,20,0q�6`   .+�58      �� $��Score��6   $
��Bold"�6$   �� 59      $ 
Horizontal=�6   .+�5:      �� $��X��6   $��20��6$   �� 5;      -   5        $��XScoreLabel��5;      $��0��6+   $��30��67   $��Center=�6B   5<      �� 5=      $ 
Horizontal=�6   .+�5>      �� $��O��6   $��20��6$   �� 5?      -   5        $��OScoreLabel��5?      $��0��6+   $��30��67   $��Center=�6B   5@      �� 5A      $ 
Horizontal=�6   .+�5B      �� $
��Cats��6   $��40��6'   �� 5C      -   5        $��CatsScoreLabel��5C      $��0��6.   $��30��6:   $��Center=�6E   5D      5E      �� 5H   
   $ Vertical=�6   $��Right=�6,   $��Bottom=�6H   $��	0,0,20,20q�6c   .+�5I      �� -   5         ��Name$ ResetButton��5I      $��Reset��6*   $	��100��6:   $��30��6F   $��0,0,0,10q�6R   $ Reset the game��6d   6}   �� 5J      -   5        $ 
ExitButton��5J      $
��Exit��6)   $	��100��68   $��30��6D   $ Exit the application��6P   6o   5K      5L      5M      