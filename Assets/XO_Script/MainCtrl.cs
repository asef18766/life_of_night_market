using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtrl : MonoBehaviour
{
    
    //XO_script Scriptt = FindObjectOfType<XO_script>();
   public XO_Player[] GamePlayers = new XO_Player[] { new XO_Player("AA"), new XO_Player("BB"), new XO_Player("CC"), new XO_Player("DD") };
 
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public  void RoundEnd() {
        
        float[] sss = getPlayerTotalEarn();
        for (int i = 0; i < sss.Length; i++)
        {
            GamePlayers[i].XO_money += sss[i];
            //Debug.Log("sss"+sss[i]);
            Debug.Log(GamePlayers[i].XO_name+"money:"+ GamePlayers[i].XO_money);
        }
    }

    public float[] getPlayerTotalEarn()
    {
        float[] money = new float[4];
        Land_[] _land = FindObjectsOfType<Land_>();
        for (int u = 0; u != 4; ++u)
            money[u] = 0.0f;
        for (int u = 0; u != _land.Length; ++u)
        {
            DeltaMoney_[] land_ret = _land[u].gain_profit();
            for (int i = 0; i != land_ret.Length; ++i)
                money[land_ret[i].owner_id - 1] += land_ret[i].amount;
        }
        return money;
    }
}
