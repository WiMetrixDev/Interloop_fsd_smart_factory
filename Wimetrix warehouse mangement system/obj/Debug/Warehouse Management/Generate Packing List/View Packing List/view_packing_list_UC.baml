   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�nclr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Generate_Packing_List.View_Packing_List`Wimetrix_warehouse_mangement_system.Warehouse_Management.Generate_Packing_List.View_Packing_List  5      {    uWimetrix_warehouse_mangement_system.Warehouse_Management.Generate_Packing_List.View_Packing_List.view_packing_list_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      �localnclr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Generate_Packing_List.View_Packing_List     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � $��0,0,0,0q�6   
�������$��Stretch=�6/   $��Stretch=�6M   $	��375��6i   $	��580��6y     � ColumnDefinitions  5   
   �� 5      $
��799* �6   �� 5      .+�5   
   � -   5        $��progress_bar��5      
�������
����  � � Minimum$ 0Q�6P    � Maximum$	 100Q�6\    � Value$ 0Q�6j   $��20,160,19,280q�6t   $��10��6�   ]� 5   
   $��Stretch=�6   $��20,171,19,20q�60   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_packing_list��5         AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Visible=�6y   $��3��6�   $��
0,-118,0,0q�6�   ��61   �� *packing_list_model+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Item Code��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6N   �� *ERP_Item_Code+  5      $ Internal Order��6)    . 	 6S   �� *Internal_Order_No+  5      $ Customer Name��6)    . 	 6S   �� *Customer_Name+  5      $ Vendor Name��6)    . 	 6P   �� *Vendor_Name+  5      $ Fabric Type��6)    . 	 6P   �� *Fabric_Type+  5      $ Yarn Supplier��6)    . 	 6R   �� *Yarn_Supplier+  5      $ Yarn Lot Nor��6)    . 	 6Q   �� *Yarn_Lot_No+  5      $ Fabric Lot No��6)    . 	 6R   �� *Fabric_Lot_No+  5      $ Color��6)    . 	 6J   �� *
Color_Code+  5      $ Weight��6)    . 	 6K   �� *Weight+  5      $ Roll ID��6)    . 	 6L   �� *	Roll_ID+  5       $ 
Fabric GSM��6)    . 	 6O   �� *GSM+  5!      $ 
Goods Code��6)    . 	 6O   �� *
Goods_code+  5"      $ IGP Date��6)    . 	 6M   �� *
IGP_Date+  5#      $ IGP NO��6)    . 	 6K   �� *IGP_No+  5$      $	 DCN��6)    . 	 6H   �� *DCN+  5%      $ Supplier Code��6)    . 	 6R   �� *supplier_code+  5&      $ Fabric Content��6)    . 	 6S   �� *fabric_content+  5'      $ Supplier Roll ID��6)    . 	 6U   �� *supplier_roll_id+51      52      �� 54   
   -   5        $��btn_view_Packing��54      ���#29506D$y�	Collapsed=�6?   ���#29506D$��View Packing List��6l   $��Right=�6�   $��
0,104,19,0q�6�   $	��Top=�6�   $	��167��6�   �� 55   
   -   5        $��notifier��55   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��17(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	49,0,0,54q�6�   $��40��6  $	��576��6  �� 56   
   ���#29506D$��0q�6&   
 �� CornerRadius$
 50,0,0,0��6:   $
��Left=�6R   $��38��6m   $��	32,10,0,0q�6y   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 57   
   -   5         ��Name$ label_username_Copy��57      $��Center=�6.   $��Center=�6R   
�������$��	Username:��6�   $
��Left=�6�   $��	32,12,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��129��6  $��38��6  �� 58   
   ���#29506D$��0q�6&   $
 	05,0,0,05��6:   $
��Left=�6S   $��38��6n   $��	22,10,0,0q�6z   $	��Top=�6�   $	��110��6�   $	��150��6�   $��50��6�   �� 59   
   
����������#29506D$��5q�6:   $
 	0,05,05,0��6N   $
��Left=�6g   $��38��6�   $��
117,10,0,0q�6�   $	��Top=�6�   $	��214��6�   $	��170��6�   $��50��6�   ._�5:      �� -   5         ��Name$ combo_goods��5:   /   ���#29506D$
��Left=�6D   $	��Top=�6`   $	��145��6x    K� StylisticSet19 .  �� IsTextSearchEnabled .  �� 
IsEditable . $��Tahoma)�5>       J� IsHitTestVisible . $��10,0,0,0q�5?   )   6;   5B      �� 5C   
   $��Center=�6   $��Center=�64   
�������$��Goods Code:��6u   $
��Left=�6�   $��	20,10,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��112��6�   $��38��6�   �� 5D   
   -   5         ��Name$ btn_delete_packing_list��5D      
���\\��
���\\��$��Delete Packing List��6b   $��Right=�6�   $��	0,15,20,0q�6�   $	��Top=�6�   $	��185��6�   6�   5E      5F      