using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class game_main : MonoBehaviour
{

    bool gameplay = true;

    public GameObject MonsterN;
    public GameObject MonsterL;
    public GameObject MonsterS;
    public Vector3[] point;
    public Vector3[] Long_Point;

    public float normal_spone_timer = 5.0f;
    public float long_spone_timer = 5.0f;
    public float Special_spone_timer = 7.0f;
    float timer_n = 0;
    float timer_l = 0;
    float timer_s = 0;
    float time_score = 0;

    public Text text;
    public Text text2;

    public void gameover()
    {
        for(int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        
        gameplay = false;
    }

    
    public bool get_life()
    {
        return gameplay;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameplay)
        {
            timer_n += Time.deltaTime;
            timer_l += Time.deltaTime;
            timer_s += Time.deltaTime;


            if ( timer_n > normal_spone_timer)
            {
                int now = Random.Range(0, point.Length);
                GameObject spawn = Instantiate(MonsterN, point[now], Quaternion.identity,gameObject.transform);
                if (normal_spone_timer > 1.5f)
                {
                    normal_spone_timer -= 0.05f;
                }
                
                timer_n = 0;
            }

            if(timer_l > long_spone_timer)
            {
                int now = Random.Range(0, Long_Point.Length);
                GameObject spawn = Instantiate(MonsterL, Long_Point[now], Quaternion.identity, gameObject.transform);
                if (long_spone_timer > 2.0f)
                {
                    long_spone_timer -= 0.03f;
                }
                timer_l = 0;
            }

            if(timer_s > Special_spone_timer)
            {
                int now = Random.Range(0, point.Length);
                GameObject spawn = Instantiate(MonsterS, point[now], Quaternion.identity, gameObject.transform);
                if (Special_spone_timer > 1.5f)
                {
                    Special_spone_timer -= 0.05f;
                }

                timer_s = 0;
            }
            time_score += Time.deltaTime;
            text.text = "SCORE : " + time_score;
        }
        else
        {
            text2.text = "SCORE : " + time_score;
            int now = Random.Range(0, point.Length);

        }
        
    }
}
