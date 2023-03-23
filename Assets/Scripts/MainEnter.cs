using System.Linq;
using UnityEngine;

public class MainEnter : MonoBehaviour
{
	[SerializeField] private GameObject[] moduleGOs;

	private void Awake()
	{
		var modules = moduleGOs.Select(x => x.GetComponent<IModule>());
		foreach (var item in modules)
		{
			item?.Init();
		}
	}
}
