When building release configurations, it is very important that the x86-platform is built prior to the x64-platform.

Why?
To collect (harvest) the content to be included in the produced MSI, we are using a tool called 'heat' which comes bundled with WiX.
This tool does not support the harvest of registry information from dlls built for the x64-platform.
Therefore, pre-build events for the respective platforms are defined in the .wixproj file. But only the pre-build events for the x86-platform does the registry-info harvesting.

What happens if the x64-setup is built first?
If there are changes in the 'Kartverket.ShapeChange.EA.Addin'-project, these changes will most likely not be included in the produced x64-MSI. This is especially true if new .cs-files have been added.