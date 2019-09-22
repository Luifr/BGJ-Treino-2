using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnerController : MonoBehaviour
{

	Spawner[] spawners;

	[SerializeField]
	float timeToSpawn = 0.4f;
	float time = 0;
	int[] npcsAtSpot = { 0, 0, 0 };
	int maxNpcsPerSpot = 2;
	int npcsWaiting = 0;

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
		time += Time.deltaTime;
		if (time >= timeToSpawn)
		{
			time -= timeToSpawn;
			spawners[Random.Range(0, spawners.Length)].Spawn();
		}
	}

	void InitialiseNpc(GameObject gameObject, Direction direction)
	{
		NPCBehaviour npc = gameObject.GetComponent<NPCBehaviour>();
		if (npcsWaiting < npcsAtSpot.Length * maxNpcsPerSpot)
		{
			npc.makeOrder = Random.value > 0.0;
			if (npc.makeOrder)
			{
				bool spotFound = false;
				int index;
				do
				{
					index = Random.Range(0, 3);
					if (npcsAtSpot[index] < maxNpcsPerSpot)
					{
						spotFound = true;
						npc.stopIndex = index;
						npcsAtSpot[index]++;
					}
				} while (!spotFound);
				npcsWaiting++;
			}
		}
		if (direction == Direction.up)
			npc.move = new Vector2(0, 1);
		else if (direction == Direction.down)
			npc.move = new Vector2(0, -1);
		else if (direction == Direction.left)
			npc.move = new Vector2(-1, 0);
		else if (direction == Direction.right)
			npc.move = new Vector2(1, 0);
	}

}
