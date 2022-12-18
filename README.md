# TowerDefense skeleton project
Tower defense game skeleton for design pattern implementation
![image](https://user-images.githubusercontent.com/54746064/208293825-01607f01-89f1-4fec-9c14-6268abc9a8cd.png)

## About

This is a skeleton project specially crafted for design pattern implementation. It has React + Redux frontend togheter with .NET 6 API in the backend.
This project was created with the intent (and some hints as well!) to implement design patterns for this game.

## Main idea
Genre of the game is turn based tower defense game (although as this is a skeleton - you can easily convert it to realtime game as well).
![image](https://user-images.githubusercontent.com/54746064/208293911-2d36c008-06dc-469f-850e-9df3780a0b14.png)

The main objective is to defeat your oponent using your special items such as rockets or shields.

## Why this skeleton will benefit you?

There is litterally everything on the front end that you will need to implement all of the design patterns. Although you may need to tweak it a little bit depending on your needs. This project is heavily back-end oriented in terms of design patterns.

## Developer guide

The solution is written in React + Redux as well as .NET 6 API for the backend. It uses REST for turn based communication and SignalR for realtime communication.

### Quick start guide

In order to start the solution you will need following prerequisites:

* Visual Studio 2022 (or greater)
* .NET 6 SDK installed (should be available through Visual Studio Installer)
* Node.JS
* Your favourite code editor. We recommend Visual Studio Code.

1. Open `TowerDefense.sln` solution and select `TowerDefense.Api` as your startup project. (It should be your startup project by default)
![image](https://user-images.githubusercontent.com/54746064/208294888-d5519996-7881-477c-a93b-b3709e1138dd.png)
2. Start the API.
![image](https://user-images.githubusercontent.com/54746064/208294919-b156cfde-1445-4057-a2ec-aa1b3ba03411.png)

And you should see the following screen.
![image](https://user-images.githubusercontent.com/54746064/208295156-49e8591c-2638-4bc1-9020-3c05935ecc48.png)

Make sure you note what IP address is being used by the API. In our case we can see `https://localhost:7042`:exclamation:
It should be the same for you if the 7042 port is not being used by any other application.
The IP Address is based on your `launchSettings.json` that can be found under `Properties` directory.
3. Open `src\towerdefense-app` directory using your favourite code editor. In our case we prefer to use Visual Studio Code.
4. Open .env file and make sure the right IP Address is being used. The same one the API is listening to :exclamation:
Don't forget to add /api at the end.

![image](https://user-images.githubusercontent.com/54746064/208295369-550e708a-5efb-45b8-8730-0bd6b4374131.png)

5. Open `src\towerdefense-app` directory in terminal and run `npm install`. It will install all of the required modules.
6. In the terminal run `npm start`. And the game should start.

![image](https://user-images.githubusercontent.com/54746064/208295627-f582cd05-a423-45b4-85e1-d33b42adee98.png)

To start the game simply open up two tabs and navigate to the site. Input two usernames and start the game.

![image](https://user-images.githubusercontent.com/54746064/208295734-faf82256-27b9-4c7e-9bde-27729d1a1397.png)

If everything worked fine you should see the arena grid, player names, money, health.

![image](https://user-images.githubusercontent.com/54746064/208295778-e56241e1-41f0-4201-9860-76e1bddd1966.png)


