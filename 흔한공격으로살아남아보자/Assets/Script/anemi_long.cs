using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anemi_long : MonoBehaviour
{
    public GameObject target;
    public GameObject bulletPrefab;

    float shoot_time = 3.0f;
    float timer = 0;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Player_obj");
        //gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position);

        timer += Time.deltaTime;
        if (shoot_time < timer)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.Translate(0f, 1f, 0f);
            GameObject.Destroy(bullet, 5.0f);

            timer = 0;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "P_bullet")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
