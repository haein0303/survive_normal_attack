using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{


    public float speedforce = 10.0f;
    Rigidbody rb;

   
    Vector3 offset;
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 force = transform.forward * speedforce;
        rb.velocity = force;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "ANEMI")
        //{
        //    GameObject.Destroy(other.gameObject);
        //}

        if (other.gameObject.tag != gameObject.tag)
        {
            if (other.gameObject.tag != "Player")
            {
                GameObject.Destroy(gameObject);
            }
        }




    }
}
