   M S B A M L   `   `   `  ����F  BMainApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Sclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls.CommandsEMainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands  5      ?$clr-namespace:MainApp.WPF.ConvertersMainApp.WPF.Converters  5      �Jclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls<MainApp.WPF.UserControls.AdministrateUserRights.UserControls  5      W    QMainApp.WPF.UserControls.AdministrateUserRights.UserControls.AuthorizationDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ccmdSclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands     5      5conv$clr-namespace:MainApp.WPF.Converters     5      \localJclr-namespace:MainApp.WPF.UserControls.AdministrateUserRights.UserControls     5      
�������  � 	Resources  5      6   0MainApp.WPF.Converters.BoolToVisibilityConverter   boolToVisibility��%   &	          5   
   6)   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        Z   TMainApp.WPF.UserControls.AdministrateUserRights.UserControls.Commands.CustomCommands
   New   Command# Z 5      6h     5   
   -   5           Save# Z 5      6j     5   
   -   5           Edit# Z 5      6j     5   
   -   5           Delete# Z 5      6n   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5    
   �� -   5        	 ��Name$	 headerDetails��5       $��0��5!      $��0��5"      $��2��5#        
headerText#��[ 5$      $
��Left=�5&      ��5%      �� *HeaderDetails+5&      �� 5)   
   $��1��6   $��0��5*      $��Authorization title��5+      �� 5,   
   $��1��6   $��1��5-      
 �� Orientation$
 Vertical=�5.      $
��Left=�5/      $��Center=�50      .+�51      �� ��6   �� *" Authorization.AuthorizationTitle+{�6H   �� *ControlsEnabled+�� 52      -   5        $	 errorRoleName��52      $%��Please enter authorization name��53      
���  ��$
��Left=�55      y�56      �� *IsErrorVisible+ �� 	Converter# [  57      �� 5:   
   -   5         ��Name$ btnNew��5:      #��Z 5;      $��0��5<      $��1��5=      $	��New��5>      $��Right=�5?      $��	10,0,65,0q�5@      �� 5A   
   $
 
Horizontal=�6   $��2��5B      $��1��5C      $��Right=�5D      $��	10,0,65,0q�5E      .+�5F      �� -   5        $ btnSave��5F      $
��Save��6&   #��Z 65   �� 5G      -	   5        $ btnEdit��5G      $
��Edit��6&   #��Z 65   �� 5H      -
   5        $ 	btnDelete��5H      $��Delete��6(   #��Z 69   5I      5L      5M      