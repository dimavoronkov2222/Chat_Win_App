   M S B A M L   `   `   `  ����   Chat_Win_App    Chat_Win_App.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � Title$  Chat Application��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�
������� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � 	Resources 3  -System.Windows.Media.Effects.DropShadowEffect   ShadowEffect   ShadowDepth   
BlurRadius   Opacity	 �� 
TargetType
 �� Property �� Value��%�  &	        '��       7   '�� �     7     $ 5Q�$ 10Q�$	 0.3Q��� "	 ��.��� 
 � ��$ 0q��� 
 � �� �#FFF�� 
 � ��$ 10q��� 
 � ��$ 5q��� 
 �@J�Effect8   �� "	 ��.��� 
 � ��$ 16(��� 
 � ��$
 Bold"��� 
 �@�Cursor$
 Hand���� 
 � ��$ 5,0,0,0q��� 
 � ��$ 35���� 
 � ��
 ������� 
 � �� �	#FF3E8EDE�� 
 � ��
 ���� �� 
 � ��$ 0q��� 
 �@J�Effect8   .���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��Chat Application��$��24(�$
��Bold"����	#FF3E8EDE$��Center=�$��10q��� $��1��$	��200��$��10q�
������� �� CornerRadius$ 10�����	#FF3E8EDE$��2q�$��Stretch=�$
��Left=� J� Effect# [  ._��� -    ��Name$ UserListBox���� $��1��$��230,10,10,60q�
�������$ 10�����	#FF3E8EDE$��2q�$��Stretch=�$��Stretch=�# [  ._��� -   $ MessageListBox���� $��2�� �� Orientation$ 
Horizontal=�$��10q�.+��� $	��500��$��51��
�������$ 5�����	#FF3E8EDE$��2q�._��� -    ��Name$ MessageTextBox��$��14(�$��10q�
������ $��0q�$��0,-2,0,0q��� $ 5�����	#FF3E8EDE# [  ._��� -   $
��Send��$	��100��$��35��
�������
������ 
������ �� $ 5�����	#FF3E8EDE# [  ._��� -   $��	Send File��$��84��$��26��
�������
������ 
������ �� -   $��X��$��30��$��30��$��	0,0,10,10q�$��Right=�$	��Top=�
������ 
�������$��0q�$
��Bold"� � Cursor$
 Hand��