using UnityEngine;

public class MyTools
{
	public static Vector2 ScreenPos(Vector3 worldPosition, Camera cam, RectTransform canvas)
	{
		
		return cam.WorldToScreenPoint(worldPosition); 
	}
}
