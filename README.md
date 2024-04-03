# Build and Deploy .Net Webapplication On Azure.

## Build Application Locally
I built a ASP.NET MVC App locally. Application is an asset management application. application saves laptop details like lapgtop name, assigned user, location of asset and current status.

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/localhost.JPG)


## Automate Deployment of Azure Web Apps using Azure CLI and PowerShell


### We need to create Resource Group
Create a resource group in Azure to keep all the resources we are going to create (i.e., the app service plan and the web app). Use the command:

```bash
az group create --name ‘az400m04l09-rg’ --location ‘EastUS’ --subscription ‘Visual Studio Enterprise’


```


### Create Windows App Service Plan

Next, create an App Service Plan (ASP). An app service plan is basically a virtual machine pool that hosts your web app. You provision them by specifying a tier/SKU. The choice of SKU will have an effect on the performance of the application as well as the cost. Learn more about SKUs here. In the following example, we create an ASP with the name ‘asp-myorg-mywebapp’ with an SKU P1V2, which is a production-grade premium virtual machine.


```bash
az appservice plan create --name 'az400m04l09-sp1' --sku ‘P1V2’ --location  'EastUS' --resource-group ‘az400m04l09-rg’ --subscription ‘Visual Studio Enterprise’


```

### Create A Web App Inside the Azure App Service Plan

Next, create the web app inside the app service plan. In the following example, I am giving my application the name ‘RGATES379617835-DevTest’.

```
az webapp create --name ‘RGATES379617835-DevTest’ --plan ‘az400m04l09-sp1’ --subscription ‘Visual Studio Enterprise’ --resource-group ‘az400m04l09-rg’ --runtime “dotnet:6”

```

### create azure sql server using Azure Cli

```
az sql server create --name $server --resource-group $resourceGroup --location "$location" --admin-user $login --admin-password $password
echo "Configuring firewall..."
```

### Create Database 
az sql db create --resource-group $resourceGroup --server $server --name $database --sample-name AdventureWorksLT --edition GeneralPurpose --family Gen5 --capacity 2 --zone-redundant true # zone redundancy is only supported on premium and business critical service tiers

let's verify all the resources are deployed in azure

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/resource%20created.JPG)


### publish ASP.Net app to Azure using Visual Studio

once you configure application running on local workstation to database in azure then it's time to push code into Azure.

> **Note:**
> 
> Once you configure database to your local application by adding the string make sure to test go to SQL database server in firewall add your ip address.

### deploy the application to webapp using Visual Studio

Open the projectin visual studio and right click on the project and select publish

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/publish.JPG)

Select Azure as the target to publish

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/publish1.JPG)

Select Azure App service (windows)

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/publish2.JPG)

Now Resource group and your subscription will open. 

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/publish3.JPG)

In your resource group, apps will be shown and select the app to which you want to deploy this application.

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/publish4.JPG)


Finally, select publish (generate pubxml file) click on Finish.

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/publish5.JPG)

### Verify the app is published

let's go to Azure and click on the app to see our app load.

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/ApponAzure.png)

### test the app if it's working

We will create a new laptop by logging into the app.
![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/create%20in%20azure.JPG)

You can see the record is craeted.

![](https://github.com/AbiVavilala/ASP.NETApplication/blob/master/images/create%20in%20azure1.JPG)