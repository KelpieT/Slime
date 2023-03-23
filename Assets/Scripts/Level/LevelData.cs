using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/LevelData")]
public class LevelData : ScriptableObject
{
	[SerializeField] private List<RoomData> roomDatas;

	public int LastRoomIndex => roomDatas.Count - 1;

	public RoomData GetRoomData(int index)
	{
		return roomDatas[index];
	}

	[System.Serializable]
	public class RoomData
	{
		[SerializeField] private int enemiesCount;
		[SerializeField] private Unit enemyPrefab;
		[SerializeField] private float enemyDamage;
		[SerializeField] private float enemyTimeBetweenAttack = 1f;
		[SerializeField] private float enemySpeedMove;
		[SerializeField] private float enemyMaxHealth;

		public int EnemiesCount { get => enemiesCount; }
		public Unit EnemyPrefab { get => enemyPrefab; }
		public float EnemyDamage { get => enemyDamage; }
		public float EnemyTimeBetweenAttack { get => enemyTimeBetweenAttack; }
		public float EnemySpeedMove { get => enemySpeedMove; }
		public float EnemyMaxHealth { get => enemyMaxHealth; }
	}
}
