using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject GM;
    game_main GM_SC;
    // Start is called before the first frame update
    void Start()
    {
       // gameObject.SetActive(false);
        GM_SC = GM.GetComponent<game_main>();   
    }

    // Update is called once per frame
    void Update()
    {
        bool life = GM_SC.get_life();
        if (!life)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(false);
        }
        
    }
}
