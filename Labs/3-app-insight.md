

# Lab 3: Monitor services that are deployed to Azure

## Microsoft Azure user interface

Given the dynamic nature of Microsoft cloud tools, you might experience Azure UI changes that occur after the development of this training content. As a result, the lab instructions and lab steps might not align correctly.

Microsoft updates this training course when the community alerts us to needed changes. However, cloud updates occur frequently, so you might encounter UI changes before this training content updates. **If this occurs, adapt to the changes, and then work through them in the labs as needed.**

## Instructions

### Before you start

#### Sign in to the lab environment

Sign in to your Azure portal using the credentials provided.

> **Note**: Your lab host will provide instructions to connect to the virtual lab environment.

#### Review the installed applications

Find the taskbar on your Windows 11 desktop. The taskbar contains the icons for the applications that you'll use in this lab, including:
    
-   Microsoft Edge
-   File Explorer
-   Visual Studio Code
-   Azure PowerShell

## Lab Scenario

In this lab, you will create an Application Insights resource in Azure that will be used to monitor and log application insight data for later review. The API will be set to automatically scale if demand increases to a certain threshold and logging the data will help determine how the service is being utilized.

## Architecture diagram

![Architecture diagram depicting the monitoring of services that are deployed to Azure](./media/Lab11-Diagram.png)

### Exercise 1: Create and configure Azure resources

#### Task 1: Open the Azure portal

1. On the taskbar, select the **Microsoft Edge** icon.

1. In the browser window, browse to the Azure portal at `https://portal.azure.com`, and then sign in with the account you'll be using for this lab.

    > **Note**: If this is your first time signing in to the Azure portal, you'll be offered a tour of the portal. Select **Get Started** to skip the tour and begin using the portal.

#### Task 2: Create an Application Insights resource

1. In the Azure portal, use the **Search resources, services, and docs** text box at the top of the page to search for **Application Insights** and then, in the list of results, select **Application Insights**.

1. On the **Application Insights** blade, select **+ Create**.

1. On the **Application Insights** blade, on the **Basics** tab, perform the following actions, and select **Review + create**:
    
    | Setting | Action |
    | -- | -- |
    | **Subscription** drop-down list | Retain the default value |
    | **Resource group** section | Select **Create new**, enter **MonitoredAssets**, and then select **OK** |
    | **Name** text box | **instrm**_[yourname]_ |
    | **Region** drop-down list | Select any Azure region in which you can deploy an Application Insights resource |
    | **Resource Mode** section | Select the **Workspace-based** option |
    | **WORKSPACE DETAILS** section | Retain the default values for the **Subscription** and **Log Analytics Workspace** drop-down lists |
    
    The following screenshot displays the configured settings on the **Application Insights** blade.

    ![Create an Azure Application Insights instance blade](./media/l11_create_app_insights_portal.png)
     
1. On the **Review + create** tab, review the options that you selected during the previous steps.

1. Select **Create** to create the **Application Insights** instance by using your specified configuration.

    > **Note**: Wait for the creation task to complete before you proceed with this lab.

1. On the **Microsoft.AppInsights \| Overview** blade, select the **Go to resource** button to navigate to the blade of the newly created **Application Insights** resource.

1. On the **Application Insights** blade, in the **Configure** section, select the **Properties** link.

1. ** **[Copy to NotePad]** ** On the **Properties** blade, next to the **Instrumentation Key** entry, select the **Copy to clipboard** button, and then record the copied value. You'll use it later in this lab.

    > **Note**: The key is used by client applications to connect to a specific **Application Insights** resource.

### Task 3: Create an Azure Web API resource

1. In the Azure portal, use the **Search resources, services, and docs** text box at the top of the page to search for **App Services** and then, in the list of results, select **App Services**.

1. On the **App Services** blade, select **+ Create**.
    
1. On the **Create Web App** blade, on the **Basics** tab, perform the following actions, and then select the **Monitoring** tab:

    | Setting | Action |
    | -- | -- |
    | **Subscription** drop-down list | Retain the default value |
    | **Resource group** drop-down list |Select **MonitoredAssets** |
    | **Name** text box | Enter **smpapi**_[yourname]_ |
    | **Publish** section | Select **Code** |
    | **Runtime stack** drop-down list | Select **.NET 8 (LTS)** |
    | **Operating System** section |  Select **Windows** |
    | **Region** drop-down list |  Select the same region you chose as the location of the **Application Insights** resource |
    | **Windows Plan (East US)** section | Select **Create new**, in the **Name** text box, enter **MonitoredPlan**, and then select **OK** |
    | **Pricing plan** section |  Retain the default value |

1. On the **Monitoring** tab, perform the following actions, and then select **Review + create**:
    
    | Setting | Action |
    | -- | -- |
    | **Enable Application Insights** section | Ensure that **Yes** is selected |
    | **Application Insights** drop-down list | Select the **instrm**_[yourname]_ Application Insights resource that you created previously in this lab |
    
