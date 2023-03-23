using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room
{
	private const float SPAWN_RADIUS = 1f;
	private readonly Vector3 CENTER_SPAWN = new Vector3(6f, 0, 0);
	public event Action<Room> OnRoomClear;
	private List<Unit> enemies;
	private LevelData.RoomData roomData;
	private Vector3 playerPosition;
	private List<Vector3> enemyPositios;
	private Vector3 roomPosition;

	public IEnumerable<Unit> Enemies => enemies;
	public Vector3 PlayerPosition => playerPosition;
	public int RoomIndex { get; set; }

	public void Init(Vector3 roomPosition, LevelData.RoomData roomData)
	{
		this.roomData = roomData;
		this.roomPosition = roomPosition;
		playerPosition = roomPosition;
		int enemyCount = roomData.EnemiesCount;
		enemyPositios = CalculateEnemyPositions(enemyCount);
		enemies = InstantiateEnemies(enemyCount, enemyPositios);

	}

	private List<Vector3> CalculateEnemyPositions(int enemyCount)
	{
		List<Vector3> enemyPositios = new List<Vector3>(enemyCount);
		float angle = ConstParams.MATH_FULL_CIRCLE_DEG / enemyCount;
		for (int i = 0; i < enemyCount; i++)
		{
			Vector3 add = Quaternion.Euler(0, angle * i, 0) * Vector3.forward * SPAWN_RADIUS;
			Vector3 pos = roomPosition + CENTER_SPAWN + add;
			enemyPositios.Add(pos);
		}
		return enemyPositios;
	}

	private List<Unit> InstantiateEnemies(int enemyCount, List<Vector3> enemyPositios)
	{
		List<Unit> enemies = new List<Unit>(enemyCount);
		for (int i = 0; i < enemyCount; i++)
		{
			Unit enemy = GameObject.Instantiate<Unit>(roomData.EnemyPrefab, enemyPositios[i], Quaternion.identity);
			enemy.Init(new UnitStats(roomData));
			enemy.OnDead += RemoveEnemy;
			enemy.OnDead += CheckRoomClear;
			enemies.Add(enemy);
		}
		return enemies;
	}
	private void RemoveEnemy(Unit enemy)
	{
		enemy.OnDead -= RemoveEnemy;
		enemies.Remove(enemy);
	}
	private void CheckRoomClear(Unit enemy = null)
	{
		if (enemy != null)
		{
			enemy.OnDead -= CheckRoomClear;

		}
		if (enemies.Count == 0 || !enemies.Any(x => x != null))
		{
			OnRoomClear?.Invoke(this);
		}
	}

	public Unit GetNearestEnemy(Vector3 position)
	{
		var sortedByDistance = enemies.Where(x => x != null)
			.OrderBy(x => Vector3.Distance(x.transform.position, position));
		return sortedByDistance.FirstOrDefault();
	}
}
