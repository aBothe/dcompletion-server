
# DCompletionServer

## Server

The server is designed to reside at the actual client's side.
It must have physical access to clients' file system in order to properly access all parsed & analysed files.

## Connection

A client may establish a **TCP** connection to the server via port **13600**.
The protocol is kept in a binary format.

## Protocol

A message consists of bytes like the following:
<table>
    <tr>
        <td>Byte</td>
        <td>0<td>
        <td>1</td>
    </tr>
    <tr>
    	<td></td>
    	<td>ServerInstruction</td>
    	<td>Data</td>
    </tr>
</table>


