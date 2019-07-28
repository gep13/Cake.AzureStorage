#load nuget:?package=Cake.Recipe&version=1.0.0

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context, 
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.AzureStorage",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.AzureStorage",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunDupFinder: false,
                            shouldRunInspectCode: false,
                            shouldRunGitVersion: DirectoryExists(".git"), // This would allow building even without using a git repository
                            shouldRunDotNetCorePack: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] { 
                                BuildParameters.RootDirectoryPath + "/src/Cake.AzureStorage.Tests/*.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[FluentAssertions]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs;*/Microsoft.Build.Framework.Version.cs");
Build.RunDotNetCore();