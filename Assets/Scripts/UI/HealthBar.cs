using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	private const float HEIGHT_HP_BAR = 1.3f;
	[SerializeField] private Slider slider;
	[SerializeField] private RectTransform rectTransform;
	private HealthBarsHandler healthBarsHandler;
	private IHealth health;
	private Transform target;
	private bool wasInited;

	public void Init(IHealth health, Transform target, HealthBarsHandler healthBarsHandler)
	{
		this.health = health;
		this.target = target;
		this.healthBarsHandler = healthBarsHandler;
		SetSliderValue();
		wasInited = true;
	}

	private void SetSliderValue()
	{
		slider.value = health.Health / health.MaxHealth;
	}

	private void LateUpdate()
	{
		if (target != null)
		{
			rectTransform.position = healthBarsHandler.ScreenPos(target.position + new Vector3(0, HEIGHT_HP_BAR, 0));
			SetSliderValue();
		}
		else if (wasInited)
		{
			Destroy(gameObject);
		}
	}
}
