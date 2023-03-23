public class UnitIdleState : State
{
	public UnitIdleState(Unit unit) : base(unit)
	{
	}

	public override void StartState()
	{
		if (unit.AttackTarget != null)
		{
			unit.Attack();
			return;
		}
	}

	public override void EndState()
	{
	}

	public override void UpdateState()
	{
		if (unit.AttackTarget != null)
		{
			unit.Attack();
			return;
		}
	}
}
