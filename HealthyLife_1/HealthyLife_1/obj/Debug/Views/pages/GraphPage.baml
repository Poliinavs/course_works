   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HealthyLife_1.Views.pagesHealthyLife_1.Views.pages  5      Y1clr-namespace:HealthyLife_1.CustomControls.Params#HealthyLife_1.CustomControls.Params  5   
   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   O,clr-namespace:HealthyLife_1.ViewModels.GrapfHealthyLife_1.ViewModels.Grapf  5
      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6F   )    #HealthyLife_1.Views.pages.GraphPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:HealthyLife_1.Views.pages     5      Bgrap1clr-namespace:HealthyLife_1.CustomControls.Params     5   
   DWpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   B	viewModel,clr-namespace:HealthyLife_1.ViewModels.Grapf     5
      9system&clr-namespace:System;assembly=mscorlib     6F   -   5          N� Title$  	GraphPage��5       � DataContext 5      /   )HealthyLife_1.ViewModels.Grapf.GrapfModel  5   
   .��5      � ���#f0ede6.+�5   
   �  � Orientation$ 
Horizontal=�6   .+�5      3   -HealthyLife_1.CustomControls.Params.GraphUser  -   5          Name$ Graph��5      $
��Left=�6,   $��20 10 10 10q�6G   $	��700��6\   $	��740��6h   $��Bottom=�6u   $��2,2,2,0q�6�   �� 5      $	��450��6   $	��250��6!    � Cursor$ Arrow��6.      	CanvasSt1#���   6>   ._�5      �� -   5         ��Name$ Pokazat��5      .+�5      � $��	0 10 0 10q�6!   $	��440��64   .+�5      ��   	GrapgText#��[ 6%   $8��2Выберете график показателя��6J   5      �� 5      	 �� X1$ 0��6   	 �� Y1$ 0��6"   	 �� X2$	 800��6)   		 �� Y2$	 0��62   
���   �$��2��6H   
 �� StrokeDashArray
 5      S� X�5   "   4Q�63   X�5   "   4Q�63   5      5!      �� 5#      -   5         ��Name$ Sugar��5#   $   $
 Hand��63   ���#FFBA00  
GrapgText1#���  6V   $��
Сахар��6}    J� InputBindings 5$      d� 5%       d� Gesture$ 	LeftClicka�6+    �� Command 6?   �� *
AddSugar+ �� CommandParameter 6]   ��  �� RelativeSource ��  �� AncestorType" N�5'      �� 5)      $ 0��6   $ 0��6"   $	 800��6)   $	 0��62   
���   �$��2��6H   
 5+      S� X�5-   "   4Q�63   X�5.   "   4Q�63   5/      51      �� 53      -   5        $ Pressure��53       $
 Hand��62   #���  6@   $��Давление��6g    54      d� 55      $ 	LeftClicka�6+    6?   �� *AddPressure+ 6`   ��  �� " N�57      �� 5:      $ 0��6   $ 0��6"   $	 800��6)   $	 0��62   
���   �$��2��6H   
 5<      S� X�5>   "   4Q�63   X�5?   "   4Q�63   5@      5B      �� 5D      -   5        $ Weight��5D       $
 Hand��60   #���  6>   $��Вес��6e    5E      d� 5F      $ 	LeftClicka�6+    6?   �� *	AddWeight+ 6^   ��  �� " N�5H      �� 5V      5c      5i      5k      5l      5y      5|      