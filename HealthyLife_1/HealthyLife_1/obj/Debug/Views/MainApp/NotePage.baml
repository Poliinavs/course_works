   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HealthyLife_1.Views.MainAppHealthyLife_1.Views.MainApp  5   	   M+clr-namespace:HealthyLife_1.ViewModels.MainHealthyLife_1.ViewModels.Main  5      *    $HealthyLife_1.Views.MainApp.NotePage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HealthyLife_1.Views.MainApp     5   	   A	viewModel+clr-namespace:HealthyLife_1.ViewModels.Main     5        � Title$  NotePage��5   	   $	��484��6   $	��400��6'    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Topmost .  � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      -   'HealthyLife_1.ViewModels.Main.NoteModel  5   
   .��5      � ���#0C3B2E � RowDefinitions 5   
   �� 5      $	��60* �6   �� 5      $
��361* �6   �� 5      $	��63* �6   .+�5   
   ��  � Cursor$
 Hand��6   $��Center=�6   $��/Img/Application/back.png��6:   $��39��6]   $
��Left=�6h   $��10,0,0,0q�6�   $��40��6�    J� InputBindings 5      d� 5      	 d� Gesture$	 	LeftClicka�6   
 �� Command
 63   �� *Exit+ �� CommandParameter 6L   ��  �� RelativeSource ��  �� AncestorType" �5      �� 5   
   $��Заметки��6   $��Center=�6#   $��Center=�6>   ���#f0ede6$��30(�5      $��Medium"�5       $��verdana)�5!      �� 5"   
   $��1��6   .+�5#      �� ���#f0ede6$��1��6-   $��0 0 0 0q�6:   $��Center=�6K   $��19(�6�   ��6h   �� *currentDate+6�   �� 5$      ���#f0ede6$��1��6-   $��0 0 0 0q�6:   $��Center=�6K   $��19(�6�   ��6h   �� *currentTime+6�   �� 5%      ���#f0ede6 �� CornerRadius$ 30��6*   $��2��6<   $��50,10,50,10q�6I   ._�5&      �� �� 5'      $��10 10 10 10q�6    
���   � �� 	MaxLength$	 260��6H    �� TextWrapping$
 Wrap=�6X   $	��270��6m      WwodBox#���   6�   ��6z   �� *
noteText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5(      5)      5*      �� 5+   
   $��3��6   .+�5,      ��  �� TextAlignment$ Center=�6   ���#bd380b$��12(�5.      $��Medium"�5/      $��
Montessart)�50      $�� 20,0, 0 ,0q�51      $
��Wrap=�52       ��5,   /   �� *	ErrorNote+52       �� 53        MyButtonStyle#���  61   $��Добавить��6�   $��3��6�   $	��200��6�   ��6   �� *	AddNote+��6Y   ��  �� " �6�   55      58      59      