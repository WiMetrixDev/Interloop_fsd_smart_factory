   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Qclr-namespace:Wimetrix_warehouse_mangement_system.Asset_Tracking.Asset_AllocationCWimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Allocation  5      Z    TWimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Allocation.asset_allocation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ]localQclr-namespace:Wimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Allocation  5      $	��450��5	   
   $��884.211��6   .��5
      � 
�������$��Stretch=�6   $	��375��6:   $	��580��6J   .+�5   
   � ]� 5   
   $��Stretch=�6   $��	3,70,7,10q�60   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_update_location��5      $    HorizontalScrollBarVisibility$  Visible=�64      AutoGenerateColumns .  $��3��6�   ��6x   �� *
Asset_list+   Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Select��6-      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *Select+0  *System.Windows.Controls.DataGridTextColumn  5      $ Serial��6)    .  6K   �� *	Machine+  5      $
 Type��6)    .  6I   �� *Type+  5      $ Floor��6)    .  6K   �� *
Location+  5      $
 Line��6)    .  6J   �� *Line+  5      $ Price��6)    .   6K   �� *Price+  5      $
 RFID��6)    .  6I   �� *RFID+  5      $ Country��6)    .  6L   �� *	Country+  5      $ Sub Type��6)    .  6M   �� *
Sub_Type+  5      $ Model��6)    .  6J   �� *Model+  5      $ Vendor��6)    .  6K   �� *Vendor+  5      $ Supplier��6)    .  6N   �� *
Supplier+  5      $ Brand��6)    .  6K   �� *Brand+  5      $ IGP Date��6)    .  6N   �� *
igp_date+  5      $ Year of Manufacture��6)    .  6Y   �� *manufacturing_year+  5      $ Installation Date��6)    .  6W   �� *installation_date+5)      5*      �� 5,   
   -   5        $��notifier��5,   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��12(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	10,0,0,56q�6�   $��40��6  $	��565��6  $��2��6(  )  #MaterialDesignThemes.Wpf.DialogHost  5.   
   -   5        $��update_location_popup��5.   3      IsOpen .     CloseOnClickAway .  $��2��6i      DialogContent 5/      � 50      $��Center=�6   
�������$	��800��6G   $	��300��6T   $��0,0,0,0q�6a   .+�51      � $��Center=�6   $��	0,0,200,0q�68   .+�52      �� ���#29506D$��0q�66   	 �� CornerRadius$	 	05,0,0,05��6J   $��Center=�6c   $��38��6�   $��	0,100,0,0q�6�   $	��Top=�6�   $	��110��6�   $	��150��6�   $��50��6�   ._�53      �� $��Center=�6$   $��Center=�6H   
�������$��	Location:��6�   $��Center=�6�   $��0,0,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��110��6  $��38��6  54      �� 55      
����������#29506D$��5q�6J   $	 	0,05,05,0��6^   $��Center=�6w   $��38��6�   $��250,100,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�56      �� -   5        $��combo_location��56   =   ���#29506D$��Center=�6T   $	��Top=�6r   $	��145��6�   
 K� StylisticSet19
 . $��Tahoma)�58       J� IsHitTestVisible . $��10,0,0,0q�59   5   5;      5<      �� 5=      $:��4Please select the new Location for Selected Machines��6   $��0,10,0,0q�6[   $	��Top=�6m   $��20(�6�   $��Center=�6�   $	��Top=�6�   $��40��6�   $
��Auto��6�   6�   �� 5>      -   5         ��Name$ btn_popup_ok��5>      $��OK��63   ���#29506D$��Bottom=�6U   $��Bottom=�6p   $��Center=�6�   $��
100,0,0,20q�6�   $	��106��6�   $��30��6�   $��1��6�   6�   �� 5?      -   5        $ btn_popup_cancel��5?      $��Cancel��67   
���\\��$��Bottom=�6_   $��Bottom=�6z   $��Center=�6�   $��
0,0,150,20q�6�   $	��106��6�   $��30��6�   $��1��6�   6�   5A      .��5C      �� 
����������#29506D$��1q�6>   $	 01,01,01,01��6R   $
��Left=�6m   $��38��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��250��6�   $	��250��6�   $��50��6�   ._�5D      �� -   5         ��Name$ text_operation��5D   �   ���#29506D{�. $�� ��6A   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search Machine��6I    �� TextAlignment$ Center=�6y   $
��Left=�6�   $	��230��6�   
 . $��Tahoma)�5G       . $��	10,-5,0,5q�5H   -   6]   5J      5K      �� 5L   
   -   5        $ btn_update_location��5L      ���#29506D���#29506D$��Update Location��6Z   $��Right=�6t   $��	0,16,59,0q�6�   $	��Top=�6�   $	��167��6�   6�   �� 5M   
   -	   5        $ btn_help��5M      
������ 
������ $��Right=�6X   $��0,9,2,0q�6t   $	��Top=�6�   $��62��6�   $
��Auto��6�   .��5N      '  !MaterialDesignThemes.Wpf.PackIcon  ���#29506D�	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]] 	  Kind$ Information=�6;   $��34��6N   $��32��6Z   5O      5Q      5R      