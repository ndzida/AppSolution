   M S B A M L   `   `   `  ����F  BMainApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MainApp.WPF.UserControlsMainApp.WPF.UserControls  5      8    2MainApp.WPF.UserControls.DataEncryptionUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:MainApp.WPF.UserControls     5      
�������.��5	      � $��50q�6     � ColumnDefinitions  5
   
   �� 5      $	��250 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��51 �6   �� 5      $	��100 �6   �� 5      $��51 �6   �� 5      $	��200 �6   .+�5   
   �� $��0��6   $��0��5      $��2��5      $��
Encryption��5         
headerText#��[  5      $��5q�5      �� 5   
   $��0��6   $��0��5      $��2��5      $	��Top=�5      
�������$��5, 25q�5!      $��1��5"      $��Stretch=�5#      �� 5%   
    �� Orientation$ Vertical=�6   $��1��5&      $��0��5'      $��2��5(      .+�5)      �� $ 
Horizontal=�6   .+�5*      �� $��Value to encrypt��6   �� 5+      -   5         ��Name$ tBoxEncrypt��5+      $��13,0,0,0q�6/   �� 5,      -   5         ��Name$ 
btnEncrypt��5,      $��Encrypt��6F   5-      �� 5.      $ 
Horizontal=�6   .+�5/      �� $��Encryption result��6   �� 50      -   5        $ tBoxEncryptionResult��50      $	��625��68   51      52      �� 55   
   $��0��6   $��2��56      $��2��57      $��
Decryption��58      #��[  59      $��5q�5:      �� 5;   
   $��0��6   $��2��5<      $��2��5=      $	��Top=�5>      
�������$��5, 25q�5@      $��1��5A      $��Stretch=�5B      �� 5D   
   $ Vertical=�6   $��3��5E      $��0��5F      $��2��5G      .+�5H      �� $ 
Horizontal=�6   .+�5I      �� $��Value to encrypt��6   �� 5J      -   5        $ tBoxDecrypt��5J      $��15,0,0,0q�6/   �� 5K      -   5        $ 
btnDecrypt��5K      $��Decrypt��6F   5L      �� 5M      $ 
Horizontal=�6   .+�5N      �� $��Decryption result��6   �� 5O      -   5        $ tBoxDecryptionResult��5O      $	��625��68   5P      5Q      5R      5S      