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

### Controllers

Controllers directory is used for storing all of the REST controllers of the API. You can see the controller diagram down below.

![image](https://user-images.githubusercontent.com/54746064/208298430-31f46134-dcb7-498b-89b5-5d0f83aa69e9.png)

Controllers are responsible as mentioned for REST communication. In simple terms they get the contract, pass it to a certain handler, then get a domain object back and map it to (using AutoMapper as defined previously) the contract and return a response. That is the main responsibility for it.

We can take a look at inventory controller
```Csharp
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryHandler _inventoryHandler;
        private readonly IMapper _mapper;
        public InventoryController(IInventoryHandler inventoryHandler, IMapper mapper)
        {
            _inventoryHandler = inventoryHandler;
            _mapper = mapper;
        }

        [HttpGet("{playerName}")]
        public ActionResult<GetInventoryItemsResponse> GetItems(string playerName)
        {
            var inventory = _inventoryHandler.GetPlayerInventory(playerName);

            var getInventoryItemsResponse = _mapper.Map<GetInventoryItemsResponse>(inventory);

            return Ok(getInventoryItemsResponse);
        }
    }
```
We can see that this controller can be accessed by `api/inventory` path and it has only one http method which is GET. Also you will need to supply the playerName for it. So in order to call it you will need to use GET request and point it to `api/inventory/playerName`.
As we can see it just calls one of his dependencies (injected using Dependency Injection) `IInventoryHandler` which does all of the logic and returns domain object inventory. We mentioned earlier that we do not want to expose our inner objects to the outside so using `Automapper` we map it back to the contract and return it in the response.

### Hubs

Hubs is a directory for yet another communication logic. This directory is used to store hubs that are required for SignalR realtime communication.
There are two classes that define how SignalR communication works in this game skeleton.

![image](https://user-images.githubusercontent.com/54746064/208298757-f405a373-251c-423d-9d81-5a316a2f3f8f.png)

```Csharp
    public class GameHub : Hub
    {
        private readonly IInitialGameSetupHandler _initialGameSetup;

        public GameHub(IInitialGameSetupHandler initialGameSetup)
        {
            _initialGameSetup = initialGameSetup;
        }
        
        public async Task JoinGame(string playerName)
        {       
            _initialGameSetup.SetConnectionIdForPlayer(playerName, Context.ConnectionId);
            await _initialGameSetup.TryStartGame();
        }
    }
```
`GameHub` class is responsible for incoming messages. So it has the endpoint for `JoinGame` and waits for this message. As soon as it gets it it executes what is written in the method body. 
If you want to add more realtime functionality just add another method here with required parameters and it will listed to that endpoint on SignalR.

`NotificationHub` class is responsible for outgoing messages. We are using it to send messages to the frontend.

```Csharp
    public class NotificationHub : INotificationHub
    {
        private readonly IHubContext<GameHub> _gameHubContext;
        private readonly IPlayerHandler _playerHandler;
        public NotificationHub(IHubContext<GameHub> gameHubContext, IPlayerHandler playerHandler)
        {
            _playerHandler = playerHandler;
            _gameHubContext = gameHubContext;
        }

        public async Task NotifyGameStart(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            await _gameHubContext.Clients.Client(firstPlayer.ConnectionId).SendAsync("EnemyInfo", secondPlayer);
            await _gameHubContext.Clients.Client(secondPlayer.ConnectionId).SendAsync("EnemyInfo", firstPlayer);
        }
```
We can see that we have a method `NotifyGameStart` which is used to tell frontend that the game is going to start. We just call `_gameHubContext` to send that info to our players frontend. If you want to add more functionality - just add another method and call `_gameHubContext` with your unique method identifier name. In this example we can see that the identifier is `EnemyInfo`. You will need to note these identifiers so you can accept the messages in the front end ❗

### GameLogic

![image](https://user-images.githubusercontent.com/54746064/208299017-19e71372-90d5-462e-93d3-64e71cc4f60b.png)

Game logic is the main place where all of the domain logic is happening. We are not going to go through each class but we are going to specify a few that are the most important.

Game logic is based on the state of the game. There is a static class `GameOriginator` which holds static property `State`

```Csharp
    public class State
    {
        public IPlayer[] Players { get; } = new IPlayer[Constants.TowerDefense.MaxNumberOfPlayers];
        public Dictionary<string, bool> PlayersFinishedTurn { get; } = new();
        public int ActivePlayers => Players.Count(player => player != null);
        public List<(string PlayerName, IPerk Perk)> PerksUsedOnPlayer { get; set; } = new();
    }
```
This state is being preserved throughout the whole time the players are playing a match. It holds information about the player, the arena grid, what perks are used and etc. This is a central point of data storage.

For most of the logic on how the battle is happening the `BattleHandler` class is responsible for it.

![image](https://user-images.githubusercontent.com/54746064/208299161-3093c417-c60f-40f8-a58c-efb07bfe4d77.png)

`HandleEndTurn` method is responsible for handling how the game plays out after players have ended their turns. It calculates how the game tiles are being affected, whether they attacked and how many health does the player have after the turn.

### Notes on backend

Be aware that no security measures were implemented for the backend. So if you are playing against an enemy and he decides to do something in your name - he is able to send requests with your playername to the backend and they will get executed!


## FrontEnd

Front end is written in React TypeScript and Redux for state management. Redux is just a simple way to store your state in a global store. For more info you can read about Redux in https://redux.js.org/

### Graphics

Everything in the project is made up of a 64px x 64px rectangle which is called 'tile'. All of the images (and more!) used in the game are in the `/assets` directory. So what would you need to do to add another type of tile into the game. First of all you would need to add another value to `TileType.ts` enum
```ts
enum TileType {
  Rockets,
  Shield,
  Placeholder,
  Blank,
  Machinegun,
  Plane,
  Soldier,
  Bomb,
  Rock,
  Atomicbomb,
  Hiddingatomicbomb,
  Loadingatomicbomb,
  Attackingatomicbomb
}

export default TileType;
```

Then you would need to go to the backend and find `ItemTytpe.cs` enum and update it as well
```csharp
namespace TowerDefense.Api.GameLogic.Items
{
    public enum ItemType
    {
        Rockets,
        Shield,
        Placeholder,
        Blank,
        Plane,
    }
}
```
Now the backend can communicate with the frontend about new game tile. But we need to add graphics to it. In order to do that we would go to `TileImage.ts` which simply holds a map between enum value and an image path.

```ts
class TileImage {
	static sourceMap = new Map<TileType, string>([
		[TileType.Placeholder, PlaceholderSource],
		[TileType.Rockets, RocketsSource],
		[TileType.Shield, ShieldSource],
		[TileType.Blank, BlankSource],
		[TileType.Machinegun, MachinegunSource],
		[TileType.Plane, PlaneSource],
		[TileType.Soldier, SoldierSource],
		[TileType.Bomb, BombSource],
		[TileType.Rock, RockSource],
		[TileType.Atomicbomb, Atomicbomb],
		[TileType.Hiddingatomicbomb, Hiddingatomicbomb],
		[TileType.Loadingatomicbomb, Loadingatomicbomb],
		[TileType.Attackingatomicbomb, Attackingatomicbomb],
	]);
}

export default TileImage;
```

You would simply add another map and you will be good to go.

### State

As mentioned before Redux is being used to manage the state of the react application. Which includes storing player names, arena grid, money, shop and etc, throughout the whole time the game is played. The state store is configured in `/src/app/store.ts` file.

```ts
const persistConfig = {
	key: 'root',
	storage,
};

const persistedReducer = persistReducer(persistConfig, playerReducer);

export const store = configureStore({
	reducer: {
		player: persistedReducer,
		enemy: enemyReducer,
		shop: shopReducer,
		inventory: inventoryReducer,
		grid: gridReducer,
		perkStorage: perkStorageReducer
	},
	devTools: process.env.NODE_ENV !== 'production',
});

export const persistor = persistStore(store);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
```

As you can see the store is made up of reducers, so if you would want to insert another component that required the state - be sure to add an additional reducer.
Let's take a look on how the shop reducer is done. Down below part of the code from file `ShopSlice.ts` is specified.

```ts
const shopSlice = createSlice({
	name: 'shop',
	initialState,
	reducers: {
		setShopToInitial(state, action: PayloadAction) {
			state.selectedItem = initialState.selectedItem;
			state.shopItems = initialState.shopItems;
		},
		setSelectedItem(state, action: PayloadAction<string>) {
			state.selectedItem = action.payload;
		},
		setShopItems(state, action: PayloadAction<ShopItem[]>) {
			state.shopItems = action.payload;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(getShopItems.fulfilled, (state, action: PayloadAction<ShopItem[]>) => {
			state.shopItems = action.payload;
		});
		builder.addCase(getShopItems.rejected, () => {
			console.error('Failed to get shop from api!');
		});
	},
});

export const { setSelectedItem, setShopItems, setShopToInitial } = shopSlice.actions;
export default shopSlice.reducer;
```
We explicitly define what actions can be called on the shop. In this case `setSelectedItem`, `setShopItems` and `setShopToInitial`. They specify how you can interact with the redux state.

### Features

We will start off with the available routes in the front end. In the main `App.tsx` file you can see all of the defined routes in the game

```ts
const App: React.FC = () => {
	useEffect(() => {
		document.title = 'Tower Defense';
	}, []);

	return (
		<BrowserRouter>
			<Routes>
				<Route index element={<Home />} />
				<Route path='game-arena' element={<GameArena/>} />
				<Route path='game-finished' element={<EndGame/>} />
			</Routes>
		</BrowserRouter>
	);
};
```

We can see that `/game-arena` route gives us `GameArena` component and `/game-finished` route provides us the `EndGame` component.

Every component is inside its feature which means that
everything in the project is split up to features.
![image](https://user-images.githubusercontent.com/54746064/208299650-c9b6609c-0102-48aa-a060-ec5d3b15254b.png)

Features contains everything starting from the logic, including css and finally even the assets (image files).

Components such as `Home` and `EndGame` is for literally displayed the start game and end game screen. The root component for everything else is `GameArena` ❗

### Communication

As hinted in the previous sections we use REST and SignalR to communicate. We introduced how it is being done from the back end perspective. Now let's take a look on how it is done from the front-end side.

#### REST communication

In order for the REST communication to work we need to have frontend and backend contracts alligned. In the frontend we store contracts in `/src/contracts` directory.

![image](https://user-images.githubusercontent.com/54746064/208300395-3f61f0b6-e960-4f96-9ea2-3f777ce0f833.png)

They should contain the same properties (or less) as in the backend defined contracts.
To do a request we usually use `axios` package. Let's take a look at `ShopSlice.ts` again.

```ts
export const getShopItems = createAsyncThunk<ShopItem[]>('shop/getShop', async () => {
	const reduxStore = store.getState();
	const response = await axios.get(`${API_URL}/shop/${reduxStore.player.name}`);
	return response.data.items;
});
```
We use `createAsyncThunk` method to create a reducer (It helps to specify how we interact with the state). And inside of it we use `axios` to send a `GET` request, using an already specified player name from the store.

#### SignalR communication

In our case we use SignalR to specify only the parts of the game which need to be realtime. For example to start the game.

Looking into the file `GameArena.tsx` we can see that SignalR is used there. 

```ts
const SIGNALR_URL = `${process.env.REACT_APP_BACKEND}/gameHub`;

		if (connection) {
			connection
				.start()
				.then(() => {
					console.log('Connected!');
					connection.invoke('JoinGame', player.name);

					connection.on('EnemyInfo', (message) => {
						dispatch(setEnemyName(message.name));
						dispatch(getEnemyGridItems());
					});
   }
```
We can see that whenever we get the `EnemyInfo` method identifier, from the `/gameHub` SignalR endpoint we do some operations. In this case we dispatch `setEnemyName` and `getEnemyGridItems` reducers. So they could do the specified operations to the state. So if you want to add another listening method for SignalR, just add another `connection.on()` method. 

To send info to the backend using SingalR you can use `connection.invoke()` method. In our case we send player name to `JoinGame` endpoint. 
(Take a look at the BackEnd Hubs section to see where it gets captured if you feel confused).



