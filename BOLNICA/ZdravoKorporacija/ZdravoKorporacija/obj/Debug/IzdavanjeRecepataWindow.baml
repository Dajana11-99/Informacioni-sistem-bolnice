   M S B A M L   `   `   `  ����L  HZdravoKorporacija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ZdravoKorporacijaZdravoKorporacija  5   	   /    )ZdravoKorporacija.IzdavanjeRecepataWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ZdravoKorporacija     5   	     � Title$  IzdavanjeRecepataWindow��5   	   $	��450��6)   $	��800��66   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Izdavanje recepta��6   $��Center=�6,   $��Center=�6I   $��2��6d   $��20(�6x   �� 5   
   $��Naziv leka:��6   $��1��6&   $��0��63   $��20(�6C   �� 5   
   $��Pocetak tereapije:��6   $��2��6-   $��0��6:   $��20(�6J   �� 5   
   $��Kraj terapije:��6   $��3��6)   $��0��66   $��20(�6F   �� 5   
   $��Kolicina leka:��6   $��4��6)   $��0��66   $��20(�6F   �� 5   
   $��Period uzimanja:��6   $��5��6+   $��0��68   $��20(�6H   �� 5   
   $��id leka��6   $��6��6"   $��0��6/   $��20(�6?   6O   �� 5   
   -   5         ��Name$ idLeka��5      $��6��6#   $��1��60   $��	10 5 20 5q�6@   6V   �� 5    
   -   5        $��
BtnPotvrdi��5    #   $��Potvrdi��6   $��7��6N   $��0��6[   $��20(�6k   $��	10 5 20 5q�6y   �� 5!   
   -   5        $��BtnOdustani��5!   $   $��Odustani��6   $��7��6Q   $��1��6^   $��20(�6n   $��	10 5 20 5q�6|   �� 5"   
   -   5        $��txtNazivLeka��5"      $��1��6&   $��1��66   $��	10 5 20 5q�6C   (  "System.Windows.Controls.DatePicker  5#   
   -   5        $��datePickerPocetak��5#      $��1��6.   $��2��6>   $��	10 5 20 5q�6K     5$   
   -   5        $��datePickerKraj��5$      $��1��6+   $��3��6;   $��	10 5 20 5q�6H   �� 5%   
   -   5        $��txtKolicinaLeka��5%      $��4��6)   $��1��66   $��	10 5 20 5q�6F   �� 5&   
   -   5        $��txtPeriodUzimanja��5&      $��5��6+   $��1��68   $��	10 5 20 5q�6H   5'      5(      