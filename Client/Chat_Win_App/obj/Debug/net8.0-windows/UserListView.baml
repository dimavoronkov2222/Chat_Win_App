   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Chat_Win_App   Chat_Win_App.UserListView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  	User List��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.   
������� � WindowStyle$
 None=�5
        � AllowsTransparency$
 True��63    � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   ShadowEffect   ShadowDepth   
BlurRadius   Opacity  PlaceholderTextBoxStyle	 �� 
TargetType
 �� Property �� Value �� 
TargetType �� RelativeSource �� Mode �� UpdateSourceTrigger ��Name J� IsHitTestVisible �� Triggers P� Property P� Value �� 
TargetName �� Empty��%�  &	        &	 8       5   
   $ 5Q�60   $ 10Q�6@   $	 0.3Q�6P   �� 5   
   "	 ��60   .�5      �� 
 � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� 
������ $��0q�5   ?   $��10q�6S   ��5   &   �� *Text+ �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=�5   S   �� 5      $ Placeholder��6(   $��Search users...��6=   
�������$��Center=�5   (   $��10,0,0,0q�6C   $ False��5   (   5       5      P� 5       � ��$  ��66   . �5   "   �� $ Placeholder��6)   
 � y�$ Visible=�6X   5      P� 5       66   Z�  � ��. �5   "   �� $ Placeholder��6)   
 � y�$ Visible=�6X   5      P� 5      # Z 66    � ��. �5    "   �� $ Placeholder��6)   
 � y�$ Visible=�6X   5!      P� 5"       � ��$ *��66   . �5#   "   �� $ Placeholder��6)   
 � y�$ 	Collapsed=�6X   5$      5&      5(      5)      5*      .��5+      � $��10q�6   .+�5,   
   �� $��	User List��6   $��24(�6%   $
��Bold"�63   ���	#FF3E8EDE$��Center=�5-      $	��Top=�61   $��0,10,0,0q�6I   �� 5.   
   
������� �� CornerRadius$ 5��6$   ���	#FF3E8EDE$��2q�6M   $��0,50,0,0q�5/      $��Center=�6#   $	��Top=�6@   $	��300��6X   $��35��6d   ._�50      �� #��[ 6   51      �� 52   
   -   5         ��Name$ UserListBox��52      $��	0,100,0,0q�6(   $	��Top=�6;   
������ ��53      �� 54      .R�55      ��  �� Orientation$ 
Horizontal=�6!   .+�56      A� $��40��6"   $��40��6-   
�������$��0,0,10,0q�6E   �� 57      .+�58      �� $
��Bold"�6B   $��16(�6T   ��6(   �� *
UserName+6T   �� 59      $��Italic$�6@   
���������6(   �� *Status+6S   5:      5;      5<      5>      �� 5?   
   -   5        $��X��5?      $��30��6   $��30��6(   $��	0,0,10,10q�64   $��Right=�5@      $	��Top=�6-   
������ 
�������$��0q�5B      $
��Bold"�6%    � Cursor$
 Hand��5C      6   5D      5E      