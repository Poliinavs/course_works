   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HealthyLife_1.Views.MainAppHealthyLife_1.Views.MainApp  5   	   M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5   	   c6clr-namespace:HealthyLife_1.CustomControls.Application(HealthyLife_1.CustomControls.Application  5   
   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6N   *    $HealthyLife_1.Views.MainApp.Calendar   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HealthyLife_1.Views.MainApp     5   	   A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5   	   Gelem6clr-namespace:HealthyLife_1.CustomControls.Application     5   
   9system&clr-namespace:System;assembly=mscorlib     6N     � WindowStyle$
  None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Calendar��5   	   $	��900��6    � WindowState$ 	Maximized=�6(   .��5      �  � RowDefinitions 5   
   �� 5      $	��79* �6   �� 5      $
��727* �6   �� 5      $	��79* �6   .+�5   
   � $��1��6   $��0��6   .+�5      �  � ColumnDefinitions 5      �� 5      $
��1.2* �6#   �� 5      $��* �6#   .+�5      ��  �� CornerRadius$ 	0 20 20 0��6   ���#f0ede66.   �� 5      $��1��6   ���#0C3B2E6%   � 5       .+�5%      �� .+�5&      ��  �� Orientation$ 
Horizontal=�6!   $	��Top=�6:   $��Center=�6R   $��	0 50 0 30q�6o   .+�5'      �� $
��2020��6!      NumberCalendar#��[  60   �� 5(      $
��2021��6!   #��[  60   �� 5)      $
��2022��6!   #��[  60   �� 5*      $
��2023��6%   #��[  64   ���#FFBA006\   5,      �� 5.      $ 
Horizontal=�6!   $��Center=�6;   .+�5/      �� $��1��6!     buttonMonth#��[ 6-   �� 50      $��2��6!   #��[ 6-   �� 51      $��3��6!   #��[ 6-   �� 52      $��4��6$   #��[ 60   �� 53      $��5��6%   #��[ 61   ���#FFBA006V   �� 54      $��6��6!   #��[ 6-   �� 55      $��7��6!   #��[ 6-   �� 56      $��8��6!   #��[ 6-   �� 57      $��9��6!   #��[ 6-   �� 58      $��11��6!   #��[ 6.   �� 59      $��12��6!   #��[ 6.   5:      �� 5;      $	��0.8��6$   ���#0C3B2E$��30 10q�6F   �� 5<      $��Апрель��6$   ���#0C3B2E$��24(�6H   	 �� TextAlignment$	 Center=�6V   $��SemiBold"�6m   $��	0 15 0 20q�6�   &   System.Windows.Controls.Calendar  5>        CalendarStyle1#���  6#    # CalendarCalendarDayButtonStyle1
   CalendarDayButtonStyle#
 �  6L   5A      5D      �� 5E      $��1��6   .+�5F      �� $��20 35 30 10q�6!   $ 
Horizontal=�66   $��Center=�6O   .+�5G      �� $��16��6$   $��80(�6.   ���#f0ede66<   �� 5H      $��10 0 0 0q�6%   .+�5I      �� $��Апрель��6(   ���#f0ede6$��45(�6K   �� 5J      $��Понедельник��6(   ���#91b396$��25(�6P   5K      5O      �� 5Q      $ 10��6   $��Center=�6/   $	��355��6L   $��	0 30 0 20q�6X   ���#45685C._�5R      �  5S      �� 5T   "   $
��auto �63   �� 5U   "   $��* �63   .+�5W      � .+�5X   "   �� $��40��6)   $��1��66   $��/Img/Calendar/note.png��6C   �� 5Y   "     
TextCalend#��[ 6,   $��Note: ��6P   5Z      5_      5a      5e      5i      5p      5   /HealthyLife_1.CustomControls.Application.footer  5z   
   $��2��6   5   /HealthyLife_1.CustomControls.Application.header  5{   
   5}      5~      