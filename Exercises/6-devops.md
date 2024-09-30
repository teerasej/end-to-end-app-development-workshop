# Lab 06: CI/CD Made Easy with Azure DevOps

## Entering the Azure DevOps Portal

1. Open your web browser
2. Navigate directly to [https://aex.dev.azure.com](https://aex.dev.azure.com).
3. In the drop-down box on the left, choose **Default Directory**, instead of “Microsoft Account”.
4. If prompted (*"We need a few more details"*), provide your name, e-mail address, and location and click **Continue**.
5. Back at [https://aex.dev.azure.com](https://aex.dev.azure.com) with **Default Directory** selected click the blue button **Create new organization**.
6. Accept the *Terms of Service* by clicking **Continue**.
7. If prompted (*"Almost done"*), leave the name for the Azure DevOps organization at default (it needs to be a globally unique name) and pick a hosting location close to you from the list.
8. Once the newly created organization opens in **Azure DevOps**, Click on **New Project**. Give your project the following settings:
    - name: **eShopOnWeb**
    - visibility: **Private**
    - Advanced: Version Control: **Git**
    - Advanced: Work Item Process: **Scrum**

## Workshop Exercises

1. [DevOps: Code Review](6-1-devops-code-review.md)
2. [DevOps: CI Pipeline](6-2-devops-ci-pipeline.md)