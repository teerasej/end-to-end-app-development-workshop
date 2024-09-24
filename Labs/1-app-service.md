# Lab 01: Build a web application on Azure platform as a service offering

## Services included in this exercise

1. Azure App Service
2. Azure Blob Storage

## Instructions

### Before you start

#### Sign in to the lab environment

Sign in to your Azure portal using the credentials provided.

> **Note**: Your lab host will provide instructions to connect to the virtual lab environment.


#### Task 1: Open the Azure portal

1. On the taskbar, select the **Microsoft Edge** icon.

2. In the browser window, browse to the Azure portal at `https://portal.azure.com`, and then sign in with the account you'll be using for this lab.

   > **Note**: If this is your first time signing in to the Azure portal, you'll be offered a tour of the portal. If you prefer to skip the tour, select **Maybe later** to begin using the portal.

#### Task 2: Create a Storage account

1. In the Azure portal, use the **Search resources, services, and docs** text box to search for **Storage Accounts**, and then in the list of results, select **Storage Accounts**.

1. On the **Storage accounts** blade, select **+ Create**.

1. On the **Create a storage account** blade, on the **Basics** tab, perform the following actions, and then select **Review**:

    | Setting | Action |
    |--|--|
    | **Subscription** drop-down list | Retain the default value |
    | **Resource group** section | Select **Create new**, enter **ManagedPlatform**, and then select **OK** |
    | **Storage account name** text box | Enter **imgstor**_[yourname]_ |
    | **Region** drop-down list | Select **(US) East US** |
    | **Primary Service** drop-down list | Select **Azure Blob Storage or Azure Data Lake Storage Gen 2** |
    | **Primary Workload** drop-down list | Select **Other** |
    | **Performance** section | Select the **Standard** option |
    | **Redundancy** drop-down list | Select **Locally-redundant storage (LRS)** |

   The following screenshot displays the configured settings on the **Basics** tab of the **Create a storage account** blade.

   ![Create a storage account blade](./media/l01_create_storage.png)

   1. On the **Review** tab, review the options that you selected during the previous steps.
   
   2. Select **Create** to create the storage account by using your specified configuration.
   
      > **Note**: Wait for the creation task to complete before you proceed with this lab.
   
   3. On the **Overview** blade, select the **Go to resource** button to navigate to the blade of the newly created storage account.
   
   4. On the **Storage account** blade, in the **Security + networking** section, select **Access keys**.
   
   5. ** ***[Copy to NotePad]*** ** On the **Access keys** blade, review any one of the **Connection string**s (using **Show** button), and then record the value of either **Connection string** boxes in Notepad. The **Key**s are platform managed encryption keys and are **not** used for this lab.
   
      > **Note**: It doesn't matter which connection string you choose. They are interchangeable.
   
   6. Open Notepad, and then paste the copied connection string value to Notepad. You'll use this value later in this lab.
   
   #### Task 3: Upload a sample blob
   
   7. On the **Storage Account** blade, in the **Data storage** section, select the **Containers** link.
   
   8. On the **Containers** blade, select **+ Container**.
   
   9. In the **New container** window, perform the following actions, and then select **Create**.
   
      | Setting | Action |
      | --- | --- |
      | **Name** text box | Enter **images** |
   
   10. On the **Containers** blade, navigate into the newly created **images** container.
   
   11. On the **images** blade, select **Upload**.
   
   12. In the **Upload blob** window, perform the following actions:
   
       | Setting | Action |
       |--|--|
       | **Files** section | Select **Browse for files** or use the drag and drop feature |
       | **File Explorer** window | Browse to **[Local repository directory]\\Allfiles\\Labs\\01\\Starter\\Images**, select the **grilledcheese.jpg** file, and then select **Open** |
       | **Overwrite if files already exist** check box | Ensure that the check box is selected, and then select **Upload** |
   
       > **Note**: Wait for the blob to upload before you continue with this lab.
   
   #### Task 4: Create a web app
   
   13. On the Azure portal's navigation pane, select **Create a resource**.
   
   14. On the **Create a resource** blade, in the **Search services and marketplace** text box, enter **Web App**, and then select Enter.
   
   15. On the **Marketplace** search results blade, select the **Web App** result.
   
   16. On the **Web App** blade, select **Create**.
   
   17. On the **Create Web App** blade, on the **Basics** tab, perform the following actions, and then select the **Monitoring** tab:
   
      | Setting                            | Action                                                                                                  |
      | ---------------------------------- | ------------------------------------------------------------------------------------------------------- |
      | **Subscription** drop-down list    | Retain the default value                                                                                |
      | **Resource group** section         | Select **ManagedPlatform**                                                                              |
      | **Name** text box                  | Enter **imgapi**_[yourname]_ **(noted this one in NotePad)**                                                                           |
      | **Publish** section                | Select **Code**                                                                                         |
      | **Runtime stack** drop-down list   | Select **.NET 8 (LTS)**                                                                                 |
      | **Operating System** section       | Select **Windows**                                                                                      |
      | **Region** drop-down list          | Select the **East US** region                                                                           |
      | **Windows Plan (East US)** section | Select **Create new**, enter the value **ManagedPlan** in the **Name** text box, and then select **OK** |
      | **Pricing plan** section           | Select **Standard S1**                                                                                  |
   
      The following screenshot displays the configured settings on the **Create web app** blade.
   
      ![Create web app blade](./media/l01_create_web_api.png)
   
   18. On the **Monitoring** tab, in the **Enable Application Insights** section, select **No**, and then select **Review + create**.
   
   19. On the **Review + create** tab, review the options that you selected during the previous steps.
   
   20. Select **Create** to create the web app by using your specified configuration.
   
      > **Note**: Wait for the web app to be created before you continue with this lab.
   
   21. On the **Overview** blade, select the **Go to resource** button to navigate to the blade of the newly created web app.
   
   #### Task 5: Configure the web app
   
   22. On the **App Service** blade, in the **Settings** section, select the **Environment variables** link.
   
   23. In the **App settings** tab, select **+ Add**. Enter the following information in the **Add/Edit application setting** pop-up dialog:
   
       | Setting | Action |
       |--|--|
       | **Name** text box | Enter **StorageConnectionString** |
       | **Value** text box | Paste the storage connection string that you previously copied to Notepad |
       | **Deployment slot setting** check box | Retain the default value |
   
   24. Select **Apply** to close the pop-up dialog and return to the **App settings** section.
   
   25. At the bottom of the **App settings** section, select **Apply**.
   
      >**Note:** You may receive a warning that your app may restart when updating app settings. Select **Confirm**. Wait for your application settings to save before you continue with the lab.
   
   26. ** ***[Copy to Notepad]*** ** To get the App Service's URL, go to the **Overview** link, copy the value from the **Default domain** section, and then paste it to Notepad. Prepend `https://` to the domain name in Notepad. You’ll use this value later in the lab.
   
      > **Note**: At this point, the web server at this URL will return a placeholder webpage. You haven't deployed any code to the Web App yet. You'll deploy code to the Web App later in this lab.
   
   #### Task 6: Deploy an `ASP.NET` web application to Web Apps
   
   27. On the taskbar, select the **Visual Studio Code** icon.
   
   28. On the **File** menu, select **Open Folder**.
   
   29. In the **File Explorer** window, browse to **[Local repository directory]\\Allfiles\\Labs\\01\\Starter\\API**, and then select **Select Folder**.
   
      > **Note**: Ignore any prompts to add required assets to build and debug and to run the restore command to address unresolved dependencies.
   
   30. On the **Explorer** pane of the **Visual Studio Code** window, expand the **Controllers** folder, and then select the **ImagesController.cs** file to open the file in the editor.
   
   31. In the editor, in the **ImagesController** class on line 26, observe the **GetCloudBlobContainer** method and the code used to retrieve a container.
   
   32. In the **ImagesController** class on line 36, observe the **Get** method and the code used to retrieve all blobs asynchronously from the **images** container.
   
   33. In the **ImagesController** class on line 68, observe the **Post** method and the code used to persist an uploaded image to Storage.
   
   34. On the taskbar, select the **Terminal** icon.
   
   35. At the open terminal, enter the following command, and then select Enter to sign in to the Azure Command-Line Interface (CLI):
   
      ```
      az login
      ```
   
   36. In the **Microsoft Edge** browser window, enter the email address and password for your Microsoft account, and then select **Sign in**.
   
   37. Return to the currently open **Terminal** window. Wait for the sign-in process to finish.
   
   38. Within the Visual Studio Code, Right-click on the **[Local repository directory]\\Allfiles\\Labs\\01\\Starter\\API**

   39. Select "Open in integrated terminal" to change the current directory in the terminal to the **[Local repository directory]\\Allfiles\\Labs\\01\\Starter\\API** directory that contains the lab files.
   
   40. Enter the following command, and then select Enter to deploy the **api.zip** file to the web app that you created previously in this lab:
   
      ```
      az webapp deploy --resource-group ManagedPlatform --src-path api.zip --type zip --name  <name-of-your-api-app>
      ```
   
      > **Note**: Replace the *\<name-of-your-api-app\>* placeholder with the name of the web api that you created previously in this lab. You recently noted this app’s name in the previous steps.
   
      Wait for the deployment to complete before you continue with this lab.
   
   41. On the Azure portal's **navigation** pane, select the **Resource groups** link.
   
   42. On the **Resource groups** blade, select the **ManagedPlatform** resource group that you created previously in this lab.
   
   43. On the **ManagedPlatform** blade, select the **imgapi**_[yourname]_ web app that you created previously in this lab.
   
   44. From the **App Service** blade, select **Browse**.
   
      > **Note**: The **Browse** command will perform a GET request to the root of the website, which returns a JavaScript Object Notation (JSON) array. This array should contain the URL for your single uploaded image in your Storage account.
   
   45. Return to your browser window that contains the Azure portal.
   
   35. Close the currently running Visual Studio Code and Terminal applications.
   
   #### Review
   
   In this exercise, you created a web app in Azure, and then deployed your `ASP.NET` web application to Web Apps by using the Azure CLI and Apache Kudu zip file deployment utility.
   
   ### Exercise 2: Build a front-end web application by using Azure Web Apps
   
   #### Task 1: Create a web app
   
   36. On the Azure portal's **navigation** pane, select **Create a resource**.
   
   37. On the **Create a resource** blade, in the **Search services and marketplace** text box, enter **Web App**, and then select Enter.
   
   38. On the **Marketplace** search results blade, select **Web App**.
   
   39. On the **Web App** blade, select **Create**.
   
   40. On the **Create Web App** blade, on the **Basics** tab, perform the following actions, and then select the **Monitoring** tab:
   
      | Setting                            | Action                        |
      | ---------------------------------- | ----------------------------- |
      | **Subscription** drop-down list    | Retain the default value      |
      | **Resource group** section         | Select **ManagedPlatform**    |
      | **Name** text box                  | Enter **imgweb**_[yourname]_ **(Noted this name)** |
      | **Publish** section                | Select **Code**               |
      | **Runtime stack** drop-down list   | Select **.NET 8 (LTS)**       |
      | **Operating System** section       | Select **Windows**            |
      | **Region** drop-down list          | Select the **East US** region |
      | **Windows Plan (East US)** section | Select **ManagedPlan (S1)**   |
   
   The following screenshot displays the configured settings on the **Create web app** blade.
   
   ![Create web app blade](./media/l01_create_web_app.png)
   
   41. On the **Monitoring** tab, in the **Enable Application Insights** section, select **No**, and then select **Review + create**.
   
   42. From the **Review + create** tab, review the options that you selected during the previous steps.
   
   43. Select **Create** to create the web app by using your specified configuration.
   
      > **Note**: Wait for the creation task to complete before you continue with this lab.
   
   44. On the **Overview** blade, select the **Go to resource** button to navigate to the blade of the newly created web app.
   
   #### Task 2: Configure a web app
   
   45. On the **App Service** blade, in the **Settings** section, select the **Environment variables** link.
   
   46. In the **Environment variables** section, perform the following actions, select **Save**, and then select **Continue**:
   
       | Setting | Action |
       |--|--|
       | **App settings** tab | Select **New application setting** |
       | **Add/Edit application setting** pop-up dialog | In the **Name** text box, enter **ApiUrl** |
       | **Value** text box | Enter the web app URL that you copied previously in this lab. ** **Note** **: Make sure you include the protocol **https://**, in the URL that you copy into the **Value** text box for this application setting |
       | **Deployment slot setting** check box | Retain the default value, and then select **OK** |
       | Click **Save** in the  top menu | This will save the configuration value you just entered |
   
      > **Note**: Wait for the application settings to save before you continue with this lab.
   
   #### Task 3: Deploy an `ASP.NET` web application to Web Apps
   
   47. On the taskbar, select the **Visual Studio Code** icon.
   
   48. On the **File** menu, select **Open Folder**.
   
   49. In the **File Explorer** window, browse to **[Local repository directory]\\Allfiles\\Labs\\01\\Starter\\Web**, and then select **Select Folder**.
   
      > **Note**: Ignore any prompts to add required assets to build and debug and to run the restore command to address unresolved dependencies.
   
   50. On the **Explorer** pane of the **Visual Studio Code** window, expand the **Pages** folder, and then select the **Index.cshtml.cs** file to open the file in the editor.
   
   51. In the editor, in the **IndexModel** class on line 30, observe the **OnGetAsync** method and the code used to retrieve the list of images from the API.
   
   52. In the **IndexModel** class on line 41, observe the **OnPostAsync** method and the code used to stream an uploaded image to the backend API.
   
   53. On the taskbar, select the **Terminal** icon.
   
   54. At the open terminal, enter the following command, and then select Enter to sign in to the Azure CLI:
   
      ```
      az login
      ```
   
   55. In the **Microsoft Edge** browser window, enter the email address and password for your Microsoft account, and then select **Sign in**.
   
   56. Return to the currently open **Terminal** window. Wait for the sign-in process to finish.
   
   57. Within the Visual Studio Code, Right-click on the **[Local repository directory]\\Allfiles\\Labs\\01\\Starter\\Web** 

   58. Select "Open in integrated terminal" to change the current directory to the **[Local repository directory]\\Allfiles\\Labs\\01\\Starter\\Web** directory that contains the lab files.
   
   59. Enter the following command, and then select Enter to deploy the **web.zip** file to the web app that you created previously in this lab:
   
      ```
      az webapp deployment source config-zip --resource-group ManagedPlatform --src web.zip --name <name-of-your-web-app>
      ```
   
      > **Note**: Replace the *\<name-of-your-web-app\>* placeholder with the name of the web app that you created previously in this lab. You recently noted this app’s name in the previous steps.
   
      Wait for the deployment to complete before you continue with this lab.
   
   60. On the Azure portal's **navigation** pane, select **Resource groups**.
   
   61. On the **Resource groups** blade, select the **ManagedPlatform** resource group that you created previously in this lab.
   
   62. On the **ManagedPlatform** blade, select the **imgweb**_[yourname]_ web app that you created previously in this lab.
   
   63. On the **App Service** blade, select **Browse**.
   
   64. Observe the list of images in the gallery. The gallery should list a single image that was uploaded to Storage previously in the lab.
   
   65. In the **Contoso Photo Gallery** webpage, in the **Upload a new image** section, perform the following actions:
   
      a. Select **Browse**.
   
      b. In the **File Explorer** window, browse to **[Local repository directory]\\Allfiles\\Labs\\01\\Starter\\Images**, select the **banhmi.jpg** file, and then select **Open**.
   
      c. Select **Upload**.
   
   66. Observe that the list of gallery images has updated with your new image.
   
      > **Note**: In some rare cases, you might need to refresh your browser window to retrieve the new image.
   
   67. Return to the browser window that contains the Azure portal.
   
   68. Close the currently running Visual Studio Code and Terminal applications.
   
   #### Review
   
   In this exercise, you created an Azure web app and deployed an existing web application’s code to the resource in the cloud.