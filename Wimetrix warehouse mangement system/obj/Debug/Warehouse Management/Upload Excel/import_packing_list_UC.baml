   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Sclr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_ExcelEWimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel  5      b    \Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel.import_packing_list_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      _localSclr-namespace:Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel  5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � $��0,0,0,0q�6   
�������$��Stretch=�6/   $��Stretch=�6M   $	��375��6i   $	��580��6y   .+�5   
   �� 
���   ����#438830$��0q�6:   $��2��6N   $��Right=�6^   $��0,0,0,0q�6z   $��5��6�     J� RenderTransformOrigin$  0.5,0.5&�6�   �� 5   
   
���   ����#438830$��0q�6:   $��5��6N   $��0,0,0.4,-0.4q�6Y   $��Bottom=�6o   $��3��6�   �� 5   
   
���   ����#438830$��0q�6:   $
��Left=�6N   $��5��6i   $  0.5,0.5&�6s   �� 5   
   $��Upload Packing List��6   $��Center=�6.   $��186,10,162,0q�6K   $	��Top=�6a   $��24(�6y   $
��Bold"�6�   �� 5   
   
���   ����#438830$��0q�6:   $��5��6N   $��0,0,0,0q�6Y   $	��Top=�6j   $��3��6�   � 5   
   $��20q�6   .+�5      � -   5        $��progress_bar��5      
�������
����  � � Minimum$ 0Q�6U    � Maximum$	 100Q�6a    � Value$ 0Q�6o   $��
0,93,0,234q�6y   $
��Auto��6�   5      ]� 5   
   $��Stretch=�6   $��3��60   $��20,120,20,20q�6D   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_packing_list��5      $   HorizontalScrollBarVisibility$ Visible=�60   $��3��6Y   5      �� 5   
   -   5        $��btn_excel_import��5      ���#29506D���#29506D$��Import Packing List��6U   $��Right=�6s   $��
0,52,200,0q�6�   $	��Top=�6�   $	��167��6�   6�   �� 5   
   $��../../Assets/logo/il.png��6   $
��Left=�63   $	��166��6O   $��99��6[   $��	20,18,0,0q�6g   $	��Top=�6z   $  0.5,0.5&�6�   5      �� 5   
   -   5         ��Name$ btn_excel_upload��5      ���#29506D���#29506D$��Upload Packing List��6W   $��Right=�6u   $��	0,52,20,0q�6�   $	��Top=�6�   $	��167��6�   6�   �� 5   
   -   5        $��notifier��5   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��12(�6�   
�������$
��Bold"�6�   
�������$
��Left=�6�   $��Bottom=�6�   $��	10,0,0,56q�6  $��40��6"  $	��565��6.  �� 5   
   -   5        $��check_force_upload��5      $��Force Upload��6-   $��Right=�6D   $��	0,90,20,0q�6`   $	��Top=�6s   )  #MaterialDesignThemes.Wpf.DialogHost  5    
   -   5        $��loader��5    3      IsOpen .     CloseOnClickAway .  $��2��6[      DialogContent 5!      � 5"      $	��120q�6   .+�5#      �� $��Please Wait��6   $��Center=�62   $��	0,-60,0,0q�6O   $	��Top=�6b   $��20(�6z   $
��Bold"�6�   $��1��6�   � 5$      $��20q�6   .+�5%      "  FontAwesome.WPF.ImageAwesome  	   Icon$	 Refresh=�6*   
   Spin
 . $��48��6E   $��48��6Q   5&      5(      5*        5,   
   -   5        $��popup_status��5,   3    .   .  $��2��6a    5-      ]� 5.      $��Center=�6   
�������$
��1000��6L   $	��500��6Z   $��0,0,0,0q�6g   .+�5/      �� $<��6Following is the status of the excel you have uploaded��6   $��0,10,0,0q�6]   $	��Top=�6o   $��20(�6�   $��Center=�6�   $	��Top=�6�   $��40��6�   $
��Auto��6�   6�     50      -	   5        $#��grid_excel_upload_status_list��50         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6D   $��2��6T   $	��Top=�6i   $��Stretch=�6~   $	��359��6�   $��
10,30,10,0q�6�   �� 51      -
   5        $ btn_popup_ok��51      $��OK��63   ���#48576C$��Bottom=�6U   $��Bottom=�6p   $��Center=�6�   $��0,0,0,20q�6�   $	��106��6�   $��30��6�   $��1��6�   6�   53      55      57      58      