   M S B A M L   `   `   `  ����B  >Academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Academy.ViewsAcademy.Views  5           Academy.Views.SubjectsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Academy.Views     5      .��5
      � 
�������  � RowDefinitions  5   
   �� 5      $	��150 �6   6+   �� 5      $��* �6   6)   �� 5      $��40 �6   6*   .+�5   
   � $��0��6   .+�5      �� -   5        $��
TxtNewName��5      $
��Left=�6N   $��
112,37,0,0q�6i    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $��22��6�   $	��200��6�   ��6(   �� *	NewName+ �� Mode$ TwoWay=�6�   �� 5      $
��Left=�62   $��	112,0,0,0q�6M   $
 Wrap=�6`   $��Center=�6t   $��22��6�   $	��200��6�   ��6   �� *
NewTeacher+6�   �� 5      -   5        $��BtnUpdateSubject��5      $��30��6U   $��Update Subject��6a   $��324,40,365,10q�6�   {�6-   �� *BtnUpdateSubjects+��6z   �� *UpdateSubjectsCommand+6�   �� 5      $��30��6   $��New Subject��6!   $��324,110,365,10q�6]   ��67   �� *AddSubjectCommand+6]   �� 5      $
��Name��6   $
��Left=�6#   $��22��6>   $��	10,37,0,0q�6J   $	��Top=�6]   $	��102��6u   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5      $��Teacher��6   $
��Left=�6&   $��22��6A   $��10,0,0,0q�6M   $��Center=�6_   $	��102��6z   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5      $��1q�6   
���   �$
��Left=�6=   $	��146��6X   $��10,4,0,0q�6e   $	��Top=�6w   $	��425��6�   �� 5      $
��Left=�6   $��	440,0,0,0q�61   $����1.-) Press 'Read Subjects' to get subjects in the grid                      
2.-) Delete: Select one subject in the grid and press button 'Delete Subject'                      
3.-) New: Write in the boxes new subject data and press 'New Subject'                      
4.-) Update: select the subject in the grid to update, write only new data in the boxes, and press button 'Update Subject'��6D   $
 Wrap=�5      $��Center=�6+   $	��337��6F   $	��128��6R   5      � 5    
   $��1��6   .+�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ DatagridSubjects��5!      $��5q�6x    J� 	AllowDrop$
 True��6�      CanUserReorderColumns$ False��6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      CanUserAddRows$ false��6�   ��61   �� *
Subjects+	 �� SelectedItem	 6R   �� *SelectedItem+6�   5"      � 5#   
   $��2��6   .+�5$      �� $	��120��6   $��30��6!   $��Read Subjects��6-   $��Right=�6l   $��5q�6�   ��6E   �� *GetSubjectsCommand+6�   �� 5%      -   5        
 ��Name$
 	DelButton��5%      $	��120��6(   $��30��64   $��Delete Subject��6@   $
��Left=�6�   $��	531,5,0,5q�6�   ��6Y   �� *DeleteSubjectsCommand+6�   5&      5'      5(      