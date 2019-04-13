using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_ : MonoBehaviour
{
    public float risk;
    public float price;
    public int owner_id;
    public int type_id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float get_spirite_height()
    {
        Vector3 center= GetComponent<SpriteRenderer>().sprite.bounds.center,
                pivot =  GetComponent<SpriteRenderer>().sprite.bounds.min;
        return (center-pivot).y;
    }
}
