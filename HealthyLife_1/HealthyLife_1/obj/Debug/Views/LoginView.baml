   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:HealthyLife_1.ViewsHealthyLife_1.Views  5   	   O,clr-namespace:HealthyLife_1.ViewModels.LogInHealthyLife_1.ViewModels.LogIn  5   	   K*clr-namespace:HealthyLife_1.CustomControlsHealthyLife_1.CustomControls  5   	   #    HealthyLife_1.Views.LoginView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:HealthyLife_1.Views     5   	   B	viewModel,clr-namespace:HealthyLife_1.ViewModels.LogIn     5   	   =custom*clr-namespace:HealthyLife_1.CustomControls     5   	   -   5          � Title$  	LoginView��5
   	   $	��550��6   $	��800��6(    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency .  � DataContext 5      3   -HealthyLife_1.ViewModels.LogIn.LoginViewModel  5   
    � 	Resources 5         BooleanToVisible��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5      �� 
 �� CornerRadius$
 12��6   ��5   
   �� 5        �� ImageSource$ /img/LogIn/Back.jpg��6   ._�5"   
   �� $
 12��6   $��5q�6#    J� Opacity$	 0.8Q�67   ��5$   
   �� 5%       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5&      �  � Color$ #858039��6    � Offset$ 0Q�6.   � 5'      $ #5d9c43��6   $
 0.75Q�6/   � 5(      $ #a8bd55��6   $ 1Q�6/   5*      ��5,   
   �� 5-      $	 0,1&�6"   $	 1,1&�63   .��5.      � $ #19301a��6   $ 0Q�6/   � 5/      $ #33591d��6   $
 0.75Q�6/   � 50      $ #597014��6   $ 1Q�6/   52      ._�55      �  � RowDefinitions 56      �� 57      $��40 �6$   �� 58      .+�5:      �  � ColumnDefinitions 5;      �� 5<      �� 5=      $��25 �6'   �� 5>      $��25 �6+   �� 5?      $��25 �6+   .+�5C      �� $��Registration��6      Log#���  64    J� InputBindings 5D      d� 5E       d� Gesture$ 	LeftClicka�6+    �� Command 6?   �� *
ChangePage+ �� CommandParameter 6_   ��  �� RelativeSource ��  �� AncestorType" �5G      �� 5H      -   5         ��Name$ btnexit��5H      ���#cbdb14$��0q�5J      $��30��5K      $��30��5L      $��X��5M      ���#818a22$��16(�5O      $��Montsaerrart)�5P       � Cursor$
 Hand��5Q      $��2��5R      ��5S      �� *	btnExit+��5T      �� 5U       �� 
TargetType" ��6$   .�5V   "   ��  �� Property � �� �� Value �#cbdb146?    �� Triggers 5W   "   P� 5X   &    P� Property �@J�IsMouseOver  P� Value  . . �5Y   *   ��  � �� �#aeba296G   5Z   '   5\      ��5^      �� 5_      ! �� 
TargetType"! ��6.   .R�5`   "   �� $��18��6)   $��18��64   $
 9��6@   #��z��5a   )   ._�5b   &   �� $��Center=�67   $��Center=�5c   7   5d   #   5f      5i      5l      �� 5m      $	��250��6   $��2��5n      " �� Orientation$" Vertical=�5o      $��0,35,0,0q�5p      .+�5r      �� $��/Img/LogIn/logo.png��6   $	��100��5s      $	��100��5t      �� 5v      $��HealthyLife��6    
�������$��25(�5x      $��Medium"�5y      $��
Montessart)�5z      $��Center=�5{      $ 9Q�5|      �� 5}      $m��gOnly daily work on oneself will help to withstand the blow of fate and prolong a healthy and happy life��6    
�������$��10(�5      $��Medium"�5�      $��
Montessart)�5�      $
��Wrap=�5�      # �� TextAlignment$# Center=�5�      $��
 0,5, 0 ,0q�5�      �� 5�      $��Username��6    
�������$��12(�5�      $��Medium"�5�      $��
Montessart)�5�      $�� 0,35, 0 ,0q�5�      �� 5�      -   5        $ ��Name$$ txtUser��5�   "   $��13(�5�       $��28��5�   "   
�������% �� 	MaxLength$% 20��5�   "   $��Medium"�5�       $��
Montessart)�5�       $��	30 8 0 0 q�5�   $   $��0,5,0,0q�5�   "   
�������$��0,0,0,1q�6J   ��5�   "   �� *
Username+$ TwoWay=�& �� UpdateSourceTrigger$& PropertyChanged=�.��5�      ��5�      �� 5�      $ /img/LogIn/user1.png��6)   ' j� Stretch$' Uniform=�5�   -   ( j� 
AlignmentX$
( Left=�5�   -   5�   #   .��5�   2   5�      �� 5�      ���#bd380b$��12(�5�      $��Medium"�5�      $��
Montessart)�5�      $��
 0,0, 0 ,0q�5�      $
��Wrap=�5�       ��5�       �� *	ErrorUser+5�       �� 5�      $��Password��6    
�������$��12(�5�      $��Medium"�5�      $��
Montessart)�5�      $�� 0,35, 0 ,0q�5�      .   (HealthyLife_1.CustomControls.PasswordBox  5�      $��28��5�      $�� 0 5 0 0q�5�      )   Password) 5�   )   �� *
Password+$ TwoWay=�$& PropertyChanged=�5�      �� 5�      ���#bd380b$��12(�5�      $��Medium"�5�      $��
Montessart)�5�      $�� 0,10, 0 ,0q�5�      $
��Wrap=�5�       ��5�       �� *ErrorMessage+5�       �� 5�      -   5        $ btnreg��5�      ���#cbdb14$��0q�5�      $��Вход��5�      
�������$��16(�5�      $��Montsaerrart)�5�      $
 Hand��5�      $��0 40 0 0q�5�      ��5�      ��  �� " ���5�      �� *LoginCommand+��5�      �� 5�      " ��6$   .�5�   "   ��  � �� �#cbdb146?    5�   "   P� 5�   &    �@J�IsMouseOver  . . �5�   *   ��  � �� �#aeba296G   5�   '   5�      ��5�      �� 5�      "! ��6.   .R�5�   "   �� $	��150��6)   $��40��65   $
 9��6A   #��z��5�   )   ._�5�   &   �� $��Center=�67   $��Center=�5�   7   5�   #   5�      5�      5�      5�      5�      5�      5�      