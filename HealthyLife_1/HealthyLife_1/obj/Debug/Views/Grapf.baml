   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HealthyLife_1.ViewsHealthyLife_1.Views  5   	   c6clr-namespace:HealthyLife_1.CustomControls.Application(HealthyLife_1.CustomControls.Application  5   	   O,clr-namespace:HealthyLife_1.ViewModels.GrapfHealthyLife_1.ViewModels.Grapf  5   
   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	   	       HealthyLife_1.Views.Grapf   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:HealthyLife_1.Views     5   	   Gelem6clr-namespace:HealthyLife_1.CustomControls.Application     5   	   B	viewModel,clr-namespace:HealthyLife_1.ViewModels.Grapf     5   
   DWpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5	   	   -   5          � Title$  Grapf��5   	    � WindowStyle$
 None=�6    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��900��5   
    � WindowState$ 	Maximized=�6    � DataContext 5      /   )HealthyLife_1.ViewModels.Grapf.GrapfModel  5   
   .��5!      �  � RowDefinitions 5"   
   �� 5#      $	��79* �6   �� 5$      $
��727* �6   �� 5%      $	��79* �6   .+�5(   
   #  LiveCharts.Wpf.CartesianChart  -   5          Name$ 
GrapgSugar��5(      $
��Left=�62   $��20 10 10 10q�6M   $��1��6c   $	��800��6p   $	��400��6|   $��Bottom=�6�   $��2,2,2,0q�6�   ��5)      �� 5*       �� 
StartPoint$	 0,0&�6&   	 �� EndPoint$		 1,1&�67   .��5+      � 
 � Color$
 White��6#    � Offset$ 0Q�61   � 5,      $
 	LightGray��6#   $ 1Q�65   5-      &   LiveCharts.Wpf.Charts.Base.Chart   Series 50        LiveCharts.Wpf.LineSeries    LiveCharts.Wpf.Series   Title$
 Data��6!      Stroke
 ��  �   StrokeThickness$ 2Q�6<      Values 51   !   �� *Data+53      5   /HealthyLife_1.CustomControls.Application.footer  5<   
   $��2��6   5   /HealthyLife_1.CustomControls.Application.header  5=   
   5C      5D      