1. On the **Review + create** tab, review the options that you selected during the previous steps.

1. Select **Create** to create the web API by using your specified configuration.

    > **Note**: Wait for the creation task to complete before you proceed with this lab.

1. On the deployment **Overview** blade, select the **Go to resource** button to navigate to the blade of the newly created Azure web API.

1. On the **App Service** blade, in the **Settings** section, select the **Configuration** link.

1. In the **Configuration** section, perform the following actions:
    
    a.  On the **Application settings** tab, select **Show Values** to display secrets associated with your web API.

    b.  Note the value representing the **APPLICATIONINSIGHTS_CONNECTION_STRING** key. This value was set automatically when you built the web API resource.

1. On the **App Service** blade, in the **Settings** section, select the **Properties** link.

1. In the **Properties** section, record the value of the **URL** link. You'll use this value later in the lab to submit requests to the web API.


#### Review

In this exercise, you created the Azure resources that you'll use for the remainder of the lab.

### Exercise 2: Monitor a local web API by using Application Insights

#### Task 1: Build a .NET Web API project

1. From the lab computer, start **Visual Studio Code**.

2. In Visual Studio Code, on the **File** menu, select **Open Folder**.

3. In the **Open Folder** window, browse to **[Local repository directory]\\Allfiles\\Labs\\03\\Starter\\Api**, and then select **Select Folder**.

> You can right-click the **Api** folder in the **Explorer** pane and select **Open in integrated Terminal** to open a terminal window in the correct directory.

4. In the **Visual Studio Code** window, on the Menu Bar, select **Terminal** and then select **New Terminal***.

5. At the terminal prompt, run the following command to build the .NET Web API:

    ```
    dotnet build
    ```
    
#### Task 2: Update app code to use Application Insights

1. In the **Visual Studio Code** window, on the **Explorer** pane, select the **appsettings.json** file the following element right after the **Logging** element, replacing the `instrumentation-key` placeholder with the value of the Application Insights resource instrumentation key that you recorded earlier in this lab:

    ```json
       "ApplicationInsights":
       {
          "InstrumentationKey": "instrumentation-key"
       },
    ```

    > **Note**: If the section you are adding is the last element of the file, remove the trailing comma.

2. Your appsettings.json file should now look similar in structure to the following:

    ```json
    {
        "Logging":{
            "LogLevel": {
                "Default": "Information",
                "Microsoft.AspNetCore": "Warning"
            }
        },
       "ApplicationInsights":
       {
          "InstrumentationKey": "instrumentation-key"
       },
       "AllowedHosts": "*"
    }

    > **Note**" Ensure you have replaced the placeholder with your own instrumentation key that you recorded earlier.

3. Save the changes to the **appsettings.json** file and close it.

4. At the terminal prompt, run the following command to build the .NET Web API.

    ##### Windows
    ```
    dotnet publish -c Release -r win-x86 --self-contained -p:PublishReadyToRun=true .\SimpleApi.csproj
    ```

    ##### MacOS
    ```
    dotnet publish -c Release -r win-x86 --self-contained -p:PublishReadyToRun=true SimpleApi.csproj
    ```

#### Task 3: Test an API application locally

1. At the terminal prompt, run the following command to launch the .NET Web API.

    ```
    dotnet run
    ```

1. Review the output of the command and note the HTTP URL that the site is listening on.

1. From the taskbar, open the context menu for the **Microsoft Edge** icon, and then open a new browser window.

1. In the browser window that opens, navigate to the `http://localhost` URL and add the **/weatherforecast** relative path of your web API.

    > **Note**: The full URL is `http://localhost:[port-number]/weatherforecast`, where the `[port-number]` placeholder identifies the port number at which the web app is accessible via the HTTP protocol. For example, if the port number is 5079, the URL would be `http://localhost:5079/weatherforecast`.

    > **Note**: The page should contain an output in the following format. The actual values **will** be different. 

    ```json
    [
        {
            "date": "2023-10-29",
            "temperatureC": -8,
            "summary": "Sweltering",
            "temperatureF": 18
        },
        {
            "date": "2023-10-30",
            "temperatureC": -12,
            "summary": "Hot",
            "temperatureF": 11
        },
        {
            "date": "2023-10-31",
            "temperatureC": 50,
            "summary": "Chilly",
            "temperatureF": 121
        },
        {
            "date": "2023-11-01",
            "temperatureC": 51,
            "summary": "Chilly",
            "temperatureF": 123
        },
        {
            "date": "2023-11-02",
            "temperatureC": 29,
            "summary": "Balmy",
            "temperatureF": 84
        }
    ]
    ```

2. Refresh the browser page a number of times to simulate some responses.

3. Close the browser window that's displaying the page generated by `http://localhost:[port-number]/weatherforecast`.

