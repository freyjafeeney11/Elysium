using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	Rigidbody2D rb;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	public float KBForce;
	public LayerMask Ground;
	public Transform groundCheckCollider;
	public float KBFcounter;
	public float KBFTotalTime;
	public bool isGrounded = true;

	const float groundCheckRadius = 0.2f;
    const float overheadCheckRadius = 0.2f;
    const float wallCheckRadius = 0.2f;

	public bool KnockFromRight;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("isjumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
		//set y vleocity in thea nimator
		Debug.Log("trying to jump");
		animator.SetFloat("yVelocity", rb.velocity.y);
		Debug.Log("set it");
	}

	public void OnLanding ()
	{
		animator.SetBool("isjumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void GroundCheck() {
		isGrounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, Ground);
		if(colliders.Length > 0){
			isGrounded = true;
		}

		animator.SetBool("isjumping", !isGrounded);
	}

	void FixedUpdate ()
	{
		if(KBFcounter <= 0) {
			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		}
		else {
			if(KnockFromRight == true) {
				controller.Move(-KBForce, crouch, jump);
				Debug.Log("moving");
				Debug.Log("done moving");
			}
			if(KnockFromRight == false) {
				controller.Move(KBForce, crouch, jump);
			}
			KBFcounter -= Time.deltaTime;
		}
		// Move our character
		jump = false;
	}
}