using System;
using Cinemachine;
using UnityEngine;

public class Level : MonoBehaviour, IModule
{
	private const float PLAYER_RADIUS = 1.2f;
	private const float DISTANCE_ROOMS = 15f;
	public event Action<Level> OnLevelComplite;
	[SerializeField] private Player playerPrefab;
	[SerializeField] private Transform spawnPoint;
	[SerializeField] private LevelData levelData;
	[SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
	[SerializeField] private CinemachineTargetGroup targetGroup;
	[SerializeField] private HealthBarsHandler healthBarsHandler;
	[SerializeField] private DamageTextHandler damageTextHandler;
	[SerializeField] private Economics economics;
	[SerializeField] private Upgrades upgrades;
	private Player player;
	private Room currentRoom;

	public Player Player => player;
	public Room CurrentRoom => currentRoom;

	public void Init()
	{
		player = InstantiatePlayer();
		player.Init();
		player.SetLevel(this);
		upgrades.Init(player.PlayerStats);
		healthBarsHandler.SetNewHPBar(player, player.transform);
		player.OnTakeDamage += damageTextHandler.SetDamageText;
		targetGroup.AddMember(player.transform, 1, 1);
		cinemachineVirtualCamera.Follow = player.transform;
		InitRoom(0);
		OnLevelComplite += economics.LevelComplite;

	}

	private void InitRoom(int roomIndex)
	{
		LevelData.RoomData roomData = levelData.GetRoomData(roomIndex);

		Room room = new Room();
		room.RoomIndex = roomIndex;
		currentRoom = room;
		room.Init(new Vector3(DISTANCE_ROOMS * roomIndex, 0, 0), roomData);
		room.OnRoomClear += RoomClear;

		player.SetAttackTarget(room.GetNearestEnemy(player.transform.position));
		player.SetMovePosition(room.PlayerPosition);
		player.Move();
		player.OnMoveDone += StartRoom;
	}

	private void StartRoom(Unit unit)
	{
		player.OnMoveDone -= StartRoom;
		var room = currentRoom;
		var roomEnemies = room.Enemies;
		foreach (var item in roomEnemies)
		{
			item.SetAttackTarget(player);
			Vector3 dif = item.transform.position - room.PlayerPosition;
			item.SetMovePosition(room.PlayerPosition + dif.normalized * PLAYER_RADIUS);
			item.Move();
			targetGroup.AddMember(item.transform, 1, 1);
			healthBarsHandler.SetNewHPBar(item, item.transform);
			item.OnTakeDamage += damageTextHandler.SetDamageText;
			item.OnDead += economics.EnemyDead;

		}
	}

	private void RoomClear(Room room)
	{
		room.OnRoomClear -= RoomClear;
		if (room.RoomIndex == levelData.LastRoomIndex)
		{
			OnLevelComplite?.Invoke(this);
		}
		else
		{
			InitRoom(room.RoomIndex + 1);
		}
	}

	private Player InstantiatePlayer()
	{
		Player player = Instantiate<Player>(playerPrefab, spawnPoint.position, spawnPoint.rotation);
		return player;
	}
}
