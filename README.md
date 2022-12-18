# TowerDefense skeleton project
Tower defense game skeleton for design pattern implementation

<img src="https://user-images.githubusercontent.com/54746064/208293825-01607f01-89f1-4fec-9c14-6268abc9a8cd.png" width="600">

## About

This is a skeleton project specially crafted for design pattern implementation. It has React + Redux frontend togheter with .NET 6 API in the backend.
This project was created with the intent (and some hints as well!) to implement design patterns for this game.

## Main idea
Genre of the game is turn based tower defense game (although as this is a skeleton - you can easily convert it to realtime game as well).

<img src="https://user-images.githubusercontent.com/54746064/208293911-2d36c008-06dc-469f-850e-9df3780a0b14.png" width="600">

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

<img src="https://user-images.githubusercontent.com/54746064/208294888-d5519996-7881-477c-a93b-b3709e1138dd.png" width="300">

2. Start the API.

<img src="https://user-images.githubusercontent.com/54746064/208294919-b156cfde-1445-4057-a2ec-aa1b3ba03411.png" width="700">

&nbsp;&nbsp;&nbsp;&nbsp; And you should see the following screen.

<img src="https://user-images.githubusercontent.com/54746064/208295156-49e8591c-2638-4bc1-9020-3c05935ecc48.png" width="700">

&nbsp;&nbsp;&nbsp;&nbsp; Make sure you note what IP address is being used by the API. In our case we can see `https://localhost:7042`:exclamation:
It should be the same for you if the 7042 port is not being used by any other application.
The IP Address is based on your `launchSettings.json` that can be found under `Properties` directory.

3. Open `src\towerdefense-app` directory using your favourite code editor. In our case we prefer to use Visual Studio Code.
 
4. Open .env file and make sure the right IP Address is being used. The same one the API is listening to :exclamation:
Don't forget to add /api at the end.

