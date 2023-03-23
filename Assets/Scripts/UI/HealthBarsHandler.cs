using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBarsHandler : MonoBehaviour
{
	[SerializeField] private List<HealthBar> healthBarsPool;
	[SerializeField] private RectTransform canvas;
	[SerializeField] private Camera cam;
	[SerializeField] private HealthBar healthBarPrefab;

	public void SetNewHPBar(IHealth health, Transform target)
	{
		var healthBar = healthBarsPool.FirstOrDefault(x => (x != null)
			&& (!x.gameObject.activeInHierarchy));
		if (healthBar == null)
		{
			healthBar = Instantiate<HealthBar>(healthBarPrefab, canvas.transform);
		}
		healthBar.Init(health, target, this);
	}
	public Vector2 ScreenPos(Vector3 worldPosition)
	{
		return cam.WorldToScreenPoint(worldPosition);
	}
}
