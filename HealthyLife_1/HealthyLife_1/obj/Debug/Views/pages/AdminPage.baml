   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HealthyLife_1.Views.pagesHealthyLife_1.Views.pages  5      M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5      c6clr-namespace:HealthyLife_1.CustomControls.Application(HealthyLife_1.CustomControls.Application  5	      c6clr-namespace:HealthyLife_1.CustomControls.Application(HealthyLife_1.CustomControls.Application  5   
   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6N   )    #HealthyLife_1.Views.pages.AdminPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:HealthyLife_1.Views.pages     5      A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5      Jcontrol6clr-namespace:HealthyLife_1.CustomControls.Application     5	      Gelem6clr-namespace:HealthyLife_1.CustomControls.Application     5   
   9system&clr-namespace:System;assembly=mscorlib     6N     N� Title$  	AdminPage��5      $	��793��6   $
��1537��6&    � DataContext 5      -   'HealthyLife_1.ViewModels.Main.MainModel  5   
   .��5      � ���#f0ede6 � RowDefinitions 5   
   �� 5      $
��271* �6   �� 5      $
��468* �6   .+�5   
   �  � Orientation$ 
Horizontal=�6   ��5      �� 5       �� ImageSource$8 2/HealthyLife_1;component/img/Application/fone3.jpg��6   .+�5      ��    AdminInf#��[  6   ._�5      �� .+�5       �� ���#FFBA00$�� 0 20 0 20 q�66     PageBlockText#���  6K   $5��/Редактировать информацию��6s   �� 5"      $	��0.8��6    ���#0C3B2E$
��10 0q�6B   �� 5#        InfText#��[ 6!   $��	О нас��6B    J� InputBindings 5$      d� 5%       d� Gesture$ 	LeftClicka�6+    �� Command 6?   �� *ChangeAboutUs+5'      �� 5(      $	��0.8��6    ���#0C3B2E$
��10 0q�6B   �� 5)      #��[ 6!   $��Водный баланс��6B    5*      d� 5+      $ 	LeftClicka�6+    6?   �� *ChangeWoter+5-      �� 5.      $	��0.8��6    ���#0C3B2E$
��10 0q�6B   �� 5/      #��[ 6!   $
��Quiz��6B    50      d� 51      $ 	LeftClicka�6+    6?   �� *
ChangeQuiz+53      �� 54      $	��0.8��6    ���#0C3B2E$
��10 0q�6B   �� 55      #��[ 6!   $��Показатели��6B    56      d� 57      $ 	LeftClicka�6+    6?   �� *ChangeParam+59      5<      5=      �� 5>      #��[  6   ._�5?      �� .+�5@      �� ���#FFBA00$�� 0 20 0 20 q�66   #���  6K   $5��/Редактировать информацию��6s   �� 5F       �� CornerRadius$ 10��6   $��3��6/   $	��140��6<   $��15,-10,15,0q�6I   ���#45685C._�5G      �� $��0 0 10 0q�6'   .��5H      �� 	 �� 	MaxLength$		 500��6&   $��	10 0 0 0 q�66   
 �� TextWrapping$

 Wrap=�6I    
 Inform#��[ 6^   ��6~   �� *Inform+5I      5J      �� 5K      $��Сохранить��6<   $��0 5 0 0q�6P     MyButtonStyle#���  6a   ��6   �� *	ChangeInf+6�   5L      5M      �� 5N      #��[  6   ._�5O      �� $��	0 -10 0 0q�6   .+�5P      �� ���#FFBA00$�� 0 20 0 20 q�66   #���  6K   $*��$Добавить упражение ��6s   � 5Q      .+�5R      �� $ 10��6!   $��3��63   $	��140��6@   $	��250��6M   $��	15,0,15,0q�6Y   ���#45685C._�5S      �� $��0 0 10 0q�6+   .��5T   "   �� $		 500��6*   $	��120��6:   $	��210��6G   $	��Top=�6S   $��
10 10 0 0 q�6k   $

 Wrap=�6   #��[ 6�   ��6�   �� *
YogaText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6�    5U   &   d� 5V   *   $ 	LeftClicka�67    6K   �� *
NullText+ �� CommandParameter 6i   ��  �� RelativeSource ��  �� AncestorType" N�.��5W   =   5X   #   5Y      5[      �� 5\      $	��140��6%   .+�5]      A� $	��100��6&   ���#cbdb14$��3��6C   $	��100��6X   ��5^   "   �� 5_   &    61   �� *	ImagePath+5a      � 5b      $��0 10 0 0q�6(   $ 
Horizontal=�6:   $��20��6S   $	��150��6_   .+�5c   "   ��  � Cursor$
 Hand��6)   $��/img/LogIn/add.png��67   $��20��6S   $��Right=�6^   $��	22 0 10 0q�6z    5d   &   d� 5e   *   $ 	LeftClicka�67    6K   �� *	AddAvatar+ 6j   ��  �� " N�5g   #   �� 5i   "   $��Добавить img��6,   
�������$��14(�5k      $��Medium"�5l      $��
Montessart)�5m      $
��Wrap=�5n       �� TextAlignment$ Center=�5o      $��Center=�5p   (   5r      5t      5w      �� 5x      $��Сохранить��6;   $��0 5 0 0q�6O   #���  6`   ��6   �� *
SaveYoga+6�   5y      5z      5|      � 5~   
   $��1��6   .+�5�      �� $��0 0 10 0q�6   .��5�      � -   5         �Name$ 	UserBlock��5�      5�      5�      5�      5�      5�      