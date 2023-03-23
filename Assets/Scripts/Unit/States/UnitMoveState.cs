using UnityEngine;

public class UnitMoveState : State
{
	private const float OFFSET_CHECK_POSITION = 0.05f;
	private Vector3 position;

	public UnitMoveState(Unit unit) : base(unit)
	{
	}

	public override void StartState()
	{
		position = unit.EndPositionMove;
	}

	public override void UpdateState()
	{
		position = unit.EndPositionMove;
		Move();
		if (CheckPosition())
		{
			unit.ReachDestination();
		}
	}

	public override void EndState()
	{

	}

	private void Move()
	{

		Vector3 direction = position - unit.transform.position;
		Vector3 moveStep = direction.normalized * unit.UnitStats.SpeedMove * Time.deltaTime;
		Vector3 add = moveStep;
		if (direction.magnitude < moveStep.magnitude)
		{
			add = direction;
		}
		unit.transform.position += add;
	}

	private bool CheckPosition()
	{
		bool onPosition = Vector3.Distance(unit.transform.position, position) < OFFSET_CHECK_POSITION;
		return onPosition;
	}

}
