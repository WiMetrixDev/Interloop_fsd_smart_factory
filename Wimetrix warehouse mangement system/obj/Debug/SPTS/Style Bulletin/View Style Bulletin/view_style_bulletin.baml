   M S B A M L   `   `   `  ����U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Yclr-namespace:Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.View_Style_BulletinKWimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.View_Style_Bulletin  5      e    _Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.View_Style_Bulletin.view_style_bulletin   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      elocalYclr-namespace:Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.View_Style_Bulletin  5      .��5
      � 
�������$��Stretch=�6   $	��375��6:   $	��580��6J   $��0,0,0,0q�6Y   .+�5   
   � -   5        $��progress_bar��5      
�������
����  �  � Minimum$  0Q�6Q    � Maximum$	 100Q�6]    � Value$ 0Q�6k   $��
0,56,0,313q�6u   $
��Auto��6�   ]� 5   
   $��Stretch=�6   $��0,90,0,0q�60   $��2��6B   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��grid_view_styleBulletin��5         AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Hidden=�6      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��3��6�   $��	0,-28,0,0q�6�   ��66   �� *style_bulletin_list+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Style ID��6)      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6N   �� *
Style_ID+  5      $ Order ID��6)    . 	 6M   �� *Order+  5      $ 
Style Code��6)    . 	 6P   �� *	StyleCode+  5      $ Article��6)    . 	 6M   �� *	Article+  5      $ Operation ID��6)    . 	 6Q   �� *Operation_ID+  5      $ Operation Description��6)    . 	 6Z   �� *Operation_Description+  5      $	 SMV��6)    . 	 6H   �� *SMV+  5      $ 
Piece Rate��6)    . 	 6O   �� *	PieceRate+  5      $ OP Sequence��6)    .  	 6Q   �� *
opsequence+5%      5&      �� 5(   
   -   5        $��btn_view_style_bulletin��5(      ���#29506D���#29506D$��View Style bulletin��6\   $��Right=�6z   $��	0,10,10,0q�6�   $	��Top=�6�   $	��167��6�   6�   �� 5)   
   -   5        $��notifier��5)   �   $��NOTE: Scan ano��6   $y�Hidden=�6(   $��Center=�6<   $��Center=�6`   $��8(�6�   
�������
�������$
��Left=�6�   $��Bottom=�6�   $��	10,0,0,56q�6�   $��40��6  $	��565��6  $��2��6'  �� 5*   
   ���#29506D$��0q�6&   
 �� CornerRadius$
 50,0,0,0��6:   $
��Left=�6R   $��38��6m   $��20,8,0,0q�6y   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5+   
   ���#29506D$��0q�6&   $
 	05,0,0,05��6:   $
��Left=�6S   $��38��6n   $��10,8,0,0q�6z   $	��Top=�6�   $	��110��6�   $	��150��6�   $��50��6�   �� 5,   
   
����������#29506D$��5q�6:   $
 	0,05,05,0��6N   $
��Left=�6g   $��38��6�   $��	105,8,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5-      �� -   5         ��Name$ combo_orders��5-   /   ���#29506D$
��Left=�6E   $	��Top=�6a   $	��145��6y    K� StylisticSet19 . $��Tahoma)�5/       J� IsHitTestVisible . $��10,0,0,0q�50   )   6;   52      �� 53   
   $��Center=�6   $��Center=�64   
�������$��OrderID:��6u   $
��Left=�6�   $��	10,10,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��110��6�   $��38��6�   �� 54   
   ���#29506D$��0q�6&   $
 50,0,0,0��6:   $
��Left=�6R   $��38��6m   $��	293,8,0,0q�6y   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 55   
   ���#29506D$��0q�6&   $
 	05,0,0,05��6:   $
��Left=�6S   $��38��6n   $��	283,8,0,0q�6z   $	��Top=�6�   $	��110��6�   $	��150��6�   $��50��6�   �� 56   
   
����������#29506D$��5q�6:   $
 	0,05,05,0��6N   $
��Left=�6g   $��38��6�   $��	378,8,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�57      �� -   5        $ combo_style��57   /   ���#29506D$
��Left=�6D   $	��Top=�6`   $	��145��6x    . $��Tahoma)�59       . $��10,0,0,0q�5:   )   6;   5<      �� 5=   
   $��Center=�6   $��Center=�64   
�������$��Style Code:��6u   $
��Left=�6�   $��
283,10,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��110��6�   $��38��6�   �� 5>   
   ���#29506D$��0q�6&   $
 50,0,0,0��6:   $
��Left=�6R   $��38��6m   $��	563,6,0,0q�6y   $	��Top=�6�   $��86��6�   $	��150��6�   $��50��6�   �� 5?   
   ���#29506D$��0q�6&   $
 	05,0,0,05��6:   $
��Left=�6S   $��38��6n   $��	553,6,0,0q�6z   $	��Top=�6�   $	��110��6�   $	��150��6�   $��50��6�   �� 5@   
   
����������#29506D$��5q�6:   $
 	0,05,05,0��6N   $
��Left=�6g   $��38��6�   $��	648,6,0,0q�6�   $	��Top=�6�   $	��170��6�   $	��170��6�   $��50��6�   ._�5A      �� -   5        $ combo_article��5A   /   ���#29506D$
��Left=�6F   $	��Top=�6b   $	��145��6z    . $��Tahoma)�5C       . $��10,0,0,0q�5D   )   5F      �� 5G   
   $��Center=�6   $��Center=�64   
�������$��Article:��6u   $
��Left=�6�   $��	553,8,0,0q�6�   $	��Top=�6�   $��14(�6�   $
��Bold"�6�   $	��110��6�   $��38��6�   5H      5I      