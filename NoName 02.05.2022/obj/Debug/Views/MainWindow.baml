   M S B A M L   `   `   `  ����L  HNoName 02.05.2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:NoName_02._05._2022NoName_02._05._2022  5   	   *    $Views.NoName_02._05._2022.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:NoName_02._05._2022     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � ��5   
   �� 5         	AutBackgr �� ImageSource# [  6    � RowDefinitions 5   
   �� 5      $	��55* �6   �� 5      $	��35* �6   �� 5      $	��25* �6   �� 5      $	��35* �6   �� 5      $	��70* �6   �� 5      $	��35* �6   �� 5      $
��165* �6    � ColumnDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��10* �6   �� 5      $	��50* �6   �� 5      $	��50* �6   �� 5      $	��50* �6   �� 5      $	��10* �6   �� 5      $
��210* �6   .+�5    
   �� -   5         ��Name$ LoginA��5       $��1��5!      $��5��5"      $��1��5#      $��20(�5$      ���	#7FFFFFFF���	#7FABADB3��5'      �� *	UserLogin+ �� UpdateSourceTrigger$ PropertyChanged=�G� 5)   
   -   5         G�Name$ 	PasswordA��5)      $��1��5*      $��5��5+      $��3��5,      $��20(�5-      ���	#7FABADB3���	#7FFFFFFF5/      �� 51   
   -   5         ��Name$ lLoginA��51      $��3��52      $��
Логин��53      $��20(�54      $��	17,15,0,0q�55      �� 57   
   -   5        $ 
lPasswordA��57      $��3��58      $��2��59      $��Пароль��5:      $��15(�5;      $��	20,-5,0,0q�5<      �� 5>   
   -   5        	 ��Name$	 ToRegButtonA��5>      $��1��5?      $��2��5@      $��5��5A      $*��$Зарегистрироваться��5B      ���	#7FDDDDDD���	#7F707070��5E      �� *ChangeToRegWindow+�� 5F   
   -   5        $	 EnterButtonA��5F      $��4��5G      $��2��5H      $��5��5I      $��
Войти��5J      ���	#7F707070���	#7FDDDDDD��5M      �� *ChangeToStoreWindow+��5N      �� 
 �� ElementName$
 	PasswordA��5P      5Q      