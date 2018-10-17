using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    private CharacterController characterController;
    private Vector3 velocity;
    public GameObject bombPrefab;
    public GameObject grenadePrefab;
    public Global global;
    public int playerNumber = 1;
    public bool dead = false;
    public bool canDropBombs = true;

    [SerializeField]
    private float walkSpeed;
    private Transform myTransform;
    private Animator animator;
    GameObject partclePrefab = null;
    private int bombs = 1;

    // Use this for initialization
    void Start()
    {
        myTransform = transform;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (velocity.magnitude > 0.1f)
            {
                animator.SetFloat("Speed", velocity.magnitude);
                transform.LookAt(transform.position + velocity);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
            if (canDropBombs && Input.GetKeyDown("z"))
            { 
                SetBomb();
            }
            if (canDropBombs && Input.GetButtonDown("Grenade"))
            {
                ThrowBomb();
            }
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * walkSpeed * Time.deltaTime);
    }

    private void SetBomb()
    {
        if (bombPrefab)
        {
            var pos = new Vector3
            (
                Mathf.RoundToInt(myTransform.position.x),
                bombPrefab.transform.position.y,
                Mathf.RoundToInt(myTransform.position.z)
            );

            Instantiate(
                bombPrefab,
                myTransform.position,
                bombPrefab.transform.rotation
            );
        }
    }

    void AutoDestroyInsrantiate()
    {
        Destroy(Instantiate(partclePrefab), partclePrefab.GetComponent<ParticleSystem>().main.duration);
    }

    private void ThrowBomb()
    {
        Instantiate(
            grenadePrefab,
            myTransform.position,
            grenadePrefab.transform.rotation
            );
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            Debug.Log("P" + playerNumber + " hit by explosion!");

            dead = true;

            Destroy(gameObject);
        }
    }

}
