   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Wimetrix_warehouse_mangement_system#Wimetrix_warehouse_mangement_system  5      4    .Wimetrix_warehouse_mangement_system.index_page   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      =local1clr-namespace:Wimetrix_warehouse_mangement_system  5      -   5          �Name$  index_page1��5   	    � Title$  Interloop Managment System��5	       � WindowState$ Normal=�60   $	��720��6l    � WindowStartupLocation$ CenterScreen=�6|    � WindowStyle$
 None=�6�   $
��1200��6�    � 	Resources 5
       �� 
TargetType   ImageButtonStyle �� Property �� Value	 �� 
TargetType��%�   &	        �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      "	 ��6&   .R�5      �� 5      5      5      5      .��5      � ���	#FFDEDEDE
 � ColumnDefinitions
 5   
   �� 5      $
��335* �6   �� 5      $
��957* �6   .+�5   
   � -   5         �Name$ GridBarraTitulo��5      ���#438830$��0,0,0,0q�6=   $��2��6N   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $	��Top=�6N   $	��0,0q�6f   $	��193��6s   .+�5      �� -   5        ���#438830$��69��5   .   $��25��69   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
��������  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�6A   5      �� 5      -   5        ���#438830$��57��5   .   $��25��69   
�������.��5         $ Resize=�6.   5!      �� 5"      -   5         ��Name$ btn_exit��5"      ���#438830$��66��6@   $��25��6K   
�������.��5#        $ Power=�6.   5$      5%      5&      ]� 5(   
   -   5         ]�Name$ 	grid_main��5(      $��Stretch=�6'   
�������$��0,78,0,0q�6V   $��2��6h   � 5+   
   -   5        $ GridMenu��5+      $��Stretch=�6"   $	��Top=�6@   
�������$��0,24,0,0q�6k   $��54��6}   $��2��6�   .+�5,      ]� .+�5-      � $��58��6   
������� J� RenderTransformOrigin$ 0.5,0.5&�66   z�5.      V� 5/      .~�50      �� �� 51      �� 52      T� 53      54      .+�56      �� -   5        #��[  56      .��57      �� $��Assets/logo/wiii.png��6    $��Center=�6>   $	��Top=�6[   $��
30,10,75,0q�6s   $	��130��6�   58      59      �� 5:      $ 
Horizontal=�6   $��Stretch=�66   $��Stretch=�6R   $��75,0,0,0q�6p   .+�5;      o� $	��Top=�6   .@�5<      m� -	   5        $��menu_warehouse��5<   #   {�.  
�������$��58��6^   ��5=      �� 5>   "   $ 
Horizontal=�6-   $��70��6F   $	��150��6R   .+�5?   &     $ Inbox=�6>   $
��Auto��6K   $��30��6Y   $��5,5,0,15q�6d   $��Stretch=�6v   �� 5@   &   $��	Warehouse��6,   $��45��6A   $	��100��6M   $��	15,19,0,6q�6Y   5A   #   .@�5C      m� -
   5        $��View Stock Report��5C   '   6B   �� 5D      m� 5E      -   5        $ ��item_generate_packing_list��5E   '   $��_Generate Packing List��6I   6i   �� 5F      m� 5G      -   5        $��item_upload_excel��5G   '   $��_Upload Packing List��6@   6�   �� 5H      m� 5I      -   5        $��item_view_excel��5I   '   $��_View Packing List��6>   6Z   �� 5J      m� 5K      -   5        $��item_update_location��5K   '   $��_Update Location��6C   6]   �� 5N      m� 5O      -   5        $��item_stocking��5O   '   $��_Stock In/Out��6<   6S   �� 5P      m� 5Q      -   5        $��item_allocation��5Q   '   $��_Departmental Allocation��6>   6`   �� 5T      m� 5U      -   5        $��item_transfer_rolls��5U   '   $��_Rolls Transfer��6B   6[   �� 5V      m� 5W      -   5        $��item_roll_return��5W   '   $��_Rolls Return��6?   6V   5Y      5Z      5[      �� 5\      $ 
Horizontal=�6   $��Stretch=�66   $��Stretch=�6R   .+�5]      o� $	��Top=�6   .@�5^      m� -   5        $��menu_cutting��5^   #   {�.  $��Stretch=�6I   
�������$��58��6x   ��5_      �� 5`   "   $ 
Horizontal=�6-   $��Stretch=�6F   $��70��6b   $	��150��6n   .+�5a   &     $ Scissors=�6>   $
��Auto��6N   $��30��6\   $��5,5,0,15q�6g   $��Stretch=�6y   �� 5b   &   -   5        $��item_cutting��5b   ,   $��	Cutting
��6@   $��45��6]   $	��100��6i   $��	15,19,0,6q�6u   5c   #   .@�5e      m� -   5        $��Cutting department��5e   )   6E   5f      5g      5h      �� 5i      $ 
Horizontal=�6   $��Stretch=�66   $��Stretch=�6R   $��0,0,0,0q�6p   .+�5j      o� $	��Top=�6   .@�5k      �� $��52��6$   m� 5l      -   5        $��	menu_Spts��5l   #   {�.  $��Stretch=�6G   
�������$��58��6v   ��5m      �� 5n   "   $ 
Horizontal=�6-   $��Stretch=�6F   $��70��6b   $	��150��6n   .+�5o   &     $ Settings=�6>   $
��Auto��6N   $��30��6\   $��5,5,0,15q�6g   $��Stretch=�6y   �� 5p   &   $
��SPTS��6,   $��45��6<   $	��100��6H   $��	15,19,0,6q�6T   5q   #   .@�5s      m� -   5        $��item_cutreport��5s   '   $��Add/View Cut Report��6=   6Z   �� 5t      m� 5u      -   5        $��item_orders��5u   '   $��Add/View Operations��6;   6X   �� 5v      m� 5w      -   5        $��item_workers��5w   (   $��Add/View Workers��6<   6V   �� 5x      m� 5y      -   5        $��item_orders_add��5y   '   $��Add/View Orders��6?   6X   �� 5z      m� 5|      -   5        $��item_style_bulletin��5|   (   $��Add/View Style Bulletin��6C   6d   5}      5~      5      �� 5�      $ 
Horizontal=�6   $��Stretch=�66   $��Stretch=�6R   $��0,0,0,0q�6p   .+�5�      o� $	��Top=�6   .@�5�      �� $��52��6$   m� 5�      -   5        $��
menu_asset��5�   #   {�.  $��Stretch=�6G   
�������$��58��6v   ��5�      �� 5�   "   $ 
Horizontal=�6-   $��Stretch=�6F   $��70��6b   $	��150��6n   .+�5�   &     $ WebAsset=�6>   $
��Auto��6N   $��30��6\   $��5,5,0,15q�6g   $��Stretch=�6y   �� 5�   &   $��Asset tracking��6,   $��45��6F   $	��120��6R   $��	15,19,0,6q�6^   5�   #   .@�5�      m� $��Asset Summary��6(   �� 5�      m� 5�      -   5        $��item_asset_tracking��5�   '   $��Asset Tracking��6C   6[   �� 5�      m� 5�      -   5        $��
item_admin��5�   '   $��Administrative Dashboard��6:   6\   �� 5�      m� 5�      -   5        $��item_upload_parts_list��5�   '   $��Upload Machine Parts��6F   6d   �� 5�      m� 5�      -    5        $��item_update_machine_line��5�   '   $��Update Machine Line��6H   6e   5�      5�      5�      �� 5�      $ 
Horizontal=�6   $��Right=�66   .+�5�      �� $��Extras��6    $��Center=�6.   $��16(�6I   '  !MaterialDesignThemes.Wpf.PopupBox  5�         PlacementMode$ BottomAndAlignRightEdges=�6.      	StaysOpen .  $��10q�6i      PopupContent. 5�      �� $	��150��6%   .+�5�      �� $��Settings��6%   �� 5�      $��Account��6%   �� 5�      $
��Help��6%   �� 5�      �� 5�      -!   5        $��item_logout��5�   %   $��Logout��68   6I   5�      5�      5�      5�      5�      5�      5�      