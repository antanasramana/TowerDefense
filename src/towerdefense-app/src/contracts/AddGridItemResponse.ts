import { GridItem } from "../models/GridItem";
import { InventoryItem } from "../models/InventoryItem";

export type AddGridItemResponse = {
    inventoryItems: InventoryItem [];
    gridItems: GridItem[]
};
  