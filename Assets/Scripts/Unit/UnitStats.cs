using UnityEngine;

public class UnitStats
{
	[SerializeField] protected float maxHealth;
	[SerializeField] protected float damage;
	[SerializeField] protected float timeBetweenAttack = 1f;
	[SerializeField] private float speedMove;

	public UnitStats() { }

	public UnitStats(LevelData.RoomData roomData)
	{
		maxHealth = roomData.EnemyMaxHealth;
		damage = roomData.EnemyDamage;
		timeBetweenAttack = roomData.EnemyTimeBetweenAttack;
		speedMove = roomData.EnemySpeedMove;
	}

	public UnitStats(float maxHealth, float damage, float timeBetweenAttack, float speedMove)
	{
		this.maxHealth = maxHealth;
		this.damage = damage;
		this.timeBetweenAttack = timeBetweenAttack;
		this.speedMove = speedMove;
	}

	public float MaxHealth { get => maxHealth; }
	public float Damage { get => damage; }
	public float TimeBetweenAttack { get => timeBetweenAttack; }
	public float SpeedMove { get => speedMove; }
}
