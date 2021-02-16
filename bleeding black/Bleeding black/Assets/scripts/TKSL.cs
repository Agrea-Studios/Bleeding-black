using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TKSL : MonoBehaviour
{

    public RiasC player;
    public GameObject playerobj;

    // Start is called before the first frame update
    void Start()
    {
        playerobj = GameObject.Find("Player");
        player = playerobj.GetComponentInParent<RiasC>();
    }

     void OnCollisionEnter2D(Collision2D ColP)
    {
        if (ColP.gameObject.tag == "Piso")
        {
            player.TKSL = true;
        }
    }
    void OnCollisionExit2D(Collision2D ColP)
    {
        if (ColP.gameObject.tag == "Piso")
        {
            player.TKSL = false;
        }
    }

}
