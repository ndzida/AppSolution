   M S B A M L   `   `   `  ����F  BMainApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Sclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls.CommandsEMainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands  5      ?$clr-namespace:MainApp.WPF.ConvertersMainApp.WPF.Converters  5      �Jclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls<MainApp.WPF.UserControls.AdministrateUserRights.UserControls  5      N    HMainApp.WPF.UserControls.AdministrateUserRights.UserControls.UserDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ccmdSclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands     5      5conv$clr-namespace:MainApp.WPF.Converters     5      \localJclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls     5      
�������  � 	Resources  5      6   0MainApp.WPF.Converters.BoolToVisibilityConverter   boolToVisibility��%   &	          5   
   6)   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        Z   TMainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands.CustomCommands
   New   Command# Z 5      6h     5   
   -   5           Save# Z 5      6j     5   
   -   5           Edit# Z 5      6j     5   
   -   5           Delete# Z 5      6n   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��200 �6   �� 5      $��50 �6   .+�5#   
   �� -   5        	 ��Name$	 headerDetails��5#      $��0��5$      $��0��5%      $��2��5&        
headerText#��[ 5'      $
��Left=�5)      ��5(      �� *HeaderDetails+5)      �� 5,   
   $��1��6   $��0��5-      $��	User name��5.      �� 5/   
   $��1��6   $��1��50      
 �� Orientation$
 Vertical=�51      $
��Left=�52      $��Center=�53      .+�54      �� ��6   �� *User.Username+{�65   �� *ControlsEnabled+�� 55      -   5        $	 errorUsername��55      $��Please enter username��56      
���  ��$
��Left=�58      y�59      �� *IsErrorVisible+ �� 	Converter# [  5:      �� 5>   
   $��2��6   $��0��5?      $��Password��5@      �� 5A   
   $��2��6   $��1��5B      ��5C      �� *User.PasswordHash+{�5D      �� *ControlsEnabled+�� 5H   
   $��3��6   $��1��5I      $
 
Horizontal=�5J      $
��Left=�5K      $��Center=�5L        5M       �� 
TargetType �� Property �� Value��%Y   '��       �� 5N      " ��6   .�5O      ��  � ��$ 	30,0,20,0q�6/   5P      5Q      .+�5R      �� $��	Is active��6    d� 	IsChecked 6+   �� *User.IsActive+{�6O   �� *ControlsEnabled+�� 5S      $��Is registered��6    6/   �� *User.IsRegistered+{�6W   �� *ControlsEnabled+5T      �� 5W   
   $��4��6   $��0��5X      $��User applications��5Y      &   System.Windows.Controls.DataGrid  5Z   
   -   5          Name$ dataGridUserApplications��5Z      $��4��5[      $��1��5\         CanUserAddRows .     MaxColumnWidth$	 200Q�5^         AutoGenerateColumns .  $
��Auto��5`      $	��500��5a      $
��Left=�5b      $
��10,0q�5c      ��5d      �� *UserApplications+{�5e      �� *ControlsEnabled+   Columns 5f      4  .System.Windows.Controls.DataGridTemplateColumn  5g      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Can Access��6)      CellTemplate 5h      �� 5i      .R�5j      �� $��Center=�6'   $��Center=�5k   '   $��5q�5l   '    5m   '   �� *	IsChecked+ �� UpdateSourceTrigger$ PropertyChanged=�5n      5p        5q      $ Application title��6)    5r      �� 5s      .R�5t      �� $��Center=�6(   $	��120��5u   (   $��5q�5v   (   ��5w   (   �� *ApplicationTitle+5x      5z        5{      $
 Role��6)    5|      �� 5}      .R�5~      �� $��Center=�6'   $	��170��5   '   $��5q�5�   '   $��25��5�   '    �� SelectedValue$ RoleId��5�   '    �� DisplayMemberPath$ 	RoleTitle��5�   '   ��5�   '   �� *Roles+ �� SelectedItem 5�   '   �� *SelectedRole+{�5�   '   �� *	IsChecked+ �� NotifyOnSourceUpdated . ��5�   "   �� 5�   &   " ��6,   .�5�   *   -   5        5�   '   5�      5�      5�      5�      �� 5�   
   -	   5         ��Name$ btnNew��5�      #��Z 5�      $��0��5�      $��1��5�      $	��New��5�      $��Right=�5�      $��	10,0,65,0q�5�      �� 5�   
   $
 
Horizontal=�6   $��5��5�      $��1��5�      $��Right=�5�      $��	10,0,65,0q�5�      .+�5�      �� -
   5        $ btnSave��5�      $
��Save��6&   #��Z 65   �� 5�      -   5        $ btnEdit��5�      $
��Edit��6&   #��Z 65   �� 5�      -   5        $ 	btnDelete��5�      $��Delete��6(   #��Z 69   5�      5�      5�      