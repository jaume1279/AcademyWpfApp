   M S B A M L   `   `   `  ����B  >Academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Academy.ViewsAcademy.Views  5      $    Academy.Views.StatsStudentView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Academy.Views     5      .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $	��180 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��320 �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��0��6   
������ $��0,0,0,10q�6E   .+�5      �� $��
View Exams��6   $��31��6*   $	��120��66   $
��Left=�6B   $��	120,0,0,0q�5      $	��Top=�6(   ��6@   �� *GetExamsByStudentCommand+&   System.Windows.Controls.DataGrid  5      -   5          Name$ DatagridExamsByStudList��5      $��
10,46,5,10q�5       J� 	AllowDrop$
 True��6+      CanUserReorderColumns$ False��6<      SelectionMode$ Single=�6Z      SelectionUnit$ FullRow=�5         CanUserAddRows$ false��6/      AutoGenerateColumns$ False��6F   ��5   8   �� *ExamsByStudentList+	 �� Mode$	 TwoWay=�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Subject��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Exam.Subject.Name+6`     5      $ Title��6)   $ 70 6W    68   �� *
Exam.Title+6W     5      $
 Text��6)   $ 40 6U    67   �� *	Exam.Text+6U     5      $
 Mark��6)   $ 40 6P    67   �� *Mark+6P   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Has Cheated��6-   $	 100 6a    6B   �� *
HasCheated+6a   5!      5"      � 5#   
   $��0��6   $��0��6   .+�5$      �� $��Select Student:��6   $
��Left=�6.   $��30��6I   $��	-14,6,0,0q�6U   $	��Top=�5%      $	��124��6,   $��16(�68   $��Right=�6F   $��5,0,5,0q�5&      �� 5(      -   5         ��Name$ ComboStudent��5(       �� DisplayMemberPath$
 Name��5)      $
��Left=�60   $��31��6K   $��	110,6,0,0q�6W   $	��Top=�5*      $	��204��6/   ��5(   -   �� *StudentsList+ �� SelectedItem 6R   �� *SelectedItemComboStudent+5*   /   �� 5,      -   5         ��Name$ 
TxtNewName��5,      $
��Left=�6f   $��
112,42,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $��22��6�   $	��200��6�   ��6*   �� *SelectedItemComboStudent.Name+$	 TwoWay=�6�   �� 5-      $
��Left=�6F   $��
112,69,0,0q�6a   $
 Wrap=�6u   $	��Top=�6�   $��22��6�   $	��200��6�   ��6   �� * SelectedItemComboStudent.Email+6�   �� 5.      $
��Left=�6D   $��
112,96,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $��22��6�   $	��200��6�   ��6   �� *SelectedItemComboStudent.Dni+6�   �� 5/      $
��Left=�6L   $��112,123,0,0q�6g   $
 Wrap=�6}   $	��Top=�6�   $��22��6�   $	��200��6�   ��6   �� *&$SelectedItemComboStudent.ChairNumber+6�   �� 50      $
��Name��6   $
��Left=�6#   $��22��6>   $��	14,42,0,0q�6J   $	��Top=�6]   $��94��6u   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 51      $��Email��6   $
��Left=�6$   $��22��6?   $��	14,69,0,0q�6K   $	��Top=�6^   $��98��6v   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 52      $	��DNI��6   $
��Left=�6"   $��22��6=   $��	14,96,0,0q�6I   $	��Top=�6\   $��98��6t   $
��Left=�6   $	��Top=�6�   $��5,0,5,0q�6�   �� 53      $��Chair Number��6   $
��Left=�6+   $��22��6F   $��
14,123,0,0q�6R   $	��Top=�6f   $��98��6~   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   54      � 55   
   $��0��6   $��1��6   .+�56      �� $��Start��6   $��31��6%   $��5,6,370,143q�61   ��6F   �� *ClearCboStudentsCommand+�� 57      $��View Subjects��6   $��31��6-   $��5,42,370,107q�69   ��6O   �� *GetSubjectsByStudentCommand+  59      -   5        $ DatagridSubjByStudList��59      $��	110,5,5,5q�5:      $
 True��6*   $ False��6;   $ Single=�6Y   $ FullRow=�5;      $ false��6/   $ False��6F   ��59   7   �� *SubjectsByStudentList+$	 TwoWay=�
 5<        5=      $ Subject��6)   $	 100 6[    6:   �� *Subject.Name+6[     5>      $ Teacher��6)   $	 100 6^    6:   �� *Subject.Teacher+6^   5@      5A      � 5B   
   $��1��6   $��1��6   .+�5C      �� $
��Left=�6/   $��
190,72,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $��22��6�   $	��200��6�   ��6   �� *	MaxMark+6�   �� 5D      $��Max Mark��6   $
��Left=�6'   $��22��6B   $��	77,72,0,0q�6N   $	��Top=�6a   $��94��6y   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5E      $
��Left=�6/   $��190,113,0,0q�6J   $
 Wrap=�6`   $	��Top=�6t   $��22��6�   $	��200��6�   ��6   �� *	MinMark+6�   �� 5F      $��Min Mark��6   $
��Left=�6'   $��22��6B   $��
77,111,0,0q�6N   $	��Top=�6b   $��94��6z   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5G      $
��Left=�6/   $��190,154,0,0q�6J   $
 Wrap=�6`   $	��Top=�6t   $��22��6�   $	��200��6�   ��6   �� *	AvgMark+6�   �� 5H      $��Average Mark��6   $
��Left=�6+   $��22��6F   $��
77,154,0,0q�6R   $	��Top=�6f   $��94��6~   $
��Left=�6�   $	��Top=�6�   $��5,0,5,0q�6�   �� 5I      $��
STATISTICS��6   $
��Left=�6)   $��36��6D   $��	98,10,0,0q�6P   $	��Top=�6c   $	��292��6{   $��24(�6�   $��Center=�6�   5K      5L      5M      