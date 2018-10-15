using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    [SerializeField]
    private Transform player;
    private float distance = 8.0f;
    private Quaternion vRotation;
    public Quaternion hRotation;

	// Use this for initialization
	void Start () {
        vRotation = Quaternion.Euler(60,0,0);
        hRotation = Quaternion.identity;
        transform.rotation = hRotation * vRotation;

        transform.position = player.position - transform.rotation * Vector3.forward * distance;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }
}
