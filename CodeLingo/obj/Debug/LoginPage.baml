   M S B A M L   `   `   `  ����D  @CodeLingo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LoginPage	LoginPage  5   	       CodeLingo.LoginPage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LoginPage     5   	   -   5          � Title$  
MainWindow��5   	   $	��700��6   $
��1250��6)    � WindowState$ 	Maximized=�66   .��5	      (� .��5
   
   � $	��526��6   $	��314��6   .+�5      � 
���   � J� Opacity$ .5Q�6&   $��-31,0,-30,0q�63   �� 5      -   5         ��Name$ textBox��5      $��45��6%   $��148,2,103,267q�61   $��Welcome to CodeLingo��6H   $	��275��6g   $��32(�6s   $��	Bebas Kai)�6�   $��0q�6�   ��6�   Z� � 5      -   5         �Name$ Login��5      $��
6,40,-6,10q�6"   .+�5      �� $	��150��5      $	��208��5      
����ح�$��1q�5       �� CornerRadius$ 	0,60,0,60��5      $��39,10,39,43q�6&   ._�5      � $��-70, 10, 20,20q�6   .+�5      �� -   5        $ UserName��5       $
��Left=�62   $��30��6M   $��
196,53,0,0q�6Y   $��	UserName:��6m   $	��Top=�6�   $��80��6�   $��0q�6�   $��	Bebas Kai)�6�   $��18.667(�6�    J� RenderTransformOrigin$ 1.414,0.829&�6�   ��6�   Z� 6�   �� 5      -   5         ��Name$ UserNameField��5   "   $
��Left=�69   $��23��6T   $��
286,60,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��150��6�   $��1q�6�   $��16(�6�   �� 5      -   5        $ Password��5       $
��Left=�62   $��30��6M   $��
196,83,0,0q�6Y   $��	Password:��6m   $	��Top=�6�   $��80��6�   $��0q�6�   $��	Bebas Kai)�6�   $��18.667(�6�   ��6�   Z� G� 5      -   5        	 G�Name$	 PasswordField��5   &   $
��Left=�6=   $��23��6X   $��
286,88,0,0q�6d   $	��Top=�6x   $	��150��6�   $��1q�6�   $��16(�6�   �� 5      -   5        
 ��Name$
 LoginButton��5   !   $��Login��66   $
��Left=�6F   $��286,143,0,0q�6a   $	��Top=�6v   $��75��6�   $��	Bebas Kai)�6�   $��16(�6�   $ 1.087,-2.778&�6�   6�   �� 5      -	   5        $
 RegisterButton��5   !   $��Sign-Up��69   $
��Left=�6K   $��442,-47,-21,0q�6f   $	��Top=�6}   $��75��6�   $��	Bebas Kai)�6�   $��16(�6�   $ 
0.47,0.879&�6�   6�   �� 5      -
   5        $ RegistrationSuccessful��5       $(��"You have registered! Please login.��6@   $
��Left=�6m   $��
216,10,0,0q�6�   $	��Top=�6�   $	��220��6�   $��	Bebas Kai)�6�   $��16(�6�   
��� � �$y�Hidden=�6�   5      5      5      5       5!      5"      