import { AttackResult } from '../models/AttackResult';
import { GridItem } from '../models/GridItem';

export type EndTurnResponse = {
    gridItems: GridItem[],
    playerAttackResults: AttackResult[],
    enemyAttackResults: AttackResult[]

};