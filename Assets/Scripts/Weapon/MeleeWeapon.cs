public class MeleeWeapon : WeaponBase
{

	protected override void Attack()
	{
		target.TakeDamage(unitStats.Damage);
	}
}
