   M S B A M L   `   `   `  ????=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PL.MVVM.ViewPL.MVVM.View  5      $    PL.MVVM.View.VendorDetailsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:PL.MVVM.View     5      .??5	      ? ???#222222  ? ColumnDefinitions  5
   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      ?? 5      $??50 ?6   .+?5   
   ?? $	??250??6   $	??250??6   $	??Top=?5      $
??Left=?5      $??10q?5      $??/images/user.jpg??5      ?? 5   
   $??1??6    ? DataContext 6%   ?? *Vendor+.+?5      ?? 
???????$??30(?5      $??Center=?5      $
??Left=?5      $
??Wrap=?5      $??5q?5      ??5      ?? *	FirstName+5      ?? 5!      
???????$??30(?5#      $
??Wrap=?5%      $??Center=?5&      $
??Left=?5'      $??5q?5(      ??5$      ?? *
LastName+5(      5)      ? 5+   
   $??1??6     5,      ?? 5-      $	??100 ?6#   ?? 5.      $	??100 ?6#   ?? 5/      .+?52      ?? $??0??6      TransparentStyle#??[  53      $??Center=?54      $	??100??56      ??55      ?? *Delete+??57      ?? 58      $??Delete??59      
???????$??Center=?5;      $??Center=?5<      $??16(?5=      5?      ?? 5A      $??1??5B      #??[  5C      $??Center=?5D      $	??100??5F      ??5E      ?? *Edit+??5G      ?? 5H      $
??Edit??5I      
???????$??Center=?5K      $??Center=?5L      $??16(?5M      5O      5P      5Q      5R      