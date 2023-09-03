using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class anemi : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider boxCollider;
    NavMeshAgent nav;

    public GameObject target;

    float look_distance = 10f;

    void Awake()
    {
        target = GameObject.Find("Player_obj");
        //gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<SphereCollider>(); 
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.transform.position);
        transform.LookAt(target.transform.position);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "P_bullet")
        {
            GameObject.Destroy(gameObject);
        }
    }


}
