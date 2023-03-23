using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesUI : MonoBehaviour, IModule
{
	private const string DAMAGE_TEXT = "DMG: ";
	private const string ATTACK_TEXT = "AT: ";
	private const string FORMAT = "0.#";
	[SerializeField] private Button damageButton;
	[SerializeField] private TMP_Text damageText;
	[SerializeField] private Button timeAttackButton;
	[SerializeField] private TMP_Text timeAttackText;

	[SerializeField] private Upgrades upgrades;
	[SerializeField] private Economics economics;

	public void Init()
	{
		economics.UpdateCurrency += UpdateUI;
		UpdateUI();
		damageButton.onClick.AddListener(upgrades.IncreaseDamage);
		damageButton.onClick.AddListener(() => UpdateUI());
		timeAttackButton.onClick.AddListener(upgrades.DecreaseTimeBetweenAttack);
		timeAttackButton.onClick.AddListener(() => UpdateUI());
	}

	private void UpdateUI(int currency = 0)
	{
		damageButton.interactable = upgrades.CanBuyDamage();
		damageText.text = DAMAGE_TEXT + upgrades.GetPriceDamage();

		// damageText.text = DAMAGE_TEXT + $"{upgrades.GetCurrentDamage().ToString(FORMAT)} -> {upgrades.GetNextDamage().ToString(FORMAT)}";
		timeAttackButton.interactable = upgrades.CanBuyDamage();
		// timeAttackText.text = ATTACK_TEXT + $"{upgrades.GetCurrentTimeAttack().ToString(FORMAT)} -> {upgrades.GetNextTimeAttack().ToString(FORMAT)}";
		timeAttackText.text = ATTACK_TEXT + upgrades.GetPriceTimeAttack();
	}

}
