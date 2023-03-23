using UnityEngine;

[CreateAssetMenu(menuName = "GameData/EconomicsReward")]
public class EconomicsReward : ScriptableObject
{
	[SerializeField] private int enemyKillReward;
	[SerializeField] private int levelCompliteReward;

	public int EnemyKillReward { get => enemyKillReward; }
	public int LevelCompliteReward { get => levelCompliteReward; }
}