   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HealthyLife_1.Views.MainAppHealthyLife_1.Views.MainApp  5   	   M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5      ,    &HealthyLife_1.Views.MainApp.Meditation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HealthyLife_1.Views.MainApp     5   	   A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5        � Title$  
Meditation��5	   	   $	��450��6   $	��400��6)    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � Topmost .  � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      -   'HealthyLife_1.ViewModels.Main.YogaModel  5   
   .��5      � ���#0C3B2E � RowDefinitions 5   
   �� 5      $	��56* �6   �� 5      $	��40* �6   �� 5      $
��179* �6   �� 5      $
��128* �6   �� 5      $	��47* �6   .+�5   
   ��  � Cursor$
 Hand��6   $��Center=�6   $��/Img/Application/back.png��6:   $��39��6]   $
��Left=�6h   $��10,0,0,0q�6�    J� InputBindings 5      d� 5      	 d� Gesture$	 	LeftClicka�6   
 �� Command
 63   �� *Exit+ �� CommandParameter 6L   ��  �� RelativeSource ��  �� AncestorType" �5      �� 5    
   $��Йога��6   $��Center=�6!   $��Center=�5!      ���#f0ede6$��30(�5#      $��SemiBold"�5$      $��verdana)�5%      � 5&   
   $��50��6   $��Center=�6   $��1��6<   .+�5'      �� ���#FFBA00   
YogaNumber#���   6.   ��6S   �� *
Position+�� 5(      #��[  6   $��/��6=   �� 5)      #��[  6   ��6=   �� *Amount+5*      �� 5+   
   ���#f0ede6 �� CornerRadius$ 30��6&   $��2��68   $��	50,0,50,0q�6E   ._�5,      �� $	��400��6   ��6#   �� *Path+5-      �� 5.   
   $ 30��6   $��3��6#   $��
10,10,10,0q�60   ���#45685C._�5/      �� $��0 0 10 0q�6   .��50      �� $	��10 q�6   $
��Wrap=�6)     YogaText#��[ 6>   ��6`   �� *Text+51      52      �� 53   
   $
 Hand��6   $��4��6    $��/Img/Main/left_arrow.png��6-   $��70��6O   $
��Left=�6Z   $��Center=�6u   $��10,0,0,0q�6�    54      d� 55      $	 	LeftClicka�6   
 63   �� *Left+ 6L   ��  �� " �57      �� 5<   
   $
 Hand��6   $��4��6   $��/Img/Main/right_arrow.png��6,   $��70��6O   $��Right=�6Z   $��Center=�6w   $��0,0,10,0q�6�    5=      d� 5>      $	 	LeftClicka�6   
 63   �� *Right+ 6M   ��  �� " �5@      5C      5D      