# DataTools.MessageBoxEx #

## Customizable replacement for the system **MessageBox** class ##

__NEW!__ - Added .NET 5.0 WinForms projects.  You can now use these projects without the .NET Framework.

DataTools.MessageBoxEx is a highly customizable replacement for the system MessageBox class for both WPF and WinForms applications. 

It is intended to look and behave as closely as possible to the native MessageBox.

*(The message box will render in the [Visual Style](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application.enablevisualstyles?view=netcore-3.1) of the calling application.)*

#### [Go to the Wiki for complete API documentation.](https://github.com/ironywrit/MessageBoxEx/wiki) ####

#### [DataTools.MessageBoxEx.MessageBoxEx Class](https://github.com/ironywrit/MessageBoxEx/wiki/T_DataTools_MessageBoxEx_MessageBoxEx) ####

#### [DataTools.MessageBoxEx.MessageBoxExConfig Class](https://github.com/ironywrit/MessageBoxEx/wiki/T_DataTools_MessageBoxEx_MessageBoxExConfig) ####

#### [Browse Form1.cs in the TestApp for usage examples.](https://github.com/ironywrit/MessageBoxEx/blob/master/TestApp/Form1.cs) ####

### Some features include: ###

- **Custom Buttons**

    You can define completely custom buttons that return either a [**MessageBoxExResult**](https://github.com/ironywrit/MessageBoxEx/wiki/T_DataTools_MessageBoxEx_MessageBoxExResult) or a custom result of any type.

    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot1.png)

- **Custom Icons**

    The main icon and buttons icons are completely customizable:

    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot6.png)

- **Control Over Sounds**

    When the message box is shown it can:

    - Play the default system sound for a specific system icon.
    - Play a different system sound.
    - Mute sounds, altogether.

- **Standard System Dialog Boxes**

    -  OK button
    -  OK and Cancel buttons
    -  Yes and No buttons
    -  Yes, No, and Cancel buttons
    -  Yes, No, and Yes To All buttons
    -  Abort, Retry, and Ignore buttons

    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot4.png)

- **Check Boxes**

    A checkbox option can be placed immediately to the left of the buttons on the message box.
    *  (Note, a checkbox and a hyperlink cannot appear together, at the same time)

    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot3.png)

- **Hyper Links**

    A hyperlink that can execute any location that is valid in the Windows shell (applications, URLs, special folders, etc.)
    * Note: a checkbox and a hyperlink cannot appear together, at the same time.
    * In keyboard navigation, the hyperlink on the message box can be activated by pressing **Ctrl + Enter**

    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot2.png)


- **Drop-Down Menus**

    Custom buttons can have a drop-down menu with arrow button attached.
    * In keyboard navigation, the drop-down menu can be activated for the button with focus by pressing **Ctrl + Down Arrow**

    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot5.png)
    
- **Automatic Sizing**

    Gracefully and accurately sizes the dialog box to fit even very large content.
    * This feature is limited by screen size.
    
    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot7.png)
    
- **Resource-based Internationalization**
    
    Language resources from your own project can be referenced by MessageBoxEx to render standard dialog types by using the
    [ResourceTextConfig](https://github.com/ironywrit/MessageBoxEx/wiki/P_DataTools_MessageBoxEx_MessageBoxEx_ResourceTextConfig) static
    property.

    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot9.png)

    * [See the example project for an example.](https://github.com/nmoschkin/MessageBoxEx/tree/master/TestApp)
    Note that the example project contains two resources, _AppResources.resx_ and _AppResources.fr.resx_.
    The _fr_ in the second file is the two letter ISO language code for French.  Applications using resource-based internationalization
    will automatically pick the best set of resources to use based on the user's current system language and culture settings, but this
    behavior can be overridden.  Browse [ResourceTextConfig.cs](https://github.com/nmoschkin/MessageBoxEx/blob/master/MessageBoxEx/Classes/ResourceTextConfig.cs) to see what's involved.
        
- **If you prefer the old-fashioned 3D look**

    The message box will render in the [**Visual Style**](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application.enablevisualstyles?view=netcore-3.1) of
    the calling application.  

    **You can override the default visual style of your application by launching the message box in a new process using [ShowInNewProcess](https://github.com/ironywrit/MessageBoxEx/wiki/M_DataTools_MessageBoxEx_MessageBoxEx_ShowInNewProcess).**
    
    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot8.png)
    
    
