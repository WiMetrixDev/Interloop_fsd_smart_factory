   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Rclr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Card_AssignDWimetrix_warehouse_mangement_system.Warehouse_Management.Card_Assign  5      Y    SWimetrix_warehouse_mangement_system.Warehouse_Management.Card_Assign.assign_rfid_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      dlocalRclr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Card_Assign     5      .��5	      � $��0,0,0,0q�6   
�������$��Stretch=�6/   $��Stretch=�6M   $	��375��6i   $	��580��6y   .+�5   
   �� 
���   ����#438830$��0q�6:   $��2��6N   $��Right=�6^   $��0,0,0,0q�6z   $��5��6�     J� RenderTransformOrigin$  0.5,0.5&�6�   �� 5   
   
���   ����#438830$��0q�6:   $��5��6N   $��0,0,0.4,-0.4q�6Y   $��Bottom=�6o   $��3��6�   �� 5   
   
���   ����#438830$��0q�6:   $
��Left=�6N   $��5��6i   $  0.5,0.5&�6s   �� 5   
   $��Assign RFID Cards��6   $��Center=�6,   $��0,10,0,0q�6I   $	��Top=�6[   $��24(�6s   $
��Bold"�6�   $��1��6�   �� 5   
   
���   ����#438830$��0q�6:   $��5��6N   $��0,0,0,0q�6Y   $	��Top=�6j   $��3��6�   � 5   
   $��10,20,30,20q�6   .+�5      �� ���#438830$��0q�6*    �� CornerRadius$ 50,0,0,0��6>   $
��Left=�6V   $��38��6q   $��	27,77,0,0q�6}   $	��Top=�6�   $	��120��6�   $	��150��6�   $��50��6�   �� 5      
����������#438830$��5q�6>   $ 0,0,10,0��6R   $
��Left=�6j   $��38��6�   $��
145,77,0,0q�6�   $	��Top=�6�   $	��167��6�   $	��170��6�   $��50��6�   ._�5      �� -   5         ��Name$ text_username��5      $
��Left=�63   $	��Top=�6N   $	��145��6f    K� StylisticSet19 . $��Tahoma)�5       J� IsHitTestVisible . $��5,-3,0,0q�5      5      �� 5      -   5         ��Name$ label_packing_list��5      $��Center=�61   $��Center=�6U   
�������$��Packing List:��6�   $
��Left=�6�   $��	45,77,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6  $	��100��6  $��38��6   5      ]� 5   
   $��Stretch=�6   $
��Left=�60   $��20,177,411,20q�6K   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_unassigned_list��5      $   HorizontalScrollBarVisibility$ Visible=�63   $��3��6\   $	��371��6l   $��	0,-36,0,0q�6x   5      ]� 5    
   $��Stretch=�6   $��Right=�60   $��0,177,20,20q�6L   $	��386��6a   .+�5!        -   5        $��grid_assigned_list��5!      $ Visible=�61   $��3��6Z   $	��410��6j   $��	0,-36,0,0q�6v   5"      �� 5#   
   $��../../Assets/logo/il.png��6   $
��Left=�63   $��70��6O   $��	20,18,0,0q�6[   $	��Top=�6n   $	��120��6�   $  0.5,0.5&�6�   5%      �� 5&   
   -   5         ��Name$ btn_assign_cards��5&      $��Assign Cards��6+   $
��Left=�6B   $��330,97,303,0q�6]   $	��Top=�6s   $	��167��6�   5'      5(      