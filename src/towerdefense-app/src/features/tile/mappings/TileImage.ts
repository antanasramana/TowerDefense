import TileType from '../enums/TileType';
import PlaceholderSource from '../assets/placeholder.png';
import RocketsSource from '../assets/rockets.png';
import ShieldSource from '../assets/shield.png';
import BlankSource from '../assets/blank.png';
import MachinegunSource from '../assets/machinegun.png';
import PlaneSource from '../assets/plane.png';
import SoldierSource from '../assets/soldier.png';
import BombSource from '../assets/bomb.png';
import RockSource from '../assets/rock.png';
import Atomicbomb from '../assets/atomicbomb.png';
import Hiddingatomicbomb from '../assets/hiddingatomicbomb.png';
import Loadingatomicbomb from '../assets/loadingatomicbomb.png';
import Attackingatomicbomb from '../assets/attackingatomicbomb.png';

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
