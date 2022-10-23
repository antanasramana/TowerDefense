import DamageType from './DamageType';

export type Damage = {
    intensity: number
    size: number;
    time: number;
    damageType: DamageType
};
  