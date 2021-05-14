/*
run this

	dotnet cake --settings_skipverification=true

	export CAKE_SETTINGS_SKIPVERIFICATION=true
	dotnet cake
*/
#addin nuget:?package=Cake.FileHelpers
// #addin "MagicChunks"

FilePathCollection files = null;
files = GetFiles("./*.nupkg");
DeleteFiles(files);

if (DirectoryExists ("./Content/tools/"))
{
	DeleteDirectory
				(
					"./Content/tools/",
					new DeleteDirectorySettings
					{
						Recursive = true,
						Force = true
					}
				);

}

/*
no need to test builds
CakeExecuteScript
(
	"./Content/build.cake",
	new CakeSettings
	{
		Arguments = new Dictionary<string, string> 
						{
							{"target", "clean"},
						}
	}
);
*/

DateTime dt = DateTime.Now;
string version = $"{dt.ToString("yyyy.MM.dd.HHmm")}";

FilePath file_source = GetFiles ($"./*.nuspec").ToList () [0];
Information($"file = {file_source} : ");
Information($"{FileReadText(file_source)}");
FilePath file_destination = new FilePath
(
	file_source.FullPath.Replace
							(
								"HolisticWare.DotNetNew.CakeScriptDebugTemplate.CSharp",
								$"new.tmp.{version}"
							)
);
Information($"file = {file_destination} : ");
CopyFile(file_source, file_destination);


// https://github.com/xamarin/GoogleApisForiOSComponents/blob/master/update.cake
// https://gsferreira.com/archive/2018/06/versioning-net-core-applications-using-cake/
XmlPoke
(
	file_destination,
    //"/ns:package/ns:metadata/ns:version/",
	"//version",
    version,
    new XmlPokeSettings 
	{
        Namespaces = new Dictionary<string, string> 
		{
            { "ns", "http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd" },
        }
    }
);
Information($"{FileReadText(file_destination)}");


// https://github.com/sergeyzwezdin/magic-chunks
// TransformConfig
// (
// 	file.ToString(), 
// 	$"new.tmp.{version}.nuspec",
// 	new TransformationCollection 
// 	{
// 		{ "package/metadata/version", version },
// 	}
// );



int exit_code = StartProcess
(
	"nuget", 
	new ProcessSettings
	{ 
		Arguments = $"pack new.tmp.{version}.nuspec" 
	}
);

// This should output 0 as valid arguments supplied
Information("Exit code: {0}", exit_code);

// NuGetPackSettings settings =
// 						new NuGetPackSettings 
// 									{
// 										Version = version
// 									}
// 						;
// NuGetPack
// (
// 	"./nuget/HolisticWare.DotNetNew.XamarinProjectsStructureTemplate.CSharp.nuspec",
// 	settings
// );

files = GetFiles("./new.tmp.*.nuspec");
DeleteFiles(files);
