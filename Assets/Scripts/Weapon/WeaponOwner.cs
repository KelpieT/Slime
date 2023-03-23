using System;
using UnityEngine;

public class WeaponOwner : MonoBehaviour
{
	private const int MaxDistanceRay = 100;
	private const int DistancePlane = 40;

	public event Action OnEmptyCage;

	[SerializeField] private WeaponBase currentWeapon;


	public void Init(UnitStats unitStats = null)
	{
		currentWeapon.Init(unitStats);
	}

	public void TryAttack(Unit target)
	{
		if (currentWeapon == null)
		{
			Debug.Log("weapon null");
			return;
		}
		Vector3 endPos = target.transform.position;
		WeaponBase.AttackStatus status = currentWeapon.TryAttack(target);
		switch (status)
		{
			case WeaponBase.AttackStatus.EmptyCage:
				OnEmptyCage?.Invoke();
				break;
		}

	}

}
