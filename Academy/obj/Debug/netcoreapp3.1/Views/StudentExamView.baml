   M S B A M L   `   `   `  ����B  >Academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Academy.ViewsAcademy.Views  5      #    Academy.Views.StudentExamView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Academy.Views     5      .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $	��180 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   � $��0��6   .+�5      �� $��Students Name��6   $
��Left=�6,   $��28��6G   $��
-11,47,0,0q�6S   $	��Top=�5      $	��124��6,   $��16(�68   $��Right=�6F   $��5,0,5,0q�5      �� 5       �� DisplayMemberPath$
 Name��5      $
��Left=�60   $��31��6K   $��
113,44,0,0q�6W   $	��Top=�5      $	��203��6/   ��5      �� *StudentsList+ �� SelectedItem 6<   �� *SelectedItemComboStudent+5   /   �� 5      $��
Exam Title��6   $
��Left=�6)   $��29��6D   $��
-11,92,0,0q�6P   $	��Top=�5      $	��124��6,   $��16(�68   $��Right=�6F   $��5,0,5,0q�5      �� 5      $ Title��5      $
��Left=�61   $��31��6L   $��
113,90,0,0q�6X   $	��Top=�5      $	��203��6/   ��5      �� *	ExamsList+ 69   �� *SelectedItemComboExam+5   /   �� 5      $
��Left=�6   $��113,131,0,0q�61    �� TextWrapping$
 Wrap=�6\   $	��Top=�5      $��52��6.   $��29��69   ��5   F   �� *Mark+5   9   �� 5      $
��Mark��6   $
��Left=�6#   $��29��6>   $��-11,131,0,0q�6J   $	��Top=�5      $	��119��6,   $��16(�68   $��Right=�6F   $��5,0,5,0q�5       �� 5!      $
��Left=�66   $��
333,46,0,0q�6Q   $	��Top=�5"      $��94��6,   ��5!      �� *Student.Email+5"   ,   �� 5#      $
��Left=�64   $��
432,46,0,0q�6O   $	��Top=�5$      $��95��6,   ��5#      �� *Student.Dni+5$   ,   �� 5%      $��Has Cheated��6E   $
��Left=�6[   $��214,131,0,0q�6v   $	��Top=�5&      $��29��6/   $	��102��6;    d� 	IsChecked 5%      �� *
HasCheated+ �� Mode$ TwoWay=�5&   ;   �� 5'      $��New Exam-Mark��6   $��362,131,273,18q�6W   ��6-   �� *AddStudentExamCommand+6W   �� 5(      -   5        $��BtnUpdateExam��5(      $��Update Exam-Mark��6*   $��567,131,68,18q�5)   B   ��6   �� *UpdateStudentExamCommand+6B   5+      � 5,   
   $��1��6   .+�5-      &   System.Windows.Controls.DataGrid  -   5          Name$ DatagridStudentExam��5-      $��5q�5.       J� 	AllowDrop$
 True��6"      CanUserReorderColumns$ False��63   	   SelectionMode$	 Single=�6Q   
   SelectionUnit$
 FullRow=�5/         CanUserAddRows$ false��6/      AutoGenerateColumns$ False��6F   ��5-   4   �� *StudentExamList+ 6\   �� *SelectedItem+   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Student��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Student.Name+  52      $ 
Exam Title��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6\    6=   �� *
Exam.Title+6\     53      $ Exam Subject��6)   $	 100 6e    6?   �� *Exam.Subject.Name+6e     54      $ 	Exam Mark��6)    6<   �� *Mark+4  .System.Windows.Controls.DataGridCheckBoxColumn  55      $ Has Cheated��6-   $	 100 6a    6B   �� *
HasCheated+6a   58      59      � 5:   
   $��2��6   .+�5;      �� $	��120��6   $��30��6!   $��Read Exams-Marks��6-   $��Right=�5<      $��5q�61   ��5;   H   �� *GetStudentExamCommand+5<   1   �� 5=      -   5         ��Name$ 	DelButton��5=      $	��120��6(   $��30��64   $��Delete Exam-Mark��6@   $
��Left=�5>   B   $��	531,5,0,5q�6]   ��6   �� *DeleteStudentExamCommand+6]   5A      5C      5D      