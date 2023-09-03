using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    float xAxis;
    float yAxis;

    Vector3 moveVec = Vector3.zero;

    public float moveSpeed = 10.0f;
    public float turnSpeed = 3.0f;

    Vector3 offset = Vector3.zero;
    Animator animator;

    bool attack = false;
    float timeoffset = 0.0f;
    float attack_timer = 0.5f;


    public GameObject bulletPrefab;
    public GameObject GM;

    public game_main GM_Script;

    bool is_live = true;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GM_Script = GM.GetComponent<game_main>();

       // Cursor.lockState = CursorLockMode.Locked;

        // Cursor visible

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        offset = Vector3.zero;

       

        if (is_live)
        {
            horizontal = Input.GetAxis("Mouse X");
            transform.Rotate((horizontal * turnSpeed) * Vector3.up);


            if (Input.GetKey(KeyCode.D)) offset += transform.right * Time.deltaTime * moveSpeed;
            if (Input.GetKey(KeyCode.A)) offset -= transform.right * Time.deltaTime * moveSpeed;
            if (Input.GetKey(KeyCode.W)) offset += transform.forward * Time.deltaTime * moveSpeed;
            if (Input.GetKey(KeyCode.S)) offset -= transform.forward * Time.deltaTime * moveSpeed;

            if (Input.GetKey(KeyCode.F1))
            {
                if(turnSpeed > 2)
                {
                    turnSpeed--;
                }         
                
            }
            if (Input.GetKey(KeyCode.F2)) turnSpeed++;

            transform.position += offset;

            if (Input.GetKey(KeyCode.Space) && !attack)
            {
                attack = true;
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.Translate(0f, 1f, 0f);
                GameObject.Destroy(bullet, 5.0f);
                print("ATTACK");

            }

            if (attack)
            {
                timeoffset += Time.deltaTime;
                if (timeoffset >= attack_timer)
                {
                    attack = false;
                    timeoffset = 0.0f;
                    print("ATTACK FALSE");
                }
            }

            animator.SetBool("is_attack", attack);
            animator.SetBool("is_run", offset != Vector3.zero);
            
        }
        else
        {
            transform.position = Vector3.zero;
            animator.SetBool("is_attack", false);
            animator.SetBool("is_run", false);
            animator.SetBool("game_over", true);
            
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("Lobby");
            }
        }

        if (transform.position.y < -10.0f)
        {
            GM_Script.gameover();
        }
    }

    private void FixedUpdate()
    {
        is_live = GM_Script.get_life();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ANEMI")
        {
            GM_Script.gameover();
        }
    }
}
