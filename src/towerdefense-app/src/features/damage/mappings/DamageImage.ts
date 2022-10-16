import DamageType from '../../../models/DamageType';
import FireSource from '../assets/Fire_Small.png';
import FireBigSource from '../assets/Fire_Big.png';
import ProjectileSource from '../assets/Projectile_Small.png';
import ProjectileBigSource from '../assets/Projectile_Big.png';

class DamageImage {
	static sourceMap = new Map<DamageImage, string>([
		['Fire_Small', FireSource],
		['Fire_Big', FireBigSource],
		['Projectile_Small', ProjectileSource],
		['Projectile_Big', ProjectileBigSource]
	]);
}

export default DamageImage;