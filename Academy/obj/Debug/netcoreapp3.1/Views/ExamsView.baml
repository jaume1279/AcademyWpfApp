   M S B A M L   `   `   `  ����B  >Academy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Academy.ViewsAcademy.Views  5          Academy.Views.ExamsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Academy.Views     5      .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $	��180 �6   6+   �� 5      $��* �6   6)   �� 5      $��40 �6   6*   .+�5   
   � $��0��6   .+�5      �� $��Title��6   $
��Left=�6$   $��22��6?   $��	23,21,0,0q�6K   $	��Top=�6^   $��60��5      $
��Left=�6   $	��Top=�6A   $��5,0,5,0q�6`   �� 5      -   5        $��TxtTitle��5      $
��Left=�6J   $��	88,21,0,0q�6e    �� TextWrapping$
 Wrap=�5      $	��Top=�6*   $��22��6B   $	��200��6N   ��5   &   �� *Title+ �� Mode$ TwoWay=�5   N   �� 5      $
��Text��6   $
��Left=�6#   $��22��6>   $��	23,48,0,0q�6J   $	��Top=�6]   $��60��5      $
��Left=�6   $	��Top=�6A   $��5,0,5,0q�6`   �� 5      -   5        $��TxtText��5      $
��Left=�6H   $��	88,48,0,0q�6c   $
 Wrap=�5      $	��Top=�6*   $	��117��6B   $	��200��6O   ��5   %   �� *Text+$ TwoWay=�5   O   �� 5      $
��Date��6   $
��Left=�6#   $��24��6>   $��
328,21,0,0q�6J   $	��Top=�6^   $��60��5      $
��Left=�6   $��Center=�6A   $��5,0,5,0q�6c   (  "System.Windows.Controls.DatePicker  5      $
��Left=�6   $��
388,21,0,0q�66   $	��Top=�5         SelectedDate 64   �� *Date+�� 5      $��Subject��6   $
��Left=�6&   $��24��6A   $��
328,57,0,0q�6M   $	��Top=�6a   $��60��5      $
��Left=�6   $��Center=�6A   $��5,0,5,0q�6c   �� 5        �� DisplayMemberPath$
 Name��5!      $
��Left=�60   $��24��6K   $��
388,57,0,0q�6W   $	��Top=�5"      $	��217��6/   ��5       �� *SubjectsList+ �� SelectedItem 6<   �� *SelectedItemComboSubject+ �� StringFormat$ 
DD/MM/yyyy��5"   /   �� 5#      $��New Exam��6   $��318,90,318,41q�6K   ��6(   �� *AddExamCommand+6K   �� 5$      -   5        $��BtnUpdateExam��5$      $��Update Exam��6*   $��512,90,122,41q�5%   ;   ��6   �� *UpdateExamCommand+6;   �� 5&      $
��Left=�6   $��36��61   $��318,144,0,0q�6=   $
 Wrap=�6R   $	��Top=�5'      $	��445��60   $����Rule: All exams must have: Title, Text, Date, Subject                      
Rule: Can exist two identic exams in different Date. ��5(      5,      � 5-   
   $��1��6   .+�5.      &   System.Windows.Controls.DataGrid  -   5          Name$ DatagridExams��5.      $��5q�5/       J� 	AllowDrop$
 True��6"   	   CanUserReorderColumns$	 False��63   
   SelectionMode$
 Single=�6Q      SelectionUnit$ FullRow=�50         CanUserAddRows$ false��6/      AutoGenerateColumns$ False��6F   ��5.   .   �� *	ExamsList+ 6P   �� *SelectedItem+   Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *Title+6R     53      $
 Text��6)   $	 200 6P    67   �� *Text+6P     54      $
 Date��6)   $ 70 6P    67   �� *Date+6P     55      $ Subject��6)   $	 100 6[    6:   �� *Subject.Name+6[   57      58      � 59   
   $��2��6   .+�5:      �� $	��120��6   $��30��6!   $��
Read Exams��6-   $��Right=�5;      $��5q�61   ��5:   B   �� *GetExamsCommand+5;   1   �� 5<      -   5         ��Name$ 	DelButton��5<      $	��120��6(   $��30��64   $��Delete Exam��6@   $
��Left=�5=   ;   $��	531,5,0,5q�6V   ��6   �� *DeleteExamCommand+6V   5?      5@      5A      