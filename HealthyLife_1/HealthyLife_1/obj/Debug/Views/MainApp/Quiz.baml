   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HealthyLife_1.Views.MainAppHealthyLife_1.Views.MainApp  5   	   M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5      &     HealthyLife_1.Views.MainApp.Quiz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HealthyLife_1.Views.MainApp     5   	   A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5        � Title$
  Quiz��5	   	   $	��484��6   $	��400��6#    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      -   'HealthyLife_1.ViewModels.Main.QuizModel  5   
    � 	Resources 5         BooleanToVisible  GreenSliderStyle �� 
TargetType �� Property �� Value  SliderThumbTemplate	 �� 
TargetType��%:  &	        &	      &	 �    �� 5   
   6'   �� 5   
   " ��6)   .�5      ��  �@�Minimum$ 1Q�6(   �� 5       �@�Maximum$ 10Q�6(   �� 5       �@�Value$ 5Q�6&   �� 5       � �� �#FFBA006+   �� 5       � ��
 �����6+   �� 5       � ��$ 1q�60   �� 5        � ��$ 30��6'   �� 5!       � ��$	 200��6&   �� 5"       �@��Orientation$ 
Horizontal=�6,   5#      �� 5%      "	 n�6:   .R�5&      A� $��20��6   $��20��6%   
���   �
��� � �$��2��6M   5'      5*      y�5+      �� 5,   
   
 �� Path$
 IsViewVisible�6    �� Mode$ TwoWay=�6'    �� 	Converter# [  65   .��50      � ���#0C3B2E � RowDefinitions 52   
   �� 53      $	��32* �6   �� 54      $
��193* �6   .+�56   
   ��  � Cursor$
 Hand��6   $��Center=�6   $��/Img/Application/back.png��6:   $��39��6]   $
��Left=�6h   $��10,0,0,0q�6�    J� InputBindings 57      d� 58       d� Gesture$ 	LeftClicka�6    �� Command 63   �� *Exit+ �� CommandParameter 6L   ��  �� RelativeSource ��  �� AncestorType" �5:      �� 5;   
   $��Опрос Дня��6   $��Center=�6%   $��Center=�6@   ���#f0ede6$��30(�5=      $��Medium"�5>      $��verdana)�5?      �� 5@   
   $��1��6   .+�5A      �� ���#f0ede6$��1��6-   $��0 0 0 0q�6:   $��Center=�6K   $��19(�6�   ��6h   �� *currentDate+6�   �� 5B      ���#f0ede6$��1��6-   $��0 0 0 0q�6:   $��Center=�6K   $��19(�6�   ��6h   �� *currentTime+6�   �� 5C      $��1��6   $��0 10 0 0q�6%   $��Medium"�68   $��Center=�6L   ���#f0ede6$��23(�6�   ��6i   �� *
TextParm+6�   � 5E      .+�5F      �� ���#f0ede6$��1��61   $��	190 0 0 0q�6>   $��Medium"�6R   $��Center=�6f   $��23(�6�   ��6�   �� *Amount+$ TwoWay=�6�   �� 5G      ���#f0ede6$��1��61   $��0 0 0 0q�6>   $��Medium"�6P   $��Center=�6d   $��/��6�   $��23(�6�   �� 5H      ���#FFBA00$��1��61   $��0 0 0 0q�6>   $��Medium"�6P   $��Center=�6d   $��4��6�   $��23(�6�   5I      �� 5J      ���#f0ede6 �� CornerRadius$ 30��6*   $��2��6<   $��50,10,50,10q�6I   ._�5K      �� $��	0 30 0 30q�60   $��80��6C   ��6   �� *Pass+6C   5L      �� 5M      ���#f0ede6$��0 0 0 10q�6-   $��Medium"�6@   $��14(�6T   $��Center=�6b   ��6   �� *mark+�� 5N      -   5        #��[ 5N   _    � Minimum$ 1Q�6�    � Maximum$ 10Q�6�   $��0 0 0 20q�6�    �� TickPlacement$ BottomRight=�6�    �� TickFrequency$ 1Q�6�    � Value 6   �� *mark+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5P      -   5         ��Name$ btnexit��5P      ���#FFBA00$	��200��5S      $��40��5T      $��0 0 0 10q�5U      $��Center=�5V      $��
Далее��5W      ���#f0ede6$��16(�5Y      $��Montsaerrart)�5Z      $
 Hand��5[      $��2��5\      ��5]      �� *	btnnext+��5^      ��  �� " ���5`      �� 5a      "	 ��6&   .R�5b      �� $	��200��6!   $��40��6-   $ 9��69   #��z��5c   )   ._�5d      �� $��Center=�6/   $��Center=�5e   7   5f      5h      5k      5n      5p      5q      