   M S B A M L   `   `   `  ���� K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ZolyFramework.UI.WindowsZolyFramework.UI.Windows  I)clr-namespace:ZolyFramework.UI.ConvertersZolyFramework.UI.Converters  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089A    ;ZolyFramework.UI.Converters.ResizeModeToVisibilityConverter #  ResizeModeToVisibilityConverter @ <ResizeModeToVisibilityConverterForRestoreButtonGroupAndThumb     CanMinimizeB   <ZolyFramework.UI.Converters.WindowStateToVisibilityConverter , (WindowStateToVisibilityConverterMaximize   	Maximized   Normal + 'WindowStateToVisibilityConverterRestoreA   ;ZolyFramework.UI.Converters.WindowStateToThicknessConverter 6 2WindowStateToThicknessConverterForZolyWindowBorder   	Maximized   Normal   	Minimized=   7ZolyFramework.UI.Converters.BooleanToThicknessConverter  BooleanToThicknessConverter  ZolyWindowChromeButtonStyle �� 
TargetType �� Property �� Value  	TextBrush	 �� 
TargetType&   System.Windows.Media.TextOptions
   TextFormattingMode �� Triggers P� Property P� Value  
HoverBrush 	 TextHoverBrush 
 PressedBrush  TextPressedBrush)   #ZolyFramework.UI.Windows.ZolyWindow3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Opacity   RenderingBias  ZolyWindowDropShadowBrush   Color �� 	Converter �� RelativeSource � ColumnDefinitions � RowDefinitions n�Name J� Opacity � Cursor
 � Tag  ZolyWindowBorderBrush  ZolyWindowBackgroundBrush �Name �� ContentStringFormat �� ContentStringFormat J� SnapsToDevicePixels �� Orientation  ��Name! � ToolTip�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     2windows&clr-namespace:ZolyFramework.UI.Windows  8
converters)clr-namespace:ZolyFramework.UI.Converters  8d2http://schemas.microsoft.com/expression/blend/2008  Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  %�  &	        &	      &	      &	 =     &	 `     &	 �     &	 �     '  �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7         $  	Collapsed=�  $ 	Collapsed=�$ Visible=�  $ Visible=�$ 	Collapsed=�  $ -9q�$ 10q�$ 10q�  �� " ��.���  � ��$ Marlett)���  � ��$ 14(���  � ��$ Right=���  � ��$	 Top=���  � ��$ 26����  � ��$ 34����  � |� .  ��  � �� Z� ��  � ��
 ���� ��  � ��# �  ��  � �� �� "	 ��.R��� $��0q�#��z��._��� #��z��$	��Top=�$��Disabled=�$��Center=�$��Center=�$
 Display=� P�  �@J�IsMouseOver . . ��� # �   � ���� # � 	  � ��P�  �@J�AreAnyTouchesOver . . ��� # �   � ���� # � 	  � ��P�  � �� . . ��� # � 
  � ���� # �   � ���� "  .���  �@�Title$ 
ZolyWindow����  �@�WindowStyle$
 None=���  �@�AllowsTransparency . ��  � ��
 ���� ��  �@J�SnapsToDevicePixels . ��  �@�
ResizeMode$ CanResizeWithGrip=���  � ��$	 100����  � ��$	 100����  �@�UseLayoutRounding . ��  �@J�Effect   $ 8Q�$ 0Q�$	 0.4Q�$ Performance=�# �  ��  � �� �� "	  .R�� 
������ ���� *WindowState+8    �� *TemplatedParent+ �� $��8 ��� $��* ��� $��8 � �� $��8 ��� $
��Auto ��� $��* ��� $��8 �.+�n� $ Thumb1��$ 0Q�$��0��$��0��$ SizeNWSE��$ TL��y��� *
ResizeMode+8   �� *TemplatedParent+n� $ Thumb2��$ 0Q�$��0��$��2��$ SizeNESW��$ TR��y��� *
ResizeMode+8   �� *TemplatedParent+n� $ Thumb3��$ 0Q�$��3��$��0��$ SizeNESW��$ BL��y��� *
ResizeMode+8   �� *TemplatedParent+n� $ Thumb4��$ 0Q�$��3��$��2��$ SizeNWSE��$ BR��y��� *
ResizeMode+8   �� *TemplatedParent+n� $ Thumb5��$ 0Q�$��0��$��1��$ SizeNS��$ T��y��� *
ResizeMode+8   �� *TemplatedParent+n� $ Thumb6��$ 0Q�$��3��$��1��$ SizeNS��$ B��y��� *
ResizeMode+8   �� *TemplatedParent+n� $ Thumb7��$ 0Q�$��1��$��0��$��2��$ SizeWE��$ L��y��� *
ResizeMode+8   �� *TemplatedParent+n� $ Thumb8��$ 0Q�$��1��$��2��$��2��$ SizeWE��$ R��y��� *
ResizeMode+8   �� *TemplatedParent+�� $��1��$��1��$��2��#���  ���� *
ShowBorder+8 	  �� *TemplatedParent+._�� #���  .+�� $ DragZoneGrid��$	��Top=����� *CloseButton.ActualHeight+ �� *TemplatedParent+� $��0q�.+��� #��z��#��z��# z $��0q���. # z �� $ 
Horizontal=�$	��Top=�$��Right=�$��RightToLeft=�.+��� $  CloseButton��8��
 $��r��$! Close��� y��� *
ResizeMode+8   �� *TemplatedParent+.+��� $  RestoreButton��8�� $��2��$! Restore Down��y��� *WindowState+8   �� *TemplatedParent+�� $  MaximizeButton��8�� $��1��$! Maximize��y��� *WindowState+8   �� *TemplatedParent+�� $  MinimizeButton��8�� $��0��$! Minimize��y��� *
ResizeMode+8   �� *TemplatedParent+