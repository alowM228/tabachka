   M S B A M L   `   `   `  ����C  ?Tabachka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TabachkaTabachka  5   	       Tabachka.zakaz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Tabachka     5   	     � Title$  zakaz��5   	   $	��450��6   $	��800��6$   .��5	      �  � RowDefinitions 5   
   �� 5      $
��238* �6   6,   �� 5      $	��45* �6   6+   �� 5      $	��45* �6   6+   �� 5      $	��45* �6   �� 5      $	��45* �6   6+   �� 5      $	��45* �6   6+   �� 5      $	��45* �6    � ColumnDefinitions 5   
   �� 5      $	��40* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   �� 5      $	��75* �6   6-   .+�5"   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 Aqw��5"      $��11��6K   $��0,0,10,0q�6`   �� 5#   
   -   5         ��Name$ NameTbx��5#      $
��Left=�6$    �� TextWrapping$
 Wrap=�6@   $)��#Окончательная цена��6U   $	��Top=�6o   $	��132��6�   $��28��6�   $��3��6�   $��3��6�   $��5��6�   $��	64,10,0,0q�6�   �� 5$   
   -   5        $ NameTbx1��5$      $
��Left=�6$   $
 Wrap=�6@   $��Статус��6T   $	��Top=�6b   $��78��6z   $��28��6�   $��7��6�   $��2��6�   $��3��6�   $��	64,10,0,0q�6�   �� 5&   
   -   5         ��Name$ bt��5&      $��Добавить��6   $
��Left=�60   $��0,16,0,0q�6K   $	��Top=�6]   $��27��6u   $	��102��6�   $��2��6�   $��4��6�   $��1��6�   $��2��6�   �� 5'   
   -   5        $��Удалить��5'      $
��Left=�6#   $��	76,11,0,0q�6>   $	��Top=�6Q   $	��101��6�   $��28��6�   $��8��6�   $��3��6�   $��4��6�   $��2��6�   �� 5(   
   -   5        $��Изменить��5(      $
��Left=�6$   $��
76,10,0,35q�6?   $	��101��6S   $��8��6v   $��3��6�   $��5��6�   $��2��6�   �� 5)   
   -   5         ��Name$ cb_zakachik��5)      $��2��6(   $��2��68   $
��Left=�6L   $��3��6g   $	��120��6t   $��	10,13,0,0q�6�   $	��Top=�6�   6�   �� 5*   
   -   5        $ bt_nazad��5*      $��
Назад��6#   $
��Left=�63   $��0,10,0,0q�6N   $	��Top=�6`   $��27��6x   $	��102��6�   $��2��6�   $��5��6�   $��1��6�   �� 5+   
   -	   5        $ cb_prodavec��5+      $��3��6(   $��3��68   $
��Left=�6L   $��3��6g   $	��120��6t   $��	76,12,0,0q�6�   $	��Top=�6�   6�   5,      5-      