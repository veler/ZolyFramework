   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0897    1ZolyFramework.UI.Windows.Controls.ZolyProgressBar  �� 
TargetType �� Property    ZolyProgressBarProgressBrush �� Value " ZolyProgressBarBackgroundBrush  ZolyProgressBarBorderBrush �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� RepeatBehavior	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  5      %�  '         �� 5
      "    6   .�5   
   ��  � ��# �   6'   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6(   �� 5   
    � ��$ 0q�6,   �� 5   
    � �� 5      �� 5      "   6"   .R�5      � $ TemplateRoot��6    5        5      CommonStates��. 5   "     Determinate��6.     5   "   Indeterminate��. 5   &   �� $ Forever��61   .��5   *   U� $V	 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6H   $
 	Animation��6�   .\�5   .     $ 0��6C   $
 0.25Q�6O     5   .   $ 0:0:1��6C   $
 0.25Q�6S     5   .   $ 0:0:2��6C   $
 0.25Q�6S   5   +   *� 5   *   $'	 !(UIElement.RenderTransformOrigin)�6G   $
 	Animation��6�   .'�5   .     $ 0��6B   $ -0.5,0.5&�6N     5   .   $ 0:0:1��6B   $ 0.5,0.5&�6R     5    .   $ 0:0:2��6B   $ 1.5,0.5&�6R   5!   +   5"   '   5#   #   5$      .+�5&      �� #��z��6!   #��z��6M   #��z��6�   �� 5'      $ 
PART_Track��6$   � 5(      $ PART_Indicator��6   }�. $
��Left=�6K   .+�5)      �� $ 	Indicator��6(   #��z��6;   �� 5*      $ 	Animation��6(   #��z��6;   $ 0.5,0.5&�6_   z�5+   "   V� 5,   &   .~�5-   *   �� �� 5.   *   �� 5/   *   T� 50   *   51   '   53      54      55       56      P� 57       �@�Orientation$ Vertical=�69   . �58      �� $ TemplateRoot��6@    �@�LayoutTransform 59   "   �� 5:   &   $	 -90Q�66   5<      5=      P� 5>       �@�IsIndeterminate . . �5?      �� $ 	Indicator��6;    � y�$ 	Collapsed=�6R   5@      5B      5D      5E      5H      