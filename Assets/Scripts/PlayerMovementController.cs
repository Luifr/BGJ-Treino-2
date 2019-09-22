using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	Rigidbody2D body;
	SpriteRenderer spriteRenderer;
	Animator animator;
	float horizontal;
	float vertical;
	float moveLimiter = 0.7f;

	[SerializeField]
	float runSpeed = 10.0f;

	bool dash = false;
	float dashCooldown = 0.8f;
	float dashtimer = 0;

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		runSpeed = 10.0f;
		dashtimer -= Time.deltaTime;

		// Gives a value between -1 and 1
		horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
		vertical = Input.GetAxisRaw("Vertical"); // -1 is down

		// Dash
		if (Input.GetKeyDown(KeyCode.Space) && dashtimer <= 0)
		{
			dash = true;
			dashtimer = dashCooldown;
		}

		animator.SetBool("isMoving", horizontal != 0 || vertical != 0);

		if (horizontal == -1)
			spriteRenderer.flipX = true;
		else if (horizontal == 1)
			spriteRenderer.flipX = false;

	}

	void FixedUpdate()
	{
		Vector2 move = new Vector2(horizontal, vertical);
		move.Normalize();
		Vector2 velocity = move * runSpeed;
		if (dash)
		{
			dash = false;
			velocity *= 7;
		}
		body.velocity = velocity;
	}
}
