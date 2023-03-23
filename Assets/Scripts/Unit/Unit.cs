using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IHealth
{
	public event Action<Unit> OnDead;
	public event Action<Unit> OnMoveDone;
	public event Action<float, Unit> OnTakeDamage;

	[SerializeField] private WeaponOwner weaponOwner;
	private UnitStats unitStats;
	protected StateMachine stateMachine;
	private State currentState;
	private bool wasInited;
	private float health;
	private float maxHealth;
	private Vector3 endPositionMove;
	private Unit attackTarget;

	public UnitStats UnitStats => unitStats;
	public WeaponOwner WeaponOwner => weaponOwner;
	public float Health => health;
	public float MaxHealth => maxHealth;
	public Vector3 EndPositionMove => endPositionMove;
	public Unit AttackTarget => attackTarget;

	public virtual void Init(UnitStats unitStats)
	{
		this.unitStats = unitStats;
		weaponOwner.Init(unitStats);
		InitStateMachine();
		InitHealth(unitStats.MaxHealth);
		wasInited = true;
	}

	private void InitHealth(float maxHealth)
	{
		this.maxHealth = maxHealth;
		health = maxHealth;
	}


	protected virtual void InitStateMachine()
	{
		Dictionary<StateMachine.StateEnum, State> states = new Dictionary<StateMachine.StateEnum, State>();

		states.Add(StateMachine.StateEnum.Move, new UnitMoveState(this));
		states.Add(StateMachine.StateEnum.Attack, new UnitAttackState(this));
		states.Add(StateMachine.StateEnum.Idle, new UnitIdleState(this));
		states.Add(StateMachine.StateEnum.Dead, new UnitDeadState(this));

		stateMachine = new StateMachine(states);
	}

	public void TakeDamage(float damage)
	{

		Debug.Log($"{health} - {damage}");
		if (health <= 0)
		{
			return;
		}
		health -= damage;
		OnTakeDamage?.Invoke(damage, this);
		if (health <= 0)
		{

			Dead();
		}
	}

	public virtual void Dead()
	{
		OnDead?.Invoke(this);
		Destroy(gameObject);
	}

	protected virtual void ChangeState(StateMachine.Command command)
	{
		currentState?.EndState();
		currentState = stateMachine.GetNextStateByCommand(command);
		currentState?.StartState();
	}

	private void Update()
	{
		if (wasInited == false)
		{
			return;
		}
		currentState?.UpdateState();
	}

	public void ReachDestination()
	{
		OnMoveDone?.Invoke(this);
		ChangeState(StateMachine.Command.Idle);
	}

	public void CheckTarget()
	{
		ChangeState(StateMachine.Command.Idle);
	}

	public void Attack()
	{
		ChangeState(StateMachine.Command.Attack);
	}

	public void SetAttackTarget(Unit attackTarget)
	{
		this.attackTarget = attackTarget;
	}

	public void SetMovePosition(Vector3 position)
	{
		endPositionMove = position;
	}

	public void Move()
	{
		ChangeState(StateMachine.Command.Move);
	}

}
