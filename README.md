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

