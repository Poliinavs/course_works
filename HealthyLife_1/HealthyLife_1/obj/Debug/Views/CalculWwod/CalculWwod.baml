   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HealthyLife_1.Views.CalculWwodHealthyLife_1.Views.CalculWwod  5   	   ]3clr-namespace:HealthyLife_1.ViewModels.CalculFolder%HealthyLife_1.ViewModels.CalculFolder  5	   
   /    )HealthyLife_1.Views.CalculWwod.CalculWwod   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:HealthyLife_1.Views.CalculWwod     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   C	viewModel3clr-namespace:HealthyLife_1.ViewModels.CalculFolder  5	   
     � Topmost  .  � Title$ 
CalculWwod��5   	   $	��420��6   $	��400��6)    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      5   /HealthyLife_1.ViewModels.CalculFolder.MealModel  5   
   .��5      � ���#0C3B2E � RowDefinitions 5   
   �� 5      $	��59* �6   �� 5      $	��49* �6   �� 5      $
��221* �6   �� 5      $	��91* �6   .+�5   
   ��  � Cursor$
 Hand��6   $��Center=�6   $��/Img/Application/back.png��6:   $��39��6]   $
��Left=�6h   $��10,0,0,0q�6�   $��40��6�    J� InputBindings 5      d� 5      	 d� Gesture$	 	LeftClicka�6   
 �� Command
 63   �� *Exit+ �� CommandParameter 6L   ��  �� RelativeSource ��  �� AncestorType" �5!      �� 5#   
   $��Ввод продукта��6   $��Center=�6*   $��Center=�5$      ���#f0ede6$��30(�5&      $��SemiBold"�5'      $��verdana)�5(      $��36��61   $	��254��6=   �� 5*   
   $
��Left=�6+   $��1��5+      $��Center=�5,      ���#f0ede6$��30(�5.      $��10,0,0,0q�5/      $��SemiBold"�50      $��verdana)�51      $��36��61   $	��139��6=   ��5*      �� *Meal+51   =   �� 53   
   $
��Left=�6   $��1��60   ���#FFBA00$��
328,10,0,0q�6R      
YogaNumber#���   6g   $��62��6�   ��6�   �� *Time+6�   �� 56   
   $��3��6   .+�57      �� ���#bd380b$��12(�59      $��Medium"�5:      $��
Montessart)�5;      $�� 20,0, 0 ,0q�5<      $
��Wrap=�5=       ��57      �� *
ErorButton+5=       �� 5>      $��0 12 0 0q�60     MyButtonStyle#���  6B   $��Добавить��6�   $��3��6�   $	��200��6�   ��6   �� *AddRez+��6j   ��  �� " �6�   5@      �� 5B   
    �� CornerRadius$ 30��6   $��2��6#   $��
10,10,10,0q�60   ���#45685C._�5C      �� .+�5D      � $��	10 10 0 0q�6   .+�5E      �� $��Ккал в 1 ��6!     WwodText#���  62   �� 5F      ���#FFBA00$��0 10 0 0q�66   #���  6b   ��6I   �� *	Measure+6b   �� 5G      $��:��6!   $��2 10 0 0q�6*   #���  6=   �� 5H      $	��200��6e    �� 	MaxLength$ 3��6q     WwodBox#���  6   ��6   �� *Kkal+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6   5I      �� 5J       K� ZIndex$ 2��6   $��1��6-   ���#FFBA00$
��20 3q�6M   �� 5K      ���#bd380b$��12(�5M      $��Medium"�5N      $��
Montessart)�5O      $�� 20,0, 0 ,0q�5P      $
��Wrap=�5Q       ��5K      �� *	ErrorKkal+5Q       � 5R      $��	10 10 0 0q�6   .+�5S      �� $��Вес��6!   #��[ 6-   �� 5T      $��(��6!   $��4 10 0 0q�6*   #���  6=   �� 5U      ���#FFBA00$��0 10 0 0q�6O   #���  6b   ��66   �� *	Measure+6b   �� 5V      $��)��6!   $��0 10 0 0q�6*   #���  6<   �� 5W      $ 3��6g   #��[ 6u   ��6   �� *Weight+$ TwoWay=�$ PropertyChanged=�6u   5X      �� 5Y      $ 2��6   $��1��6-   ���#FFBA00$
��20 3q�6M   �� 5Z      ���#bd380b$��12(�5\      $��Medium"�5]      $��
Montessart)�5^      $�� 20,0, 0 ,0q�5_      $
��Wrap=�5`       ��5Z      �� *
ErorWeight+5`       � 5a      $��	10 10 0 0q�6   .+�5b      �� $��Изменить вес:��6!   #��[ 67   	� 5k      -   5         	�Name$ radioButton2��5k   "     MyCheckBoxStyle#��[ 6[   $��Г��6�    	� 	GroupName$ MyRadioGroup��6�   {�69   �� *
NewMeasure+ 5l      d� 5m      $	 	LeftClicka�6+   $ Г��6^   
 6?   �� *
NewMeasure+6^   5o      	� 5q      -   5        $ radioButton3��5q   "   #��[ 68   $
��Кг��6a   $ MyRadioGroup��6n    5r      d� 5s      $	 	LeftClicka�6+   $
 Кг��6^   
 6?   �� *
NewMeasure+6^   5u      	� 5v      -   5        $ radioButton4��5v   $   #��[ 6:   $
��Мл��6c   $ MyRadioGroup��6p    5w      d� 5x      $	 	LeftClicka�6+   $
 Мл��6^   
 6?   �� *
NewMeasure+6^   5z      5|      �� 5}      $ 2��6   $��1��6-   ���#FFBA00$
��20 3q�6M   5~      5�      5�      5�      