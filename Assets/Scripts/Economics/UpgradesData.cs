using UnityEngine;

[CreateAssetMenu(menuName = "GameData/UpgradesData")]
public class UpgradesData : ScriptableObject 
{
	[SerializeField] private int startPriceDamage;
	[SerializeField] private int startPriceAttackTime;
	[SerializeField] private int addPriceDamagePerLevel;
	[SerializeField] private int addPriceTimePerLevel;

	public int StartPriceDamage { get => startPriceDamage;  }
	public int StartPriceAttackTime { get => startPriceAttackTime;  }
	public int AddPriceDamagePerLevel { get => addPriceDamagePerLevel;  }
	public int AddPriceTimePerLevel { get => addPriceTimePerLevel;  }
}