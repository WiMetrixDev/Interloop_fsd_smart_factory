   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�bclr-namespace:Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.View_AssetsTWimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.View_Assets  5      i    cWimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.View_Assets.view_assets_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      tlocalbclr-namespace:Wimetrix_warehouse_mangement_system.Asset_Tracking.administrative_portal.View_Assets     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��450��5	   
   $��884.211��6   .��5
      � 
�������$��Stretch=�6   $	��375��6:   $	��580��6J   .+�5   
   � .+�5      �� 
����������#29506D$��1q�6>   $y�	Collapsed=�6R     �� CornerRadius$  01,01,01,01��6i   $
��Left=�6�   $��38��6�   $��8,8,0,0q�6�   $	��Top=�6�   $	��250��6�   $	��250��6�   $��50��6�   ._�5      �� -   5         ��Name$ text_operation��5   �   ���#29506D{�. $�� ��6A   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search Machine��6I    �� TextAlignment$ Center=�6y   $
��Left=�6�   $	��230��6�    K� StylisticSet19 . $��Tahoma)�5       J� IsHitTestVisible . $��	10,-5,0,5q�5   )   6Y   5      �� 5      
����������#29506D$y�Visible=�6>   $��1q�6S   $  01,01,01,01��6g   $
��Left=�6�   $��38��6�   $��8,8,0,0q�6�   $	��Top=�6�   $	��250��6�   $	��250��6�   $��50��6�   ._�5      �� -   5        $ text_rfid_search��5   �   ���#29506D{�. $�� ��6A   $ Search RFID��6I   $ Center=�6v   $
��Left=�6�   $	��230��6�    . $��Tahoma)�5       . $��	10,-5,0,5q�5   -   6@   5      5      ]� 5   
   $��Stretch=�6   $��	3,70,7,10q�60   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_update_location��5      $   HorizontalScrollBarVisibility$ Visible=�6a      AutoGenerateColumns .  $��3��6�   ��6�   �� *
asset_list+   Columns 5       4  .System.Windows.Controls.DataGridCheckBoxColumn  5!      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Select��6-   
   
IsReadOnly
 .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *Select+0  *System.Windows.Controls.DataGridTextColumn  5"      $	 Serial��6)   
 .  6K   �� *	Machine+  5#      $
	 Type��6)   
 .  6I   �� *Type+  5$      $
	 Line��6)   
 .  6J   �� *Line+  5%      $	 Floor��6)   
 .  6K   �� *
Location+  5&      $	 Price��6)   
 .   6K   �� *Price+  5'      $
	 RFID��6)   
 .  6I   �� *RFID+  5(      $	 Country��6)   
 .  6L   �� *	Country+  5)      $	 Sub Type��6)   
 .  6M   �� *
Sub_Type+  5*      $	 Model��6)   
 .  6J   �� *Model+  5+      $	 Vendor��6)   
 .  6K   �� *Vendor+  5,      $	 Supplier��6)   
 .  6N   �� *
Supplier+  5-      $	 Brand��6)   
 .  6K   �� *Brand+  5.      $	 IGP Date��6)   
 .  6N   �� *
igp_date+  5/      $	 Year of Manufacture��6)   
 .  6Y   �� *manufacturing_year+  50      $	 Installation Date��6)   
 .  6W   �� *installation_date+52      53      �� 54   
   -   5        $��notifier��54   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��12(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	10,0,0,56q�6�   $��40��6  $	��565��6  $��2��6(  �� 55   
   -   5         ��Name$ btn_update_price��55      ���#29506D���#29506D$��Update Price��6W   $��Right=�6n   $��	0,10,10,0q�6�   $	��Top=�6�   $	��159��6�   6�   �� 56   
   -   5        $ btn_update_machine_lines��56      ���#29506D���#29506D$��Refresh Machine Locations��6_   $��Right=�6�   $��
0,10,174,0q�6�   $	��Top=�6�   $	��210��6�   6�   59      5:      