   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Rclr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Roll_ReturnDWimetrix_warehouse_mangement_system.Warehouse_Management.Roll_Return  5      Y    SWimetrix_warehouse_mangement_system.Warehouse_Management.Roll_Return.roll_return_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ^localRclr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Roll_Return  5      $	��375��5	      $	��580��6   .��5
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
   $��Roll Return��6   $��Center=�6&   $��408,10,449,0q�6C   $	��Top=�6Y   $��24(�6q   $
��Bold"�6�   $��42��6�   $	��143��6�   �� 5   
   
���   ����#438830$��0q�6:   $��5��6N   $��0,0,0,0q�6Y   $	��Top=�6j   ]� 5   
   $��Stretch=�6   $��20,225,20,20q�60   $��2��6F   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_issuance��5         AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�6t      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��3��6�   $��
0,-110,0,0q�6�   ��6,   �� *issuance_grid_list+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType��%E   '        �� 5      "  6   .�5      -   5        5      5         Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Select All��6.   	   
IsReadOnly	 .  
   CanUserSort
 .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6i   �� *Select+0  *System.Windows.Controls.DataGridTextColumn  5       $ Order ID��6)   	 . 
 .   6a   �� *Order+  5!      $ Vendor��6)   	 . 
 .   6_   �� *Vendor+  5"      $ 
Fabric Lot��6)   	 . 
 .   6c   �� *
Fabric_Lot+  5#      $ Fabric Type��6)   	 . 
 .   6d   �� *Fabric_Type+  5$      $ Roll ID��6)   	 . 
 .   6`   �� *	Roll_ID+  5%      $ Color��6)   	 . 
 .   6^   �� *Color+  5&      $ Weight��6)   	 . 
 .   6_   �� *Weight+50      51      �� 53   
   -   5        $��btn_return_roll��53      ���#29506D���#29506D$��Return to Warehouse��6T   $��Right=�6r   $��	0,72,20,0q�6�   $	��Top=�6�   $	��177��6�   6�   �� 54   
   $��../../Assets/logo/il.png��6   $
��Left=�63   $��	20,18,0,0q�6P   $	��Top=�6c   $	��131��6{   $��96��6�   $ 0.5,0.5&�6�   56      �� 57   
   -   5        $��notifier��57   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��12(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	31,0,0,31q�6�   $��40��6  $	��300��6  $��1��6(  �� 58   
   -   5         ��Name$ btn_roll_reject��58      
���\\��
���\\��$��Reject��6Z   $��Right=�6k   $��
0,72,202,0q�6�   $	��Top=�6�   $	��177��6�   6�   5Y      5[      