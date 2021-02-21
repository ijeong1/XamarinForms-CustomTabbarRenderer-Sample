# XamarinForms-CustomTabbarRenderer-Sample

# About this Project

Original Post by Andrew Hoefling

The original auther - Andrew Hoefling - implemented the android renderer only, so I simply added a custom renderer for iOS.

Reference - https://www.andrewhoefling.com/Blog/Post/xamarin-forms-shell-customizing-the-tabbar-android
![Concept](https://github.com/ahoefling/XamarinShellSamples/blob/master/Samples/Samples.ShellItemRenderer/design/did_you.png)

# Screenshots
- iOS

![iOS](https://github.com/ijeong1/XamarinForms-CustomTabbarRenderer-Sample/blob/main/screenshot_ios.png)

- Android

![Android](https://github.com/ijeong1/XamarinForms-CustomTabbarRenderer-Sample/blob/main/screenshot_android.png)

# How to use
AppShell file
```
<c:CustomTabBar Style="{StaticResource BaseStyle}">
   <c:CustomTabBar.LargeTab>
      <Tab Title="New Task" Icon="tab_newtask.png">
         <ShellContent ContentTemplate="{DataTemplate local:NewTaskPage}" />
      </Tab>
   </c:CustomTabBar.LargeTab>
   
   <Tab Title="Dashboard" Icon="tab_dashboard.png">
      <ShellContent ContentTemplate="{DataTemplate local:DashboardPage}" />
   </Tab>
        
   <Tab Title="Profile" Icon="tab_profile.png">
      <ShellContent ContentTemplate="{DataTemplate local:ProfilePage}" />
   </Tab>
</c:CustomTabBar>
```
