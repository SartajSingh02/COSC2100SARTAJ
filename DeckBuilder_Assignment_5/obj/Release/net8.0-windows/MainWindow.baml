   M S B A M L   `   `   `  ����   DeckBuilder    DeckBuilder.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Deck Builder��$	��500��$	��700�� � WindowStartupLocation$ CenterScreen=�.��]� .+�o� $	��Top=�.@�m� $��_File��.@�m� -   $��	Save Deck��m� -   $��	Load Deck��m� -   $��Export to XML��m� -   $��Export to JSON��m� $��_Edit��.@�m� -   $��	Clear All��m� $��_Help��.@�m� -   $
��Help��m� -   $��About��� $��10q�.+��� $
��Left=�$	��Top=�$	��200��.+��� $��Add Custom Card��$
��Bold"�$��0,0,0,5q���  �� Orientation$ 
Horizontal=�$��0,5,0,10q�.+��� $��Suit:��$��Center=�$��0,0,5,0q��� -   $��SuitTextBox��$	��100�� � ToolTip$&  Enter the suit for a custom card���� $ 
Horizontal=�$��0,5,0,10q�.+��� $��Rank:��$��Center=�$��0,0,5,0q��� -	   $��RankTextBox��$	��100��$&  Enter the rank for a custom card���� -
   $��Add Custom Card��$	��150��$��0,0,0,10q��� $��
Deal Cards��$
��Bold"�$��0,10,0,5q��� $ 
Horizontal=�$��0,5,0,10q�.+��� $��Draw:��$��Center=�$��0,0,5,0q��� -   $��DrawTextBox��$��50��$��0,0,5,0q�$' !Enter the number of cards to draw���� -   $
��Deal��$��50���� $��Cards Dealt��$
��Bold"�$��0,10,0,5q��� -   $��DealtCardsListBox��$	��150��$	��100���� $��Center=�$	��Top=�$	��200��.+��� $
��Deck��$
��Bold"�$��Center=�$��0,0,0,5q��� -   $��DeckListView��$	��180��$	��250��$��Center=�$( "Displays the current deck of cards�� � ContextMenu �� .@�m� -   $��	Save Deck��m� -   $��	Load Deck��m� -   $��	Clear All���� $��Right=�$	��Top=�$	��200��.+��� $��Deck Controls��$
��Bold"�$��0,10,0,5q��� -   $��
_View Deck��$	��150��$��0,0,0,10q��� -   $��_Shuffle��$	��150��$��0,0,0,10q�$2 ,Shuffles the deck and displays the new order���� -   $��_Reset��$	��150��$��0,0,0,10q�$+ %Resets the deck to its original state�� �� 	IsDefault$
 True�� J� InputBindings �� 
 �� Key$ Escape�� �� Command �� *ResetCommand+�� -   $��E_xit��$	��150��$��0,0,0,10q�$B <Closes the application and optionally resets unsaved changes�� �� $ Escape�� �� *ExitCommand+�� $ 
Horizontal=�$��0,5,0,10q�.+��� $��Joker Color:��$��Center=�$��0,0,5,0q��� -   $��JokerColorTextBox��$	��100��$&  Enter the color for a Joker card���� -   $��	Add Joker��$	��150��$��0,0,0,10q��� $ 
Horizontal=�$��0,5,0,10q�.+��� $��
Wild Card:��$��Center=�$��0,0,5,0q��� -   $��WildAbilityTextBox��$	��100��$/ )Enter the special ability for a Wild card���� -   $��Add Wild Card��$	��150��$��0,0,0,10q