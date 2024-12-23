using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Bullet : MonoBehaviour
{
    public GameObject HitSpark;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            return;
        }

        Instantiate(HitSpark, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
