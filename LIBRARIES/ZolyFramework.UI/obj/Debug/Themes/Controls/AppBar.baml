   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0898    2ZolyFramework.UI.Windows.Controls.ZolyBottomAppBar  �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources   Key �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   	Collapsed	 R� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value   EasingFunction0  *System.Windows.Media.Animation.QuinticEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode   Visible   Hidden � RowDefinitions �Name ��Name # ZolyAppBarClosedBackgroundBrush ��Name5   /ZolyFramework.UI.Windows.Controls.ZolyTextBlock  Name �� TextAlignment �� Padding �� Triggers P� Property P� Value �� 
TargetName N� EnterActions ��Name  OpenStoryboard N� ExitActions  CloseStoryboard # ZolyAppBarOpenedBackgroundBrush ]� 
Conditions �� Property  �� Value5   /ZolyFramework.UI.Windows.Controls.ZolyTopAppBar8   2ZolyFramework.UI.Windows.Controls.ZolyAppBarButton " ZolyRaisedButtonHoverTextBrush! �� Orientation" �� ElementName#   Icon&   System.Windows.Media.TextOptions$   TextFormattingMode * &ZolyRaisedButtonFocusedBackgroundBrush & "ZolyRaisedButtonFocusedBorderBrush $  ZolyRaisedButtonFocusedTextBrush (	 $ZolyRaisedButtonHoverBackgroundBrush $
  ZolyRaisedButtonHoverBorderBrush * &ZolyRaisedButtonPressedBackgroundBrush & "ZolyRaisedButtonPressedBorderBrush $  ZolyRaisedButtonPressedTextBrush ' #ZolyRaisedButtonDisabledBorderBrush % !ZolyRaisedButtonDisabledTextBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  5      %j  '         7  7  '  
    7  7  '      �� 5
      "    6   .�5   
   ��  �@K�ZIndex$
 1000��6)   �� 5   
    � ��$ Stretch=�6.   �� 5   
    � �� 5      �� 5      "   6"    5      ���� 5      OpenStoryboard  .��5      T� $ (UIElement.Visibility)�6<   $ OpenTextBlock��6o   ..�5   "   i� $ 0��69   #	 Z 6E   5      U� 5      $ (FrameworkElement.Height)�6<   $ Border��6r   .\�5   "     $
 0��67   $ 15Q�6C     5   "   $
 0:0:0.3��67   $	 105Q�6I    5   &     5   *   $ 	EaseInOut=�66   5   #   5      T� 5      $ (UIElement.Visibility)�6<   $ contentPresenter��6o   ..�5   "   i� $ 0:0:0.1��69   #	 Z 6K   5      5       �� 5!      CloseStoryboard  .��5"      T� $ (UIElement.Visibility)�6<   $ contentPresenter��6o   ..�5#   "   i� $ 0:0:0.1��69   #	 Z 6K   5$      U� 5%      $ (FrameworkElement.Height)�6<   $ Border��6r   .\�5&   "     $
 0��67   $	 105Q�6C     5'   "   $
 0:0:0.3��67   $ 15Q�6I    5(   &     5)   *   $ 	EaseInOut=�66   5+   #   5,      T� 5-      $ (UIElement.Visibility)�6<   $ OpenTextBlock��6o   ..�5.   "   i� $ 0��69   	 5/   &    50   *   	Collapsed=�6@   52   #   i� 53   "   $ 0:0:0.2��69   #	 Z 6K   54      55      56      .R�57      �  58      �� 59      $��* �6,   �� 5:      $
