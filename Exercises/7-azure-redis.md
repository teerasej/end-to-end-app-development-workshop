

# Lab 07: Azure Redis

## Microsoft Azure user interface

Given the dynamic nature of Microsoft cloud tools, you might experience Azure UI changes that occur after the development of this training content. As a result, the lab instructions and lab steps might not align correctly.

Microsoft updates this training course when the community alerts us to needed changes. However, cloud updates occur frequently, so you might encounter UI changes before this training content updates. **If this occurs, adapt to the changes, and then work through them in the labs as needed.**

## Instructions

### Before you start

#### Sign in to the lab environment

Sign in to your Azure portal using the credentials provided.

> **Note**: Your lab host will provide instructions to connect to the virtual lab environment.



## Lab Scenario

In this lab, you will create an Azure Redis Cache instance and use it to store and retrieve data from a .NET console application.

### Exercise 1: Create Azure resources

#### Task 1: Open the Azure portal

1. On the taskbar, select the **Microsoft Edge** icon.
1. In the browser window, browse to the Azure portal at `https://portal.azure.com`, and then sign in with the account you'll be using for this lab.

    > **Note**: If this is your first time signing in to the Azure portal, you'll be offered a tour of the portal. If you prefer to skip the tour, select **Get Started** to begin using the portal.

#### Task 2: Create an Azure Cache for Redis instance

1. In the Azure portal, use the **Search resources, services, and docs** text box to search for **cache for redis**, and then, in the list of results, select **Azure Cache for Redis**.

1. On the **Azure Cache for Redis** blade, select **+ Create**.

1. On the **New Redis Cache** blade, on the **Basics** tab, perform the following actions, and then select **Next**:

    | Setting | Action |
    | -- | -- |
    | **Subscription** drop-down list | Retain the default value |
    | **Resource group** section | Select **Create new**, enter _[yourname]_**CacheAssets**, and then select **OK** |
    | **DNS Name** text box | Enter **redis-cache-**_[yourname]_ |
    | **Location** drop-down list | Select **Australia East** |
    | **Cache SKU** section | Select the **Basic (No SLA)** option |
    | **Cache size** drop-down list | Select **C0 (250 MB Cache)** |

    The following screenshot displays the configured settings in the **Create a storage account** blade.

    ![Screenshot displaying the configured settings on the Create a redis cache blade](./media/l07-new-redis-cache.png)

2. On the **Networking** tab, select **Next**.
3. On the **Advanced** tab, select **enable** for **Microsoft Entra Authentication** and **Access Key Authentication**, then select **Next**.
4. On the **Review + Create** tab, review the options that you selected during the previous steps.
5. Select **Create** to create the storage account by using your specified configuration.

    > **Note**: Wait for the creation task to complete before you proceed with this lab.

6. On the **Overview** blade, select the **Go to resource** button to navigate to the blade of the newly created Azure Cache for redis account.

7. ** **[Copy to NotePad]** ** Open the '**Setting > Authentication > Access keys**' tab, and then record the value of the **Primary connection string** box in Notepad. You'll use this value later in this lab.

    > **Note**: The **Primary connection string** is the connection string that you'll use to connect to the Azure Cache for Redis instance.

### Exercise 2: Accessing the Redis instance using the Redis Console

#### Task 1: Access the Redis Console

You can securely issue commands to your Azure Cache for Redis instances using the Redis Console, which is available in the Azure portal for all cache tiers.

1. Open the Redis instance in the Azure portal.

2. To access the Redis Console, select **Oveview** blade, then select **Console** tab.

![Screenshot of Redis Console](./media/l07-redis-console-menu.png)


3. Issue the following commands against your cache instance, and review the results. To issue commands against your cache instance, type the command you want into the console:

    ```bash
    > set somekey somevalue
    OK

    > get somekey
    "somevalue"
    
    > exists somekey
    (string) 1
    
    > del somekey
    (string) 1
    
    > exists somekey
    (string) 0
    ```

#### Task 2: Adding an expiration time to values

Caching is important because it allows us to store commonly used values in memory. However, we also need a way to expire values when they are stale. In Redis this is done by applying a time to live (TTL) to a key.

1. Follow the steps in the script below to add a time to live of 5 seconds to counter key:

    ```bash
    > set counter 100
    OK

    > expire counter 5
    (integer) 1

    > get counter
    100

    ... wait (I mean we 'really' wait...)...

    > get counter
    (nil)
    ```

5. On the **Access keys** blade, review any one of the **Connection string**\s (using **Show** button), and then record the value of either **Connection string** boxes in Notepad. The **Key**\s are platform managed encryption keys and are **not** used for this lab.

   > **Note**: It doesn't matter which connection string you choose. They are interchangeable.

6. Open Notepad, and then paste the copied connection string value to Notepad. You'll use this value later in this lab.

#### Exercise 3: Interact with Azure Cache for Redis by using .NET

1.  In Visual Studio Code's explorer view, browse to **[Local repository directory]\\Allfiles\\Labs\\07\\Starter\\redis-cache-dotnet**.

2. Right-click on the **redis-cache-dotnet** folder, and then select **Open in Terminal**.

3. Run the following command to restore the dependencies:

    ```bash
    dotnet build
    ```

4. Open the **Program.cs** file. This file contains the code that interacts with the Azure Cache for Redis instance.
   
5. At line 9, Replace the value `your-redis-cache-connection-string` with your connection string value that you copied from the Azure portal.

    ```csharp
    var connectionString = "your-redis-cache-connection-string";
    ```

6. Save file
7. Explore the code that interacts with the Azure Cache for Redis instance.
8. Back to the terminal, run the following command to execute the code:

    ```bash
    dotnet run
    ```

9. explore the output of the code. it should display the following output:

    ```bash
    i-love-rocky-road
    pong
    ```
### Remove the resources group

1. In the Azure portal, use the **Search resources, services, and docs** text box to search for **Resource groups**, and then in the list of results, select _[yourname]_**CacheAssets**.
2. On the _[yourname]_**CacheAssets** blade, select **Delete resource group**.
3. In the **Delete resource group** blade, enter the name of the resource group to confirm that you want to delete the resource group, and then select **Delete**.


## Review

In this exercise, you deployed an Azure Redis Cache instance and interacted with it using the Redis Console and a .NET console application.
