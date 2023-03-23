using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageTextHandler : MonoBehaviour
{
	[SerializeField] private List<DamageText> damageTextPool;
	[SerializeField] private RectTransform canvas;
	[SerializeField] private Camera cam;
	[SerializeField] private DamageText damageTextPrefab;

	public void SetDamageText(float damage, Unit target)
	{
		var damageText = damageTextPool.FirstOrDefault(x => (x != null)
			&& (!x.gameObject.activeInHierarchy));
		if (damageText == null)
		{
			damageText = Instantiate(this.damageTextPrefab, canvas.transform);
		}
		damageText.Init(damage, ScreenPos(target.transform.position));
	}
	private Vector2 ScreenPos(Vector3 worldPosition)
	{
		return cam.WorldToScreenPoint(worldPosition);
	}
}


