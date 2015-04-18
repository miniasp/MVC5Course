【ASP.NET MVC 5 開發實戰】練習專案
==================================

使用工具
--------

* Visual Studio 2013 
    * [Visual Studio 2013 Update 4](http://www.microsoft.com/zh-tw/download/details.aspx?id=44921)
	* [Web Essentials 2013 for Update 4](http://vswebessentials.com/)
* SQL Server 2012 Management Studio
    * [CHT\x64\SQLManagementStudio_x64_CHT.exe](http://www.microsoft.com/zh-tw/download/details.aspx?id=29062)
* SQL Server 2012 LocalDB (SQL Server 11.0.3000)
	* 伺服器名稱: **``(localdb)\v11.0``**
	*  [SQL Server 2012 Express LocalDB (SqlLocalDB) 深入剖析](http://blog.miniasp.com/post/2012/09/03/SQL-Server-2012-Express-LocalDB-Quick-Start.aspx)
* SQL Server 2014 LocalDB (SQL Server 12.0.2456.0)
	* 伺服器名稱: **``(localdb)\MSSQLLocalDB``**
* SQL Server Data Tools (SSDT) LocalDB (SQL Server 12.0.2000.8)
	* 伺服器名稱: **``(localdb)\ProjectsV12``**
* LocalDB 各版本示意圖
<br>
  ![image](https://cloud.githubusercontent.com/assets/88981/7217567/c189301c-e664-11e4-854c-106e1d64f11a.png)


建立 ASP.NET MVC 5 專案步驟說明
-------------------------------

1. [檔案] / [新增] / [專案]

	![image](https://cloud.githubusercontent.com/assets/88981/4964338/795bee9c-6793-11e4-9e8d-ebc2026c8dfa.png)

2. 選擇 [Web] 分類，選擇 [ASP.NET Web 應用程式]，設定專案 [名稱]

	![image](https://cloud.githubusercontent.com/assets/88981/4964335/45a716c6-6793-11e4-9c8a-fecf11e41ea0.png)

3. 選擇 [MVC] 專案範本，並勾選 [Web API] 核心參考

	![image](https://cloud.githubusercontent.com/assets/88981/4964334/4226a9e4-6793-11e4-830f-9b334af7d0f0.png)

專案 NuGet 套件介紹
-------------------

以下是 Visual Studio 2013 Update 4 內建的 ASP.NET MVC 5 專案範本專案的 NuGet 套件介紹。

### [ 後端套件 ]

* ASP.NET MVC 5.2.2
  - 官網: http://www.asp.net/mvc
  - 專案位址: http://aspnetwebstack.codeplex.com/
  - 範例專案: http://aspnet.codeplex.com/SourceControl/latest
* ASP.NET Web API 5.2.2
  - 官網: http://www.asp.net/web-api
  - 專案位址: http://aspnetwebstack.codeplex.com/
  - 範例專案: http://aspnet.codeplex.com/SourceControl/latest
* ASP.NET Identity 2.1.0
  - 官網: http://www.asp.net/identity
  - 專案位址: https://aspnetidentity.codeplex.com/
  - 範例專案: http://aspnet.codeplex.com/SourceControl/latest
* Entity Framework 6.1.1
  - 官網: http://www.asp.net/entity-framework
  - 專案位址: https://entityframework.codeplex.com/
* Microsoft.AspNet.Web.Optimization 1.1.3
  - 用來將 javascript, js 最小化 (minification) 與 打包 (bundling) 的工具
  - ASP.NET Optimization introduces a way to bundle and optimize CSS and JavaScript files.
  - 專案位址: https://aspnetoptimization.codeplex.com/
  - 官方文件: https://aspnetoptimization.codeplex.com/documentation
  - NuGet 套件: https://www.nuget.org/packages/Microsoft.AspNet.Web.Optimization
  - 相關連結
    * [Bundling and Minification | The ASP.NET Site](http://www.asp.net/mvc/overview/performance/bundling-and-minification)
    * [c# - Bundler not including .min files - Stack Overflow](http://stackoverflow.com/questions/11980458/bundler-not-including-min-files)
    * [kenhaines.net | WebGrease: As seen in Visual Studio 2012](http://kenhaines.net/post/2012/06/09/WebGrease-As-seen-in-Visual-Studio-2012.aspx)
    * [Web Optimization in Visual Studio 2012 RC | Howard Dierking](http://codebetter.com/howarddierking/2012/06/04/web-optimization-in-visual-studio-2012-rc/)
* Microsoft.Web.Infrastructure 1.0.0.0
  - 用來在執行時期動態註冊 HTTP modules (相依於 Microsoft.AspNet.Web.Optimization 套件)
* WebGrease 1.5.2
  - 用來最佳化 javascript, css 與圖片檔案 (相依於 Microsoft.AspNet.Web.Optimization 套件)
  - WebGrease is a suite of tools for optimizing javascript, css files and images.
  - 專案位址: https://webgrease.codeplex.com/
* Antlr 3.4.1.9004
  - 用來解析 CSS 語法的工具 (相依於 WebGrease 套件) [ [說明](http://stackoverflow.com/questions/20412234/what-is-the-purpose-of-antlr-package-in-visual-studio-2013-asp-net-project) ]
* Newtonsoft.Json (Json.NET) 6.0.4
  - 提供 .NET 環境操作 JSON 資料 (相依於 WebGrease 套件)
  - 官網: http://james.newtonking.com/json
  - 專案位址: https://github.com/JamesNK/Newtonsoft.Json
* OWIN 1.0
  - 官網: http://owin.org/
* Microsoft.Owin 3.0.0 (Katana)
  - 專案位址: http://katanaproject.codeplex.com/
  - [其他 Katana 相關套件](http://katanaproject.codeplex.com/wikipage?title=Packages)
  	- Microsoft.Owin.Host.SystemWeb<br>
  	  OWIN server that enables OWIN-based applications to run on IIS using the ASP.NET request pipeline.
	- Microsoft.Owin.Security<br>
	  Common types which are shared by the various authentication middleware components.
	- Microsoft.Owin.Security.Cookies<br>
	  Middleware that enables an application to use cookie based authentication, similar to ASP.NET's forms authentication.
	- Microsoft.Owin.Security.Facebook<br>
	  Middleware that enables an application to support Facebook's OAuth 2.0 authentication workflow.
	- Microsoft.Owin.Security.Google<br>
	  Contains middlewares to support Google's OpenId and OAuth 2.0 authentication workflows.
	- Microsoft.Owin.Security.MicrosoftAccount<br>
	  Middleware that enables an application to support the Microsoft Account authentication workflow.
	- Microsoft.Owin.Security.OAuth<br>
	  Middleware that enables an application to support any standard OAuth 2.0 authentication workflow.
	- Microsoft.Owin.Security.Twitter<br>
	  Middleware that enables an application to support Twitter's OAuth 2.0 authentication workflow.

### [ 前端套件 ]

* jQuery 1.10.2
	* 官網: http://www.jquery.com/
	* 專案位址: http://github.com/jquery/jquery 
* jQuery Validation 1.11.1
	* 官網: http://jqueryvalidation.org/
	* 專案位址: https://github.com/jzaefferer/jquery-validation 
* Microsoft.jQuery.Unobtrusive.Validation 3.2.2
	* 用來與 ASP.NET MVC 5 表單驗證功能搭配使用的 JS 函式庫
	* 套件位址: https://www.nuget.org/packages/Microsoft.jQuery.Unobtrusive.Validation/
	* 版本說明: http://go.microsoft.com/fwlink/?LinkId=389866  
* Bootstrap 3.0.0
	* 官網: http://getbootstrap.com/
* Modernizr 2.6.2
	* 官網: http://modernizr.com/
* Respond 1.2.0
	* 專案位址: https://github.com/scottjehl/Respond 

相關連結
--------

* [Visual Studio 2012 RC is released - The Big Web Rollup - Scott Hanselman](http://www.hanselman.com/blog/VisualStudio2012RCIsReleasedTheBigWebRollup.aspx)
* [ASP.NET features in New Project Templates in Visual Studio 2013](http://blogs.msdn.com/b/webdev/archive/2013/10/16/asp-net-features-in-new-project-templates-in-visual-studio-2013.aspx)
* [Announcing release of ASP.NET and Web Tools 2013.1 for Visual Studio 2012](http://blogs.msdn.com/b/webdev/archive/2013/11/18/announcing-release-of-asp-net-and-web-tools-2013-1-for-visual-studio-2012.aspx)
* [Announcing new Web Features in Visual Studio 2013 Update 2 RTM](http://blogs.msdn.com/b/webdev/archive/2014/05/12/announcing-new-web-features-in-visual-studio-2013-update-2-rtm.aspx)
* [Announcing new Web Features in Visual Studio 2013 Update 3 RTM](http://blogs.msdn.com/b/webdev/archive/2014/08/04/announcing-new-web-features-in-visual-studio-2013-update-3-rtm.aspx)
* [Announcing the Release of ASP.NET MVC 5.1, Web API 2.1 and Web Pages 3.1](http://blogs.msdn.com/b/webdev/archive/2014/01/20/announcing-the-release-of-asp-net-mvc-5-1-asp-net-web-api-2-1-and-asp-net-web-pages-3-1.aspx)
* [Announcing the Release of ASP.NET MVC 5.2, Web API 2.2 and Web Pages 3.2](http://blogs.msdn.com/b/webdev/archive/2014/07/02/announcing-the-release-of-asp-net-mvc-5-2-web-api-2-2-and-web-pages-3-2.aspx)
* [Getting Started with Entity Framework 6 Code First using MVC 5](http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
* [Getting Started with Entity Framework 5 Code First using MVC 4](http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
* [Getting Started with ASP.NET MVC 4](http://www.asp.net/mvc/overview/older-versions/getting-started-with-aspnet-mvc4/intro-to-aspnet-mvc-4)
