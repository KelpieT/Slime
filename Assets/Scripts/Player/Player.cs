using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
	[SerializeField] private PlayerStatsData playerStatsData;
	private PlayerStats playerStats;
	private Level level;

	public Level Level => level;

	public PlayerStats PlayerStats { get => playerStats;  }

	public void Init()
	{
		playerStats = playerStatsData.StartStats;
		base.Init(playerStats);
	}

	protected override void InitStateMachine()
	{
		Dictionary<StateMachine.StateEnum, State> states = new Dictionary<StateMachine.StateEnum, State>();

		states.Add(StateMachine.StateEnum.Move, new UnitMoveState(this));
		states.Add(StateMachine.StateEnum.Attack, new UnitAttackState(this));
		states.Add(StateMachine.StateEnum.Idle, new PlayerIdleState(this));
		states.Add(StateMachine.StateEnum.Dead, new UnitDeadState(this));

		stateMachine = new StateMachine(states);
	}

	public void SetLevel(Level level)
	{
		this.level = level;
	}
}
