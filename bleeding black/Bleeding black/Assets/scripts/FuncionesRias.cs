using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionesRias : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private RiasC playerC;
    void Start()
    {
        player = GameObject.Find("Player");
        playerC = player.GetComponentInParent<RiasC>();
    }

    // Update is called once per frame
    void Update()
    {
      MuerteDelJugador();
    }

    public void MuerteDelJugador(){

        playerC.cdm = (playerC.vcontrol[0] <= 0) ? true : false;
        if(playerC.cdm == true)
        {
            Destroy(player);
        }

    }

    public void OnCollisionEnter2D(Collision2D colision){

        if(colision.gameObject.tag == "Corazon"){

            playerC.Cdv = (playerC.vcontrol[0] == playerC.vcontrol[1]) ? false : true;
            if(playerC.Cdv == true)
            {
                playerC.vcontrol[0] =+ 1;
            }

        }

    }

}
