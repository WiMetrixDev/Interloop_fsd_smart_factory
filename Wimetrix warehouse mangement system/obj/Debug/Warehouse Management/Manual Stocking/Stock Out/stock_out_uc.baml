   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�`clr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_OutRWimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_Out  5      e    _Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_Out.stock_out_uc   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      rlocal`clr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Manual_Stocking.Stock_Out     5      .��5	      � 
�������$��Stretch=�6   $	��375��6:   $	��580��6J   .+�5   
   � -   5        $��progress_bar��5      
�������
����  �  � Minimum$  0Q�6Q   $��10��6]    � Maximum$	 100Q�6i    � Value$ 0Q�6w   $��10,84,10,356q�6�   6�   ]� 5   
   $��Stretch=�6   $��0,90,0,0q�60   $��2��6B   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_out��5      $   HorizontalScrollBarVisibility$ Hidden=�6'      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   $��3��6^   $��5q�6n   5      �� 5   
   -   5        $��btn_stock_out��5      ���#29506D���#29506D$��	Stock Out��6R   $��Right=�6f   $��	0,17,10,0q�6�   $	��Top=�6�   $	��167��6�   6�   �� 5   
   -   5        $��notifier��5   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��12(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	10,0,0,56q�6�   $��40��6  $	��565��6  $��2��6(  �� 5   
   ���#29506D$��0q�6&    �� CornerRadius$ 50,0,0,0��6:   $
��Left=�6R   $��38��6m   $��	20,17,0,0q�6y   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5   
   ���#29506D$��0q�6&   $ 	05,0,0,05��6:   $
��Left=�6S   $��38��6n   $��	10,17,0,0q�6z   $	��Top=�6�   $	��110��6�   $	��150��6�   $��50��6�   �� 5   
   
����������#29506D$��5q�6:   $ 	0,05,05,0��6N   $
��Left=�6g   $��38��6�   $��
105,17,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5      �� -   5         ��Name$ combo_orders��5   /   ���#29506D$
��Left=�6E   $	��Top=�6a   $	��145��6y    K� StylisticSet19 . $��Tahoma)�5       �� 
IsEditable . 	 J� IsHitTestVisible	 . $��10,0,0,0q�5   )   5      �� 5   
   $��Center=�6   $��Center=�64   
�������$��OrderID:��6u   $
��Left=�6�   $��	10,19,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��110��6�   $��38��6�   �� 5   
   -   5        
 ��Name$
 btn_load��5      ���#29506D���#29506D$
��Load��6O   $
��Left=�6^   $��
296,19,0,0q�6y   $	��Top=�6�   $	��167��6�   6�   5       5!      