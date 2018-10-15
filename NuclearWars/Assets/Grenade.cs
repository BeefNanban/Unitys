using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public GameObject ExplodePrefab;
    RaycastHit hit;
    public LayerMask levelMask;
    private bool explodedp = false;

    // Use this for initialization
    void Start()
    {
        Invoke("ExplodeP", 3f);
    }

    private void ExplodeP()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10))
        {
            if (hit.collider.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
        Destroy(gameObject, 0.3f);
    }

    private IEnumerator CreateExplordeP(Vector3 direction)
    {
        for (int i = 1; i < 3; i++)
        {
            RaycastHit hit;
            Physics.Raycast
            (
                transform.position + new Vector3(0, 0.5f, 0),
                direction,
                out hit,
                i,
                levelMask
            );

            if (!hit.collider)
            {
                Instantiate
                (
                    ExplodePrefab,
                    transform.position + (i * direction),
                    ExplodePrefab.transform.rotation
                );
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 2000));
    }
}
