   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HealthyLife_1.Views.pagesHealthyLife_1.Views.pages  5      M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5      ,    &HealthyLife_1.Views.pages.CalendarPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:HealthyLife_1.Views.pages     5      A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5        N� Title$  CalendarPage��5	       � DataContext 5      2   ,HealthyLife_1.ViewModels.Main.CalendarMaodel  5   
   .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��1.2* �6#   �� 5      $��* �6#   .+�5      ��  �� CornerRadius$ 	0 20 20 0��6   ���#f0ede66.   �� 5      $��1��6   ���#0C3B2E6%   � 5      .+�5      �� .+�5       ��  �� Orientation$ 
Horizontal=�6!   $	��Top=�6:   $��Center=�6R   $��	0 50 0 30q�6o   .+�5!      �� $
��2020��6!      NumberCalendar#��[  60   �� 5"      $
��2021��6!   #��[  60   �� 5#      $
��2022��6!   #��[  60   �� 5$      $
��2023��6!   #��[  60   ���#FFBA006X   5&      �� 5(      $ 
Horizontal=�6!   $��Center=�6;   .+�5)      �� $��1��6!     buttonMonth#��[ 6-   �� 5*      $��2��6!   #��[ 6-   �� 5+      $��3��6!   #��[ 6-   �� 5,      $��4��6!   #��[ 6-   �� 5-      $��5��6!   #��[ 6-   ���#FFBA006R   �� 5.      $��6��6!   #��[ 6-   �� 5/      $��7��6!   #��[ 6-   �� 50      $��8��6!   #��[ 6-   �� 51      $��9��6!   #��[ 6-   �� 52      $��11��6!   #��[ 6.   �� 53      $��12��6!   #��[ 6.   54      �� 55      $	��0.8��6    ���#0C3B2E$��30 10q�6B   �� 56      $��Май��6    ���#0C3B2E$��24(�6A    �� TextAlignment$ Center=�6O   $��SemiBold"�6f   $��	0 15 0 20q�6|   &   System.Windows.Controls.Calendar  58        CalendarStyle1#���  6E    # CalendarCalendarDayButtonStyle1   CalendarDayButtonStyle# �  6n      SelectedDate 6   �� *SelectedDate+6n   5;      5>      �� 5?      $��1��6   .+�5@      �� $��20 35 30 10q�6   $ 
Horizontal=�62   $��Center=�6K   .+�5A      �� $��80(�65   ���#f0ede6��6    �� *Day+6C   �� 5B      $��10 0 0 0q�6!   .+�5C      �� ���#f0ede6$��45(�6P   ��6$   �� *Month+6P   �� 5D      ���#91b396$��25(�6O   ��6$   �� *Week+6O   5E      5I      �� 5K        CalendarNote#���  6   ._�5M      � .+�5N      �� $��40��6%   $��1��62   $��/Img/Calendar/note.png��6?   �� 5O        
TextCalend#��[ 6(   $��Note: ��6L   �� 5P      #��[ 6$   $!��Наведи на меня ��6H   �� 5Q      $
��Wrap=�6$   #��[ 68   ��6\   �� *Note+5T      5W      �� 5X      $ 10��6   $��Center=�6+   $	��355��6H   $��	0 30 0 20q�6T   ���#45685C._�5Z      �� .+�5\      � $��
10 10 10 0q�6    .+�5]      ��   UserBase#��[ 6%   $��Вес: ��6G   �� 5^        UserText#��[ 6%   ��6G   �� *Weight+5_      �� 5`      $	��0.8��6    ���#f0ede6$
��10 0q�6B   � 5a      $��
10 10 10 0q�6    .+�5b      �� #��[ 6%   $��Давление: ��6G   �� 5c      #��[ 6%   ��6G   �� *
Pressure+5d      �� 5e      $	��0.8��6    ���#f0ede6$
��10 0q�6B   � 5f      $��
10 10 10 0q�6    .+�5g      �� #��[ 6%   $��Сахар: ��6G   �� 5h      #��[ 6%   ��6G   �� *Sugar+5i      �� 5j      $	��0.8��6    ���#f0ede6$
��10 0q�6B   � 5k      $��
10 10 10 0q�6    .+�5l      �� #��[ 6%   $��
Ккал: ��6G   �� 5m      #��[ 6%   ��6G   �� *Kkal+5n      �� 5o      $	��0.8��6    ���#f0ede6$
��10 0q�6B   � 5p      $��
10 10 10 0q�6    .+�5q      �� #��[ 6%   $��
Вода: ��6G   �� 5r      #��[ 6%   ��6G   �� *Woter+5s      5w      5y      5}      5�      5�      5�      