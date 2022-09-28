import TileType from '../enums/TileType';
import PlaceholderSource from '../assets/placeholder.png';
import RocketsSource from '../assets/rockets.png';
import ShieldSource from '../assets/shield.png';
import BlankSource from '../assets/blank.png';

class TileImage {
	static sourceMap = new Map<TileType, string>([
		[TileType.Placeholder, PlaceholderSource],
		[TileType.Rockets, RocketsSource],
		[TileType.Shield, ShieldSource],
		[TileType.Blank, BlankSource],
	]);
}

export default TileImage;
