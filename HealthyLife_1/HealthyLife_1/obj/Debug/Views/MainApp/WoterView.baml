   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HealthyLife_1.Views.MainAppHealthyLife_1.Views.MainApp  5   	   M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5      W0clr-namespace:HealthyLife_1.CustomControls.Woter"HealthyLife_1.CustomControls.Woter  5   	   +    %HealthyLife_1.Views.MainApp.WoterView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HealthyLife_1.Views.MainApp     5   	   A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5      Bglass0clr-namespace:HealthyLife_1.CustomControls.Woter     5   	   5custom"HealthyLife_1.CustomControls.Woter     5	   
     � Title$  Woter��5   	   $	��250��6   $	��400��6%    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      )   #HealthyLife_1.ViewModels.Main.Woter  5   
   .��5      � ���#0C3B2E � RowDefinitions 5   
   �� 5      $	��34* �6   �� 5      $	��91* �6   .+�5   
   ��  � Cursor$
 Hand��6   $��Center=�6   $��/Img/Application/back.png��6:   $��39��6]   $
��Left=�6h   $��10,0,0,0q�6�    J� InputBindings 5      d� 5       d� Gesture$ 	LeftClicka�6   	 �� Command	 63   �� *Exit+
 �� CommandParameter
 6L   ��  �� RelativeSource ��  �� AncestorType" �5      �� 5    
   .+�5!      �� $��Водный баланс��6   $��Center=�6-   $��Center=�6H   ���#f0ede6$��30(�5#      $��Medium"�5$      $��verdana)�5%      $��36��61   $	��238��6=   �� 5&      $��Center=�65   ���#f0ede6$��15(�5)      $��Medium"�5*      $��verdana)�5+      $��36��61   ��5&      �� *currentDate+5+   1   5,      �� 5-   
   $��1��6   .+�5.      � .+�5/      ��    	WoterText#��[  6   $+��%Текущее количество: ��6?   �� 50      $
��Bold"�6   #���   6.   ��6R   �� *
NowWoter+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 51      #��[  6   $�� мл��6?   �� 52      $��	100 0 0 0q�6   #��[  60   $!��Объем стакана: ��6S   �� 53      $
��Bold"�6   #��[  6/   ��6R   �� *
AmountMl+�� 54      #���   6   $�� мл��6A   55      � 57      -   5         �Name$ 	WoterWrap��57       � Orientation$ 
Horizontal=�6/   .+�59      1   +HealthyLife_1.CustomControls.Woter.WoterCup   J� Opacity$	 0.5Q�6%   5=      5@      5D      5E      