public class UnitAttackState : State
{

	public UnitAttackState(Unit unit) : base(unit)
	{
	}

	public override void StartState()
	{
	}

	public override void UpdateState()
	{
		if (unit.AttackTarget == null)
		{
			unit.CheckTarget();
			return;
		}
		unit.WeaponOwner.TryAttack(unit.AttackTarget);
	}

	public override void EndState()
	{
	}

}
