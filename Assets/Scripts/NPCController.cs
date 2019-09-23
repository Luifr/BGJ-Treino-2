using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
	public Vector2 move;
	Rigidbody2D body;

	[SerializeField]
	GameObject orderPrefab;

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
			StartCoroutine(MoveToOrder());
		}

	}

	void FixedUpdate()
	{
		body.velocity = move * runSpeed;
	}

	IEnumerator MoveToOrder()
	{
		yield return new WaitForSeconds(move.y > 0 ? (1.2f + stopIndex * 0.5f) : (1.8f - stopIndex * 0.5f));
		move = new Vector2(-1, 0);
		yield return new WaitForSeconds(1f);
		MakeOrder();
		move = new Vector2(0, 0);
	}

	void MakeOrder()
	{
		GameObject order = Instantiate(orderPrefab, new Vector2(-0, 0), Quaternion.identity);
		order.transform.parent = transform;
		order.transform.localPosition = new Vector2(-1f, 1f);
	}

}
