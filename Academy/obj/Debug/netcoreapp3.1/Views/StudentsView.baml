   M S B A M L   `   `   `  ����B  >Academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Academy.ViewsAcademy.Views  5           Academy.Views.StudentsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Academy.Views     5      .��5
      � 
�������  � RowDefinitions  5   
   �� 5      $	��150 �6   6+   �� 5      $��* �6   6)   �� 5      $��40 �6   6*   .+�5   
   � $��0��6   .+�5      �� -   5        $��
TxtNewName��5      $
��Left=�6N   $��
112,37,0,0q�6i    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $��22��6�   $	��200��6�   ��6(   �� *	NewName+ �� Mode$ TwoWay=�6�   �� 5      $
��Left=�60   $��	112,0,0,0q�6K   $
 Wrap=�6^   $��Center=�6r   $��22��6�   $	��200��6�   ��6   �� *
NewEmail+6�   �� 5      $
��Left=�6.   $��
112,91,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $��22��6�   $	��200��6�   ��6   �� *NewDni+6�   �� 5      $
��Left=�60   $��112,117,0,0q�6K   $
 Wrap=�6a   $	��Top=�6u   $��22��6�   $	��200��6�   ��6   �� *
NewChair+6�   �� 5      -   5        $��BtnUpdateStd��5      $��30��6L   $��Update Student��6X   $��324,40,365,10q�6�   {�6)   �� *BtnUpdateStd+��6q   �� *UpdateStudentsCommand+6�   �� 5      $��30��6   $��New Student��6!   $��324,110,365,10q�6]   ��67   �� *AddStudentCommand+6]   �� 5      $
��Name��6   $
��Left=�6#   $��22��6>   $��	10,37,0,0q�6J   $	��Top=�6]   $	��102��6u   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5      $��Email��6   $
��Left=�6$   $��22��6?   $��10,0,0,0q�6K   $��Center=�6]   $	��102��6x   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5      $	��DNI��6   $
��Left=�6"   $��22��6=   $��	10,91,0,0q�6I   $	��Top=�6\   $	��102��6t   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5      $��Chair Number��6   $
��Left=�6+   $��22��6F   $��
10,117,0,0q�6R   $	��Top=�6f   $	��102��6~   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5      $��1q�6   
���   �$
��Left=�6=   $	��146��6X   $��10,4,0,0q�6e   $	��Top=�6w   $	��425��6�   �� 5      $
��Left=�6   $��	440,0,0,0q�61   $����1.-) Press 'Read Students' to get students in the grid                      
2.-) Delete: Select one student in the grid and press button 'Delete Student'                      
3.-) New: Write in the boxes new student data and press 'New Student'                      
4.-) Update: select the student in the grid to update, write only new data in the boxes, and press button 'Update Student'��6D   $
 Wrap=�5!      $��Center=�6+   $	��337��6F   $	��128��6R   5"      � 5#   
   $��1��6   .+�5$      &   System.Windows.Controls.DataGrid  -   5          Name$ DatagridStudents��5$      $��5q�6x    J� 	AllowDrop$
 True��6�      CanUserReorderColumns$ False��6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      CanUserAddRows$ false��6�   ��61   �� *
Students+	 �� SelectedItem	 6R   �� *SelectedItem+6�   5%      � 5&   
   $��2��6   .+�5'      �� $	��120��6   $��30��6!   $��Read Students��6-   $��Right=�6l   $��5q�6�   ��6E   �� *GetStudentsCommand+6�   �� 5(      -   5        
 ��Name$
 	DelButton��5(      $	��120��6(   $��30��64   $��Delete Student��6@   $
��Left=�6�   $��	531,5,0,5q�6�   ��6Y   �� *DeleteStudentsCommand+6�   5)      5*      5+      