   M S B A M L   `   `   `  ���� K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ZolyFramework.UI.Windows.Controls!ZolyFramework.UI.Windows.Controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0898    2ZolyFramework.UI.Windows.Controls.ZolyBottomAppBar  �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources   Key �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   	Collapsed	 R� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value   EasingFunction0  *System.Windows.Media.Animation.QuinticEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode   Visible   Hidden � RowDefinitions �Name ��Name # ZolyAppBarClosedBackgroundBrush ��Name5   /ZolyFramework.UI.Windows.Controls.ZolyTextBlock  Name �� TextAlignment �� Padding �� Triggers P� Property P� Value �� 
TargetName N� EnterActions ��Name  OpenStoryboard N� ExitActions  CloseStoryboard # ZolyAppBarOpenedBackgroundBrush ]� 
Conditions �� Property  �� Value5   /ZolyFramework.UI.Windows.Controls.ZolyTopAppBar8   2ZolyFramework.UI.Windows.Controls.ZolyAppBarButton " ZolyRaisedButtonHoverTextBrush! �� Orientation" �� ElementName#   Icon&   System.Windows.Media.TextOptions$   TextFormattingMode * &ZolyRaisedButtonFocusedBackgroundBrush & "ZolyRaisedButtonFocusedBorderBrush $  ZolyRaisedButtonFocusedTextBrush (	 $ZolyRaisedButtonHoverBackgroundBrush $
  ZolyRaisedButtonHoverBorderBrush * &ZolyRaisedButtonPressedBackgroundBrush & "ZolyRaisedButtonPressedBorderBrush $  ZolyRaisedButtonPressedTextBrush ' #ZolyRaisedButtonDisabledBorderBrush % !ZolyRaisedButtonDisabledTextBrush�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     8d2http://schemas.microsoft.com/expression/blend/2008  Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  <controls/clr-namespace:ZolyFramework.UI.Windows.Controls  %  '         7  7  '  �    7  7  '  �    �� "    .���  �@K�ZIndex$
 1000����  � ��$ Stretch=���  � �� �� "    ���� OpenStoryboard  .��T� $ (UIElement.Visibility)�$ OpenTextBlock��..�i� $ 0��#	 Z U� $ (FrameworkElement.Height)�$ Border��.\�  $
 0��$ 15Q�  $
 0:0:0.3��$	 105Q�   $ 	EaseInOut=�T� $ (UIElement.Visibility)�$ contentPresenter��..�i� $ 0:0:0.1��#	 Z �� CloseStoryboard  .��T� $ (UIElement.Visibility)�$ contentPresenter��..�i� $ 0:0:0.1��#	 Z U� $ (FrameworkElement.Height)�$ Border��.\�  $
 0��$	 105Q�  $
 0:0:0.3��$ 15Q�   $ 	EaseInOut=�T� $ (UIElement.Visibility)�$ OpenTextBlock��..�i� $ 0��	  	Collapsed=�i� $ 0:0:0.2��#	 Z .R��  �� $��* ��� $
��Auto �.+�� $ ContainerGrid��$
��Auto���� $ Border��$��1��$��15��#���  #��z��#��z��._�� }�. .+��� $ contentPresenter��$��Stretch=�$��Stretch=�$
��Auto��$y�Hidden=�  $ OpenTextBlock��$
��Wrap=�
�������$
��Auto��$��24(�$ Right=�$��Segoe UI Symbol)�$��Medium"�$ 0,0,11,0q�$	����$
��Auto��$��
0,-8.5,0,0q� P�  �@  IsOpen .  . ��� $ Border��# �   � ��P�  �@  IsOpen .  �� $$ OpenStoryboard_BeginStoryboard��8��   �� $% CloseStoryboard_BeginStoryboard��8�� . ��� $ Border��# �   � ��]�  ��  �@J�IsMouseOver  . ��  �@  IsOpen  .  ./��� $ Border��# �   � ���� "   .���  �@K�ZIndex$
 1000����  � ��$ Stretch=���  � �� �� "   ���� OpenStoryboard  .��T� $ (UIElement.Visibility)�$ OpenTextBlock��..�i� $ 0��#	 Z U� $ (FrameworkElement.Height)�$ Border��.\�  $
 0��$ 15Q�  $
 0:0:0.3��$	 105Q�   $ 	EaseInOut=�T� $ (UIElement.Visibility)�$ contentPresenter��..�i� $ 0:0:0.1��#	 Z �� CloseStoryboard  .��T� $ (UIElement.Visibility)�$ contentPresenter��..�i� $ 0:0:0.1��#	 Z U� $ (FrameworkElement.Height)�$ Border��.\�  $
 0��$	 105Q�  $
 0:0:0.3��$ 15Q�   $ 	EaseInOut=�T� $ (UIElement.Visibility)�$ OpenTextBlock��..�i� $ 0��	  	Collapsed=�i� $ 0:0:0.2��#	 Z .R��  �� $
��Auto ��� $��* �.+��� $ Border��$��15��#���  #��z��#��z��._�� }�. .+��� $ contentPresenter��$��Stretch=�$��Stretch=�$
��Auto��$y�Hidden=�  $ OpenTextBlock��$
��Wrap=�
�������$
��Auto��$��24(�$ Right=�$��Segoe UI Symbol)�$��Medium"�$ 0,0,11,0q�$	����$
��Auto��$��
0,-8.5,0,0q�� $ ContainerGrid��$��1��$
��Auto�� P�  �@ IsOpen .  . ��� $ Border��# �   � ��P�  �@ IsOpen .  �� $$ OpenStoryboard_BeginStoryboard��8��   �� $% CloseStoryboard_BeginStoryboard��8�� . ��� $ Border��# �   � ��]�  ��  �@J�IsMouseOver  . ��  �@ IsOpen  .  ./��� $ Border��# �   � ���� "   .���  � ��$ Segoe UI)���  � ��$ Stretch=���  � ��$ 90����  � ��$ 90����  � ��$ 0q���  � �� Z� ��  � ��
 ���� ��  � ��# �  ��  � ��$ Medium"���  � ��$ 15(���  � ��$ Center=���  � ��$ Center=���  � ��$ Stretch=���  � ��$	 5,0q���  � |� .  ��  �@��	IsEnabled .  ��  � �� �� "  .R��� #��z��#��z��
������ ._��� $! Vertical=�.+�� $
 grid��$��50��$��Center=�$��Stretch=����� *ActualHeight+$
" grid��.+�A� #��z��$��Stretch=�$��Stretch=��� $��Center=�$
��Auto��$��0q�$
��Wrap=�#��z# $��Center=�$
��Auto��$��Segoe UI Symbol)�$��22(�  #��z��#��z��$
��Wrap=�$ Center=�$��Disabled=�$��Center=�$��Bottom=�$$ Display=�$��0q�$��12(� P�  �@J�	IsFocused . . ��� # �   � ���� # �   � ���� # �   � ��P�  �@J�IsMouseOver . . ��� # � 	  � ���� # � 
  � ���� # �   � ��P�  �@J�AreAnyTouchesOver . . ��� # � 	  � ���� # � 
  � ���� # �   � ��P�  � �� . . ��� # �   � ���� # �   � ���� # �   � ��P�  � {� .  . ��� # �   � ���� # �   � ��