using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exphit : MonoBehaviour {

    RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 10))
        {
            
        }
    }
}