![image](https://user-images.githubusercontent.com/54746064/208295369-550e708a-5efb-45b8-8730-0bd6b4374131.png)

5. Open `src\towerdefense-app` directory in terminal and run `npm install`. It will install all of the required modules.
6. In the terminal run `npm start`. And the game should start.

<img src="https://user-images.githubusercontent.com/54746064/208295627-f582cd05-a423-45b4-85e1-d33b42adee98.png" width="600">

To start the game simply open up two tabs and navigate to the site. Input two usernames and start the game.

<img src="https://user-images.githubusercontent.com/54746064/208295734-faf82256-27b9-4c7e-9bde-27729d1a1397.png" width="600">

If everything worked fine you should see the arena grid, player names, money, health.

<img src="https://user-images.githubusercontent.com/54746064/208295778-e56241e1-41f0-4201-9860-76e1bddd1966.png" width="600">

### Troubleshoot
* If you experience CORS errors on the front end. Make sure you take a look at the API's `Program.cs` file where you will find CORS policy. Make sure the origin is the same as your frontend IP Address!
```Csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy(Policy.DevelopmentCors, builder =>
    {
        builder.WithOrigins("https://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((x) => true)
               .AllowCredentials();
    });
});
```



## Back-End
### Architecture
The solution is seperated into different directories according to the responsibility of the classes inside them.
There are six different directories which are responsible for one particular thing.

![image](https://user-images.githubusercontent.com/54746064/208297102-50e28cc1-1ad7-477e-8267-a1ff54c9bfa2.png)

We will dive into each one of them.

### Contracts

Let's start off with contracts directory. It is used to store the contracts that are used to communicate between FrontEnd and BackEnd. Those are also known as Data Transfer Objects (DTO). 
Contracts directory is seperated into several different directories according to the area that they specify a contract on. The paradigm on this is that we don't want our application to be dependant on outside contact and we don't want to expose our inner objects to the outside. Therefore contracts are being used only in communication purposes. These contracts should be in sync with the contracts defined in the frontend so the communication works as expected. But FrontEnd is going to be presented later.

![image](https://user-images.githubusercontent.com/54746064/208297581-868c8456-00a0-4b5c-934c-151981f41ca7.png)


### Bootstrap

Bootstrap contains everything that is needed in order to start the application, including AutoMapper profiles as well as dependency injection features. Class diagram is provided down below.

![image](https://user-images.githubusercontent.com/54746064/208297551-dbe0d6e9-20f7-4095-8404-5b0aa2fb2c9a.png)


Throughout the solution we use dependency injection to inject certain objects. If you feel that you don't have enough knowledge about dependency injection you can read more about it in https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0 .
To give you an example where dependency injection is used we have `BattleHandler` class:
```Csharp
    public class BattleHandler : IBattleHandler
    {
        private readonly State _gameState;
        private readonly IAttackHandler _attackHandler;
        private readonly INotificationHub _notificationHub;
        private readonly IGameHandler _gameHandler;

        public BattleHandler(IAttackHandler attackHandler, IGameHandler gameHandler, INotificationHub notificationHub)
        {
            _gameState = GameOriginator.GameState;
            _attackHandler = attackHandler;
            _gameHandler = gameHandler;
            _notificationHub = notificationHub;
        }
    }
```
We can see that the `BattleHandler` class needs dependencies such as `IAttackHandler`, `IGameHandler`, `INotificationHub`. In order not to couple the classes we used dependency injection so it automatically provides us the implementations through constructor. But we need to register those implementations before the start of the application. Therefore in the bootstrap directory we can see `GameEngineSetup` class which is responsible for that. If you want to add another dependency, and inject it into the constructor simply add another line in the `GameEngineSetup` class and you will be good to go.
```Csharp
    public static class GameEngineSetup
    {
        public static void SetupGameEngine(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<INotificationHub, NotificationHub>();
            serviceCollection.AddTransient<IShopHandler, ShopHandler>();
            serviceCollection.AddTransient<ITurnHandler, TurnHandler>();
            serviceCollection.AddTransient<IBattleHandler, BattleHandler>();
            serviceCollection.AddTransient<IInitialGameSetupHandler, InitialGameSetupHandler>();
            serviceCollection.AddTransient<IInventoryHandler, InventoryHandler>();
            serviceCollection.AddTransient<IGridHandler, GridHandler>();
            serviceCollection.AddTransient<IPlayerHandler, PlayerHandler>();
            serviceCollection.AddTransient<IAttackHandler, AttackHandler>();
            serviceCollection.AddTransient<IGameHandler, GameHandler>();
            serviceCollection.AddTransient<IPerkHandler, PerkHandler>();
        }
    }
```

Also for the sake of time saving we used AutoMapper which maps the domain objects (the objects that we use inside oru application) to our contracts. It just simply copies the values of the properties from one object to another. You can read more about it on https://automapper.org/
In order for the automapper to work we need to specify the mapping profiles for each of the object. We do that in bootstrap as well, under the `AutoMapper` directory.

![image](https://user-images.githubusercontent.com/54746064/208298090-82f3f3ca-f12a-4199-b11a-761cc021d2fc.png)

In the AutoMapperSetup we just register the object mapping profiles.
```Csharp
    public static class AutoMapperSetup
    {
        public static void SetupAutoMapper(this IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InventoryMapProfile());
                cfg.AddProfile(new ShopMapProfile());
                cfg.AddProfile(new ArenaGridMapProfile());
                cfg.AddProfile(new PlayerMapProfile());
                cfg.AddProfile(new PerkStorageProfile());
            });
            serviceCollection.AddSingleton(config.CreateMapper());
        }
    }
```
In the profile itself we specify how the object and the contract should be mapped. As of example we have `IPlayer` interface which is used in the solution domain and `GetPlayerInfoResponse` contract and we want to create a map for it. We simply inherit the Profile class and we define in the constructor how the mapping should be done. By default Automapper automatically maps properties if their name match, but if they don't we have to specify it explicitly. As can be seen down below we are mapping from `Name` in the domain object to `PlayerName` in the contract object. You will see the usage of this in the controllers later on in the documentation.

```Csharp
    public class PlayerMapProfile : Profile
    {
        public PlayerMapProfile()
        {
            CreateMap<IPlayer, AddNewPlayerResponse>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Name));
            CreateMap<IPlayer, GetPlayerInfoResponse>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Name));
        }
    }
```




