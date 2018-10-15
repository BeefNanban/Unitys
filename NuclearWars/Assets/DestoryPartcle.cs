using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class DestoryPartcle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

        Destroy(gameObject, (float)particleSystem.main.duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
