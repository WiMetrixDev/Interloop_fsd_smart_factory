   M S B A M L   `   `   `  ���� U  QWimetrix Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Wimetrix_warehouse_mangement_system#Wimetrix_warehouse_mangement_system  4    .Wimetrix_warehouse_mangement_system.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Clocal1clr-namespace:Wimetrix_warehouse_mangement_system     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$"  Database Connection         ��$	��500��$	��800�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency . $��1,0,0,0q� � WindowStartupLocation$ CenterScreen=�.��� $��-2,10,2,-10q� � ColumnDefinitions �� $	��55* ��� $	��17* �.+��� $��/Assets/logo/wiii.png��$��Center=�$��53��$��294,0,107.331,0q�$	��Top=�$	��204���� ���#29506D$��0q� �� CornerRadius$ 50,0,0,0��$
��Left=�$��38��$��235,255,0,0q�$	��Top=�$	��130��$	��150��$��50���� 
����������#29506D$��5q�$ 0,0,10,0��$
��Left=�$��38��$��357,255,0,0q�$	��Top=�$	��170��$	��170��$��50���� -    ��Name$ text_password��$��372,260,93,0q�$	��Top=�$	��145�� K� StylisticSet19 . $��Tahoma)�	 J� IsHitTestVisible	 . �� -   
 ��Name$
 db_login��$��Login��
������ ���#29506D$��Center=�$��352,329,151,135q�$	��107��$
��Auto�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$
 0.37Q�T� �� -   $
 btn_windowClose��$��X��$��13(�$��Right=�$	��Top=�$��Center=�$��Center=�$��40��$��25��$��1��$��0,0,10,0q�
���  ���� -   $
 	btn_setIP��
������ 
������ $
��Left=�$��113,408,0,16q�$��66��$
��Auto��$��1��.��'  !MaterialDesignThemes.Wpf.PackIcon  ���#29506D�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Information=�$��34��$��32���� -   $
 btn_windowMinimize��$��-��$��13(�$��Right=�$	��Top=�$��Center=�$��Center=�$��40��$��25��$��1��$��0,0,55,0q����#29506D$ 1.317,0.456&��� -    ��Name$ label_password_Copy��$��Center=�$��Center=�
�������$��	Password:��$
��Left=�$��243,255,0,0q�$	��Top=�$��14(�$
��Bold"�$	��129��$��38���� ���#29506D$��0q�$ 50,0,0,0��$
��Left=�$��38��$��235,195,0,0q�$	��Top=�$	��130��$	��150��$��50���� 
����������#29506D$��5q�$ 0,0,10,0��$
��Left=�$��38��$��357,195,0,0q�$	��Top=�$	��170��$	��170��$��50���� -   $ text_password_Copy��$��372,200,93,0q�$	��Top=�$	��145�� . $��Tahoma)�	 . �� -   $ label_username��$��Center=�$��Center=�
�������$��	Username:��$
��Left=�$��243,195,0,0q�$	��Top=�$��14(�$
��Bold"�$	��129��$��38���� $��Set IP��$��1��$
��Left=�$��127,458,0,0q�$	��Top=�)  #MaterialDesignThemes.Wpf.DialogHost  -	   $��ip_popup��   IsOpen .     CloseOnClickAway .  $��2��   DialogContent � $	��120q�.+��� $��Please provide IP Address��$��Center=�$��	0,-60,0,0q�$	��Top=�$��20(�$
��Bold"�$��1��]� -
    ]�Name$ ip_dock��
������ $��0,0,0,0q�.+��� ���#438830$��0q�$ 50,0,0,0��$
��Left=�$��38��$��0,0,0,0q�$	��Top=�$	��130��$	��150��$��50���� 
����������#438830$��5q�$ 0,0,0,0��$
��Left=�$��38��$��0,0,0,0q�$	��Top=�$	��170��$	��170��$��50���� -   $ label_ip��$��Center=�$��Center=�
�������$	��IP:��$
��Left=�$��
-300,0,0,0q�$	��Top=�$��14(�$
��Bold"�$	��129��$��38���� -   $ text_ip��$��
-180,5,0,0q�$	��Top=�$	��145�� . $��Tahoma)�	 . �� -   $
 btn_set��$	��Set�����#48576C���#48576C$
��Left=�$��20,0,0,0q�$	��106��$
��Auto��$��1��