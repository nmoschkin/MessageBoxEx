# MessageBoxEx.Show Method (String, String, String, MessageBoxExButtonSet, MessageBoxExIcons, Boolean)
 

Shows a message box with a message, title, standard buttons, a standard icon, and an option toggle.

**Namespace:**&nbsp;<a href="N_DataTools_MessageBoxEx.md">DataTools.MessageBoxEx</a><br />**Assembly:**&nbsp;MessageBoxEx (in MessageBoxEx.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public static MessageBoxExResult Show(
	string message,
	string title,
	string optionText,
	MessageBoxExButtonSet buttons,
	MessageBoxExIcons icon,
	out bool optionResult
)
```

**VB**<br />
``` VB
Public Shared Function Show ( 
	message As String,
	title As String,
	optionText As String,
	buttons As MessageBoxExButtonSet,
	icon As MessageBoxExIcons,
	<OutAttribute> ByRef optionResult As Boolean
) As MessageBoxExResult
```


#### Parameters
&nbsp;<dl><dt>message</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />Text to display in the dialog box</dd><dt>title</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />Title of the dialog box</dd><dt>optionText</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />Option toggle button message.</dd><dt>buttons</dt><dd>Type: <a href="T_DataTools_MessageBoxEx_MessageBoxExButtonSet.md">DataTools.MessageBoxEx.MessageBoxExButtonSet</a><br />An IEnumerable of MessageBoxExButton objects.</dd><dt>icon</dt><dd>Type: <a href="T_DataTools_MessageBoxEx_MessageBoxExIcons.md">DataTools.MessageBoxEx.MessageBoxExIcons</a><br />The standard icon for the box.</dd><dt>optionResult</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.boolean" target="_blank">System.Boolean</a><br />The result of the option toggle button.</dd></dl>

#### Return Value
Type: <a href="T_DataTools_MessageBoxEx_MessageBoxExResult.md">MessageBoxExResult</a><br />\[Missing <returns> documentation for "M:DataTools.MessageBoxEx.MessageBoxEx.Show(System.String,System.String,System.String,DataTools.MessageBoxEx.MessageBoxExButtonSet,DataTools.MessageBoxEx.MessageBoxExIcons,System.Boolean@)"\]

## See Also


#### Reference
<a href="T_DataTools_MessageBoxEx_MessageBoxEx.md">MessageBoxEx Class</a><br /><a href="Overload_DataTools_MessageBoxEx_MessageBoxEx_Show.md">Show Overload</a><br /><a href="N_DataTools_MessageBoxEx.md">DataTools.MessageBoxEx Namespace</a><br />