��Auto �6,   .+�5<      � $ ContainerGrid��6   $
��Auto��66   �� 5=      $ Border��6!   $��1��61   $��15��6>   #���  6J   #��z��6�   #��z��6�   ._�5>      � }�. .+�5?   "   �� $ contentPresenter��63   $��Stretch=�6M   $��Stretch=�6k   $
��Auto��6�   $y�Hidden=�6�     5@   "   $ OpenTextBlock��69   $
��Wrap=�6P   
�������$
��Auto��6w   $��24(�6�   $ Right=�6�   $��Segoe UI Symbol)�6�   $��Medium"�6�   $ 0,0,11,0q�6�   $	����6�   $
��Auto��6�   $��
0,-8.5,0,0q�6
  5A      5B      5C       5D      P� 5E       �@  IsOpen .  . �5F      �� $ Border��6;   # �  6O    � ��5G      P� 5H       �@  IsOpen .  5I      �� 5J   "   $$ OpenStoryboard_BeginStoryboard��62   8��  6Z    5L      �� 5M   "   $% CloseStoryboard_BeginStoryboard��62   8�� 6[   . �5O      �� $ Border��6;   # �  6O    � ��5P      ]� 5Q       5R      �� 5S   "    �@J�IsMouseOver  . 6C   �� 5T   "    �@  IsOpen  .  6>   ./�5V      �� $ Border��6;   # �  6O    � ��5W      5Y      5[      5\      �� 5`      "   6   .�5a   
   ��  �@K�ZIndex$
 1000��6)   �� 5b   
    � ��$ Stretch=�6.   �� 5c   
    � �� 5d      �� 5e      "  6"    5f      ���� 5g      OpenStoryboard  .��5h      T� $ (UIElement.Visibility)�6<   $ OpenTextBlock��6o   ..�5i   "   i� $ 0��69   #	 Z 6E   5j      U� 5k      $ (FrameworkElement.Height)�6<   $ Border��6r   .\�5l   "     $
 0��67   $ 15Q�6C     5m   "   $
 0:0:0.3��67   $	 105Q�6I    5n   &     5o   *   $ 	EaseInOut=�66   5q   #   5r      T� 5s      $ (UIElement.Visibility)�6<   $ contentPresenter��6o   ..�5t   "   i� $ 0:0:0.1��69   #	 Z 6K   5u      5v      �� 5w      CloseStoryboard  .��5x      T� $ (UIElement.Visibility)�6<   $ contentPresenter��6o   ..�5y   "   i� $ 0:0:0.1��69   #	 Z 6K   5z      U� 5{      $ (FrameworkElement.Height)�6<   $ Border��6r   .\�5|   "     $
 0��67   $	 105Q�6C     5}   "   $
 0:0:0.3��67   $ 15Q�6I    5~   &     5   *   $ 	EaseInOut=�66   5�   #   5�      T� 5�      $ (UIElement.Visibility)�6<   $ OpenTextBlock��6o   ..�5�   "   i� $ 0��69   	 5�   &    5�   *   	Collapsed=�6@   5�   #   i� 5�   "   $ 0:0:0.2��69   #	 Z 6K   5�      5�      5�      .R�5�      �  5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5�      �� $ Border��6!   $��15��61   #���  6=   #��z��6|   #��z��6�   ._�5�      � }�. .+�5�   "   �� $ contentPresenter��63   $��Stretch=�6M   $��Stretch=�6k   $
��Auto��6�   $y�Hidden=�6�     5�   "   $ OpenTextBlock��69   $
��Wrap=�6P   
�������$
��Auto��6w   $��24(�6�   $ Right=�6�   $��Segoe UI Symbol)�6�   $��Medium"�6�   $ 0,0,11,0q�6�   $	����6�   $
��Auto��6�   $��
0,-8.5,0,0q�6
  5�      5�      � 5�      $ ContainerGrid��6   $��1��66   $
��Auto��6C   5�       5�      P� 5�       �@ IsOpen .  . �5�      �� $ Border��6;   # �  6O    � ��5�      P� 5�       �@ IsOpen .  5�      �� 5�   "   $$ OpenStoryboard_BeginStoryboard��62   8��  6Z    5�      �� 5�   "   $% CloseStoryboard_BeginStoryboard��62   8�� 6[   . �5�      �� $ Border��6;   # �  6O    � ��5�      ]� 5�       5�      �� 5�   "    �@J�IsMouseOver  . 6C   �� 5�   "    �@ IsOpen  .  6>   ./�5�      �� $ Border��6;   # �  6O    � ��5�      5�      5�      5�      �� 5�      "   6   .�5�   
   ��  � ��$ Segoe UI)�6'   �� 5�   
    � ��$ Stretch=�60   �� 5�   
    � ��$ 90��6"   �� 5�   
    � ��$ 90��6#   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � �� 6(   Z� �� 5�   
    � ��
 ���� 6'   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$ Medium"�6'   �� 5�   
    � ��$ 15(�6%   �� 5�   
    � ��$ Center=�67   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��$ Stretch=�6.   �� 5�   
    � ��$	 5,0q�6#   �� 5�   
    � |� .  6&   �� 5�   
    �@��	IsEnabled .  69   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� #��z��6   #��z��6Q   
������ ._�5�      �� $! Vertical=�6%   .+�5�      � $
 grid��6#   $��50��6b   $��Center=�6n   $��Stretch=�6�   ��61   �� *ActualHeight+$
" grid��.+�5�   "   A� #��z��6*   $��Stretch=�6N   $��Stretch=�6l   �� 5�   "   $��Center=�6,   $
��Auto��6I   $��0q�6W   $
��Wrap=�6b   #��z# 6v   $��Center=�6�   $
��Auto��6�   $��Segoe UI Symbol)�6�   $��22(�6�   5�        5�      #��z��65   #��z��6V   $
��Wrap=�6�   $ Center=�6�   $��Disabled=�6�   $��Center=�6�   $��Bottom=�6�   $$ Display=�6  $��0q�6@  $��12(�6K  5�      5�       5�      P� 5�       �@J�	IsFocused . . �5�      �� # �  6;    � ���� 5�      # �  6<    � ���� 5�      # �  6;    � ��5�      P� 5�       �@J�IsMouseOver . . �5�      �� # � 	 6;    � ���� 5�      # � 
 6<    � ���� 5�      # �  6;    � ��5�      P� 5�       �@J�AreAnyTouchesOver . . �5�      �� # � 	 6;    � ���� 5�      # � 
 6<    � ���� 5�      # �  6;    � ��5�      P� 5�       � �� . . �5�      �� # �  6;    � ���� 5�      # �  6<    � ���� 5�      # �  6;    � ��5�      P� 5�       � {� .  . �5�      �� # �  6<    � ���� 5�      # �  6;    � ��5�      5�      5�      5�      5�      