using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land_ : MonoBehaviour
{
    public House_ house;
    public List<House_> data;
    const float cost_rate=3.0f;
    const float profit_rate=0.1f;
    public float tmp_delta_explode_rate=0.0f;
    // Start is called before the first frame update
    Transform tf;
    void Start()
    {
        data=new List<House_>();
        tf=GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if(debug)
        {
            add_house_by_id(1,1);
            debug=false;
        }
        update_house_pos();
    }
    public float get_risk()
    {
        float ret=0.0f;
        for(int u=0;u!=data.Count;++u)
        {
            ret+=data[u].risk;
        }
        return ret+tmp_delta_explode_rate;
    }
    public void add_house(House_ house)
    {
        Instantiate(house,new Vector3(0,0,0),new Quaternion());
        data.Add(house);
    }
    public float explode()
    {
        float ret=0.0f;
        for(int u=0;u!=data.Count;++u)
            ret+=(data[u].price*cost_rate);
        clear_house();
        return ret;
    }
    public DeltaMoney_[] gain_profit()
    {
        DeltaMoney_[] ret=new DeltaMoney_[data.Count];
        for(int u=0;u!=data.Count;++u)
        {
            ret[u].owner_id=data[u].owner_id;
            ret[u].amount=data[u].price*profit_rate;
        }
        return ret;
    }
    void clear_house()
    {
        for(int u=0;u!=data.Count;++u)
            Destroy(data[u]);
        data.Clear();
    }
    bool debug=true;
    void update_house_pos()
    {
        Vector3 local_pos=tf.position;
        for(int u=0;u!=data.Count;++u)
        {
            data[u].transform.position=local_pos+(new Vector3(0.0f,0.5f+data[u].get_spirite_height(),-0.5f+(u+1)/(data.Count)));
        }
    }
    public void add_house_by_id(int type_id,int owner_id)
    {
        House_ h=new House_();
        h.type_id=type_id;
        h.owner_id=owner_id;
        add_house(h);
    }
}
