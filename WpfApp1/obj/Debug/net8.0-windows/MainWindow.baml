   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Library��5   	   $	��450��6   $	��800��6&   .��5      � .+�5   
   �� -   5        $��AuthorSearchBox��5      $	��200��6)   $��20��65   $
��Left=�6A   $	��Top=�6\   $��	10,10,0,0q�6t   �� 5   
   -   5        $��Search by Author��5      $	��105��6,   $��20��68   $
��Left=�6D   $	��Top=�6_   $��
220,10,0,0q�6w   6�   �� 5	   
   -   5        $��GenreSearchBox��5	      $	��200��6(   $��20��64   $
��Left=�6@   $	��Top=�6[   $��	10,40,0,0q�6s   �� 5
   
   -   5        $��Search by Genre��5
      $	��105��6+   $��20��67   $
��Left=�6C   $	��Top=�6^   $��
220,40,0,0q�6v   6�   �� 5   
   -   5        $��SearchByName��5      $	��200��6&   $��20��62   $
��Left=�6>   $	��Top=�6Y   $��	10,70,0,0q�6q   �� 5   
   -   5        $��Search by Name��5      $	��105��6*   $��20��66   $
��Left=�6B   $	��Top=�6]   $��
220,70,0,0q�6u   6�   �� 5   
   -   5        $!��Search by Genre
and Author��5      $	��105��6?   $��50��6K   $
��Left=�6W   $	��Top=�6r   $��
330,20,0,0q�6�    J� RenderTransformOrigin$ 0.648,0.061&�6�   �� 5   
   -   5        $��Refresh��5      $	��150��6?   $��30��6K   $
��Left=�6W   $	��Top=�6r   $��
629,10,0,0q�6�   �� 5   
   -	   5        $��Delete Book��5      $	��150��6@   $��30��6L   $
��Left=�6X   $	��Top=�6s   $��
629,50,0,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -
   5        $��BooksDataGrid��5         AutoGenerateColumns$ False��6F   $��Stretch=�6b   $��Stretch=�6�   $��10,100,10,10q�6�   ��6(   �� *Books+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ Title��6%    64   �� *Title+  5      $ Author��6%    65   �� *Author.FullName+  5      $ Genre��6%    64   �� *
Genre.Name+  5      $ Publish Year��6%    6;   �� *PublishYear+  5      $
 IBSN��6%    63   �� *IBSN+  5      $ Quantity��6%    67   �� *QuantityInStock+5      �� 5"   
   -   5        $��Add Book��5"      $	��150��6$   $��20��60   $
��Left=�6<   $	��Top=�6W   $��
455,30,0,0q�6o   6�   �� 5#   
   -   5        $��	Edit Book��5#      $	��150��6%   $��20��61   $
��Left=�6=   $	��Top=�6X   $��	455,5,0,0q�6p   6�   �� 5$   
   -   5        $��Manage Authors��5$      $	��150��6*   $��20��66   $
��Left=�6B   $	��Top=�6]   $��
455,54,0,0q�6u   6�   �� 5%   
   -   5        $��Manage Genres��5%      $	��150��6)   $��20��65   $
��Left=�6A   $	��Top=�6\   $��
455,78,0,0q�6t   6�   5(      5)      