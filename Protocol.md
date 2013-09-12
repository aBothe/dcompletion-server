
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
    	<td>Description</td>
    	<td>ServerInstruction</td>
    	<td>Data</td>
    </tr>
</table>

A server instruction may be:
<table>
    <tr><td>Code</td><td>Meaning</td></tr>
	
    <tr>
    	<td>1</td>
    	<td>Clear parse cache</td>
    </tr>
</table>

