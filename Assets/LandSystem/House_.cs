using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class House_ : MonoBehaviour
{
    public float risk;
    public float price;
    public int owner_id;
    public int type_id;
    static string[] str;
    public int HouseTypeAmount=6;
    static float[] t_price;
    static float[] t_risk;
    // Start is called before the first frame update
    void Start()
    {
        /*
        危險x3
            大屌燒    ID 1   　價1500    危0.45
            鹽水雞    ID 2    　價1700    危0.45
            臭豆腐    ID 3    　價800    危0.5
        平衡x1
            彈珠檯    ID 4    　價1600    危0.3
        安全x2
            冬瓜茶    ID 5    　價2000    危0.2
            霜淇淋    ID 6    　價1800    危0.2
         */
        str=new string[HouseTypeAmount];
        str[0]="大屌燒";
        str[1]="鹽水雞";
        str[2]="臭豆腐";
        str[3]="彈珠檯";
        str[4]="冬瓜茶";
        str[5]="霜淇淋";

        t_price=new float[HouseTypeAmount];
        t_price[0]=1500;
        t_price[1]=1700;
        t_price[2]=800;
        t_price[3]=1600;
        t_price[4]=2000;
        t_price[5]=1800;

        t_risk=new float[HouseTypeAmount];
        t_risk[0]=0.45f;
        t_risk[1]=0.45f;
        t_risk[2]=0.5f;
        t_risk[3]=0.3f;
        t_risk[4]=0.2f;
        t_risk[5]=0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(type_id>=1&&type_id<=HouseTypeAmount)
        {
            risk=t_risk[type_id-1];
            price=t_price[type_id-1];
        }
    }
    public string getHousePhisicalName(int type)
    {
        if(type>=1&&type<=HouseTypeAmount)
            return str[type-1];
        return "";
    }
    public float get_spirite_height()
    {
        Vector3 center= GetComponent<SpriteRenderer>().sprite.bounds.center,
                pivot =  GetComponent<SpriteRenderer>().sprite.bounds.min;
        return (center-pivot).y;
    }
}
