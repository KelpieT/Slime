using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
	public enum AttackStatus
	{
		Success,
		EmptyCage,
		Reload
	}

	protected UnitStats unitStats;
	private float lastAttackTime;
	protected Unit target;

	public void Init(UnitStats unitStats)
	{
		this.unitStats = unitStats;
	}

	public AttackStatus TryAttack(Unit target)
	{
		this.target = target;
		bool readyToAttack = Time.time - lastAttackTime >= unitStats.TimeBetweenAttack;
		if (readyToAttack)
		{
			Attack();
			ResetAttackTime();
			return AttackStatus.Success;
		}
		else
		{
			return AttackStatus.Reload;
		}
	}

	protected abstract void Attack();

	private void ResetAttackTime()
	{
		lastAttackTime = Time.time;
	}
}
