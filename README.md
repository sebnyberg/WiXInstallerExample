# WiXInstallerExample

This is an example project of how a simple WPF WiX installer can be set-up using a WiX Installer project and a WiX BootStrapper project.

## Prerequisites

In order to run this project, you need to have the WiX Toolset installed. Download the latest installer at http://wixtoolset.org/releases/.

The project was made using Visual Studio 2015.

## Creating the Package (Setup) project

1. Add a new project to your solution of the type Setup Project (found under Windows Installer XML). If you can't find this type of project, make sure that WiX is installed and that you have restarted Visual Studio since.
2. Rightclick References -> Add Reference... Continue to add references to WiXUIExtension.dll, WiXNetFxExtension.dll and all the projects you will need to reference in the Setup. That is: your WPF project should be included as a reference.
3. Copy the .wxs files from this project to yours and include them, or laternatively create the files yourself and paste the content of this projects' files into yours. There is no rule for what the .wxs files other than Product are to be named, the only requirement is that the root element is `<Fragment>`.

Now you can start editing the files so that they fit your project. Most of the Ids and other types of references are self-explanitory. The `ComponentGroupRef` and `ComponentRef` in the Product.wxs file references elements in the Components.wxs file. 

It is important that you generate new GUID's for all your components and the upgrade code. This can be done by using the built-in Visual Studio GUID generator in the menu at Tools -> Create GUID. If you have ReSharper installed, you can type nguid and press tab to generate a new GUID. There are also GUID creation extensions which can be installed through the Visual Studio Gallery.

Replace all references to `Name=ExampleWixApp` to the name of your application. Then replace `WpfApp` to the name of your WPF project.

### Selecting the UI guide type

There are a number of different install UI types. If none is specified, the project will simply install without any dialogue presented to the user.

Included in the project is a sequence which presents the user with Welcome dialog, Install directory dialogue, then installs the program. If you want to use one of the UI presets you can define it like so:

```
<!-- WixUI_Minimal / WixUI_InstallDir are the most used options -->
<UIRef Id="WixUI_Minimal">
```

### Changing the application icon

The application icon included in the example project was copied from the [Visual Studio 2015 icons library](https://www.microsoft.com/en-us/download/details.aspx?id=35825). 

After finding an appicon, make sure that you set the Copy to Output Directory property of the file to "Always".

## Creating the Setup (Bootstrapper) project

If you wish to make sure that the user has some library available before installing your application, for example the .NET Framework version 4.5, you can use a Bootstrapper project. Simply add the project to your solution and copy the content of the bundle.wxs file to yours. Once again rename references where needed.

You also need to reference the Setup project and the WixNetFxExtension.dll by clicking References -> Add Reference...

If you decide to use a Bootstrapper project, the regular UI structure of the Setup will be skipped and no Uninstall shortcut will be added to the Windows start-menu. The application will however uninstall as usual through the Programs and Features.

## Creating upgrades

When a new version of the project is to be installed by the client(s), change the product version in both the Package and Setup project to reflect that a new version has been built. The installer will automatically detect that the installation is an upgrade of an existing application and thus reinstall with the updated files.