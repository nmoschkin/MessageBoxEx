# MessageBoxEx.Show Method (String, String, String, IEnumerable(MessageBoxExButton), Bitmap, Object, Boolean)
 

Creates a message box with custom buttons, custom icon, and an option toggle.

**Namespace:**&nbsp;<a href="N_DataTools_MessageBoxEx.md">DataTools.MessageBoxEx</a><br />**Assembly:**&nbsp;MessageBoxEx (in MessageBoxEx.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
public static MessageBoxExResult Show(
	string message,
	string title,
	string optionText,
	IEnumerable<MessageBoxExButton> buttons,
	Bitmap icon,
	out Object customResult,
	out bool optionResult
)
```

**VB**<br />
``` VB
Public Shared Function Show ( 
	message As String,
	title As String,
	optionText As String,
	buttons As IEnumerable(Of MessageBoxExButton),
	icon As Bitmap,
	<OutAttribute> ByRef customResult As Object,
	<OutAttribute> ByRef optionResult As Boolean
) As MessageBoxExResult
```


#### Parameters
&nbsp;<dl><dt>message</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />Text to display in the dialog box</dd><dt>title</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />Title of the dialog box</dd><dt>optionText</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.string" target="_blank">System.String</a><br />Text of the option checkmark</dd><dt>buttons</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.collections.generic.ienumerable-1" target="_blank">System.Collections.Generic.IEnumerable</a>(<a href="T_DataTools_MessageBoxEx_MessageBoxExButton.md">MessageBoxExButton</a>)<br />An IEnumerable of MessageBoxExButton objects.</dd><dt>icon</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank">System.Drawing.Bitmap</a><br />The custom icon for the box.</dd><dt>customResult</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.object" target="_blank">System.Object</a><br />The result of the button that was pressed.</dd><dt>optionResult</dt><dd>Type: <a href="https://docs.microsoft.com/dotnet/api/system.boolean" target="_blank">System.Boolean</a><br />The result of the option toggle.</dd></dl>

#### Return Value
Type: <a href="T_DataTools_MessageBoxEx_MessageBoxExResult.md">MessageBoxExResult</a><br />\[Missing <returns> documentation for "M:DataTools.MessageBoxEx.MessageBoxEx.Show(System.String,System.String,System.String,System.Collections.Generic.IEnumerable{DataTools.MessageBoxEx.MessageBoxExButton},System.Drawing.Bitmap,System.Object@,System.Boolean@)"\]

## See Also


#### Reference
<a href="T_DataTools_MessageBoxEx_MessageBoxEx.md">MessageBoxEx Class</a><br /><a href="Overload_DataTools_MessageBoxEx_MessageBoxEx_Show.md">Show Overload</a><br /><a href="N_DataTools_MessageBoxEx.md">DataTools.MessageBoxEx Namespace</a><br />