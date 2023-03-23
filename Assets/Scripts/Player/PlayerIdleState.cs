public class PlayerIdleState : State
{
	private Player player;

	public PlayerIdleState(Unit unit) : base(unit)
	{
		if (unit is Player player)
		{
			this.player = player;
		}
	}

	public override void StartState()
	{
		if (unit.AttackTarget != null)
		{
			unit.Attack();
			return;
		}
	}

	public override void UpdateState()
	{
		if (unit.AttackTarget == null)
		{
			Unit target = FindNewTarget();
			if (target != null)
			{
				unit.SetAttackTarget(target);
			}
		}
		else
		{
			unit.Attack();
		}
	}

	public override void EndState()
	{

	}

	private Unit FindNewTarget()
	{
        var v = player.Level.CurrentRoom.GetNearestEnemy(player.transform.position);
		return player.Level.CurrentRoom.GetNearestEnemy(player.transform.position);
	}

}
