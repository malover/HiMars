   M S B A M L   `   `   `  ????=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HiMarsHiMars  5   	   5clr-namespace:PL.MVVM.ViewModelPL.MVVM.ViewModel  5   	       PL.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:HiMars     5   	   5	viewModelclr-namespace:PL.MVVM.ViewModel     5   	     ? Title$  
MainWindow??5   	   $	??600??6   $	??920??6)    ? AllowsTransparency$
 True??5	   	    ? WindowStyle$
 None=?5
   	   
??????  ? WindowStartupLocation$ CenterScreen=?5   	    ? DataContext 5      %   PL.MVVM.ViewModel.MainViewModel  5   
   .??5      ?? ???#272537 ?? CornerRadius$ 20??6"   ._?5   
   ?  ? ColumnDefinitions 5      ?? 5      $	??225 ?5      ?? 5       ? RowDefinitions 5      ?? 5      $??75 ?6    ?? 5      .+?5      ?? $??0??6   $??0??5      $??HiMars Warehouse??5      $??22(?5       
???????$??20, 0, 0, 0q?5"      $??Center=?5#      $
??Left=?5$      ?? 5'      $??1??6   $??0??5(      $??5q?5)      .+?5+      	? $??
Categories??6   $??50??5,      
???????$??14(?5.         MenuButtonTheme#??[  5/       d? 	IsChecked$
 TrueY?51      ??50      ?? *CategoriesViewCommand+51      	? 52      $??Goods??6   $??50??53      
???????$??14(?55      #??[  56      ??57      ?? *GoodsViewCommand+	? 58      $??Vendors??6   $??50??59      
???????$??14(?5;      #??[  5<      ??5=      ?? *VendorsViewCommand+5>      ?? 5@      $??1??6   $??1??5A      $??5, 5, 10, 10q?5B      ??5C      ?? *CurrentView+5D      5E      5F      