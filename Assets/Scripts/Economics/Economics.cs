using System;
using UnityEngine;

public class Economics : MonoBehaviour, IModule
{
	public event Action<int> UpdateCurrency;
	[SerializeField] private EconomicsReward reward;
	[SerializeField] private CurrencyUI currencyUI;
	private int currency;

	public int Currency
	{
		get => currency; set
		{
			currency = value;
			UpdateCurrency?.Invoke(currency);
			if (currency < 0)
			{
				Debug.LogWarning("Wrong math!!!");
			}
		}
	}

	public void Init()
	{
		currencyUI.Init(this);
	}

	public void EnemyDead(Unit unit)
	{
		Currency += reward.EnemyKillReward;
	}

	public void LevelComplite(Level level)
	{
		Currency += reward.LevelCompliteReward;
	}

	public void Decrease(int subtract)
	{
		currency -= subtract;
		UpdateCurrency?.Invoke(currency);
	}

	public bool CanBuy(int price)
	{
		return currency >= price;
	}

}
