   M S B A M L   `   `   `  ����
  MyToDo     BlankApp1.Views.MainWindow   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      $
��1226��5      $	��648��5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5	       � Title 5      �� *Title+.��5
      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $	��200��6%   .+�5      �� 
���   �$��	IndexView��5      $��首页��5      ��5      �� *	command+5      �� 5      
������ $��0q�5      $��ToDoView��5      $��待办��5      ��5      �� *	command+5      �� 5       
������ $��0q�5"      $��NoteView��5$      $��日记��5%      ��5#      �� *	command+5%      �� 5'      
������ $��0q�5)      $��	TrashView��5+      $��	回收站��5,      ��5*      �� *	command+5,      5.      �� 5/   
   $��1��6   .+�50      �� !  Prism.Regions.RegionManager   
RegionName$ ContentRegion��6   51      52      53      