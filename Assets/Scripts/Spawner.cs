using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	GameObject prefab;
	[SerializeField]
	Direction direction;

	public delegate void Initialise(GameObject gameObject);
	public Initialise InstatiateCallBack = null;

	public void Spawn(Vector3 position)
	{
		Instantiate(prefab, position, Quaternion.identity);
	}

	public void Spawn()
	{
		GameObject gameObject = Instantiate(prefab, transform.position, Quaternion.identity);
		if (InstatiateCallBack != null)
		{
			InstatiateCallBack(gameObject);
		}
	}


	public enum Direction
	{
		up,
		left,
		down,
		right
	}
}
