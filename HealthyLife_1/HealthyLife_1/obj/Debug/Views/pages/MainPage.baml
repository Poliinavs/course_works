   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HealthyLife_1.Views.pagesHealthyLife_1.Views.pages  5      M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5      c6clr-namespace:HealthyLife_1.CustomControls.Application(HealthyLife_1.CustomControls.Application  5
   
   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6N   (    "HealthyLife_1.Views.pages.MainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:HealthyLife_1.Views.pages     5      A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5      Gelem6clr-namespace:HealthyLife_1.CustomControls.Application     5
   
   9system&clr-namespace:System;assembly=mscorlib     6N     N� Title$  MainPage��5       � DataContext 5      -   'HealthyLife_1.ViewModels.Main.MainModel  5   
   .��5      � ���#f0ede6 � RowDefinitions 5   
   �� 5      $
��271* �6   �� 5      $
��468* �6   .+�5   
   �  � Orientation$ 
Horizontal=�6   ��5      �� 5       �� ImageSource$8 2/HealthyLife_1;component/img/Application/fone3.jpg��6   .+�5       ��    CanvasSt#��[  6   ._�5!      �� .+�5"      �� $1��+/HealthyLife_1;component/Img/Main/woter.jpg��6     PageBlockImg#��[ 6Q    J� InputBindings 5#      d� 5$       d� Gesture$ 	LeftClicka�6+    �� Command 6?   �� *
AddWoter+5&      �� 5'        PageBlockText#��[ 6!   $��Водный баланс��6H   5(      5)      �� 5*      #��[  6   ._�5+      �� .+�5,      �� $9��3/HealthyLife_1;component/Img/Main/Elem/calories.png��6   #��[ 6Y    5-      d� 5.      $ 	LeftClicka�6+    6?   �� *	AddCalcul+50      �� 51      #��[ 6!   $%��Калькулятор Ккал��6H   52      53      �� 54      #��[  6   ._�55      �� .+�56      �� $;��5/HealthyLife_1;component/Img/Main/Elem/meditation.png��6   #��[ 6[    57      d� 58      $ 	LeftClicka�6+    6?   �� *	AddYoga+5:      �� 5;      #��[ 6!   $��Медитации��6H   5<      5=      �� 5>      #��[  6   ._�5?      �� .+�5@      �� $9��3/HealthyLife_1;component/Img/Main/Elem/calendar.png��6   #��[ 6Y    5A      d� 5B      $ 	LeftClicka�6+    6?   �� *AddCalendar+5D      �� 5E      #��[ 6!   $��Календарь��6H   5F      5G      5H      � 5I   
   $��1��6    5J      �� 5K      $��3* �6    �� 5L      $	��10* �6     � ColumnDefinitions 5N      �� 5O      �� 5P      .+�5S      �� #���  6   $��Center=�6A   $��45(�6\   $
��Bold"�6j   $��Заметки��6|   �� 5T      	 � Cursor$
	 Hand��6   $/��)/HealthyLife_1;component/Img/Main/Add.png��6#   $��70��6V   $��Right=�6a   $��0 0 40 0q�6}    5U      d� 5V      $ 	LeftClicka�6#    67   �� *	AddNote+
 �� CommandParameter
 6T   ��  �� RelativeSource ��  �� AncestorType" N�5X      �� 5Y      $��1��6   #���  6(   $��Center=�6P   $��45(�6k   $
��Bold"�6y   $��Опрос дня��6�   �� 5Z      $
	 Hand��6   $��1��6#   $��/Img/Main/Add.png��63   $��70��6N   $��Right=�6Y   $��0 0 40 0q�6u    5[      d� 5\      $ 	LeftClicka�6#    67   �� *	AddQuiz+
 6T   ��  �� " N�5^      �� 5e      $��1��6   .��5f      �� -   5         ��Name$ 	StackNote��5f      5h      5i      � 5m      $ 
Horizontal=�6   $��1��62   $��1��6?   .+�5n      �� $
	 Hand��6   $��1��6'   $��1��67   $6��0/HealthyLife_1;component/Img/Main/left_arrow.png��6D   $��70��6~   $	��Top=�6�   $
��Left=�6�   $��10 0 0 0q�6�    5o      d� 5p      $ 	LeftClicka�6'    6;   �� *
LeftQuiz+
 6Y   ��  �� " N�5r      7   1HealthyLife_1.CustomControls.Application.QuizUser  5s      -   5          Name$ QuizUser��5s       $��0 0 0 0q�62   �� 5t      $
	 Hand��6   $��1��6&   $��1��66   $7��1/HealthyLife_1;component/Img/Main/right_arrow.png��6C   $��70��6~   $	��Top=�6�   $��Right=�6�   $��0 0 10 0q�6�    5u      d� 5v      $ 	LeftClicka�6'    6;   �� *	RightQuiz+
 6Z   ��  �� " N�5x      5y      5�      5�      5�      