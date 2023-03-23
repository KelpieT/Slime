using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
	[SerializeField] private TMP_Text text;
    
	public void Init(Economics economics)
	{
		economics.UpdateCurrency += UpdateUI;
	}

	private void UpdateUI(int currency)
	{
		text.text = currency.ToString();
	}

}
