using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update () {

		if(gameObject.tag == "J1") 
		{
			if(Input.GetKey(KeyCode.LeftArrow)) horizontalMove = -runSpeed;
			else if(Input.GetKey(KeyCode.RightArrow)) horizontalMove = runSpeed;
			else horizontalMove = 0;
		}
		else if(gameObject.tag == "J2") 
		{
			if(Input.GetKey(KeyCode.Q)) horizontalMove = -runSpeed;
			else if(Input.GetKey(KeyCode.D)) horizontalMove = runSpeed;
			else horizontalMove = 0;
		}
		else if(gameObject.tag == "J3") 
		{
			if(Input.GetKey(KeyCode.H)) horizontalMove = -runSpeed;
			else if(Input.GetKey(KeyCode.K)) horizontalMove = runSpeed;
			else horizontalMove = 0;
		}


		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.tag == "J1" || Input.GetKeyDown(KeyCode.Z) && gameObject.tag == "J2" || Input.GetKeyDown(KeyCode.U) && gameObject.tag == "J3")
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		/*if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}*/

	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
