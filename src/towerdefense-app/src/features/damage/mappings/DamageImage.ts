import DamageType from '../../../models/DamageType';
import FireSource from '../assets/Fire.png';
import ProjectileSource from '../assets/Projectile.png';

class DamageImage {
	static sourceMap = new Map<DamageImage, string>([
		[DamageType.Fire, FireSource],
		[DamageType.Projectile, ProjectileSource]
	]);
}

export default DamageImage;