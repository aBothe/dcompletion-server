
# DCompletionServer

## Server

The server is designed to reside at the actual client's side.
It must have physical access to clients' file system in order to properly access all parsed & analysed files.

## Connection

A client may establish a **TCP** connection to the server via port **13600**.
The protocol is kept in a binary format.

## Protocol

A message sent to the server consists of bytes structured as following:
<table>
    <tr>
        <td>Byte offset</td>
        <td>0</td>
        <td>1</td>
    </tr>
    <tr>
    	<td>Content</td>
    	<td>ServerInstruction</td>
    	<td>Data</td>
    </tr>
</table>

### Data types
* By default, numbers are unsigned
* wsstring:
<table>
    <tr>
        <td>Byte offset</td>
        <td>0</td>
        <td>2</td>
    </tr>
    <tr>
    	<td>Content</td>
    	<td>(ushort) String length</td>
    	<td>(short[length]) UTF16 encoded characters</td>
    </tr>
</table>
* T[n] consists of n T instances

### Server instructions
<table>
    <tr><td>Code</td><td>Meaning</td></tr>
    <tr><td>1</td><td>Clear parse cache</td></tr>
    <tr><td>2</td><td>Parse directories</td></tr>
    <tr><td>3</td><td>Preresolve UFCS methods for better completion</td></tr>
	
    <tr><td>4</td><td>Wait for the last parse/ufcs analysis task to finish</td></tr>
	<tr><td>5</td><td>Get Parse progress</td></tr>
    <tr><td>6</td><td>Stop the last parse/ufcs task</td></tr>
	
	<tr><td>7</td><td>GetCompletionOption</td></tr>
	<tr><td>8</td><td>SetCompletionOption</td></tr>
	
	<tr><td>14</td><td>OpenFile</td></tr>
	<tr><td>15</td><td>ReleaseFile</td></tr>
	
	<tr><td>9</td><td>InsertText</td></tr>
	<tr><td>10</td><td>RemoveText</td></tr>
	<tr><td>11</td><td>ReplaceText</td></tr>
	
	<tr><td>12</td><td>RequestCompletionItems</td></tr>
	<tr><td>13</td><td>GetItemDescription</td></tr>
</table>

### Clear parse cache
<table>
    <tr>
        <td>Byte offset</td>
        <td>0</td>
    </tr>
    <tr>
    	<td>Content</td>
    	<td>1</td>
    </tr>
</table>

### Parse directories
<table>
    <tr>
        <td>Byte offset</td>
        <td>0</td>
        <td>1</td>
        <td>2</td>
        <td>3</td>
    </tr>
    <tr>
    	<td>Content</td>
    	<td>2</td>
    	<td>1 if directories shall be used for UFCS analyis after parsing</td>
    	<td>Directory count</td>
    	<td>(wsstring[n]) Paths</td>
    </tr>
</table>