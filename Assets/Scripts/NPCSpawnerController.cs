using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnerController : MonoBehaviour
{

	Spawner[] spawners;

	// Start is called before the first frame update
	void Start()
	{
		spawners = transform.GetComponentsInChildren<Spawner>();
		foreach (Spawner spawner in spawners)
		{
			spawner.InstatiateCallBack = InitialiseNpc;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	void InitialiseNpc(GameObject gameObject)
	{

	}

}
