   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0892    ,ZolyFramework.UI.Windows.Controls.ZolyFlyout  �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources   Key �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value	   EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase
   
EasingMode<  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� KeyTime p� Value   EasingFunction � ColumnDefinitions �Name ��Name  ZolyFlyoutBorderBrush  ZolyFlyoutBackgroundBrush � RowDefinitions6   0ZolyFramework.UI.Windows.Controls.ZolyFlatButton  Name  ZolyFlyoutForegroundBrush5   /ZolyFramework.UI.Windows.Controls.ZolyTextBlock �� RelativeSource ��Name �� Triggers :� RoutedEvent  OpeningStoryboard>   8ZolyFramework.UI.Windows.Controls.ZolyFlyoutContentPanel  	TextBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  5      %   '         7  '  b    �� 5
      "    6   .�5   
   ��  �@K�ZIndex$
 1040��6)   �� 5   
    � �� 5      �� 5      "   6"    5      ���� 5      OpeningStoryboard  .��5      U� $ (FrameworkElement.Width)�6<   $ FlyoutBorder��6q   .\�5   "     $ 0��67   $ 0Q�6C     5   "   $ 0:0:0.3��67   $	 330Q�6I   	 5   &     5   *   $
 EaseOut=�65   5   #   5      U� 5      $ (UIElement.Opacity)�6<   $ 
HeaderGrid��6l   .\�5   "     $ 0��67   $ 0Q�6C     5   "   $ 0:0:0.1��67   $ 0Q�6I     5   "   $ 0:0:0.5��67   $ 1Q�6I   	 5   &     5   *   $
 EaseOut=�65   5    #   5!      r� 5"      $ (FrameworkElement.Margin)�6?   $ 
HeaderGrid��6u   .	�5#   "     $ 0��6:   $ 50,0,0,0q�6F     5$   "   $ 0:0:0.1��6:   $ 50,0,0,0q�6L     5%   "   $ 0:0:0.5��6:   $ 0q�6L    5&   &     5'   *   $
 EaseOut=�65   5)   #   5*      U� 5+      $ (UIElement.Opacity)�6<   $ contentPresenter��6l   .\�5,   "     $ 0��67   $ 0Q�6C     5-   "   $ 0:0:0.1��67   $ 0Q�6I     5.   "   $ 0:0:0.5��67   $ 1Q�6I   	 5/   &     50   *   $
 EaseOut=�65   52   #   53      r� 54      $ (FrameworkElement.Margin)�6?   $ contentPresenter��6u   .	�55   "     $ 0��6:   $ 80,0,0,0q�6F     56   "   $ 0:0:0.1��6:   $ 80,0,0,0q�6L     57   "   $ 0:0:0.5��6:   $ 20,0,0,0q�6L    58   &     59   *   $
 EaseOut=�65   5;   #   5<      5=      5>      .R�5?      � $	��400��6   $	��200��6*    5@      �� 5A      $��* �6/   �� 5B      $
��Auto �6/   .+�5D      � $ ContainerGrid��6   
������ $��0��6O   $
��Auto��6_   �� 5E      $ FlyoutBorder��6!   $��1��67   $��0q�6G   $��1,0,0,0q�6R   #���  6l   #���  6�   $��Stretch=�6�   $��Right=�6�   $	��315��6  ._�5F      �  5G   "   �� 5H   &   $��75 �64   �� 5I   &   $��1* �64   .+�5K   "   � $ 
HeaderGrid��6'   $��0��6;   $��	15,15,0,0q�6H    5L   &   �� 5M   *   $��75 �6;   �� 5N   *   $��1* �6;   .+�5P   &     $ CloseZolyFlatButton��6>   $��Segoe UI Symbol)�6[   $	����6x   $��Stretch=�6�   $��0q�6�   $��Stretch=�6�   $
��Auto��6�   $��0��6�   $
��Auto��6�   $��32(�6�   #���  6	  $��Normal"�6B    5Q   &   $��1��6=   $��Center=�6�   $��CharacterEllipsis=�6�   $��20(�6�   #���  6�   ��6M   �� *Content.Title+ �� *TemplatedParent+6�   5R   #   � 5S   "   $��1��6'   ��64   �� *Content.Content.Background+ �� *TemplatedParent+.+�5T   &   �� $ contentPresenter��67   $��20,0,0,0q�6Q   $��Right=�6c   $��Stretch=�6   5U   #   5V      5W      5X       5Y      :� 5Z      $  controls:ZolyFlyout.Opened��6'   .[�5[      �� 8��  6.   5\      5^      5`      5a      �� 5e      "   6   .�5f   
   ��  � ��$ 0,15,0,0q�6$   �� 5g   
    � ��# �  6'   �� 5h   
    � ��$ 15(�6%   �� 5i   
    � ��$	 100��6&   �� 5j   
    � ��$	 300��6%   �� 5k   
    � ��$	 300��6%   �� 5l   
    � ��$	 300��6"   �� 5m   
    � �� 5n      �� 5o      "  6"   .R�5p      �� 5q      5s      5t      5w      