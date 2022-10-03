import Level from "../features/player/enums/Levels";

export type AddNewPlayerRequest = {
  playerName: string;
  level: Level
};
