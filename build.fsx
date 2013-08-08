// include Fake libs
#I @"tools\FAKE\tools\"
#r @"tools\FAKE\tools\FakeLib.dll"

open Fake
open Fake.AssemblyInfoFile
open Fake.Git
open System.IO

//Project config
let project                 = "mite.net"
let projectName             = "mite.net"
let projectSummary          = "A .NET library for interacting with the RESTful API of mite, a sleek time tracking webapp."
let projectDescription      = "A .NET library for interacting with the RESTful API of mite, a sleek time tracking webapp."
let authors                 = ["Christoph Keller"]
let homepage                = "https://github.com/ccellar/mite.net"

// Directories
let buildDir                = @".\build"
let testDir                 = @".\test"
let deployDir               = @".\Publish"
let nugetDir                = @".\nuget" 
let packagesDir             = @".\packages"

let buildnet20              = Path.Combine(buildDir, "net20")
let buildnet40cp            = Path.Combine(buildDir, "net40cp")
let buildnet35cp            = Path.Combine(buildDir, "net35cp")

// version info
let semver = File.ReadAllText(".semver")

let mutable version         = semver
let mutable nugetVersion    = ""
let mutable asmVersion      = ""
let mutable asmInfoVersion  = ""

let gitbranch               = Git.Information.getBranchName "."
let sha                     = Git.Information.getCurrentHash() 

// Targets
Target "Clean" (fun _ -> 

    CleanDirs [buildDir; testDir; deployDir; nugetDir]
    RestorePackages()
)

Target "BuildVersions" (fun _ ->

    asmVersion      <- version// + "." + build
    asmInfoVersion  <- asmVersion + " - " + gitbranch + " - " + sha
    
    nugetVersion    <- version

    match System.String.Equals(gitbranch, "master", System.StringComparison.CurrentCultureIgnoreCase) with
        | true -> ()
        | false -> (nugetVersion <- nugetVersion + "-" + "beta")
    
    SetBuildNumber nugetVersion   // Publish version to TeamCity
)

Target "AssemblyInfo" (fun _ ->

    ReplaceAssemblyInfoVersions (fun p ->
        {p with
            AssemblyVersion = asmVersion
            AssemblyInformationalVersion = asmInfoVersion
            OutputFileName = @".\src\lib\mite.net\Properties\VersionInfo.cs"
            })    
)

Target "BuildAppNet20" (fun _ ->
    !+ @"src\lib\**\*.csproj"      
        |> Scan
        |> MSBuild buildnet20 "Rebuild" [("Configuration","NET20-Release");]
        |> Log "Build-Output: "        
)

Target "BuildAppNet40CP" (fun _ ->
    !+ @"src\lib\**\*.csproj"      
        |> Scan
        |> MSBuild buildnet40cp "Rebuild" [("Configuration","NET40CP-Release");]
        |> Log "Build-Output: "        
)

Target "BuildAppNet35CP" (fun _ ->
    !+ @"src\lib\**\*.csproj"      
        |> Scan
        |> MSBuild buildnet35cp "Rebuild" [("Configuration","NET35CP-Release");]
        |> Log "Build-Output: "        
)

Target "BuildTest" (fun _ ->
    !! @"src\tests\**\*.csproj"
      |> MSBuildDebug testDir "Build"
      |> Log "TestBuild-Output: "
)

Target "NUnitTest" (fun _ ->  

    !! (testDir + @"*.Tests.dll")
        |> NUnit (fun p -> 
            {p with 
                ToolPath = @".\tools\NUnit.Runners\tools\"; 
                Framework = "net-4.0";
                DisableShadowCopy = true; 
                OutputFile = testDir + @"TestResults.xml"})
)

Target "CreateNuGet" (fun _ -> 
   
    let nugetToolsDir = nugetDir @@ "tools"

    CreateDir nugetToolsDir

    !+ (buildDir @@ @"*.dll") 
      //++ (buildDir @@ @"*.dll")   
        |> Scan
        |> CopyTo nugetToolsDir

    NuGet (fun p -> 
        {p with
            Authors = authors
            Project = project
            Description = projectDescription
            Version = nugetVersion                           
            OutputPath = nugetDir
            AccessKey = getBuildParamOrDefault "nugetkey" ""
            Publish = hasBuildParam "nugetkey" }) "mite.net.nuspec"
)

Target "BuildZip" (fun _ ->     

    let deployZip = deployDir @@ sprintf "%s-%s.zip" project asmVersion

    !+ (buildDir @@ @"*.dll") 
      //++ (buildDir @@ @"*.dll")   
       |> Scan
       |> Zip buildDir deployZip
)

Target "ResetVersion" (fun _ ->

    fireAndForgetGitCommand "." "checkout -- .\src\lib\mite.net\Properties\VersionInfo.cs"

)

// Dependencies
"Clean"
  ==> "BuildVersions"
  ==> "AssemblyInfo"
  ==> "BuildAppNet20"
  ==> "BuildAppNet40CP"
  ==> "BuildAppNet35CP"
  //==> "BuildTest" // Tests currently don't run during build?!
  //==> "NUnitTest"
  ==> "BuildZip"
  ==> "CreateNuGet"
  ==> "ResetVersion"
 
// start build
RunTargetOrDefault "ResetVersion"