   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:Wimetrix_warehouse_mangement_system.SPTS.CutReport2Wimetrix_warehouse_mangement_system.SPTS.CutReport  5      I    CWimetrix_warehouse_mangement_system.SPTS.CutReport.upload_cutreport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Llocal@clr-namespace:Wimetrix_warehouse_mangement_system.SPTS.CutReport  5      .��5
      � 
�������$��Stretch=�6   $	��375��6:   $	��580��6J   .+�5   
   � $��0q�6   $��2��6   .+�5      � -   5        $��progress_bar��5      
�������
����  �  � Minimum$  0Q�6U    � Maximum$	 100Q�6a    � Value$ 0Q�6o   $��
0,56,0,313q�6y   $
��Auto��6�   5      ]� 5   
   $��Stretch=�6   $��0,90,0,0q�60   $��2��6B   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_packing_list��5      $   HorizontalScrollBarVisibility$ Hidden=�60      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   $��3��6g   $��	0,-28,0,0q�6�   5      �� 5   
   -   5        $��btn_excel_import��5      ���#29506D���#29506D$��Import Cut Report��6U   $
��Left=�6q   $��	10,10,0,0q�6�   $	��Top=�6�   $	��167��6�   6�   �� 5   
   -   5         ��Name$ btn_excel_upload��5      ���#29506D���#29506D$��Upload Cut Report��6W   $��Right=�6s   $��	0,10,10,0q�6�   $	��Top=�6�   $	��167��6�   6�   �� 5   
   -   5        $��notifier��5   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��8(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	10,0,0,56q�6�   $��40��6  $	��565��6  $��2��6'  )  #MaterialDesignThemes.Wpf.DialogHost  5   
   -   5        $��popup_status��5   3      IsOpen .  $��Center=�6G   $��Center=�6d      CloseOnClickAway .  $��2��6�      DialogContent 5      ]� 5      $��Center=�6   
�������$
��1000��6L   $	��500��6Z   $��0,0,0,0q�6g   .+�5      �� $A��;Following is the status of the Cut Report you have uploaded��6   $��0,10,0,0q�6b   $	��Top=�6t   $��20(�6�   $��Center=�6�   $	��Top=�6�   $��40��6�   $
��Auto��6�   6�     5      -   5        $#��grid_excel_upload_status_list��5      $ * 6D   $��2��6T   $	��Top=�6i   $��Stretch=�6~   $	��359��6�   $��
10,30,10,0q�6�   �� 5      -   5        $ btn_popup_ok��5      $��OK��63   ���#48576C$��Bottom=�6U   $��Bottom=�6p   $��Center=�6�   $��0,0,0,20q�6�   $	��106��6�   $��30��6�   $��1��6�   6�   5      5       5"      5#      