using UnityEngine;

public class Upgrades : MonoBehaviour
{
	[SerializeField] private PlayerStatsData playerStatsData;
	[SerializeField] private UpgradesData upgradesData;
	[SerializeField] private Economics economics;
	private PlayerStats playerStats;

	public void Init(PlayerStats playerStats)
	{
		this.playerStats = playerStats;
	}
	public void IncreaseDamage()
	{
		int price = GetPriceDamage();
		economics.Decrease(price);
		playerStats.IncreaseDamage(playerStatsData.StepValuesStats.Damage);
	}

	public void DecreaseTimeBetweenAttack()
	{
		int price = GetPriceTimeAttack();
		economics.Decrease(price);
		playerStats.DecreaseTimeBetweenAttack(playerStatsData.StepValuesStats.TimeBetweenAttack);
	}

	public int GetPriceDamage()
	{
		int price = upgradesData.StartPriceDamage + playerStats.DamageLevel * upgradesData.AddPriceDamagePerLevel;
		return price;
	}

	public int GetPriceTimeAttack()
	{
		int price = upgradesData.StartPriceAttackTime + playerStats.TimeAttackLevel * upgradesData.AddPriceTimePerLevel;
		return price;
	}

	public bool CanBuyDamage()
	{
		return economics.CanBuy(GetPriceDamage());
	}

	public bool CanBuyTimeAttack()
	{
		return economics.CanBuy(GetPriceTimeAttack());
	}

	public float GetCurrentDamage()
	{
		return playerStats.Damage;
	}

	public float GetNextDamage()
	{
		return playerStats.Damage + playerStatsData.StepValuesStats.Damage;
	}

	public float GetCurrentTimeAttack()
	{
		return playerStats.TimeBetweenAttack;
	}

	public float GetNextTimeAttack()
	{
		return playerStats.TimeBetweenAttack - playerStatsData.StepValuesStats.TimeBetweenAttack;
	}



}

