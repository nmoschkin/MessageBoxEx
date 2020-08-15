# MessageBoxExConfig Class
 

Configuration object to be passed to MessageBoxEx.Show() containing parameters and customization options for the dialog box.


## Inheritance Hierarchy
<a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">System.Object</a><br />&nbsp;&nbsp;DataTools.MessageBoxEx.MessageBoxExConfig<br />
**Namespace:**&nbsp;<a href="N_DataTools_MessageBoxEx.md">DataTools.MessageBoxEx</a><br />**Assembly:**&nbsp;MessageBoxEx (in MessageBoxEx.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public class MessageBoxExConfig
```

**VB**<br />
``` VB
Public Class MessageBoxExConfig
```

The MessageBoxExConfig type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_DataTools_MessageBoxEx_MessageBoxExConfig__ctor.md">MessageBoxExConfig</a></td><td>
Initializes a new instance of the MessageBoxExConfig class</td></tr></table>&nbsp;
<a href="#messageboxexconfig-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_AlwaysOnTop.md">AlwaysOnTop</a></td><td>
Sets a value indicating that the dialog box shall be the top-most window on the desktop until it is dismissed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_CustomButtons.md">CustomButtons</a></td><td>
List of custom buttons. Default buttons arae only displayed if this list is empty.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_CustomIcon.md">CustomIcon</a></td><td>
Specifies the custom icon to display.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_CustomResult.md">CustomResult</a></td><td>
The custom result of the button that was pressed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_Icon.md">Icon</a></td><td>
Specifies the icon displayed to the left of the message, in the message box.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_Message.md">Message</a></td><td>
Specifies the message to be displayed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_MessageBoxType.md">MessageBoxType</a></td><td>
Specifies the message box type.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_MuteSound.md">MuteSound</a></td><td>
Specifies whether to mute alert sounds.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_OptionMode.md">OptionMode</a></td><td>
The mode of the option text. Default is checkbox. In Url mode the OptionText can be any file or process that you have permission to start.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_OptionResult.md">OptionResult</a></td><td>
The state of the checkbox when the dialog box was closed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_OptionText.md">OptionText</a></td><td>
Toggle option text. If this text is not null, either a URL or a check box will be displayed. The state of the toggle when the dialog closes can be found in the OptionResult property. In URL mode this can be any file or process that you have permission to start.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_OptionTextUrl.md">OptionTextUrl</a></td><td>
The URL linked to the option text.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_SoundIcon.md">SoundIcon</a></td><td>
Play a custom sound when the dialog box opens, regardless of the default sound for the selected icon.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_Title.md">Title</a></td><td>
Specifies the title of the dialog box.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_DataTools_MessageBoxEx_MessageBoxExConfig_UrlClickDismiss.md">UrlClickDismiss</a></td><td>
Specify whether or not clicking the Url dismisses the dialog box. The default result will be returned.</td></tr></table>&nbsp;
<a href="#messageboxexconfig-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="https://docs.microsoft.com/dotnet/api/system.object.equals#System_Object_Equals_System_Object_" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="https://docs.microsoft.com/dotnet/api/system.object.finalize#System_Object_Finalize" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="https://docs.microsoft.com/dotnet/api/system.object.gethashcode#System_Object_GetHashCode" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="https://docs.microsoft.com/dotnet/api/system.object.gettype#System_Object_GetType" target="_blank">GetType</a></td><td>
Gets the <a href="https://docs.microsoft.com/dotnet/api/system.type" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="https://docs.microsoft.com/dotnet/api/system.object.memberwiseclone#System_Object_MemberwiseClone" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">Object</a>.
 (Inherited from <a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="https://docs.microsoft.com/dotnet/api/system.object.tostring#System_Object_ToString" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#messageboxexconfig-class">Back to Top</a>

## See Also


#### Reference
<a href="N_DataTools_MessageBoxEx.md">DataTools.MessageBoxEx Namespace</a><br />