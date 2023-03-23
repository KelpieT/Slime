using System.Collections;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
	private const string DAMAGE_TEXT_FORMAT = "#";
	[SerializeField] private float radiusSpawn = 1.5f;
	[SerializeField] private float angleSpawn = 90f;
	[SerializeField] private float lifeTime = 1f;
	[SerializeField] private RectTransform rectTransform;
	[SerializeField] private TMP_Text text;
	private bool wasInited;

	public void Init(float damage, Vector2 screenPosition)
	{
		Vector2 offset =  Quaternion.Euler(0, 0, Random.Range(-angleSpawn, angleSpawn))* Vector3.up * radiusSpawn;
		rectTransform.position = screenPosition + offset;
		text.text = damage.ToString(DAMAGE_TEXT_FORMAT);
		StartCoroutine(Fade());
	}

	public IEnumerator Fade()
	{
		yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
	}


}
