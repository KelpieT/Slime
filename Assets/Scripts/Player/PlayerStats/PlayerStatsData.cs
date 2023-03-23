using UnityEngine;

[CreateAssetMenu(menuName = "GameData/PlayerStatsData")]
public class PlayerStatsData : ScriptableObject
{
	[SerializeField] private PlayerStats startStats;
	[SerializeField] private PlayerStats stepValuesStats;

	public PlayerStats StartStats { get => startStats; }
	public PlayerStats StepValuesStats { get => stepValuesStats; }
}