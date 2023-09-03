using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anemi_bullet : MonoBehaviour
{

    public float speedforce = 10.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = transform.forward * speedforce;
        rb.velocity = force;
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag != gameObject.tag)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
