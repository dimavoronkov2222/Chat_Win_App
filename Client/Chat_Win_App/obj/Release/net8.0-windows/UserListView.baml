   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   Chat_Win_App   Chat_Win_App.UserListView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6sys&clr-namespace:System;assembly=mscorlib       � Title$  	User List��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�
������� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � 	Resources 3  -System.Windows.Media.Effects.DropShadowEffect   ShadowEffect   ShadowDepth   
BlurRadius   Opacity  PlaceholderTextBoxStyle	 �� 
TargetType
 �� Property �� Value �� 
TargetType �� RelativeSource �� Mode �� UpdateSourceTrigger ��Name J� IsHitTestVisible �� Triggers P� Property P� Value �� 
TargetName �� Empty��%S  &	        &	         $ 5Q�$ 10Q�$	 0.3Q��� "	 ��.��� 
 � �� �� " ��.R�� .+��� 
������ $��0q�$��10q����� *Text+ �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=��� $ Placeholder��$��Search users...��
�������$��Center=�$��10,0,0,0q�$ False�� P�  � ��$  ��. ��� $ Placeholder��
 � y�$ Visible=�P�  Z�  � ��. ��� $ Placeholder��
 � y�$ Visible=�P� # Z  � ��. ��� $ Placeholder��
 � y�$ Visible=�P�  � ��$ *��. ��� $ Placeholder��
 � y�$ 	Collapsed=�.��� $��10q�.+��� $��	User List��$��24(�$
��Bold"����	#FF3E8EDE$��Center=�$	��Top=�$��0,10,0,0q��� 
������� �� CornerRadius$ 5�����	#FF3E8EDE$��2q�$��0,50,0,0q�$��Center=�$	��Top=�$	��300��$��35��._��� #��[ �� -    ��Name$ UserListBox��$��	0,100,0,0q�$	��Top=�
������ ���� .R���  �� Orientation$ 
Horizontal=�.+�A� $��40��$��40��
�������$��0,0,10,0q��� .+��� $
��Bold"�$��16(����� *
UserName+�� $��Italic$�
����������� *Status+�� -   $��X��$��30��$��30��$��	0,0,10,10q�$��Right=�$	��Top=�
������ 
�������$��0q�$
��Bold"� � Cursor$
 Hand��