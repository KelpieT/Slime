using System;

[Serializable]
public class PlayerStats : UnitStats
{
	private int damageLevel;
	private int timeAttackLevel;

	public int DamageLevel { get => damageLevel; }
	public int TimeAttackLevel { get => timeAttackLevel; }

	public void IncreaseDamage(float add)
	{
		damage += add;
		damageLevel++;
	}

	public void DecreaseTimeBetweenAttack(float subtract)
	{
		timeBetweenAttack -= subtract;
		if (timeBetweenAttack < 0)
		{
			timeBetweenAttack = 0;
		}
		timeAttackLevel++;
	}
}
