using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class I_Event_
{
    public float pro=0.0f;
    public string event_msg="";
    public abstract void act(CardSystem cs,Land_[] lands);
}
