   M S B A M L   `   `   `  ����H  DHealthyLife_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HealthyLife_1HealthyLife_1  5      9!clr-namespace:HealthyLife_1.ViewsHealthyLife_1.Views  5          HealthyLife_1.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -localclr-namespace:HealthyLife_1     5      3start!clr-namespace:HealthyLife_1.Views     5        �� 	Resources  5       �� MergedDictionaries �� Source �� 
TargetType �� Property �� Value   CalendarStyle1&   System.Windows.Controls.Calendar �� EndPoint �� 
StartPoint � Color	 � Offset
 �� 
TargetType ��Name5  /System.Windows.Controls.Primitives.CalendarItem  Name   CalendarItemStyle  CalendarCalendarItemStyle1 � 	Resources �Name � 	Resources  Key �� Color'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration �� 
TargetName	 W� To �� TargetProperty �� CornerRadius ��Name � ColumnDefinitions � RowDefinitions ��Name  DisabledColor J� Opacity �� RadiusX  �� RadiusY! �� Stretch" �� Triggers# P� Property$ P� Value% �� 
TargetName& �� Value' �� Binding( �� RelativeSource) �� AncestorType # CalendarCalendarDayButtonStyle1:  4System.Windows.Controls.Primitives.CalendarDayButton*   Transitions%  System.Windows.VisualTransition+   GeneratedDuration	, �� To- R� KeyTime. R� Value  System.Windows.Visibility/ ��Name0 F�Name1 J� RenderTransformOrigin2 J� IsHitTestVisible�� 5   
    5      �� 5      $* $/Dictionary/Main/DictionaryMain.xaml?�6%   %�  '[�       &	  X     &	     7  7  &	 �    �� 5      " [�6   .�5      ��  �@[�ShowsNavigationUI .  66   5      �� 5      "  6+   .�5      ��  � �� �	#FF3333336/   �� 5       � �� 5      �� 5       $ 0.5,1&�6.   $ 0.5,0&�6?   .��5!      � $ 	#FFE4EAF0��6+   $	 0Q�6=   � 5"      $ 	#FFECF0F4��6+   $
	 0.16Q�6=   � 5#      $ 	#FFFCFCFD��6+   $
	 0.16Q�6=   � 5$      $ 	#FFFFFFFF��6+   $	 1Q�6=   5%      5'      �� 5(       � �� 5)      �� 5*      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5+      � $ 	#FFA3AEB9��6+   $	 0Q�6=   � 5,      $ 	#FF8399A9��6+   $	 0.375Q�6=   � 5-      $ 	#FF718597��6+   $	 0.375Q�6=   � 5.      $ 	#FF617584��6+   $	 1Q�6=   5/      51      �� 52       � ��$ 1q�64   �� 53       � �� 54      �� 55      "
  6*   .R�56      �� $ 	PART_Root��6)   $��Center=�6<   .+�57   "     $ PART_CalendarItem��6/   #��z��6J   #��z��6t   #��z��6�   #��z 6�   58      59      5;      5<      �� 5=      "  67   .�5>      ��  � ��$ 0,3,0,3q�6+   �� 5?       � �� 5@      �� 5A      "
  6*    5B      ���� 5C   "   (��       6/   **(CalendarItem.DayTitleTemplateResourceKey+).R�5D   &   �� ���	#FF333333$��Trebuchet MS)�6G   $��SemiBold"�6a   $��18(�6w   $��Center=�6�   $��10q�6�   $��Center=�6�   ��6�   �� 6�   5E   #   5F      .R�5G      � $ 	PART_Root��6#    5H   "   ���� 5I   &   DisabledColor $ 	#A5FFFFFF��6L   5J   #    5K   "     5L   &   CommonStates��. 5M   *     
Normal��66     5N   *   Disabled��. 5O   .   �� .��5P   2   W� $ 0D�6B   $ PART_DisabledVisual��6O   $ 1X�6{   $ Opacity�6�   5Q   /   5R   +   5S   '   .+�5U   "   �� #��z��6)   #��z��6S   #��z��6   $ 1��6�   ._�5V   &   �� ._�5W   *   � .+�5Z   .   �� $ PART_PreviousButton��65   $y�	Collapsed=�6R   �� 5[   .   $ PART_HeaderButton��65   $y�	Collapsed=�6P   �� 5\   .   $ PART_NextButton��65   $y�	Collapsed=�6N   � 5]   .   $ PART_MonthView��63   $y�Visible=�6K    5^   2   �� 5_   6   $
��Auto �6G   �� 5`   6   $
��Auto �6G   �� 5a   6   $
��Auto �6G   �� 5b   6   $
��Auto �6G   �� 5c   6   $
��Auto �6G   �� 5d   6   $
��Auto �6G   �� 5e   6   $
��Auto �6G    5g   2   �� 5h   6   $
��Auto �6D   �� 5i   6   $
��Auto �6D   �� 5j   6   $
��Auto �6D   �� 5k   6   $
��Auto �6D   �� 5l   6   $
��Auto �6D   �� 5m   6   $
��Auto �6D   �� 5n   6   $
��Auto �6D   5p   /   � 5q   .   $ PART_YearView��63   $y�Hidden=�6J    5r   2   �� 5s   6   $
��Auto �6G   �� 5t   6   $
��Auto �6G   �� 5u   6   $
��Auto �6G   �� 5v   6   $
��Auto �6G    5x   2   �� 5y   6   $
��Auto �6D   �� 5z   6   $
��Auto �6D   �� 5{   6   $
��Auto �6D   5}   /   5~   +   5   '   5�   #   �� 5�   "   $ PART_DisabledVisual��6,   8��  $ 0Q�6o   $ 2��6{   $  2��6�   8�� $
! Fill=�6�   $��1��6�   $y�	Collapsed=�6�   5�      " 5�      P� 5�   "   # � {�$ .  . �5�   &   �� $% PART_DisabledVisual��6C    � y�$ Visible=�6d   5�   #   �� 5�   "   $
& Year��6�   ' 6.   �� *DisplayMode+( �� *FindAncestor+")  .a�5�   &   �� $% PART_MonthView��6C    � y�$ Hidden=�6_   �� 5�   &   $% PART_YearView��6C    � y�$ Visible=�6^   5�   #   �� 5�   "   $& Decade��6�   ' 6.   �� *DisplayMode+( �� *FindAncestor+")  .a�5�   &   �� $% PART_MonthView��6C    � y�$ Hidden=�6_   �� 5�   &   $% PART_YearView��6C    � y�$ Visible=�6^   5�   #   5�      5�      5�      �� 5�      "  6<   .�5�      ��  � ��$ 40��6*   �� 5�       � ��$ 40��6+   �� 5�       � ��$ 18(�6-   �� 5�       � ��$ 5q�6+   �� 5�       �@�Cursor$
 Hand��6+   �� 5�       � ��$ Center=�6?   �� 5�       � ��$ Center=�6=   �� 5�       � �� 5�      �� 5�      "
  6*   .R�5�      �  5�   "     5�   &   CommonStates��* 5�   *     5�   .   $+ 0:0:0.1D�6?   . 5�   *     
Normal��66     5�   *   	MouseOver��. 5�   .   �� .��5�   2   W� $ 0D�6B   $ HighlightBackground��6O   $	 0.5X�6{   $ Opacity�6�   5�   /   5�   +     5�   *   Pressed��. 5�   .   �� .��5�   2   W� $ 0D�6B   $ HighlightBackground��6O   $	 0.5X�6{   $ Opacity�6�   5�   /   5�   +     5�   *   Disabled��. 5�   .   �� .��5�   2   W� $ 0D�6B   $ HighlightBackground��6O   $ 0X�6{   $ Opacity�6�   W� 5�   2   $ 0D�6B   $ 
NormalText��6O   $	 .35X�6r   $ Opacity�6{   5�   /   5�   +   5�   '     5�   &   SelectionStates��* 5�   *     5�   .   $+ 0D�6?   . 5�   *     
Unselected��66     5�   *   Selected��. 5�   .   �� .��5�   2   W� $ 0D�6B   $ SelectedBackground��6O   $ .9X�6z   $ Opacity�6�   �� 5�   2   $ 0D�6A   $ 
NormalText��6N   $, #FFBA00X�6q   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6~   5�   /   5�   +   5�   '     5�   &   CalendarButtonFocusStates��* 5�   *     5�   .   $+ 0D�6?   . 5�   *     CalendarButtonFocused��. 5�   .   �� .��5�   2   T� $ 0D�6P   $ DayButtonFocusVisual��6]   $ 
Visibility�6�   ..�5�   6   i� $- 0��6M   . 5�   :    5�   >   Visible=�6R   5�   7   5�   3   5�   /   5�   +     5�   *   CalendarButtonUnfocused��. 5�   .   �� .��5�   2   T� $ 0D�6P   $ DayButtonFocusVisual��6]   $ 
Visibility�6�   ..�5�   6   i� $- 0��6M   . 5�   :    5�   >   	Collapsed=�6T   5�   7   5�   3   5�   /   5�   +   5�   '     5�   &   ActiveStates��* 5�   *     5�   .   $+ 0D�6?   . 5�   *     
Active��66     5�   *   Inactive��. 5�   .   �� .��5�   2   �� $ 0D�6A   $ 
NormalText��6N   $, #4a4a4aX�6q   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6~   5�   /   5�   +   5�   '     5�   &   	DayStates��* 5�   *     5�   .   $+ 0D�6?   . 5�   *     
RegularDay��66     5�   *   	Today��. 5�   .   �� .��5�   2   W� $ 0D�6B   $ TodayBackground��6O   $ 1X�6w   $ Opacity�6~   �� 5�   2   $ 0D�6A   $ 
NormalText��6N   $, 	#FFFFFFFFX�6q   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6�   5�   /   5�   +   5�   '     5�   &   BlackoutDayStates��* 5�   *     5�   .   $+ 0D�6?   . 5�   *     	NormalDay��66     5�   *   BlackoutDay��. 5�   .   �� .��5�   2   W� $ 0D�6B   $ Blackout��6O   $ .2X�6p   $ Opacity�6x   5�   /   5   +   5  '   .+�5  "   �� $ TodayBackground��6,   ���#0C3B2E$ 0Q�6T   $ 30��6`   $  30��6m   �� 5  "   $ SelectedBackground��6,   ���#0C3B2E$ 0Q�6W   $ 30��6c   $  30��6p   �� 5  "   #��z��6)   #��z��6S   #��z��6   �� 5  "   $ HighlightBackground��6,   ���#f0ede6$ 0Q�6X   $ 30��6d   $  30��6q   �� 5  "   $/ 
NormalText��63   
���   �$��Center=�6f   $	��5 3q�6�   $��Center=�6�   F� 5  "   $0 Blackout��6'   }�����5 �Z @�J� �Q2� �J� �̉� iV� �A�� �J� �W�� �J� ѷ�� #�� �>8� 7T�K�� 7T�� � ��� ћ�� 7T����G @7T��� �D� 	���	#FF000000$��Stretch=�6N  $��3q�6l  $ 0Q�6w  $1 0.5,0.5&�6�  $
! Fill=�6�  $��Stretch=�6�  �� 5	  "   $ DayButtonFocusVisual��6,   2 .  $ 30��6c   $  30��6p   ���#FFBA00$y�	Collapsed=�6�   5
     5     5     5     5     5     