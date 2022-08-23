using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;


    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
	private Vector3 v_velocity;
    private float moveSpeed;
    private float gravity;


	private void Start()
	{

        characterController = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();

        moveSpeed = 6f;
        gravity = 0.5f;
		
	}
	// Update is called once per frame
	void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W))
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);

        inputZ = Input.GetAxis("Vertical");
    }
	private void FixedUpdate()
	{
        if(characterController.isGrounded)
		{
            v_velocity.y = 0f;
		}
		else
		{
            v_velocity.y -= gravity * Time.deltaTime;
		}

        v_movement = characterController.transform.forward * inputZ;

        characterController.transform.Rotate(Vector3.up * inputX * (250f * Time.deltaTime));

        characterController.Move(v_movement * moveSpeed * Time.deltaTime);
        characterController.Move(v_velocity);
	}
}
