# MessageBoxExResult Enumeration
 

Message box results.

**Namespace:**&nbsp;<a href="N_DataTools_MessageBoxEx.md">DataTools.MessageBoxEx</a><br />**Assembly:**&nbsp;MessageBoxEx (in MessageBoxEx.dll) Version: 1.0.0.0 (1.0.0.0)

## Syntax

**C#**<br />
``` C#
[FlagsAttribute]
public enum MessageBoxExResult
```

**VB**<br />
``` VB
<FlagsAttribute>
Public Enumeration MessageBoxExResult
```


## Members
&nbsp;<table><tr><th></th><th>Member name</th><th>Value</th><th>Description</th></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.No">**No**</td><td>0</td><td>Converts to false when cast to bool</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.Cancel">**Cancel**</td><td>8</td><td>Does not convert to false when cast to bool</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.Abort">**Abort**</td><td>0</td><td>Converts to false when cast to bool</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.Yes">**Yes**</td><td>1</td><td>Converts to true when cast to bool</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.OK">**OK**</td><td>1</td><td>Converts to true when cast to bool</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.Retry">**Retry**</td><td>1</td><td>Converts to true when cast to bool</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.All">**All**</td><td>2</td><td>All can be combined with any other flag (for future features).</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.YesToAll">**YesToAll**</td><td>3</td><td>A bitwise OR of Yes and All</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.Ignore">**Ignore**</td><td>4</td><td>Converts to true when cast to bool</td></tr><tr><td /><td target="F:DataTools.MessageBoxEx.MessageBoxExResult.Custom">**Custom**</td><td>256</td><td>Custom result to be retrieved from the CustomResult parameter.</td></tr></table>

## See Also


#### Reference
<a href="N_DataTools_MessageBoxEx.md">DataTools.MessageBoxEx Namespace</a><br />