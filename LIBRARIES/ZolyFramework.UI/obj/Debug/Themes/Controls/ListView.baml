   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  5      I)clr-namespace:ZolyFramework.UI.ConvertersZolyFramework.UI.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ZolyListViewContainerStyle  �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property P� Value # ZolyListViewItemHoverBackground " ZolyListViewItemHoverTextBrush & "ZolyListViewItemSelectedBackground % !ZolyListViewItemSelectedTextBrush ! ZolyMenuItemDisabledTextBrush �� Triggers ( $ZolyHorizontalListViewContainerStyle  VeryLighterThemeBrush  LighterThemeBrush &	 "ZolyHorizontalListViewDataTemplate 
 	TextBrush  LighterBackgroundBrush  GridViewColumnHeaderGripper	 �� Padding  ZolyGridViewColumnHeader   ZolyListViewEnabledTextBrush " ZolyListViewEnabledBorderBrush
 �Name J� IsHitTestVisible ��Name ��Name n�Name �� 
TargetName ) %ZolyListViewColumnOverBackgroundBrush # ZolyListViewColumnOverTextBrush , (ZolyListViewColumnPressedBackgroundBrush & "ZolyListViewColumnPressedTextBrush ! ZolyListViewDisabledTextBrush ��Name � ActualWidth � ActualHeight � ColumnDefinitions � RowDefinitions8    2ZolyFramework.UI.Windows.Controls.ZolyScrollViewer! �� ColumnHeaderContainerStyle �� AllowsColumnReorder �� RelativeSource �� ColumnHeaderToolTip �� ColumnHeaderStringFormat �� ColumnHeaderContextMenu �� ColumnHeaderTemplate �� Columns# �� ColumnHeaderTemplateSelector ��Name �� CanContentScroll-  'System.Windows.Input.KeyboardNavigation    DirectionalNavigation5   /ZolyFramework.UI.Windows.Controls.ZolyScrollBar!  Name" � Cursor# �� ScrollableWidth$ � Maximum% � Minimum& �� Orientation,' �� %ComputedHorizontalScrollBarVisibility( �� ViewportWidth) �� ViewportSize* � Value+ �� Mode, �� ScrollableHeight*- �� #ComputedVerticalScrollBarVisibility. �� ViewportHeight/ �� ElementName>   8ZolyFramework.UI.Windows.Controls.ZolyHorizontalListView & "ZolyListViewEnabledBackgroundBrush # ZolyListViewDisabledBorderBrush0 ]� 
Conditions1 �� Property2 �� Value3 � Orientation9   3ZolyFramework.UI.Converters.BooleanToStyleConverter  BooleanToStyleConverter4   True4   .ZolyFramework.UI.Windows.Controls.ZolyListView5 �� 	Converter�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  5      8
converters)clr-namespace:ZolyFramework.UI.Converters  5      %  &	        &	 x    &		 �    &	 }    &	 �    7  (�� l    5�      *'%GridView.GridViewScrollViewerStyleKey+)7  '      7  7 	 &	 �    7$�'  �    7   7  �� 5
      "  ��6/   .�5   
   ��  � ��$ 0q�6,   �� 5   
    � ��$ Stretch=�67   �� 5   
    � ��$ 32��6#   �� 5   
    � ��$ 15(�6%   �� 5   
    � ��$ 4,4,4,4q�6$   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      � .+�5      ��  . #��z��6<   #��z��6p   #��z��6�   ._�5      �� #��z��63   #��z��6r   5      5       5      P� 5       �@J�IsMouseOver . . �5      �� # �  6;    � ���� 5      # �  6;    � ��5      P� 5       �@��
IsSelected . . �5      �� # �  6;    � ���� 5      # �  6;    � ��5       P� 5!       � {� .  . �5"      �� # �  6;    � ��5#      5%      5'       5(   
   P� 5)       �@J�IsKeyboardFocusWithin . . �5*      ��  �@��
IsSelected . 6/   5+      5-      �� 5/      "  ��69   .�50   
   ��  � ��$ 0q�6,   �� 51   
    � ��$ 2,0,0,2q�6#   �� 52   
    � ��$ 4,4,4,4q�6$   �� 53   
    � �� 54      �� 55      " ��6"   .R�56      � .+�57      ��  . #��z��6<   #��z��6p   #��z��6�   ._�58      �� #��z��6/   59      5:       5;      P� 5<       �@J�IsMouseOver . . �5=      �� # �  6;    � ��5>      P� 5?       �@��
IsSelected . . �5@      �� # �  6;    � ��5A      P� 5B       � {� .  . �5C      �� # �  6;    � ��5D      5F      5H      5I      �� 5J      .R�5K   
   �� $	��225��6   $��52��6   $��1q�6)   #��� 
 6=   ._�5L      � #���  6   .+�5M      �� 5N      5O      5P      �� 5R      "  n�5S      .�5T   
   ��  � ��$ 18��5U      �� 5V   
    � ��
 ���� 5W      �� 5X   
    � �� 5Y      �� 5Z      " n�6"   .R�5[      �� #	 z��6   
������ $��0 0 0 2q�5]      ._�5^      �� $��Center=�6$   $��1��5_      #��z��5`      5a      5b      5d      5e      �� 5f      "  ��6-   .�5g   
   ��  � ��# �  6'   �� 5h   
    � ��# �  6(   �� 5i   
    �@J�SnapsToDevicePixels . 60   �� 5j   
    � ��$
 Left=�67   �� 5k   
    � ��$ Center=�65   �� 5l   
    � ��$ 4 2 4 2q�6$   �� 5m   
    � ��$ 32��6#   �� 5n   
    � ��$ 15(�6%   �� 5o   
    � �� 5p      �� 5q      " ��6"   .R�5r      � $
 
HeaderGrid��6   .+�5s      �� 
������  . 5t      �� 5u      $ HeaderBorder��6!   #	 z��5v      $��0 0 0 1q�6,   #��z��6F   ._�5w      �� $ HeaderContent��6/   #��z��5x   	   #��z��5y   	   $��0,0,0,1q�5z   	   #��z��5{   	   #��z��5|   	   ��. # z 5~   	   5      n� 5�      $ PART_HeaderGripper��6    $��Right=�5�      $��0,0,-9,0q�5�      8��  5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ 
HeaderGrid��6%   # �  5�   	    � ���� 5�      # �  5�   	    � ��5�      P� 5�       � �� . . �5�      �� $ 
HeaderGrid��6%   # �  5�   	    � ���� 5�      # �  5�   	    � ��5�      P� 5�       � {� .  . �5�      �� # �  5�   	    � ��5�      5�      5�      �� 5�   
    � �� 5�      �� 5�      .R�5�      �� $��15(�6    ��6.   �� 5�      5�       5�   
   P� 5�       �@��Role$ Floating=�5�      . �5�      ��  �@J�Opacity$	 0.7Q�5�      �� 5�       � �� 5�      �� 5�      " ��6*   .R�5�      �� $ PART_FloatingHeaderCanvas��6%   .+�5�   "   �� ���	#60000000#��z 5�   
   #��z 5�   
   5�      5�      5�      5�      5�      �� 5�      "  ��6E   .�5�   
   ��  � |� .  6&   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      � #��z��6    .  5�      �� 5�      $��* �6/   �� 5�      $
��Auto �6/    5�      �� 5�      $��* �6,   �� 5�      $
��Auto �6,   .+�5�      ]� #��z��6$   .+�5�         $	��Top=�68   |�.  $��Hidden=�6_   $��Hidden=�6�   .��5�   "   �� 8   $��0q�6�  # z 6�   6=   �� **(TemplatedParent.View.AllowsColumnReorder+ �� *TemplatedParent+ 6�   �� **(TemplatedParent.View.ColumnHeaderToolTip+ �� *TemplatedParent+ 6x  �� */-TemplatedParent.View.ColumnHeaderStringFormat+ �� *TemplatedParent+ 6�  �� *.,TemplatedParent.View.ColumnHeaderContextMenu+ �� *TemplatedParent+ 6~  �� *+)TemplatedParent.View.ColumnHeaderTemplate+ �� *TemplatedParent+ 6�  �� *TemplatedParent.View.Columns+ �� *TemplatedParent+ 6\  �� *31TemplatedParent.View.ColumnHeaderTemplateSelector+ �� *TemplatedParent+6�  5�      �� 5�      $! PART_ScrollContentPresenter��65   # z��6Z   #��z��6�   #��z��6�   $  Local=�6�   # z 6  5�        5�      $! PART_HorizontalScrollBar��61   $" Arrow��6S   #$ z# 6b   $	% 0.0Q�6�   $& 
Horizontal=�6�   $��1��6�   #y�z' 6�   #) z( 6h  * 6  �� *HorizontalOffset+$+ OneWay=� �� *TemplatedParent+6h    5�      $! PART_VerticalScrollBar��61   $" Arrow��6Q   $��1��6`   #$ z, 6p   $	% 0.0Q�6�   $& Vertical=�6�   #y�z- 6�   #) z. 6d  * 6  �� *VerticalOffset+$+ OneWay=� �� *TemplatedParent+6d  ]� 5�      $��1��6j   ��.  $��1��6�   ��6$   �� *
Background+$/ PART_VerticalScrollBar��.+�5�      �� $
��Left=�6(   
�������#y�z- 6K   $��1��6�   �� 5�      $	��Top=�6(   
�������$��1��6J   #y�z' 6U   5�      5�      5�      5�      5�      �� 5�      "   6   .�5�   
   ��  � ��# �  6'   �� 5�   
    � ��# �  6(   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$ 1q�6,   �� 5�   
    � ��$
 Auto=�6G   �� 5�   
    � ��$ Disabled=�6E   �� 5�   
    � �� . 6:   �� 5�   
    �@��PanningMode$
 Both=�65   �� 5�   
    �@��IsFlicksEnabled .  63   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��8   6/   �� 5�   
    � ��8  6)   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �� $ Bd��6   #��z��6)   #��z��6U   #��z��6�   $	 1q�6�    . ._�5�         |�.  #��z��6F   .��5�      �� # z 6-   5�      5�       5�      P� 5�       � {� .  . �5�      �� $ Bd��6<   # �  6L    � ���� 5�      # �  6;    � ��5�      ]� 5�      0 5�      �� 5�   "   1 �@��
IsGrouping2 . 6B   �� 5�   "   "1 �@%�IsVirtualizingWhenGrouping2 .  6d   ./�5�      ��  � �� .  6N   5�      5�      5�      �� 5   
    � �� 5     �� 5     .R�5     � $3 Vertical=�6    5     5     5       5     84   6I   �� 5     "   6   .�5  
   ��  � ��# �  6'   �� 5  
    � ��# �  6(   �� 5  
    � ��# �  6'   �� 5  
    � ��$ 1q�6,   �� 5  
    � �� . 6:   �� 5  
    �@��PanningMode$
 Both=�65   �� 5  
    �@��IsFlicksEnabled .  63   �� 5  
    � ��8   6/   �� 5  
    � �� 5     �� 5     "  6"   .R�5     �� $ Bd��6   #��z��6)   #��z��6U   #��z��6�   $	 0q�6�    . ._�5        #��z��64   ��6X   �� *IsColumnsVisible+85   �� *TemplatedParent+.��5     �� # z 6-   5     5      5     P� 5      � {� .  . �5     �� $ Bd��6<   # �  6L    � ���� 5      # �  6;    � ��5!     ]� 5"     0 5#     �� 5$  "   1 �@��
IsGrouping2 . 6B   �� 5%  "   "1 �@%�IsVirtualizingWhenGrouping2 .  6d   ./�5'     ��  � �� .  6N   5(     5*     5,     5-     5/     