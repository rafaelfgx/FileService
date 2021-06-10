# FileService

## Run

<details>
<summary>Command Line</summary>

#### Prerequisites

* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

#### Steps

1. Open directory **source\FileService** in command line and execute **dotnet run**.
3. Open <https://localhost:5000>.

</details>

<details>
<summary>Visual Studio Code</summary>

#### Prerequisites

* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Visual Studio Code](https://code.visualstudio.com)
* [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)

#### Steps

1. Open **source** directory in Visual Studio Code.
2. Press **F5**.

</details>

<details>
<summary>Visual Studio</summary>

#### Prerequisites

* [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Visual Studio](https://visualstudio.microsoft.com)

#### Steps

1. Open **source\FileService.sln** in Visual Studio.
2. Set **FileService** as startup project.
3. Press **F5**.

</details>

## Example

### AppSettings.json

```json
{
    "Directory": "C:\\Files (Windows) OR /root/files (Linux)"
}
```

### Post

https://localhost:5000/files

```json
{
    "Name": "Attachment.txt",
    "Bytes": "QXR0YWNobWVudA=="
}
```

```json
{
    "Name": "Attachment.txt",
    "Bytes": "QXR0YWNobWVudA==",
    "Subdirectory": "Groups\\1\\Texts (Windows) OR groups/1/texts (Linux)"
}
```

### Get

https://localhost:5000/files/GUID

### Delete

https://localhost:5000/files/GUID
