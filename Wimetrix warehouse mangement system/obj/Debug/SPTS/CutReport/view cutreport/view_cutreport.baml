   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Oclr-namespace:Wimetrix_warehouse_mangement_system.SPTS.CutReport.view_cutreportAWimetrix_warehouse_mangement_system.SPTS.CutReport.view_cutreport  5      V    PWimetrix_warehouse_mangement_system.SPTS.CutReport.view_cutreport.view_cutreport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      [localOclr-namespace:Wimetrix_warehouse_mangement_system.SPTS.CutReport.view_cutreport  5      .��5
      � 
�������$��Stretch=�6   $	��375��6:   $	��580��6J   $��0,0,0,0q�6Y   .+�5   
   � $��0,-4,0,4q�6   .+�5      � -   5        $��progress_bar��5      
�������
����  �  � Minimum$  0Q�6U    � Maximum$	 100Q�6a    � Value$ 0Q�6o   $��
0,56,0,313q�6y   $
��Auto��6�   �� 5      ���#29506D$��0q�6*    �� CornerRadius$ 50,0,0,0��6>   $
��Left=�6V   $��38��6q   $��20,8,0,0q�6}   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5      ���#29506D$��0q�6*   $ 	05,0,0,05��6>   $
��Left=�6W   $��38��6r   $��10,8,0,0q�6~   $	��Top=�6�   $	��110��6�   $	��150��6�   $��50��6�   �� 5      
����������#29506D$��5q�6>   $ 	0,05,05,0��6R   $
��Left=�6k   $��38��6�   $��	105,8,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5      �� -   5         ��Name$ combo_orders��5   3   ���#29506D$
��Left=�6I   $	��Top=�6e   $	��145��6}    K� StylisticSet19 . $��Tahoma)�5       J� IsHitTestVisible . $��10,0,0,0q�5   -   5      �� 5      $��Center=�6   $��Center=�68   
�������$��OrderID:��6y   $
��Left=�6�   $��	10,10,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��110��6�   $��38��6�   5      ]� 5   
   $��Stretch=�6   $��0,90,0,0q�60   $��2��6B   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_view_cutreport��5         AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�6|   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6�   $��3��6�   $��	0,-28,0,0q�6�   ��62   �� *cutreport_model_list+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��6)      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *Order+  5      $ 
Style Code��6)    .  6O   �� *Style+  5      $ 
Style Code��6)    .  6P   �� *Style+  5      $ 
Style Code��6)    .  6O   �� *Style+  5      $ Article��6)    .  6L   �� *	Article+  5       $
 Size��6)    .  6I   �� *Size+  5!      $ Color��6)    .  6J   �� *Color+  5"      $	 Lot��6)    .  6H   �� *Lot+  5#      $ Bundle��6)    .  6K   �� *Bundle+  5$      $ Quantity��6)    6;   �� *
Quantity+5/      51      �� 53   
   -   5        $��btn_load_cutreport��53      ���#29506D���#29506D$��Load Cut Report��6W   $��Right=�6q   $��113,10,10,0q�6�   $	��Top=�6�   $	��167��6�   6�   �� 54   
   -   5        $��notifier��54   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��8(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	10,0,0,56q�6�   $��40��6  $	��565��6  $��2��6'  58      59      