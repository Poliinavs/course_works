   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HealthyLife_1.ViewsHealthyLife_1.Views  5   	   M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5      c6clr-namespace:HealthyLife_1.CustomControls.Application(HealthyLife_1.CustomControls.Application  5	   
   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6N   "    HealthyLife_1.Views.MainPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:HealthyLife_1.Views     5   	   A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5      Gelem6clr-namespace:HealthyLife_1.CustomControls.Application     5	   
   9system&clr-namespace:System;assembly=mscorlib     6N     � WindowStyle$
  None=�5   
    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ MainView��5   	   $	��864��6    � WindowState$ 	Maximized=�6(    � DataContext 5      3   -HealthyLife_1.ViewModels.Main.MainModelContex  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $	��37* �6   �� 5      $
��413* �6   .+�5   
   � $��0��6   $��73��6   ���#45685C.+�5       �� $��HealthyLife��6   $��Center=�6+   $��Center=�6F   
�������$��50(�5"      $��Medium"�5#      $��verdana)�5$      �� 5&      $7��1/HealthyLife_1;component/img/Application/home.png��6   $��Uniform=�6P   $��Center=�5'      $
��Left=�5(      $��10 10 10 10q�5)       � Cursor$
 Hand��5*       J� InputBindings 5+      d� 5,      	 d� Gesture$	 	LeftClicka�6#   
 �� Command
 67   �� *
ReturnHome+5.      �� 5/      -   5         ��Name$ btnexit��5/      $��Right=�50      $��0 0 10 0q�51      ���#FFBA00$��0q�53      $��40��54      $��40��55      $��X��56      ���#0C3B2E$��16(�58      $��Montsaerrart)�59      $
 Hand��5:      $��2��5;      ��5<      �� *Exit+��5=      �� 5>       �� 
TargetType" ��6   .�5?      ��  �� Property � �� �� Value �#FFBA0067    �� Triggers 5@      P� 5A       P� Property �@J�IsMouseOver P� Value . . �5B   "   ��  � �� �#0C3B2E6?   5C      5E      ��5G      �� 5H       �� 
TargetType" ��6&   .R�5I      �� $��40��6!   $��40��6,    �� CornerRadius$ 9��68   #��z��5J   )   ._�5K      �� $��Center=�6/   $��Center=�5L   7   5M      5O      5R      5T      �� 5]      $��0,71,0,0q�6   $��2��6)   .+�5^       � -   5          �Name$ Pages��5^      $	��720��6#     � NavigationUIVisibility$ Hidden=�60   $��Stretch=�6Q   $��Stretch=�6o     � Source 5_      �� *Uri+��5`      �� *Page+5b      � 5c      -   5         �Name$ footer��5c      $��73��6#   ���#45685C.+�5d      �  � Orientation$ 
Horizontal=�6   .+�5e      � $
 Hand��6!    
  Footer#���   6/    5f      d� 5g      $	 	LeftClicka�6+   
 6?   �� *Calcul+.+�5i      �� $0��*/HealthyLife_1;component/Img/Main/food.png��6    $��50��6T   �� 5j        PageBlockText#���  6%   
�������$��10 0 0 0q�6a   $��Center=�6s   $��Питание��6�   5k      � 5l      $
 Hand��6!   #���   6/    5m      d� 5n      $	 	LeftClicka�6+   
 6?   �� *	Pokazat+.+�5p      �� $3��-/HealthyLife_1;component/Img/Main/health1.png��6    $��50��6W   �� 5q      #���  6%   
�������$��10 0 0 0q�6a   $��Center=�6s   $��Здоровье��6�   5r      � 5s      $
 Hand��6!   #���   6/    5t      d� 5u      $	 	LeftClicka�6+   
 6?   �� *	statistic+.+�5w      �� $6��0/HealthyLife_1;component/Img/Main/statistics.png��6    $��50��6Z   �� 5x      #���  6%   
�������$��10 0 0 0q�6a   $��Center=�6s   $��Статистика��6�   5y      � 5z      $
 Hand��6!   #���   6/    5{      d� 5|      $	 	LeftClicka�6+   
 6?   �� *Inform+.+�5~      �� $2��,/HealthyLife_1;component/Img/Main/inform.png��6    $��50��6V   �� 5      #���  6%   
�������$��10 0 0 0q�6a   $��Center=�6s   $��Справка��6�   5�      5�      5�      5�      5�      5�      