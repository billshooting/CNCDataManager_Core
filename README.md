# CNCDataManager_Core
CNCDataManager ASP.NET Core + TypeScript + Angular版本
这是一个提供数控机床数据服务和选型服务的网站源代码。

---

后端采用ASP.NET Core，项目名称`CNCDataAPI`，SDK版本为`1.0.0-preview2-003156`，建议使用`Visual Studio 2015 update3`打开项目。由于`Visual Studio 2017`构建.NET Core的工具换成了MSBuild，使用此版本打开项目可能要花一些时间进行项目迁移。
生成发布建议均采用`Visual Studio`自带的工具进行发布。由于项目中需要用到一些不包含在项目中的C++ dll，所以在**第一次远程部署**时，仍需采用命令行部署。

- 编译：
`dotnet build "{YOUR PATH}\CNCDataManager_Core\src\CNCDataAPI" --configuration Release --no-dependencies`

- 发布到临时文件夹：
`dotnet publish "{YOUR PATH}\CNCDataManager_Core\src\CNCDataAPI" --framework net452 --runtime win7-x86 --output "C:\PublishTemp\CNCDataAPI" --configuration Release --no-build`

- 部署到远程服务器（在这之前，将需要用到的C++dll复制到临时文件夹下）
`msdeploy" -source:manifest='C:\PublishTemp\obj\CNCDataAPI\SourceManifest.xml' -dest:manifest='C:\PublishTemp\obj\CNCDataAPI\DestinationManifest.xml',
ComputerName='{主机名}',UserName='{账号}',Password='{密码}',IncludeAcls='False',AuthType='Basic' 
-verb:sync -enablerule:AppOffline -enableRule:DoNotDeleteRule -retryAttempts:20`

前端的采用AngularjS作为开发框架，Typescript作为开发语言，项目名称`CNCDataManager`。可以使用`Visual Studio`开发，但更建议使用`VS Code`，配合Typescript效果更好。

- 调试时生成：
`gulp`
在项目目录下敲入`gulp`命令，此时Typescript文件会编译为单独的js文件。
- 发布时生成
`gulp bundle`生成Typescript文件的合并js文件。
`gulp publish`会将所有`html`文件，`css`文件，`js`文件压缩并拷贝到`CNCDataManager_Publish`项目中，此时可以借助`Visual Studio`发布Typescript项目的功能部署前端项目。






