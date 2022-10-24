import TileType from '../features/tile/enums/TileType';

export type GridItem = {
  id: number;
  itemType: TileType;
  level: number
  health: number
  damage: number
  powerUps: string[]
};
