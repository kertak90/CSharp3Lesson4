   M S B A M L   `   `   `  ����B  >Lesson1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Lesson1.ViewLesson1.View  5      '    !Lesson1.View.RecipientsInfoEditor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Lesson1.View     5      $��438.559��5      $��275.636��60     � DataContext  5      �� *MainWindowModel+   Locator �� Source# [  .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��0��6$   $��Id��61   �� 5   
   $��0��6   $��1��6$   $��Имя��61   �� 5   
   $��0��6   $��2��6$   $��Email��61   �� 5   
   $��1��6   $��0��6"   ��6/   �� *SelectedRecepient.Id+�� 5   
   $��1��6   $��1��6"   ��6/   �� *SelectedRecepient.Name+�� 5   
   $��1��6   $��2��6"   ��6/   �� *SelectedRecepient.Email+A� 5   
   $��0��6   $��3��6&   $��2��63   $	��Top=�6G   $��Center=�6_   .+�5      �� $��0,10,0,0q�6   $��20, 5q�5      $+��%Сохранить изменения��5!      ��5      �� *WriteRecipientDataCommand+��5       �� *SelectedRecepient+5!      �� 5"      $��0,10,0,0q�6   $��20, 5q�5#      $��Создать��5&      ��5$      �� *WriteRecipientDataCommand+��5%      �� *SelectedRecepient+5&      5'      5(      5)      