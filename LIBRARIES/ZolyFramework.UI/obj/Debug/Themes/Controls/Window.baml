   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ZolyFramework.UI.WindowsZolyFramework.UI.Windows  5      I)clr-namespace:ZolyFramework.UI.ConvertersZolyFramework.UI.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089A    ;ZolyFramework.UI.Converters.ResizeModeToVisibilityConverter #  ResizeModeToVisibilityConverter @ <ResizeModeToVisibilityConverterForRestoreButtonGroupAndThumb     CanMinimizeB   <ZolyFramework.UI.Converters.WindowStateToVisibilityConverter , (WindowStateToVisibilityConverterMaximize   	Maximized   Normal + 'WindowStateToVisibilityConverterRestoreA   ;ZolyFramework.UI.Converters.WindowStateToThicknessConverter 6 2WindowStateToThicknessConverterForZolyWindowBorder   	Maximized   Normal   	Minimized=   7ZolyFramework.UI.Converters.BooleanToThicknessConverter  BooleanToThicknessConverter  ZolyWindowChromeButtonStyle �� 
TargetType �� Property �� Value  	TextBrush	 �� 
TargetType&   System.Windows.Media.TextOptions
   TextFormattingMode �� Triggers P� Property P� Value  
HoverBrush 	 TextHoverBrush 
 PressedBrush  TextPressedBrush)   #ZolyFramework.UI.Windows.ZolyWindow3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Opacity   RenderingBias  ZolyWindowDropShadowBrush   Color �� 	Converter �� RelativeSource � ColumnDefinitions � RowDefinitions n�Name J� Opacity � Cursor
 � Tag  ZolyWindowBorderBrush  ZolyWindowBackgroundBrush �Name �� ContentStringFormat �� ContentStringFormat J� SnapsToDevicePixels �� Orientation  ��Name! � ToolTip�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      2windows&clr-namespace:ZolyFramework.UI.Windows  5      8
