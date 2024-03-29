/*
    https://cakebuild.net/blog/2016/05/debug-cake-file

    https://cakebuild.net/blog/2016/09/debug-cake-vscode

    Install Cake.CoreCLR NuGet package to your tools folder
    Install Cake Extension for Visual Studio Code
    Set up .NET Core debugger in Visual Studio Code. 
    See http://aka.ms/vscclrdebugger for details
    Open the directory containing your Cake files in Visual Studio Code

    https://redth.codes/debugging-cake-on-macos-with-mono/

    Install the Mono Debugger VSCode extension.
    Install the Cake VSCode extension.

    https://github.com/cake-build/cake/releases/tag/v1.3.0
*/
#tool nuget:?package=Cake.CoreCLR

/*
    Cake Addins
*/
#addin nuget:?package=Cake.FileHelpers

/*
    #load-ing other scripts disables debugging for some reason

    works 
*/
#load "utilities.cake"

string TARGET = Argument ("t", Argument ("target", "Default"));


Task ("libs")
	.Does 
    (
        () =>
        {
            // put breakpoint and test
            Information("Target = libs");
        }
    );

Task ("clean")
	.Does 
    (
        () =>
        {
            // if (DirectoryExists ("./externals"))
            // {
            //     DeleteDirectory 
            //             (
            //                 "./externals", 
            //                 new DeleteDirectorySettings { Recursive = true, Force = true }
            //             );

            //     CleanDirectories ("./**/packages");
            //     CleanDirectories("./**/bin");
            //     CleanDirectories("./**/obj");
            // }

            return;
        }
    );


Task ("Default")
	.IsDependentOn ("libs")
    ;

RunTarget (TARGET);