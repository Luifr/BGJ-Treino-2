using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
	public Vector2 move;
	Rigidbody2D body;

	[SerializeField]
	float runSpeed = 5.0f;
	public bool makeOrder;
	public int stopIndex;
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		if (!makeOrder)
		{
			Destroy(gameObject, 4f);
		}
		else
		{
			StartCoroutine(MakeOrder());
		}

	}

	void FixedUpdate()
	{
		body.velocity = move * runSpeed;
	}

	IEnumerator MakeOrder()
	{
		yield return new WaitForSeconds(move.y > 0 ? (1.2f + stopIndex * 0.5f) : (1.8f - stopIndex * 0.5f));
		move = new Vector2(-1, 0);
	}
}
