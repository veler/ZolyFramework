   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0897    1ZolyFramework.UI.Windows.Controls.ZolyContextMenu  �� 
TargetType �� Property "  ZolyContextMenuBackgroundBrush �� Value  ZolyContextMenuBorderBrush �� 
TargetType
 J� Uid8   2ZolyFramework.UI.Windows.Controls.ZolyScrollViewer �� 
ResourceId �� TypeInTargetAssembly-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation J� SnapsToDevicePixels4   .ZolyFramework.UI.Windows.Controls.ZolyMenuItem	 �� RelativeSource
 �� AncestorLevel �� AncestorType   ZolyMenuItemEnabledTextBrush ��Name �Name � ColumnDefinitions z� SharedSizeGroup F�Name ��Name5   /ZolyFramework.UI.Windows.Controls.ZolyTextBlock  Name m� InputGestureText �� Triggers P� Property P� Value �� 
TargetName �� Value �� Binding �� ElementName �� Path �� Triggers ]�Name �Name � AllowsTransparency  � VerticalOffset! � HorizontalOffset" �� ClearTypeHint#   TabNavigation$ � IsSharedSizeScope # ZolyMenuItemOverBackgroundBrush & "ZolyMenuItemPressedBackgroundBrush ! ZolyMenuItemDisabledTextBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  5      %'  '         '  {    �� 5      "    6   .�5   
   ��  � ��# �   6'   �� 5   
    � ��$ 1q�6,   �� 5   
    � ��# �  6(   �� 5   
    � ��$ Center=�65   �� 5   
    � ��$ 2q�6$   �� 5   
    �@�IsSharedSizeScope . 63   �� 5   
    �@��HasDropShadow .  6*   �� 5   
    �@��PanningMode$
 Both=�65   �� 5   
    �@��IsFlicksEnabled .  63   �� 5   
    � ��$ 15(�6%   �� 5   
    � ��$ Medium"�6'   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� $ 	Border_93��6   ._�5      �� #��z��6!   #��z��6M   #��z��6�   $ 	Border_50��6�   ._�5        ��. $ ScrollViewer_9��6�   ��6P   C� *�� $ MenuScrollViewer��" �+.��5   "   �� $ Cycle=�61   #��z��6b   # z 6�   $ ItemsPresenter_5��6�   5      5      5       5!      5#      5$      �� 5(      "   6   .�5)   
   ��  � �� 67   �� *HorizontalContentAlignment+	 �� *FindAncestor+$
 1��" ���� 5*   
    � �� 65   �� *VerticalContentAlignment+	 �� *FindAncestor+$
 1��" ���� 5+   
    � ��# �  6'   �� 5,   
    � ��
 ���� 6'   �� 5-   
    � ��$ 1q�6,   �� 5.   
    � ��$ 15(�6%   �� 5/   
    � ��$ Medium"�6'   �� 50   
    �@��PanningMode$
 Both=�65   �� 51   
    �@��IsFlicksEnabled .  63   �� 52   
    � ��$ 36��6#   �� 53   
    � �� 54      �� 55      "  6"   .R�56      �� $ Bd��6   #��z��6)   #��z��6U   #��z��6�    . $ 	Border_38��6�   ._�57      � $
 Grid��6   $ Grid_49��6-    58      �� 59   "   $��17��63   $ MenuItemIconColumnGroup��6A   $
��Auto �6k   �� 5:   "   $��* �63   �� 5;   "   $ MenuItemIGTColumnGroup��63   $
��Auto �6\   �� 5<   "   $��14 �63   .+�5>      F� $ 
GlyphPanel��6#   =����    �� �     >I Ѡ%& @�p �`Vl ��* �`Vl     Ѡ%& �0F 	#��z��6h   $��LeftToRight=�6�   $��4,0,6,0q�6�   $ Path_12��6�   $y�Hidden=�6�   $��Center=�6�   �� 5?      $ ContentPresenter��6/   #��z��6I   #��z��6|   $��1��6�   $��Header��6�   #��z��6�   $��Center=�6�   ��. # z 6  $ ContentPresenter_33��6[    5@      $ InputGestureText��65   $��2��6O   $��Right=�6_   $��5,2,0,2q�6v   #��z 6�   $ TextBlock_10��6�   5A      5B       5C      P� 5D       �@m�	IsChecked . . �5E      �� $ 
GlyphPanel��6;    � y�$ Visible=�6S   5F      �� 5G      $ False��6&    5H      �� 5I   "   $ MenuItemIcon��6*   $ Source�6E   .a�5K      �� $ ContentPresenter��6B    � ��$ Center=�6`   5L      5N      5P       5Q   
   P� 5R       �@m�Role$ TopLevelHeader=�6&   . �5S      ��  � ��$	 0,1q�6+   �� 5T       � ��$	 6,3q�6,   �� 5U       � �� 5V      �� 5W      "  6*   .R�5X      �� $ Bd��6%   #��z��61   #��z��6]   #��z��6�    . $ 	Border_39��6�   ._�5Y   "   � .+�5Z   &   ]� $ 	DockPanel��60   $ DockPanel_4��6C   .+�5[   *   F� $ 
GlyphPanel��6/   =����    �� �     >I Ѡ%& @�p �`Vl ��* �`Vl     Ѡ%& �0F 	#��z��6t   $��LeftToRight=�6�   $��4,0,6,0q�6�   $ Path_13��6�   $y�	Collapsed=�6�   $��Center=�6�   �� 5\   *   $ ContentPresenter��6;   #��z��6U   #��z��6�   $��Header��6�   #��z��6�   $��Center=�6�   ��. # z 6  $ ContentPresenter_35��6W  5]   '   � 5^   &   $ 
PART_Popup��6,    . $��Right=�6Z   $  -3��6l   $! -2��6�   |�.  $��Slide=�6�   ��6�   �� $ IsSubmenuOpen�	 �� *TemplatedParent+.��5_   *   �� $��SubMenuBorder��69   ��.  ��6N   C� *�� " �$ SubmenuContent��+.��5`   .   �� #���  65   #��z��6p   $ 	Border_50��6�   ._�5a   2     $��SubMenuScrollViewer��6L   ��. $	��400��6   ��6�   C� *�� " �$ MenuScrollViewer��+.��5b   6   � $" Enabled=�6;   .+�5c   :   �� $��0��6A   $��0��6L   $
��Left=�6V   $	��Top=�6q   .+�5d   >   �� #���   6�   ��6H   �� $ SubMenuBorder��$ ActualHeight���6�   �� $ SubMenuBorder��$ ActualWidth�6�   5e   ;   �� 5f   :   $��ItemsPresenter��6I   $��2q�6_   $# Cycle=�6j   $ Cycle=�6�   $ . 6�   5g   7   5h   3   5i   /   5j   +   5k   '   5l   #   5m       5n      P� 5o   "    �@m�	IsChecked . . �5p   &   �� $ 
GlyphPanel��6C    � y�$ Visible=�6[   5q   #   5s      5u      5v      P� 5w       �@m�Role$ TopLevelItem=�6&   . �5x      ��  � ��$	 0,1q�6+   �� 5y       � ��$	 6,3q�6,   �� 5z       � �� 5{      �� 5|      "  6*   .R�5}      �� $ Bd��6%   #��z��61   #��z��6]   #��z��6�    . $ 	Border_41��6�   ._�5~   "   ]� $ 	DockPanel��6,   $ DockPanel_5��6?   .+�5   &   F� $ 
GlyphPanel��6+   =����    �� �     >I Ѡ%& @�p �`Vl ��* �`Vl     Ѡ%& �0F 	#��z��6p   $��LeftToRight=�6�   $��4,0,6,0q�6�   $ Path_14��6�   $y�	Collapsed=�6�   $��Center=�6�   �� 5�   &   $ ContentPresenter��67   #��z��6Q   #��z��6�   $��Header��6�   #��z��6�   $��Center=�6�   ��. # z 6  $ ContentPresenter_37��6S  5�   #   5�       5�      P� 5�   "    �@m�	IsChecked . . �5�   &   �� $ 
GlyphPanel��6C    � y�$ Visible=�6[   5�   #   5�      5�      5�      P� 5�       �@m�Role$ SubmenuHeader=�6&   . �5�      ��  � ��$	 Top=�63   �� 5�       � ��$	 0,2q�6,   �� 5�       � �� 5�      �� 5�      "  6*   .R�5�      �� $ Bd��6%   #��z��61   #��z��6]   #��z��6�    . $ 	Border_42��6�   ._�5�   "   � .+�5�   &   � $
 Grid��6+   $ Grid_50��69    5�   *   �� 5�   .   $��17��6?   $ MenuItemIconColumnGroup��6M   $
��Auto �6w   �� 5�   .   $��* �6?   �� 5�   .   $��5��6?   $ MenuItemIGTColumnGroup��6L   $
��Auto �6u   �� 5�   .   $��14 �6?   .+�5�   *   F� $ 
GlyphPanel��6/   =����    �� �     >I Ѡ%& @�p �`Vl ��* �`Vl     Ѡ%& �0F 	#��z��6t   $��LeftToRight=�6�   $��4,0,6,0q�6�   $ Path_15��6�   $y�Hidden=�6�   $��Center=�6�   �� 5�   *   $ ContentPresenter��6;   #��z��6U   #��z��6�   $��1��6�   $��Header��6�   #��z��6�   $��Center=�6�   ��. # z 6+  $ ContentPresenter_39��6g  F� 5�   *   $
 Path��6/   $��3��6=   $��Right=�6M   "����        � 	= �g5 �    ��j 	#��z��6{   $��4,0,6,0q�6�   $ Path_16��6�   $��Center=�6�   5�   '   � 5�   &   $ 
PART_Popup��6,    . $��Right=�6Z   $  -3��6l   $! -2��6�   |�.  $��Slide=�6�   ��6�   �� $ IsSubmenuOpen�	 �� *TemplatedParent+.��5�   *   �� $��SubMenuBorder��69   ��.  ��6N   C� *�� " �$ SubmenuContent��+.��5�   .   �� #���  65   #��z��6p   $ 	Border_50��6�   ._�5�   2     $��SubMenuScrollViewer��6L   ��. $	��400��6   ��6�   C� *�� " �$ MenuScrollViewer��+.��5�   6   � $" Enabled=�6;   .+�5�   :   �� $��0��6A   $��0��6L   $
��Left=�6V   $	��Top=�6q   .+�5�   >   �� #���   6�   ��6H   �� $ SubMenuBorder��$ ActualHeight���6�   �� $ SubMenuBorder��$ ActualWidth�6�   5�   ;   �� 5�   :   $��ItemsPresenter��6I   $��2q�6_   $# Cycle=�6j   $ Cycle=�6�   $ . 6�   5�   7   5�   3   5�   /   5�   +   5�   '   5�   #   5�       5�      P� 5�   "    �@m�	IsChecked . . �5�   &   �� $ 
GlyphPanel��6C    � y�$ Visible=�6[   5�   #   5�      5�      5�      P� 5�       �@m�Role$ SubmenuItem=�6&   . �5�      ��  � ��$	 Top=�63   �� 5�       � ��$	 0,2q�6,   5�      P� 5�       �@m�IsHighlighted . . �5�      ��  � ��# �  6/   5�      P� 5�       �@m�	IsPressed . . �5�      ��  � ��# �  6/   5�      P� 5�       � {� .  . �5�      ��  � ��# �  6/   5�      5�      5�      