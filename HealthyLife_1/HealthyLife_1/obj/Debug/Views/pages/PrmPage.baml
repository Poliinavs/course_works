   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HealthyLife_1.Views.pagesHealthyLife_1.Views.pages  5      Y1clr-namespace:HealthyLife_1.CustomControls.Params#HealthyLife_1.CustomControls.Params  5   
   O,clr-namespace:HealthyLife_1.ViewModels.ParamHealthyLife_1.ViewModels.Param  5	   	   '    !HealthyLife_1.Views.pages.PrmPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:HealthyLife_1.Views.pages     5      Dshugar1clr-namespace:HealthyLife_1.CustomControls.Params     5   
   B	viewModel,clr-namespace:HealthyLife_1.ViewModels.Param     5	   	     N� Title$  PrmPage��5       � DataContext 5      ,   &HealthyLife_1.ViewModels.Param.PrmView  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��3* �6   .+�5   
   �  � Orientation$ 
Horizontal=�6   ��5      �� 5       �� ImageSource$8 2/HealthyLife_1;component/img/Application/fone3.jpg��6   .+�5      ��  � Cursor$
 Hand��6   
���  ��   	CanvasSt2#���   67    J� InputBindings 5      d� 5       d� Gesture$ 	LeftClicka�6#    �� Command 67   �� *btnAddSugar+	 �� CommandParameter	 6X   �� 
 �� RelativeSource
 ��  �� AncestorType" N�._�5      �� .+�5      ��   PageBlockText1#��[ 6!   $��Caxaр��6I   �� 5      $7��1/HealthyLife_1;component/Img/Main/Param/sugar.png��6     PageBlockImg#��[ 6W   5       5!      �� 5"      ���#c726a7#���   6,    5#      d� 5$      $ 	LeftClicka�6#    67   �� *ShowPressure+	 6Y   �� 
 �� " N�._�5&      �� .+�5'      �� #���  6!   $��Давление��6J   �� 5(      $:��4/HealthyLife_1;component/Img/Main/Param/pressure.png��6   #���  6Z   $��0 0 0 10q�6�   5)      5*      �� 5,      ���#3d783e#���   6,    5-      d� 5.      $ 	LeftClicka�6#    67   �� *
ShowWeight+	 6W   �� 
 �� " N�._�50      �� .+�51      �� #���  6!   $��Вес��6J   �� 52      $8��2/HealthyLife_1;component/Img/Main/Param/weight.png��6   #���  6X   $��0 0 0 10q�6   53      54      56      � 57   
   -   5         �Name$ Pokazat��57      ���#f0ede6$��2��6<   .+�59      �� $
 Hand��6   $��	140 0 0 0q�6"   $6��0/HealthyLife_1;component/Img/Main/left_arrow.png��65   $��70��6o   $	��Top=�6z   $
��Left=�6�    5:      d� 5;      $ 	LeftClicka�6#    67   �� *
LeftShugar+	 6W   �� 
 �� " N�5=      5   /HealthyLife_1.CustomControls.Params.ShugarParam  5?      -   5          Name$ Param��5?   7   $��-10 -40 0 0q�6"   67   �� 5C      $
 Hand��6   $7��1/HealthyLife_1;component/Img/Main/right_arrow.png��6#   $��70��6^   $	��Top=�6i   $��Center=�6�   $��	130 0 0 0q�6�    5D      d� 5E      $ 	LeftClicka�6#    67   �� *RightShugar+	 6X   �� 
 �� " N�5G      5J      5Q      5R      