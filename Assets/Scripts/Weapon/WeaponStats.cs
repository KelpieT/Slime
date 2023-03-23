using System;
using UnityEngine;

[Serializable]
public class WeaponStats
{
	[SerializeField] protected float damage;
	[SerializeField] protected float timeBetweenAttack = 1f;
	public float Damage => damage;
	public float TimeBetweenAttack => timeBetweenAttack;
}