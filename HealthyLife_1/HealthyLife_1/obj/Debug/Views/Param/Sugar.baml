   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HealthyLife_1.Views.ParamHealthyLife_1.Views.Param  5   	   _4clr-namespace:HealthyLife_1.ViewModels.Param.Pokazat&HealthyLife_1.ViewModels.Param.Pokazat  5      %    HealthyLife_1.Views.Param.Sugar   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:HealthyLife_1.Views.Param     5   	   J	viewModel4clr-namespace:HealthyLife_1.ViewModels.Param.Pokazat     5      -   5          � Title$  Sugar��5
   	   $	��450��6   $	��400��6$    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      7   1HealthyLife_1.ViewModels.Param.Pokazat.ShugarView  5   
   .��5      � ���#0C3B2E � RowDefinitions 5   
   �� 5      $	��56* �6   �� 5      $
��205* �6   �� 5      $
��119* �6   �� 5      $	��70* �6   .+�5   
   ��  � Cursor$
 Hand��6   $��Center=�6   $��/Img/Application/back.png��6:   $��39��6]   $
��Left=�6h   $��10,0,0,0q�6�   $��40��6�    J� InputBindings 5      d� 5       d� Gesture$ 	LeftClicka�6   	 �� Command	 63   �� *Exit+
 �� CommandParameter
 6L   ��  �� RelativeSource ��  �� AncestorType" �5      �� 5   
   $��
Сахар��6   $��Center=�6!   $��Center=�6<   ���#f0ede6$��30(�5!      $��Medium"�5"      $��verdana)�5#      $��36��61   $��94��6=   �� 5$   
   $��1��6   $��	40,0,0,23q�6!   $
��Left=�64   ���#f0ede6$��19(�6�   $	��150��6�   ��6O   �� *currentDate+6�   �� 5%   
   $��1��6   $��
310,0,0,23q�6!   $
��Left=�65   ���#f0ede6$��19(�6�   $��50��6�   ��6P   �� *currentTime+6�   �� 5&   
   ���#f0ede6 �� CornerRadius$ 30��6&   $��1��68   $��50,38,50,17q�6E   ._�5'      �� $	��400��6   $	��150��6"   $��/Img/Main/Param/sugar.png��61   5(      �� 5*   
   $��2��6   .+�5+      �  � Orientation$ 
Horizontal=�6   .+�5,      �� $+��%Значение показателя��6   ���#f0ede6$��20 0 0 0q�5.      $��19(�5/      $��Medium"�50      $��
Montessart)�51      �� 53      $��ммоль/л��6   ���#f0ede6$��90 0 0 0q�55      $��19(�56      $��Medium"�57      $��
Montessart)�58      5:      �� 5=      -   5         ��Name$ txtUser��5=      $��20(�5>       $��	0 10 0 20q�5?      $��Medium"�5@       $��
Montessart)�5A        �� 	MaxLength$ 10��5B      $��30��5D   "   $	��360��5E   %   ���#f0ede6$��0,0,0,2q�5F   8   ��5C   "   �� *AmountPokazat+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5F   8   �� 5H      $��2��6   $
��Left=�6&   $��23 0 0 0q�6A   $	��200��6S    �� SelectedIndex 6`   �� *	Condition+ � 	Resources 5J       �� 
TargetType �� Property �� Value��%�   '��       �� 5K      " ��6   .�5L      ��  � ��$ 16(�65   �� 5M       � ��
 �   �67   �� 5N       � ��
 �����67   �� 5O       � ��
 �����68   �� 5P       � ��$ 1q�6<   5R      5S      .@�5T      �� $��До обеда��6   �� 5U      $��После обеда��6   5V      5W      �� 5X   
   $��3��6   .+�5Y      �� ���#bd380b$��12(�5[      $��Medium"�5\      $��
Montessart)�5]      $�� 20,0, 0 ,0q�5^      $
��Wrap=�5_       ��5Y      �� *ErorPokazat+5_       �� 5a      -   5         ��Name$ btnexit��5a      ���#FFBA00$	��200��5d      $��Bottom=�5e      $��Center=�5g      $��Добавить��5h      ���#0C3B2E$��16(�5j      $��Montsaerrart)�5k      $
 Hand��5l      $��0,9,0,9q�5n   �   ��6   �� *ADDParamSugar+��65   ��  �� " ���5p      �� 5q       �� 
TargetType" ��6&   .R�5r      �� $	��200��6!   $��40��6-   $ 9��69   #��z��5s   )   ._�5t      �� $��Center=�6/   $��Center=�5u   7   5v      5x      5{      5}      5      5�      