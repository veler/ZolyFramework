   M S B A M L   `   `   `  ���� K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0892    ,ZolyFramework.UI.Windows.Controls.ZolyFlyout  �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources   Key �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value	   EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase
   
EasingMode<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value   EasingFunction � ColumnDefinitions �Name ��Name  ZolyFlyoutBorderBrush  ZolyFlyoutBackgroundBrush � RowDefinitions6   0ZolyFramework.UI.Windows.Controls.ZolyFlatButton  Name  ZolyFlyoutForegroundBrush5   /ZolyFramework.UI.Windows.Controls.ZolyTextBlock �� RelativeSource ��Name �� Triggers :� RoutedEvent  OpeningStoryboard>   8ZolyFramework.UI.Windows.Controls.ZolyFlyoutContentPanel  	TextBrush�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     8d2http://schemas.microsoft.com/expression/blend/2008  Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  %�  '         7  '  �    �� "    .���  �@K�ZIndex$
 1040����  � �� �� "    ���� OpeningStoryboard  .��U� $ (FrameworkElement.Width)�$ FlyoutBorder��.\�  $ 0��$ 0Q�  $ 0:0:0.3��$	 330Q�	   $
 EaseOut=�U� $ (UIElement.Opacity)�$ 
HeaderGrid��.\�  $ 0��$ 0Q�  $ 0:0:0.1��$ 0Q�  $ 0:0:0.5��$ 1Q�	   $
 EaseOut=�r� $ (FrameworkElement.Margin)�$ 
HeaderGrid��.	�  $ 0��$ 50,0,0,0q�  $ 0:0:0.1��$ 50,0,0,0q�  $ 0:0:0.5��$ 0q�   $
 EaseOut=�U� $ (UIElement.Opacity)�$ contentPresenter��.\�  $ 0��$ 0Q�  $ 0:0:0.1��$ 0Q�  $ 0:0:0.5��$ 1Q�	   $
 EaseOut=�r� $ (FrameworkElement.Margin)�$ contentPresenter��.	�  $ 0��$ 80,0,0,0q�  $ 0:0:0.1��$ 80,0,0,0q�  $ 0:0:0.5��$ 20,0,0,0q�   $
 EaseOut=�.R�� $	��400��$	��200�� �� $��* ��� $
��Auto �.+�� $ ContainerGrid��
������ $��0��$
��Auto���� $ FlyoutBorder��$��1��$��0q�$��1,0,0,0q�#���  #���  $��Stretch=�$��Right=�$	��315��._��  �� $��75 ��� $��1* �.+�� $ 
HeaderGrid��$��0��$��	15,15,0,0q� �� $��75 ��� $��1* �.+�  $ CloseZolyFlatButton��$��Segoe UI Symbol)�$	����$��Stretch=�$��0q�$��Stretch=�$
��Auto��$��0��$
��Auto��$��32(�#���  $��Normal"�  $��1��$��Center=�$��CharacterEllipsis=�$��20(�#���  ���� *Content.Title+ �� *TemplatedParent+� $��1������ *Content.Content.Background+ �� *TemplatedParent+.+��� $ contentPresenter��$��20,0,0,0q�$��Right=�$��Stretch=� :� $  controls:ZolyFlyout.Opened��.[��� 8��  �� "   .���  � ��$ 0,15,0,0q���  � ��# �  ��  � ��$ 15(���  � ��$	 100����  � ��$	 300����  � ��$	 300����  � ��$	 300����  � �� �� "  .R��� 