using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptPrueba : MonoBehaviour
{
	private float ViewPos;
	private float Speed;
	private bool Moving;
	private Vector2 InputMovement;
	private Rigidbody Rb;

	void Start()
    {
		Speed = 5f;
		ViewPos = 0f;

		Moving = false;

		Rb = GetComponent<Rigidbody>();
	}

	public void OnMovement(InputAction.CallbackContext context)
	{
		InputMovement = context.ReadValue<Vector2>();

		Moving = true;
	}

	void Update()
    {
		if (InputMovement == new Vector2(0, 0))
		{
			Moving = false;
		}

		if (Moving == true)
		{
			ViewPos = Mathf.Atan2(InputMovement.x, InputMovement.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, ViewPos, 0f);
		}
	}

	void FixedUpdate()
	{
		if (Moving == true)
		{
			Rb.velocity = new Vector3(InputMovement.x * Speed, 0, InputMovement.y * Speed);
		}
		else
		{
			Rb.velocity = new Vector3(0, 0, 0);
		}
	}
}