4. In Visual Studio Code, select **Kill Terminal** (the **Recycle Bin** icon) to close the **terminal** pane and any associated processes.

#### Task 4: Review metrics in Application Insights

1. On your lab computer, switch to the **Microsoft Edge** browser window displaying the Azure portal.

1. In the Azure portal, navigate back to the blade of the **instrm**_[yourname]_ Application Insights resource you created previously in this lab.

1. On the **Application Insights** blade, in the tiles in the center of the blade, find the displayed metrics. Specifically, find the number of server requests that have occurred and the average server response time.

    The following screenshot displays the **Application Insights** metrics of the local web app.

    ![Application Insights metrics of the local web app in the Azure portal](./media/l11_web_app_metrics_portal.png)

    > **Note**: It can take up to five minutes to observe requests in the Application Insights metrics charts.

#### Review

In this exercise, you created an API app by using ASP.NET and configured it to stream application metrics to Application Insights. You then used the Application Insights dashboard to review performance details about your API.

### Exercise 3: Monitor a web API using Application Insights

#### Task 1: Deploy an application to the web API

1. On the lab computer, switch to the Visual Studio Code.

2. In the **Visual Studio Code** window, at the explorer, right-click on the **[Local repository directory]\\Allfiles\\Labs\\03\\Starter\\Api** folder, and then select **Open in Integrated Terminal**.

3. Run the following command to create a zip file containing the starter project that you'll deploy next to the Azure web API:

    ```bash
    az webapp deploy --resource-group MonitoredAssets --src-path api.zip --type zip --name  <name-of-your-api-app>  
    ```

    > **Note**: Replace `<name-of-your-api-app>` with the name of the Azure web API app that you created earlier in this lab.

4.  On the lab computer, launch another Microsoft Edge browser window.

5.  In the browser window, navigate to the Azure Web API app into which you deployed the API app previously in this task by appending to its URL (that you recorded previously in this lab) the suffix **/weatherforecast**.

    > **Note**: For example, if your URL is `https://smpapianu.azurewebsites.net`, the new URL would be `https://smpapianu.azurewebsites.net/weatherforecast`.

6.  Verify that the output resembles the one generated when running the API app locally.

    > **Note**: The output will include different values but it should have the same format.

#### Task 2: Configure in-depth metric collection for Web Apps

1. On your lab computer, switch to the **Microsoft Edge** browser window displaying the Azure portal.

1. In the Azure portal, navigate back to the blade of the **smpapi**_[yourname]_ web app resource you created previously in this lab.

1. On the **App Service** blade, select **Application Insights**.

1. On the **Application Insights** blade, perform the following actions, select **Apply**, and then in the confirmation dialog, select **Yes**:

    | Setting | Action |
    | -- | -- |
    | **Application Insights** slider | Ensure it is set to **Enable** |
    | **Instrument your application** section | Select the **.NET** tab |
    | **Collection level** section | Select **Recommended** |
    | **Profiler** section | Select **On** |
    | **Snapshot debugger** section | Select **Off** |
    | **SQL Commands** section | Select **Off** |

    
    The following screenshot displays the **Application Insights** settings of the Azure Web API.
    
    ![Application Insights settings of the Azure Web API](./media/l11_web_api_insights.png)

1. Switch to the browser tab you opened in the previous task to display the results of deployment of your API app to the target Azure API app (including the **/weatherforecast** relative path in the target URL) and refresh the browser page several times.

1. Review the JSON-formatted output generated by the API.

1. Record the URL that you used to access the JSON-formatted output.

    > **Note**: The URL should be in the format `https://smpapianu.azurewebsites.net/weatherforecast` if **smpapianu** was the site name you created earlier.

#### Task 3: Get updated metrics in Application Insights

1. Return to the browser window displaying the Azure web app in the Azure portal.

1. On the **Application Insights** blade of the web app, select the **View Application Insights data** link.

1. On the **Application Insights** blade, review the collected metrics in the tiles in the center of the blade, including the number of server requests that have occurred and the average server response time.
 
    The following screenshot displays the **Application Insights** metrics of the Azure web app in the Azure portal.
     
    ![Application Insights metrics of the Azure web app in the Azure portal](./media/l11_azure_web_app_metrics_portal.png)

    > **Note**: It can take up to five minutes for updated metrics to appear in the Application Insights metrics charts.

#### Task 4: View real-time metrics in Application Insights

1. On the **Application Insights** blade, in the **Investigate** section, select **Live metrics**.

1. Switch back to the browser window displaying the target API app running in the target Azure web app (which targets the **/weatherforecast** relative path in the target URL), and then refresh the browser page several times.

1. Switch to the browser window displaying the **Live metrics** blade and review its content.

    > **Note**: The **Incoming Requests** section should update within seconds, showing the requests that you made to the web API.

#### Review

In this exercise, you configured and tested Application Insights logging of your web API app and viewed live information about the requests being made.