   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DownArrowGeometry   ComboBoxReadonlyToggleButton  �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels ��Name
 � Tag �� Padding	 � ColumnDefinitions
 F�Name4    .ZolyFramework.UI.Windows.Controls.ZolyComboBox & "ZolyComboBoxEnabledBackgroundBrush " ZolyComboBoxEnabledBorderBrush   ZolyComboBoxEnabledTextBrush ! ZolyComboBoxDisabledTextBrush �� RelativeSource �� AncestorLevel �� AncestorType  ZolyMenuItemBackgroundBrush   ZolyMenuItemEnabledTextBrush �� Triggers P� Property P� Value & "ZolyMenuItemPressedBackgroundBrush #	 ZolyMenuItemOverBackgroundBrush !
 ZolyMenuItemDisabledTextBrush �Name �Name � AllowsTransparency �� MaxDropDownHeight �� ElementName8   2ZolyFramework.UI.Windows.Controls.ZolyScrollViewer-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation d�Name    PlaceHolderForeground d� 	IsChecked �� Mode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate �� 
TargetName # ZolyComboBoxDisabledBorderBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  5      %�  &	        &	 -     '   8    �5      M 0 0 L 3.5 4 L 7 0 Z�6@   �� 5      "  d�61   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � �� .  6&   �� 5   
    � |� .  6&   �� 5   
    �@��	ClickMode$ Press=�6&   �� 5   
    � ��$ 1q�6,   �� 5   
    � �� 5      �� 5      " d�6"   .R�5      �� $ Chrome��6    . #��z��6H   $��1q�6t   #��z��6�   ._�5      � .+�5      �� $ PlaceHolderTextBlock��6(   #��z��6F   #y�z 6g   $��Center=�6�   $ 2,0,0,0q�6�   � 5      $��Right=�6#   $��20��6?   	 5   "   �� 5   &   $��3 �67   �� 5   &   .+�5   "   F� $
 Arrow��6�   $��1��6'   #��z��67   $��Center=�6[   $��3,1,0,0q�6x   $��Center=�6�   #���   6�   5      5      5       5!      5#      5$      �� 5%      "    6   .�5&   
   ��  � ��# �  6'   �� 5'   
    � ��# �  6(   �� 5(   
    � ��# �  6'   �� 5)   
    �@  PlaceHolderForeground# �  62   �� 5*   
    � ��$ 1q�6,   �� 5+   
    � ��$
 Auto=�6G   �� 5,   
    � ��$
 Auto=�6E   �� 5-   
    � ��$ 15(�6%   �� 5.   
    � ��$ 36��6#   �� 5/   
    � ��$
 Auto��6"   �� 50   
    � �� 51      �� 52      "  ��6   .�53      ��  � �� 6C   �� *HorizontalContentAlignment+ �� *FindAncestor+$ 1��" ���� 54       � �� 6A   �� *VerticalContentAlignment+ �� *FindAncestor+$ 1��" ���� 55       � ��$ 15(�61   �� 56       � ��$ Medium"�63   �� 57       �@��PanningMode$
 Both=�6A   �� 58       �@��IsFlicksEnabled .  6?   �� 59       � ��$	 4,3q�60   �� 5:       � ��# �  63   �� 5;       � ��# �  63   �� 5<       � ��# �  64   �� 5=       � ��$ 0q�68   �� 5>       � ��$ 36��6/   �� 5?       � �� 5@      �� 5A      " ��6.   .R�5B   "   �� $ Bd��6)   #��z��65   #��z��6_   ._�5C   &   �� $��Center=�67   #��z��6R   5D   #    5E   "   P� 5F   &    �@��
IsSelected . . �5G   *   �� # �  6G    � ��5H   '   P� 5I   &    �@J�IsMouseOver . . �5J   *   �� # � 	 6G    � ��5K   '   P� 5L   &    � {� .  . �5M   *   �� # � 
 6G    � ��5N   '   5P      5R      5S      5U      �� 5V   
    � �� 5W      �� 5X      "   6"   .R�5Y      � $ MainGrid��6    . 	 5Z      �� 5[      $��* �6/   �� 5\      #��� r�6/   $��0 �6�   .+�5^      � $ 
PART_Popup��6+   $��1q�6     . $��Bottom=�6�   $��Slide=�6�   $��2��6�   ��6Y   �� *IsDropDownOpen+ �� *TemplatedParent+.��5_      �� $ DropDownBorder��6%   #��z��6=   #��z 6g   #��z��6�   $��1q�6�   ��6�   �� *ActualWidth+$ MainGrid��._�5`   "     ��. .��5a   &   �� # z 65   $ 	Contained=�6q   5b   #   5c      5d      d� 5e      $ PlaceHolderToggleButton��6'   #���  6H   #��z��6   #��z��6�   #��z 6�   $��2��6
  $��0��5f       5g      �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+��6~   �� *PlaceHolder+ �� *TemplatedParent+�� 5h      $��0��6+   #��z��5i      $	��4,3q�6^    .  # z 6�   #��z 6�   #��z 6�   #��z��6*  $��Center=�6k  5j       5k      P� 5l       �@��HasItems .  . �5m      �� $ DropDownBorder��67    � ��$ 95��6S   5n      P� 5o       � {� .  . �5p      �� # �  6;    � ���� 5q      # �  6<    � ��5r      P� 5s       �@��
IsGrouping . . �5t      ��  � �� .  6N   5u      5w      5y      5z      5}      