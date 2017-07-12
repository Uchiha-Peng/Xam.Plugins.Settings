1.  项目添加NuGet引用——Xam.Plugin.Settings[在共享项目和各个平台都要引用]
2.  新建Settings.cs,加入如下代码     


```c#
  public static class Settings
       {
              private static ISettings AppSettings
              {
                     get
                     {
                           return CrossSettings.Current;
                     }
              }
              #region Setting Constants
              private const string SettingsKey = "settings_key";
              private static readonly string SettingsDefault = string.Empty;
              #endregion
              public static string GeneralSettings
              {
                     get
                     {
                           return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
                     }
                     set
                     {
                           AppSettings.AddOrUpdateValue(SettingsKey, value);
                     }
              }
       }
```

3. 默认cs中仅添加了一个配置文件，将代码修改如下

  ```c#
   public static class Settings
         {
                private static ISettings AppSettings
                {
                       get
                       {
                             return CrossSettings.Current;
                       }
                }
     
          private const string usName = "Key_usName";
     
          private const string usPwd = "Key_usPwd";
     
          private static readonly string SettingsDefaultValue = string.Empty;
     
          public static string usNameSettings
          {
              get => AppSettings.GetValueOrDefault(usName, SettingsDefaultValue);
              set => AppSettings.AddOrUpdateValue(usName, value);
          }
          public static string usPwdSettings
          {
              get => AppSettings.GetValueOrDefault(usPwd, SettingsDefaultValue);
              set => AppSettings.AddOrUpdateValue(usPwd, value);
          }     
         }

  ```

4. 页面加载方法中为需要缓存的输入项目绑定到Settings

  ```c#
   public MainPage()
   {
         InitializeComponent();
         UsName.Text = Settings.UserNameSettings;
         UsPwd.Text = Settings.UsPwdSettings;
   }     
  ```

5. 在按钮点击事件中，把输入的值保存到Setting中

   ```c#
    private void Button_Clicked(object sender, EventArgs e)
           {
               Settings.UserNameSettings=UsName.Text;
               Settings.UsPwdSettings= UsPwd.Text;
           }
   ```

 6. 获取Settings数据     

    ```c#
        {
            DisplayAlert("Message","用户名： "+Settings.UserNameSettings+" 密码： "+Settings.UsPwdSettings,"OK");
        }
    ```