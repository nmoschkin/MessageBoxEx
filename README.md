# DataTools.MessageBoxEx #

## Customizable replacement for the system **MessageBox** class ##

DataTools.MessageBoxEx is a highly customizable replacement for the system MessageBox class for both WPF and WinForms applications. 

It is intended to look and behave as closely as possible to the native MessageBox.

*(The message box will render in the Visual Style of the calling application.)*

### [Go to the Wiki for complete API documentation.](https://github.com/ironywrit/MessageBoxEx/wiki) ###

### Some features include: ###

- **Custom Buttons**

    You can define completely custom buttons that return either a **MessageBoxExResult** or a custom result of any type.

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
    * In keyboard navigation, the hyperlink on the message box can be activated by pressing **Ctrl + Down Arrow**


    ![](https://raw.githubusercontent.com/ironywrit/MessageBoxEx/master/Screenshots/screenshot5.png)
