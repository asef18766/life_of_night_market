using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land_ : MonoBehaviour
{
    List<House_> data;
    const float cost_rate=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public float get_risk()
    {
        float ret=0.0f;
        for(int u=0;u!=data.Count;++u)
        {
            ret+=data[u].risk;
        }
        return ret;
    }
    public void add_house(House_ house)
    {
        data.Add(house);
    }
    public float explode()
    {
        float ret;
        for(int u=0;u!=data.Count;++u)
            ret+=(data[u].price*cost_rate);
        clear_house();
        return ret;
    }
    public DeltaMoney_[] gain_profit()
    {
        DeltaMoney_[] ret=new DeltaMoney_(data.Count);
        for(int u=0;u!=data.Count;++u)
        {
            ret[u].owner_id=data[u].owner_id;
            ret[u].amount;
        }
        return ret;
    }
    void clear_house()
    {
        data.Clear();
    }
}
