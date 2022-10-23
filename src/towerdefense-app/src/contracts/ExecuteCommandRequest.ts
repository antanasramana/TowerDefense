import CommandType from '../models/CommandType';

export type ExecuteCommandRequest = {
    playerName: string;
    inventoryItemId: string;
    gridItemId: number;
    shopItemId: string;
    commandType: CommandType
  };
  