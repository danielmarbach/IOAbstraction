Set-Executionpolicy unrestricted
$base_dir = resolve-path .
Import-Module $base_dir\..\Tools\Psake\psake.psm1
.\psake.ps1 default.ps1