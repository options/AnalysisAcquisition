# Bot app Dev 

## Overview

This project was generated with Microsoft Bot Framework, C# and ASP.NET.

- Sources for Bot app(UBone Bot)
- developed with [Microsoft Bot framework](https://dev.botframework.com/) using C#, ASP.NET
- used multi-dialogs for conversation flow
- User can send/upload a document file(PDF only now) to Bot for asking analysis
- Bot simply rename it for preventing file-name duplicattion and forward it to Azure Blob storage for following analysis process

The Bot app is hosting on Azure Web App.

Architecture of Bot app communicating with Front-end is as follows.

![Front-end UI Architecture](images/frontend-bot.png)
