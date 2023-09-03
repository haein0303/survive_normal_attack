using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class hit_anemi : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider boxCollider;
    NavMeshAgent nav;

    public GameObject target;

    Animator animator;

    public int life_counter = 1;

    float look_distance = 10f;

    bool is_move = true;
    float m_time = 0;

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
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("atk_trigger");
            life_counter--;
            is_move = false;
            if (life_counter <= 0)
            {
                GameObject.Destroy(gameObject);
            }
            
        }
    }

}
