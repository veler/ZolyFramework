   M S B A M L   `   `   `  ����K  GZolyFramework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]@clr-namespace:ZolyFramework.UI.Windows;assembly=ZolyFramework.UIZolyFramework.UI.Windows  5   	   [?clr-namespace:ZolyFramework.UI.Layout;assembly=ZolyFramework.UIZolyFramework.UI.Layout  5   	   	 Theme:   4ThemeSample.Responsive_Window.ResponsiveLayoutWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Twindows@clr-namespace:ZolyFramework.UI.Windows;assembly=ZolyFramework.UI     5   	   Rlayout?clr-namespace:ZolyFramework.UI.Layout;assembly=ZolyFramework.UI     5   	   -   5        )   #ZolyFramework.UI.Windows.ZolyWindow   Name$  
ZolyWindow��5       � Title$ ResponsiveWindow��5   	   $	��500��6"   $
��1000��6/    � 	Resources 5         MiddleStoryboard �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  SmallStoryboard��%  &	        &	 �     �� 5   
   .��5	      U� $ (FrameworkElement.Width)�6&   $ PaneGrid��6[   .\�5
   	     $ 0��6   $	 500Q�6*     5   	   $ 0:0:0.4��6   $	 250Q�60    5   
     5      $ 	EaseInOut=�6   5   
   5   	   5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6)   $ PaneGrid��6^   .\�5        $ 0��6!   $	 250Q�6-     5      $ 0:0:0.4��6!   $	 150Q�63    5        5      $ 	EaseInOut=�6   5      5      5      5      /   )ZolyFramework.UI.Windows.ResponsiveWindow	   ResponsiveLayout	 5   
   5   /ZolyFramework.UI.Layout.ResponsiveLayoutManager  3   -ZolyFramework.UI.Layout.ResponsiveLayoutState  5      
   StoryboardName$
 SmallStoryboard��6+      MaxWidth$	 400Q�6L     5       $
 MiddleStoryboard��6+   $	 700Q�6M   5!      .��5#      � .+�5$   
   � -   5         �Name$ PaneGrid��5$        
ThemeBrush#���  6!   $
��Left=�6K   $	��500��6f   �� 5%   
   $��Layout content��6   $��Right=�6)   $��
0,161,26,0q�6E   $��26��6Y   $	��Top=�6e   � 5'   
   -   5        $ DragGrid��5'      $��26��6!   $	��Top=�6-   5(      5)      