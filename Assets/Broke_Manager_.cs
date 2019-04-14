using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Broke_Manager_ : MonoBehaviour
{
    PlayerData player_data;
    public GameObject[] sprites=new GameObject[4];
    
    // Start is called before the first frame update
    void Start()
    {
        player_data=FindObjectOfType<PlayerData>();
    }
    // Update is called once per frame
    void Update()
    {
        sprites[0].GetComponent<Image>().enabled=(player_data.money_P1<=0);
        sprites[1].GetComponent<Image>().enabled=(player_data.money_P2<=0);
        sprites[2].GetComponent<Image>().enabled=(player_data.money_P3<=0);
        sprites[3].GetComponent<Image>().enabled=(player_data.money_P4<=0);
    }
}
