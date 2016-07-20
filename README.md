# evangelist.me
A launchpad for everything related to Generic Evangelist. 

1. Fork this Repo into your own account
2. Clone the Repo onto your local disk
3. Open evangelist-site.sln with Visual Studio 2015
4. Press F5 or start Debugging

 At this point IISExpress should start running in your system tray hosting the site on localhost and a browser window should pop up to render it. The site will be missing your personalised data, data for your talks and links and your images. Also, the Articles page will show an exception error page as it requires a blog feed.

5. Open the file appsettings.json and find the Personalise section and fill it with details about yourself.
6. Replace images in the wwwroot/images folder with some which make sense for you

 At this point, if you want to publish to Azure, right-click on the evangelist-site project in Visual Studio and choose publish, select Azure App Service and configure your service. 
 When the service has started you can create a SQL Azure database of your choosing (put this in the same Azure Resource Group as your App Service) and then take the connection string for the SQL Azure database and set it as a connection string in the Application Settings pane of your App Service using BetaConnection as the key value for it.
 (The site is configured to use a local database when you run the code from Visual Studio but this connection string will override that setting when you publish your site to Azure).

 Once done, publish your site if you didn't earlier and check that the site still works.

7. Open your site at the /admin page and you can add talks, resources and resource groups which will be stored in the SQL database and be rendered on your site
 
Once your site is up and running go crazy and personalise it!

Example sites are http://martink.me and http://peted.co.uk
