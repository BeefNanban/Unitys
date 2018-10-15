using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject ExplodePrefab;
    RaycastHit hit;
    public LayerMask levelMask;
    private bool exploded = false;

    // Use this for initialization
    void Start() {
        Invoke("Explode", 3f);
    }

    // Update is called once per frame
    private void Explode()
    {
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);

        GetComponent<MeshRenderer>().enabled = false;
        exploded = true;

        StartCoroutine(CreateExplorde(Vector3.forward)); // 上に広げる
        StartCoroutine(CreateExplorde(Vector3.right)); // 右に広げる
        StartCoroutine(CreateExplorde(Vector3.back)); // 下に広げる
        StartCoroutine(CreateExplorde(Vector3.left)); // 左に広げる

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10))
        {
           if( hit.collider.tag == "Player")
            {
                Destroy(gameObject);
            }
        }

        Destroy(gameObject, 0.3f);
    }
    
    private IEnumerator CreateExplorde(Vector3 direction)
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

    public void OnTriggerEnter(Collider other)
    {
        if(!exploded && other.CompareTag("Explosion"))
        {
            CancelInvoke("Explode");

            Explode();
        }
    }
}

