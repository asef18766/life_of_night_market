using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

public class PlayerOperator : MonoBehaviour
{

    public PlayMakerFSM targetFSM;

    // Start is called before the first frame update
    public void CheckLand()
    {
        targetFSM.SendEvent("CheckLand");
    }

    public void CardFinish()
    {
        targetFSM.SendEvent("CardFinish");
    }


    public void CheckLandAll()
    {
        targetFSM.SendEvent("CheckLandAll");
    }


}
