   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0898    2ZolyFramework.UI.Windows.Controls.ZolyScrollViewer  �� 
TargetType �� Property �� Value �� 
TargetType �Name � ColumnDefinitions � RowDefinitions ��Name ��Name	 �� CanContentScroll
 �� CanHorizontallyScroll �� CanVerticallyScroll5   /ZolyFramework.UI.Windows.Controls.ZolyScrollBar  Name4  .System.Windows.Automation.AutomationProperties   AutomationId � Cursor �� ScrollableHeight � Maximum � Minimum* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ViewportSize   ScrollBarStyle1 � Value �� Mode �� RelativeSource �� ScrollableWidth �� Orientation, �� %ComputedHorizontalScrollBarVisibility �� ViewportWidth ( $ZolyScrollBarRepeatButtonTransparent  ZolyScrollBarThumb  ZolyScrollBarThumbBrush J� SnapsToDevicePixels   ZolyScrollBarBackgroundBrush  ZolyScrollBarBorderBrush ]�Name J� IsMouseOver ]� DecreaseRepeatButton  �� PageUpCommand! ]� IncreaseRepeatButton" �� PageDownCommand# ]� Thumb$ �� Triggers% P� Property& P� Value' �� PageLeftCommand( �� PageRightCommand�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  5      %$  '         &	 /    &	 w    '  �    7  7  7  7  7  7  �� 5      "    6   .�5   
   ��  � �� 5      �� 5      "   6"   .R�5      � $
 Grid��6   #��z��6)    5      �� 5      $��* �6/   �� 5      $
��Auto �6/    5      �� 5      $��* �6,   �� 5      $
��Auto �6,   .+�5      �� $ Corner��6$   $��1��64   #��� ��6D   $��1��6�   �� 5      $! PART_ScrollContentPresenter��61   #	 z��6V   
 .   .  #��z��6�   #��z��6�   $��0��6  #��z��6.  $��0��6Q    5      $ PART_VerticalScrollBar��61   $ VerticalScrollBar��6Q   $ Arrow��6�   $��1��6�   # z 6�   $ 0Q�6�   $��0��6�   #y�z 6�   # z 6�  #���   6�   6/  �� *VerticalOffset+$ OneWay=� �� *TemplatedParent+6�    5      $ PART_HorizontalScrollBar��61   $ HorizontalScrollBar��6S   $ Arrow��6�   $��0��6�   # z 6�   $ 0Q�6�   $ 
Horizontal=�6�   $��1��6�   #y�z 6  # z 6�  #���   6�   6M  �� *HorizontalOffset+$ OneWay=� �� *TemplatedParent+6�  5      5      5      5       �� 5$      "  ��69   .�5%   
   ��  �@�OverridesDefaultStyle . 62   �� 5&   
    � ��
 ���� 6'   �� 5'   
    � |� .  6&   �� 5(   
    � �� .  6&   �� 5)   
    � �� 5*      �� 5+      " ��6"   .R�5,      �� #��z��6    #��z��6D   #��z��6f   5-      5/      50      �� 51      "  n�6'   .�52   
   ��  �@�OverridesDefaultStyle . 62   �� 53   
    � �� .  6&   �� 54   
    � �� 55      �� 56      " n�6"   .R�57      �� $ 	rectangle��6    #���  63   #��z��6d    . #��z��6�   58      5:      5;      �� 5=      "   6   .�5>   
   ��  �@��IsPressAndHoldEnabled .  69   �� 5?   
    �@��IsFlicksEnabled .  63   �� 5@   
    � ��# �  6'   �� 5A   
    � ��# �  6(   �� 5B   
    � ��# � ��6'   �� 5C   
    � ��$	 1,0q�6,   �� 5D   
    � ��$ 10��6"   �� 5E   
    � ��$ 10��6%   �� 5F   
    � �� 5G      �� 5H      "  6"   .R�5I      � $ Bg��6    . .+�5J      �� #��z��6!   #��z��6M   #��z��6�   ]� 5K      $ 
PART_Track��6    ��. #{�z 6O    5L      �� 5M   "   #��Z  6/   8��  6\   ! 5O      �� 5P   "   #��Z" 6/   8�� 6^   # 5R      n� 5S   "   8�� 6(   5U      5V      5W      5Y      $ 5Z   
   P� 5[      % �@��Orientation$& 
Horizontal=�6-   . �5\      ��  � ��$
 Auto��6*   �� 5]       � ��$ 0��6-   �� 5^       � ��$ 10��6+   �� 5_       � ��$ 10��6.   �� 5`       � ��$	 0,1q�64   �� 5a       � �� 5b      �� 5c      "  6*   .R�5d      � $ Bg��6#    . .+�5e   "   �� #��z��6)   #��z��6U   #��z��6�   ]� 5f   "   $ 
PART_Track��6(   #{�z 6<    5g   &   �� 5h   *   #��Z' 67   8�� 6f   ! 5j   &   �� 5k   *   #��Z( 67   8�� 6g   # 5m   &   n� 5n   *   8�� 60   5p   #   5q      5r      5t      5u      5w      5y      