   M S B A M L   `   `   `  ����  Chat_Win_App    Chat_Win_App.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	     � Title$  LoginWindow��5   	   $	��450��6   $	��400��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   
������� � WindowStyle$
 None=�5        � AllowsTransparency$
 True��63    � 	Resources 5	      3  -System.Windows.Media.Effects.DropShadowEffect   ShadowEffect   ShadowDepth   
BlurRadius   Opacity��%B   &	          5
   
   $ 5Q�60   $ 10Q�6@   $	 0.3Q�6P   5      .��5      � .+�5   
   �� 	 �� CornerRadius$	 10��6   
�������
 �� Padding$
 20q�66    J� Effect# [  6C   ._�5      � .+�5      �� $��Welcome to Chat!��6   $��28(�64   $
��Bold"�6B   ���	#FF3E8EDE$��Center=�5      $	��Top=�69   $��0,10,0,0q�6Q   �� 5      $	��250��6   $��35��6%   $��0,80,0,0q�61   $��Center=�5      $	��Top=�66   $	 5��5      ���	#FF3E8EDE$��2q�6B   ._�5      �� -   5         ��Name$ UsernameTextBox��5      $��14(�5      $��10q�6,   
������ ���#333$��0q�5      5      �� 5      $��Username��6   $��14(�6,   
�������$
��Left=�5      $��	75,75,0,0q�67   $	��Top=�6J   �� 5      $	��250��6   $��35��6%   $��	0,140,0,0q�61   $��Center=�5      $	��Top=�66   $	 5��5      ���	#FF3E8EDE$��2q�6B   ._�5      G� -   5         G�Name$ PasswordBox��5   "   $��14(�5   "   $��10q�60   
������ ���#333$��0q�5!   "   5"      �� 5#      $��Password��6   $��14(�6,   
�������$
��Left=�5$      $��
75,135,0,0q�67   $	��Top=�6K   �� 5%      $	��250��6   $��40��6%   $��	0,200,0,0q�61   $��Center=�5&      $	��Top=�66   $	 20��5'      ���	#FF3E8EDE$��0q�6C   ._�5(      �� -   5        $��Login��5(      ���	#FF3E8EDE
�������$��16(�5)      $
��Bold"�6+   
������ $��0q�5*   7    � Cursor$
 Hand��5+      5,      5-      �� 5.      $	��250��6   $��40��6%   $��	0,260,0,0q�61   $��Center=�5/      $	��Top=�66   $	 20��50      ���	#FF3E8EDE$��2q�6C   ._�51      �� -   5        $��Register��51      
������ ���	#FF3E8EDE$��16(�52      $
��Bold"�6+   
������ $��0q�53   7   $
 Hand��54      55      56      �� 57      -   5        $��X��57      $��30��6%   $��30��60   $��	0,0,10,10q�6<   $��Right=�58      $	��Top=�65   
������ 
�������$��0q�5:      $
��Bold"�6-   $
 Hand��5;      6'   5<      5=      5>      5?      