   M S B A M L   `   `   `  ����F  BMainApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Sclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls.CommandsEMainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands  5      ?$clr-namespace:MainApp.WPF.ConvertersMainApp.WPF.Converters  5      �Jclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls<MainApp.WPF.UserControls.AdministrateUserRights.UserControls  5      N    HMainApp.WPF.UserControls.AdministrateUserRights.UserControls.RoleDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ccmdSclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands     5      5conv$clr-namespace:MainApp.WPF.Converters     5      \localJclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls     5      
�������  � 	Resources  5      6   0MainApp.WPF.Converters.BoolToVisibilityConverter   boolToVisibility��%   &	          5   
   6)   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        Z   TMainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands.CustomCommands
   New   Command# Z 5      6h     5   
   -   5           Save# Z 5      6j     5   
   -   5           Edit# Z 5      6j     5   
   -   5           Delete# Z 5      6n   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $	��220 �6   �� 5      $��50 �6   .+�5!   
   �� -   5        	 ��Name$	 headerDetails��5!      $��0��5"      $��0��5#      $��2��5$        
headerText#��[ 5%      $
��Left=�5'      ��5&      �� *HeaderDetails+5'      �� 5+   
   $��1��6   $��0��5,      $��
Role title��5-      �� 5.   
   $��1��6   $��1��5/      
 �� Orientation$
 Vertical=�50      $
��Left=�51      $��Center=�52      .+�53      �� ��6   �� *Role.RoleTitle+{�66   �� *ControlsEnabled+�� 54      -   5        $	 errorRoleName��54      $��Please enter role name��55      
���  ��$
��Left=�57      y�58      �� *IsErrorVisible+ �� 	Converter# [  59      �� 5<   
   $��2��6   $��0��5=      $��Authorizations��5>      &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$  dataGridRoleAuthorizations��5?      $��2��5@      $��1��5A      $	��182��5B         CanUserAddRows .     AutoGenerateColumns .  $
��Left=�5E      $
��10,0q�5F      ��5G      �� *Authorizations+{�5H      �� *ControlsEnabled+   Columns 5I      4  .System.Windows.Controls.DataGridTemplateColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Has Rights��6)      CellTemplate 5K      �� 5L      .R�5M      �� $��Center=�6'   $��5q�6D    d� 	IsChecked 6O   �� *	IsChecked+ �� UpdateSourceTrigger$ PropertyChanged=�5N      5P        5Q      $ Authorization title��6)    5R      �� 5S      .R�5T      �� $��Center=�6(   ��6E   �� *AuthorizationTitle+5U      5W      5Y      �� 5\   
   -   5         ��Name$ btnNew��5\      #��Z 5]      $��0��5^      $��1��5_      $	��New��5`      $��Right=�5a      $��	10,0,65,0q�5b      �� 5c   
   $
 
Horizontal=�6   $��3��5d      $��1��5e      $��Right=�5f      $��	10,0,65,0q�5g      .+�5h      �� -	   5        $ btnSave��5h      $
��Save��6&   #��Z 65   �� 5i      -
   5        $ btnEdit��5i      $
��Edit��6&   #��Z 65   �� 5j      -   5        $ 	btnDelete��5j      $��Delete��6(   #��Z 69   5k      5l      5m      