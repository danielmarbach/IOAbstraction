properties { 
  $script_dir = resolve-path .  
  $base_dir  = "$script_dir\..\"
  $source_dir = "$base_dir\Source"
  $lib_dir = "$source_dir\Libs"
  $build_dir = "$base_dir\build" 
  $buildartifacts_dir = "$build_dir\" 
  $sln_file = "$source_dir\IOAbstraction.sln" 
  $version = "0.2.3.0"
  $humanReadableversion = "0.2"
  $tools_dir = "$base_dir\Tools\"
  $release_dir = "$base_dir\Release"
  $xunit_dir = "$tools_dir\xUnit\"
  $commit = Get-Git-Commit
  # $uploadCategory = "Rhino-Mocks"
  # $uploadScript = "C:\Builds\Upload\PublishBuild.build"
} 

include .\psake_ext.ps1
	
task default -depends Release

task Clean { 
  remove-item -force -recurse $buildartifacts_dir -ErrorAction SilentlyContinue 
  remove-item -force -recurse $release_dir -ErrorAction SilentlyContinue 
} 

task Init -depends Clean { 
	
	Generate-Assembly-Info `
        -clscompliant false `
		-file "$source_dir\IOAbstraction\Properties\AssemblyInfo.cs" `
		-title "IOAbstraction $version" `
		-description "IOAbstraction Framework for .NET" `
		-company "bbv Software Services Ag" `
		-product "IOAbstraction $version" `
		-version $version `
		-copyright "Daniel Marbach 2009 - 2010"
		
	Generate-Assembly-Info `
        -clscompliant false `
		-file "$source_dir\IOAbstraction.Test\Properties\AssemblyInfo.cs" `
		-title "IOAbstraction $version" `
		-description "IOAbstraction Framework for .NET" `
		-company "bbv Software Services Ag" `
		-product "IOAbstraction $version" `
		-version $version `
		-copyright "Daniel Marbach 2009 - 2010"
		
	new-item $release_dir -itemType directory 
	new-item $buildartifacts_dir -itemType directory 
	cp $xunit_dir\*.* $build_dir
} 

task Compile -depends Init { 
  exec msbuild "/p:OutDir=""$buildartifacts_dir "" $sln_file"
} 

task Test -depends Compile {
  $old = pwd
  cd $build_dir
  exec "$xunit_dir\xunit.console.exe" "$build_dir\IOAbstraction.Test.dll"
  cd $old		
}


task Release -depends Test {
	& $tools_dir\zip.exe -9 -A -j `
		$release_dir\IOAbstraction-$humanReadableversion-Build-$commit.zip `
		$build_dir\IOAbstraction.dll `
		$build_dir\IOAbstraction.xml `
		license.txt `
		acknowledgements.txt
	if ($lastExitCode -ne 0) {
        throw "Error: Failed to execute ZIP command"
    }
}

task Upload -depend Release {
	if (Test-Path $uploadScript ) {
		$log = git log -n 1 --oneline		
		msbuild $uploadScript /p:Category=$uploadCategory "/p:Comment=$log" "/p:File=$release_dir\Rhino.Mocks-$humanReadableversion-Build-$env:ccnetnumericlabel.zip"
		
		if ($lastExitCode -ne 0) {
			throw "Error: Failed to publish build"
		}
	}
	else {
		Write-Host "could not find upload script $uploadScript, skipping upload"
	}
}