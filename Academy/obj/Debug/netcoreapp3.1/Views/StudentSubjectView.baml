   M S B A M L   `   `   `  ����B  >Academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Academy.ViewsAcademy.Views  5      &     Academy.Views.StudentSubjectView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Academy.Views     5      .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $	��150 �6   6+   �� 5      $��* �6   6)   �� 5      $��40 �6   6*   .+�5   
   � $��0��6   .+�5      �� $��1q�6   
���   �$��Center=�6=   $	��146��6Z   $��0,4,0,0q�6g   $	��Top=�6x   $	��780��6�   5      �� 5      $��Students Name��6   $
��Left=�6,   $��29��6G   $��
-13,46,0,0q�6S   $	��Top=�6g   $	��124��6   $��16(�6�   $��Right=�6�   $��5,0,5,0q�6�   �� 5      $��Subjects Name��6   $
��Left=�6,   $��29��6G   $��
366,46,0,0q�6S   $	��Top=�6g   $	��120��6   $��16(�6�   $��Right=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5      $��Clear��6   $��720,44,10,75q�6%   ��6;   �� *ClearCboSubjectsCommand+�� 5      $��Clear��6   $��321,44,413,75q�6%   ��6<   �� *ClearCboStudentsCommand+�� 5       �� DisplayMemberPath$
 Name��6n   $
��Left=�6�   $��31��6�   $��
113,44,0,0q�6�   $	��Top=�6�   $	��203��6�   ��6   �� *StudentsList+ �� SelectedItem 6<   �� *SelectedItemComboStudent+6�   �� 5      $
 Name��6n   $
��Left=�6�   $��31��6�   $��
498,44,0,0q�6�   $	��Top=�6�   $	��217��6�   ��6   �� *SubjectsList+ 6<   �� *SelectedItemComboSubject+6�   �� 5      $��Add new Student-Subject��6   $��152,96,152,24q�67   ��6N   �� *AddStudentSubjectCommand+5      � 5   
   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DatagridStudentSubject��5      $��5q�5   E    J� 	AllowDrop$
 True��6P      CanUserReorderColumns$ False��5         SelectionMode$ Single=�65      SelectionUnit$ FullRow=�6L      CanUserAddRows$ false��6d   	   AutoGenerateColumns$	 False��5      ��5   7   �� *StudentSubjectList+ 5      �� *SelectedItemStudSubj+
   Columns
 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Student��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Student.Name+6[     5"      $ Subject��6)   $	 200 6[    6:   �� *Subject.Name+6[   5$      5%      � 5&   
   $��2��6   .+�5'      �� $	��120��6   $��30��6!   $��Read StudentSubject��6-   $��Right=�6x   $��5q�6�   ��6K   �� *GetStudentSubjectCommand+6�   �� 5(      $	��120��6   $��30��6!   $��Delete StudentSubject��6-   $
��Left=�6}   $��	531,5,0,5q�6�   ��6M   �� *DeleteStudentSubjectCommand+6�   5)      5*      5+      