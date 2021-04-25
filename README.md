# AzureAppServiceLoggingPOC

This solution contains log messages in different levels from trace to critical. We are going to look closer at how to deploy this console application as WebJob to Azure in App Service, so we are able to see the log messages both in live stream and as files in Blob Storage. 

So in short, this is a solution to demonstrate how to turn on logging capabilities in Azure App Service. 


# PREREQUISITES

1. You need a valid Azure Subscription where you can deploy some Azure Resources.
2. Resource group in Azure for deploying this POC. 
3. PowerShell Core / Windows Azure SDK Environment / Any other shell with Azure CLI installed in Windows / Linux. 
4. You can clone the solution locally, but it's not a requirement as deployment will happen from Github URI directly to Azure (Optional) 

# STEPS

#1.az login

  NB! Might be you do not have Azure CLI installed at your computer/shell, so please download it using following command:

  Invoke-WebRequest -Uri https://aka.ms/installazurecliwindows -OutFile .\AzureCLI.msi; Start-Process msiexec.exe -Wait -ArgumentList '/I AzureCLI.msi /quiet'; rm .\AzureCLI.msi

  or UI installation file: https://aka.ms/installazurecliwindows

#2. Create an App Service Plan by using Azure CLI

  az appservice plan create --name $appPlan --resource-group $resourceGroup --location $appLocation --sku FREE

  Example:

  az appservice plan create --name AzureAppServiceLoggingPOCPlan --resource-group AzureLoggingPOC --location centralindia --sku FREE

#3. Create a Web App where the application will run, basically an App Service with deployed code from this Github Repo. 

  az webapp create --name $appName --resource-group $resourceGroup --plan $appPlan --deployment-source-url $gitRepo

  Example:

  az webapp create --name LoggingAppPOC500 --resource-group AzureLoggingPOC --plan AzureAppServiceLoggingPOCPlan --deployment-source-url https://github.com/jagjitsingh700/AzureAppServiceLoggingPOC.git

#4. Create a Storage Account where we will keep all the logs with retention

  az storage account create -n $storageAccount -g $resourceGroup -l $appLocation --sku Standard_LRS 

  Example:

  az storage account create -n loggingappstorage -g AzureLoggingPOC -l centralindia --sku Standard_LRS

#5. Now as all resources deployed. Log into Azure Portal and go into your App Service and in the Monitoring section click at App Service Logs. 

#6. Turn on both:
- Application Logging (Filesystem)
- Application Logging (Blob)

#7. When turning on Application Logging (Blob) select the existing Storage account you created in step 4. But you will need to create a container in that storage account also, just call it asplogs and enter 5 days at Retention Period. 

NB! Remember to select log level. I select Error on Application Logging to not store to much log data because it can affect performance, but on the permanent storage I select Verbose because that will not affect app performance. Remember Application Logs are default deleted after 12 hours. 
