using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour {

    public enum Mode
    {
        Normal,
        MoveTowards,
        Lerp,
        Slerp
    };

    [SerializeField]
    private Mode mode;
    private CharacterController PCon;
    private Vector3 velocity;
    private Vector3 oldVelocity;
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 5.0f;

	// Use this for initialization
	void Start () {
        PCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (PCon.isGrounded)
        {
            velocity = Vector3.zero;
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if(mode == Mode.MoveTowards)
            {
                velocity = Vector3.MoveTowards(oldVelocity, velocity, moveSpeed * Time.deltaTime);
            }else if(mode == Mode.Lerp)
            {
                velocity = Vector3.Lerp(oldVelocity, velocity, moveSpeed * Time.deltaTime);
            }else if(mode == Mode.Slerp)
            {
                Vector3.Slerp(oldVelocity, velocity, moveSpeed * Time.deltaTime);
            }
            oldVelocity = velocity;

            if(velocity.magnitude > 0f)
            {
                animator.SetFloat("Speed", velocity.magnitude);
                transform.LookAt(transform.position + velocity);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        PCon.Move(velocity * Time.deltaTime);
	}
}
