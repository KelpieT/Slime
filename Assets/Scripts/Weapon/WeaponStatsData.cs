using UnityEngine;

[CreateAssetMenu(menuName = "GameData/WeaponStatsData")]
public class WeaponStatsData : ScriptableObject
{
	[SerializeField] private UnitStats unitStats;

	public UnitStats UnitStats { get => unitStats; }
}