converters)clr-namespace:ZolyFramework.UI.Converters  5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      %l  &	        &	      &	 6     &	 l     &	 �     &	 �     &	 �     '  �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7      5      61      5      $  	Collapsed=�6v     5      $ 	Collapsed=�6c   $ Visible=�6y     5      $ Visible=�6b   $ 	Collapsed=�6v     5      $ -9q�6l   $ 10q�6{   $ 10q�6�     5      6-   �� 5      " ��60   .�5   
   ��  � ��$ Marlett)�6'   �� 5   
    � ��$ 14(�6%   �� 5   
    � ��$ Right=�60   �� 5   
    � ��$	 Top=�6.   �� 5   
    � ��$ 26��6#   �� 5   
    � ��$ 34��6"   �� 5   
    � |� .  6&   �� 5   
    � �� 6(   Z� �� 5   
    � ��
 ���� 6'   �� 5   
    � ��# �  6'   �� 5   
    � �� 5       �� 5!      "	 ��6"   .R�5"      �� $��0q�6   #��z��61   ._�5#      �� #��z��6)   $	��Top=�6M   $��Disabled=�6l   $��Center=�6�   $��Center=�6�   $
 Display=�6�   5$       5%      P� 5&       �@J�IsMouseOver . . �5'      �� # �  6;    � ���� 5(      # � 	 6;    � ��5)      P� 5*       �@J�AreAnyTouchesOver . . �5+      �� # �  6;    � ���� 5,      # � 	 6;    � ��5-      P� 5.       � �� . . �5/      �� # � 
 6;    � ���� 50      # �  6;    � ��51      53      55      56      �� 58      "  6   .�59   
   ��  �@�Title$ 
ZolyWindow��6"   �� 5:   
    �@�WindowStyle$
 None=�6(   �� 5;   
    �@�AllowsTransparency . 6/   �� 5<   
    � ��
 ���� 6'   �� 5=   
    �@J�SnapsToDevicePixels . 60   �� 5>   
    �@�
ResizeMode$ CanResizeWithGrip=�6'   �� 5?   
    � ��$	 100��6&   �� 5@   
    � ��$	 100��6%   �� 5A   
    �@�UseLayoutRounding . 6.   �� 5B   
    �@J�Effect 5C        5D      $ 8Q�6#   $ 0Q�62   $	 0.4Q�6B   $ Performance=�6P   # �  6l   5F      �� 5G   
    � �� 5H      �� 5I      "	  6"   .R�5J      � 
������ ��64   �� *WindowState+8    �� *TemplatedParent+ 5K      �� 5L      $��8 �6/   �� 5M      $��* �6/   �� 5N      $��8 �6/    5P      �� 5Q      $��8 �6,   �� 5R      $
��Auto �6,   �� 5S      $��* �6,   �� 5T      $��8 �6,   .+�5W      n� $ Thumb1��6    $ 0Q�6�   $��0��6�   $��0��6�   $ SizeNWSE��6  $ TL��6  y�60   �� *
ResizeMode+8   �� *TemplatedParent+6  n� 5X      $ Thumb2��6    $ 0Q�6�   $��0��6�   $��2��6�   $ SizeNESW��6  $ TR��6  y�60   �� *
ResizeMode+8   �� *TemplatedParent+6  n� 5Y      $ Thumb3��6    $ 0Q�6�   $��3��6�   $��0��6�   $ SizeNESW��6  $ BL��6  y�60   �� *
ResizeMode+8   �� *TemplatedParent+6  n� 5Z      $ Thumb4��6    $ 0Q�6�   $��3��6�   $��2��6�   $ SizeNWSE��6  $ BR��6  y�60   �� *
ResizeMode+8   �� *TemplatedParent+6  n� 5[      $ Thumb5��6    $ 0Q�6�   $��0��6�   $��1��6�   $ SizeNS��6  $ T��6  y�60   �� *
ResizeMode+8   �� *TemplatedParent+6  n� 5\      $ Thumb6��6    $ 0Q�6�   $��3��6�   $��1��6�   $ SizeNS��6  $ B��6  y�60   �� *
ResizeMode+8   �� *TemplatedParent+6  n� 5]      $ Thumb7��6    $ 0Q�6�   $��1��6�   $��0��6�   $��2��6  $ SizeWE��6  $ L��6&  y�60   �� *
ResizeMode+8   �� *TemplatedParent+6&  n� 5^      $ Thumb8��6    $ 0Q�6�   $��1��6�   $��2��6�   $��2��6  $ SizeWE��6  $ R��6&  y�60   �� *
ResizeMode+8   �� *TemplatedParent+6&  �� 5a      $��1��6!   $��1��6.   $��2��6>   #���  5c      ��5b      �� *
ShowBorder+8 	  �� *TemplatedParent+._�5d      � #���  6#   .+�5e   "   � $ DragZoneGrid��6'   $	��Top=�6=   ��6U   �� *CloseButton.ActualHeight+ �� *TemplatedParent+� 5f   "   $��0q�6'   .+�5g   &   �� #��z��5h      #��z��5i      # z 5j      $��0q�5k      ��. # z 5m      5n   #   �� 5o   "   $ 
Horizontal=�6-   $	��Top=�6F   $��Right=�6^   $��RightToLeft=�6z   .+�5q   &   �� $  CloseButton��6-   8��
 $��r��6w   $! Close��6�   � 5r   &   y�6+   �� *
ResizeMode+8   �� *TemplatedParent+.+�5t   *   �� $  RestoreButton��61   8�� $��2��6}   $! Restore Down��6�   y�5u   -   �� *WindowState+8   �� *TemplatedParent+�� 5w   *   $  MaximizeButton��61   8�� $��1��6~   $! Maximize��6�   y�5x   -   �� *WindowState+8   �� *TemplatedParent+5y   '   �� 5{   &   $  MinimizeButton��6-   8�� $��0��6z   $! Minimize��6�   y�5|   )   �� *
ResizeMode+8   �� *TemplatedParent+5}   #   5~      5      5�      5�      5�      5�      5�      