   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Departmental_AllocationPWimetrix_warehouse_mangement_system.Warehouse_Management.Departmental_Allocation  5      q    kWimetrix_warehouse_mangement_system.Warehouse_Management.Departmental_Allocation.departmental_allocation_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      plocal^clr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Departmental_Allocation     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $
��1000��5	   8   .��5
      � $��0,0,0,0q�6   
�������$��Stretch=�6/   $��Stretch=�6M   $	��375��6i   $	��580��6y     � RowDefinitions  5   
   �� 5      $
��119* �6   �� 5      $
��106* �6   .+�5   
   �� 
���   ����#438830$��0q�6:   $��Right=�6N   $��0,0,0,0q�6j   $��5��6{    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��2��6�   �� 5   
   
���   ����#438830$��0q�6:   $��5��6N   $��Bottom=�6Y   $��1��6t   �� 5   
   
���   ����#438830$��0q�6:   $
��Left=�6N   $��5��6i   $ 0.5,0.5&�6s   $��2��6�   �� 5   
   $��Departmenal Allocation��6   $��Center=�61   $��378,10,291,0q�6N   $	��Top=�6d   $��24(�6|   $
��Bold"�6�   $��42��6�   $	��331��6�   �� 5   
   
���   ����#438830$��0q�6:   $��5��6N   $��0,0,0,0q�6Y   $	��Top=�6j   �� 5   
   $��Total Rolls:��6   $
��Left=�6'   $��
20,110,0,0q�6B   $	��Top=�6V   $��15(�6n   $
��Bold"�6}   $��1��6�   �� 5   
   -   5        $��total_rolls_text��5      $��0��6   $
��Left=�64   $��120,110,0,0q�6O   $	��Top=�6d   $��15(�6|   $��1��6�   �� 5   
   $��Total Weight:��6   $
��Left=�6(   $��
20,140,0,0q�6C   $	��Top=�6W   $��15(�6o   $
��Bold"�6~   $��1��6�   �� 5   
   -   5        $��total_weight_text��5      $	��0.0��6   $
��Left=�67   $��120,140,0,0q�6R   $	��Top=�6g   $��15(�6   $��1��6�   ]� 5   
   $��Stretch=�6   $��20,225,20,20q�60   $��2��6F   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_issuance��5         AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��3��6�   $��	0,-49,0,0q�6�   ��6,   �� *issuance_grid_list+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType��%E   '        �� 5      "  6   .�5       -   5        5!      5"         Columns 5$      4  .System.Windows.Controls.DataGridCheckBoxColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Select All��6.   	   
IsReadOnly	 .  
   CanUserSort
 .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6i   �� *Select+0  *System.Windows.Controls.DataGridTextColumn  5&      $ Order ID��6)   	 . 
 .  6`   �� *Order+  5'      $ Vendor��6)   	 . 
 .  6^   �� *Vendor+  5(      $ 
Fabric Lot��6)   	 . 
 .  6b   �� *
Fabric_Lot+  5)      $ Fabric Type��6)   	 . 
 .  6c   �� *Fabric_Type+  5*      $ Roll ID��6)   	 . 
 .  6_   �� *	Roll_ID+  5+      $ Color��6)   	 . 
 .  6]   �� *Color+  5,      $ Supplier Lot��6)   	 . 
 .  6d   �� *Supplier_lot+  5-      $ Weight��6)   	 .  
 .  6_   �� *Weight+57      58      )  #MaterialDesignThemes.Wpf.DialogHost  59   
   -   5        $��popup_consumption_error��59   3      IsOpen .     CloseOnClickAway .  $��5,0,0,0q�6l   $��3��6}      DialogContent 5:      � 5;      $��70q�6   .+�5<      ��  �� Orientation$ Vertical=�6!   .+�5=      �� $��Action Permitted��6    $��Center=�6;   $��	0,-60,0,0q�6X   $	��Top=�6k   $��20(�6�   $
��Bold"�6�   $��1��6�   �� 5?      -   5        $��popup_Error_Message��5?   $   $��WrapWithOverflow=�6?   $��15(�6_   $	��120��6m   $$��Consumption Can not be Greater��6|   6�   �� 5A      -   5         ��Name$ btn_set��5A   !   $��OK��62   ���#29506D���#48576C$��Center=�6j   $��Bottom=�6�   $��0,20,0,0q�6�   $	��106��6�   $��1��6�   6�   5B      5C      5E      �� 5G   
   -   5        $��btn_allocate��5G      ���#29506D���#29506D$��Allocate��6Q   $��Right=�6d   $��
0,118,20,0q�6�   $	��Top=�6�   $	��129��6�   6�   �� 5H   
   $��../../Assets/logo/il.png��6   $
��Left=�63   $��	20,18,0,0q�6P   $	��Top=�6c   $	��131��6{   $��96��6�   $ 0.5,0.5&�6�   5J      �� 5K   
   -	   5        $��notifier��5K   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��12(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	31,0,0,31q�6�   $��40��6  $	��300��6  $��1��6(  � 5L   
   $��Center=�6   $	��111��6,   $��0,80,0,0q�69   $	��Top=�6K   $	��812��6c   .+�5M      �� ���#29506D$��0q�6*    �� CornerRadius$ 50,0,0,0��6>   $
��Left=�6V   $��38��6q   $��-10,-13,0,0q�6}   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5O      -
   5         ��Name$ label_username��5O      $��Center=�6-   $��Center=�6Q   
�������$��	Username:��6�   $
��Left=�6�   $��-10,-11,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��129��6  $��38��6  �� 5P      ���#29506D$��0q�6*   $ 	05,0,0,05��6>   $
��Left=�6W   $��38��6r   $��-10,-13,0,0q�6~   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5Q      
����������#29506D$��5q�6>   $ 	0,05,05,0��6R   $
��Left=�6k   $��38��6�   $��
75,-13,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5R      �� -   5         ��Name$ combo_orders��5R   2   ���#29506D$
��Left=�6H   $	��Top=�6d   $	��145��6|    �� IsTextSearchEnabled .  K� StylisticSet19 .  �� 
IsEditable . $��Tahoma)�5V       J� IsHitTestVisible . $��10,0,0,0q�5W   )   6;   5Y      �� 5Z      -   5        $ label_username_Copy��5Z      $��Center=�62   $��Center=�6V   
�������$��Order:��6�   $
��Left=�6�   $��-10,-13,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��100��6  $��38��6  �� 5[      ���#29506D$��0q�6*   $ 50,0,0,0��6>   $
��Left=�6V   $��38��6q   $��539,-13,0,0q�6}   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5]      -   5        $ label_username_Copy1��5]      $��Center=�63   $��Center=�6W   
�������$��	Username:��6�   $
��Left=�6�   $��539,-11,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6  $	��129��6  $��38��6   �� 5^      ���#29506D$��0q�6*   $ 	05,0,0,05��6>   $
��Left=�6W   $��38��6r   $��539,-13,0,0q�6~   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5_      
����������#29506D$��5q�6>   $ 	0,05,05,0��6R   $
��Left=�6k   $��38��6�   $��624,-13,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5`      �� -   5        $ combo_vendors��5`   1   ���#29506D$	��Top=�6I    .  . $��Tahoma)�5c       .  . $��10,0,5,0q�5e   )   6;   5g      �� 5h      -   5        $ label_username_Copy2��5h      $��Center=�63   $��Center=�6W   
�������$��Vendor:��6�   $
��Left=�6�   $��539,-13,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6   $	��100��6  $��38��6  �� 5i      ���#29506D$��0q�6*   $ 50,0,0,0��6>   $
��Left=�6V   $��38��6q   $��264,-13,0,0q�6}   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5j      -   5        $ label_username_Copy3��5j      $��Center=�63   $��Center=�6W   
�������$��	Username:��6�   $
��Left=�6�   $��264,-11,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6  $	��129��6  $��38��6   �� 5k      ���#29506D$��0q�6*   $ 	05,0,0,05��6>   $
��Left=�6W   $��38��6r   $��264,-13,0,0q�6~   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5l      
����������#29506D$��5q�6>   $ 	0,05,05,0��6R   $
��Left=�6k   $��38��6�   $��349,-13,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5m      �� -   5        $ 	combo_lot��5m   3   ���#29506D$
��Left=�6F   $	��Top=�6b   $	��145��6z    .  .  . $��Tahoma)�5q       . $��10,0,0,0q�5r   )   6;   5t      �� 5u      -   5        $ label_username_Copy4��5u      $��Center=�63   $��Center=�6W   
�������$��Lot No:��6�   $
��Left=�6�   $��264,-13,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6   $	��100��6  $��38��6  �� 5v      ���#29506D$��0q�6*   $ 50,0,0,0��6>   $
��Left=�6V   $��38��6q   $��119,43,0,-45q�6}   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5w      -   5        $ label_username_Copy5��5w      $��Center=�63   $��Center=�6W   
�������$��	Username:��6�   $
��Left=�6�   $��119,45,0,-47q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6  $	��129��6  $��38��6!  �� 5x      ���#29506D$��0q�6*   $ 	05,0,0,05��6>   $
��Left=�6W   $��38��6r   $��119,43,0,-45q�6~   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5y      
����������#29506D$��5q�6>   $ 	0,05,05,0��6R   $
��Left=�6k   $��38��6�   $��204,43,0,-45q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5z      �� -   5        $ combo_colors��5z   1   ���#29506D$	��Top=�6H    .  . $��Tahoma)�5}       .  . $��10,0,5,0q�5   )   6;   5�      �� 5�      -   5        $ label_username_Copy6��5�      $��Center=�63   $��Center=�6W   
�������$��Color:��6�   $
��Left=�6�   $��119,43,0,-45q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6   $	��100��6  $��38��6  �� 5�      ���#29506D$��0q�6*   $ 50,0,0,0��6>   $
��Left=�6V   $��38��6q   $��394,39,0,-41q�6}   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5�      -   5        $ label_username_Copy7��5�      $��Center=�63   $��Center=�6W   
�������$��	Username:��6�   $
��Left=�6�   $��394,41,0,-43q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6  $	��129��6  $��38��6!  �� 5�      ���#29506D$��0q�6*   $ 	05,0,0,05��6>   $
��Left=�6W   $��38��6r   $��394,39,0,-41q�6~   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5�      
����������#29506D$��5q�6>   $ 	0,05,05,0��6R   $
��Left=�6k   $��38��6�   $��479,39,0,-41q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5�      �� -   5        $ combo_fabric_type��5�   1   ���#29506D$	��Top=�6M    .  .  . $��Tahoma)�5�       . $��10,0,5,0q�5�   )   5�      5�      �� 5�      -   5        $ label_username_Copy8��5�      $
��Left=�63   $��Center=�6U   
�������$��Fabric Type:��6�   $
��Left=�6�   $��394,39,0,-41q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6  $	��100��6  $��38��6"  5�        5�   
   -   5        $��issuance_popup��5�   3    .   .  $��0,-5,5,5q�6c   $��2��6u    5�      � 5�      $	��150q�6   .+�5�      �� $��Total Rolls:��6   $
��Left=�63   $��60,-100,0,0q�6N   $	��Top=�6c   $��15(�6{   $
��Bold"�6�   $��1��6�   �� 5�      -   5        $��text_poppup_total_rolls��5�   (   $��0��6   $
��Left=�6G   $��140,-100,0,0q�6b   $	��Top=�6x   $��15(�6�   $��1��6�   �� 5�      $��Total Weight:��6   $
��Left=�64   $��220,-100,0,0q�6O   $	��Top=�6e   $��15(�6}   $
��Bold"�6�   $��1��6�   �� 5�      -   5        $��text_poppup_total_weight��5�   *   $	��0.0��6   $
��Left=�6J   $��320,-100,0,0q�6e   $	��Top=�6{   $��15(�6�   $��1��6�   �� 5�      $.��(Please select Department to be Allocated��6   $��Center=�6O   $��	0,-60,0,0q�6l   $	��Top=�6   $��20(�6�   $
��Bold"�6�   $��1��6�   ]� 5�      -   5         ]�Name$ ip_dock��5�       
������ $��0,0,0,0q�6K   .+�5�      �� ���#29506D$��0q�66   $ 05,0,0,0��6J   $
��Left=�6b   $��38��6}   $��0,0,0,0q�6�   $	��Top=�6�   $	��130��6�   $	��150��6�   $��50��6�   �� 5�      
����������#29506D$��5q�6J   $ 0,0,0,0��6^   $
��Left=�6u   $��38��6�   $��0,0,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   �� 5�      -   5        $ label_ip��5�   !   $��Center=�63   $��Center=�6W   
�������$��Department:��6�   $
��Left=�6�   $��
-300,0,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6  $	��129��6  $��38��6!  �� 5�      -   5        $ combo_popup_issuance��5�   $   $��
-180,5,0,0q�6C   $	��Top=�6W   $	��145��6o    .  . $��Tahoma)�5�       . 5�      �� 5�      -   5        $ btn_allocation_error_set��5�   !   $	��Set��6C   ���#29506D���#48576C$
��Left=�6|   $��20,0,0,0q�6�   $	��106��6�   $
��Auto��6�   $��1��6�   6�   �� 5�      -    5        $ 
btn_cancel��5�   !   $��Cancel��65   
���\\��
���\\��$
��Left=�6u   $��20,0,0,0q�6�   $	��106��6�   $
��Auto��6�   $��1��6�   6�   5�      5�      5�      5�      5�      