   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  5      I)clr-namespace:ZolyFramework.UI.ConvertersZolyFramework.UI.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089E    ?ZolyFramework.UI.Converters.BooleanToVerticalAlignmentConverter '  #BooleanToVerticalAlignmentConverter7   1ZolyFramework.UI.Windows.Controls.ZolyPasswordBox  �� 
TargetType �� Property �� Value % !ZolyTextBoxEnabledBackgroundBrush ! ZolyTextBoxEnabledBorderBrush  ZolyTextBoxEnabledTextBrush   ZolyTextBoxDisabledTextBrush-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name J� SnapsToDevicePixels5   /ZolyFramework.UI.Windows.Controls.ZolyTextBlock  Name   PlaceHolderForeground � Cursor	 �� Padding
 �� RelativeSource �� 	Converter6   0ZolyFramework.UI.Windows.Controls.ZolyFlatButton  Name8   2ZolyFramework.UI.Windows.Controls.ZolyScrollViewer  Name$ �� HorizontalScrollBarVisibility" �� VerticalScrollBarVisibility �� Triggers P� Property P� Value �� 
TargetName " ZolyTextBoxDisabledBorderBrush �� Triggers ]� 
Conditions �� Property �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  5      8
converters)clr-namespace:ZolyFramework.UI.Converters  5      %  &	        '       7   7      5      65   �� 5      "   6   .�5   
   ��  � ��$ 36��6#   �� 5   
    � ��$
 Auto��6"   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6(   �� 5   
    � ��# �  6'   �� 5   
    �@ PlaceHolderForeground# �  62   �� 5   
    � ��$ 1q�6,   �� 5   
    �@ TabNavigation$
 None=�6=   �� 5   
    � ��$
 Left=�67   �� 5   
    �@�FocusVisualStyle 6-   Z� �� 5   
    �@J�	AllowDrop . 6&   �� 5   
    �@��PanningMode$ VerticalFirst=�65   �� 5   
    �@��IsFlicksEnabled .  63   �� 5   
    � ��$ 15(�6%   �� 5   
    � �� 5      �� 5       "  6"   .R�5!      �� $ border��6   #��z��6-   #��z��6Y   #��z��6�    . ._�5"      � .+�5#        $ PlaceHolderTextBlock��65   #��z 6S   $ IBeam��6s  $	 2,0,0,0q�6�  ��6�   �� *PlaceHolder+
 �� *TemplatedParent+��6�   �� *AcceptsReturn+8   
 �� *TemplatedParent+6�  ]� 5$      ��. $��RightToLeft=�6=   .+�5%   "     $  ViewPasswordZolyFlatButton��6:   #{�z{�6^   $��0q�6�   |�.  $��15(�6�   $��Segoe UI Symbol)�6�   $	����6�   $��Right=�6�   $��36��6  $��Center=�6    5&   "   $ PART_ContentHost��6<   #��z��6V   |�.  
������ #��z 6�   #��z 6  ��6M  �� *AcceptsReturn+8  
 �� *TemplatedParent+5'      5(      5)       5*      P� 5+       �@J�	IsFocused . 5-      P� 5.       �@J�IsKeyboardFocused . 50      P� 51       �@J�IsMouseOver . 53      P� 54       �@J�AreAnyTouchesOver . 56      P� 57       � {� .  . �58      �� $ border��6<   # �  6P    � ���� 59      # �  6;    � ��5:      5<      5>       5?   
   ]� 5@       5A      �� 5B      + �@��#IsInactiveSelectionHighlightEnabled . 6O   �� 5C       �@��IsSelectionActive .  6=   ./�5E      ��  �@��SelectionBrush# � /�63   5F      5H      5K      