# DotNetNew.Templates.Item.CakeScriptDebug.CSharp

DotNetNew.Templates.Item.CakeScriptDebug.CSharp

## Installation 


### Local / Development

```
 dotnet new \
    uninstall \
        source/DotNetNew.Templates.Item.CakeScriptDebug.CSharp/content
        -v:diagnostic

 dotnet new \
    install \
        source/DotNetNew.Templates.Item.CakeScriptDebug.CSharp/content \
        --force \
        -v:diagnostic
 ```

### NuGet local


### NuGet published



## Details

### `dotnet new` templating

https://github.com/moljac/HolisticWare.WebSite.Notes/tree/master/dotnet-netfx/core/dotnet-new-templates


### Cake Debugging

https://github.com/default-writer/cake-structured-template/blob/main/cake.config


```json
{
    // Use IntelliSense to learn about possible attributes.
    // Hover to view descriptions of existing attributes.
    // For more information, visit: https://go.microsoft.com/fwlink/?linkid=830387
    // https://github.com/cake-build/cake-vscode/issues/376
    "version": "0.2.0",
    "configurations":
    [
        {
            "name": "PowerShell: Launch Current File",
            "type": "PowerShell",
            "request": "launch",
            "script": "${file}",
            "cwd": "${file}"
        },
        {
            "name": "Cake: Debug Script (Tool) AAAAAAAAAAA",
            "type": "coreclr",
            "request": "launch",
            "program": "dotnet",
            "args": 
            [
                "tool",
                "run",
                "dotnet-cake",
                "--",
                "${workspaceRoot}/build.cake",
                "--debug",
                "--verbosity=diagnostic"
            ],
            "cwd": "${workspaceRoot}",
            "stopAtEntry": true,
            "externalConsole": false,
            "justMyCode": false,

            "symbolOptions": 
            {
                "searchNuGetOrgSymbolServer": true
            }
        },        
        {
            "name": "Cake: Debug Build Script (.NET Tool)",
            "type": "coreclr",
            "request": "launch",
            "program": "dotnet-cake",
            "windows": 
            {
                "program": "dotnet-cake.exe"
            },
            "args": 
            [
                "build.cake",
                "--debug",
                "--verbosity=diagnostic"
            ],
            "cwd": "${workspaceFolder}",
            "stopAtEntry": false,
            "console": "integratedTerminal",
            "justMyCode": false
        },
        {
            "name": "Cake: Debug Current Script (.NET Tool)",
            "type": "coreclr",
            "request": "launch",
            "program": "dotnet-cake",
            "windows": 
            {
                "program": "dotnet-cake.exe"
            },
            "args": 
            [
                "${file}",
                "--debug",
                "--verbosity=diagnostic"
            ],
            "cwd": "${workspaceFolder}",
            "stopAtEntry": false,
            "console": "integratedTerminal",
            "justMyCode": false
        },
        {
            "name": "Cake: Debug Script (.NET Core Tool)",
            "type": "coreclr",
            "request": "launch",
            "program": "dotnet",
            "args":
            [
                "cake",
                "${workspaceRoot}/build.cake",
                "--debug",
                "--verbosity=diagnostic"
            ],
            "cwd": "${workspaceRoot}",
            "stopAtEntry": true,
            "externalConsole": false,
            "justMyCode": false,
            "symbolOptions":
            {
                "searchNuGetOrgSymbolServer": true
            }
        },
        {
            "name": "Cake: Debug Script (.NET Core Cake.CoreCLR)",
            "type": "coreclr",
            "request": "launch",
            "program": "${workspaceRoot}/tools/Cake.CoreCLR.1.3.0/Cake.dll",
            "args":
            [
                "${workspaceRoot}/build.cake",
                "--debug",
                "--verbosity=diagnostic"
            ],
            "cwd": "${workspaceRoot}",
            "stopAtEntry": false,
            "externalConsole": false
        },
        // https://github.com/cake-build/cake/releases/tag/v1.3.0
        {
            "name": "Cake: Debug Script (mono)",
            "type": "mono",
            "request": "launch",
            "program": "${workspaceRoot}/tools/Cake-bin-net461-v1.3.0/Cake.exe",
            "args":
            [
                "${workspaceRoot}/build.cake",
                "--debug",
                "--verbosity=diagnostic"
            ],
            "cwd": "${workspaceRoot}",
            "console": "internalConsole"
        },
        // dotnet tools/Cake.CoreCLR/Cake.dll build.cake --debug
        {
            "name": ".NET Core Attach",
            "type": "coreclr",
            "request": "attach",
            "processId": "${command.pickProcess}"
        }
    ]
}
```