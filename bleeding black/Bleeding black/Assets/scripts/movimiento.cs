using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private GameObject playerG;
    public RiasC player; 
    
    // Start is called before the first frame update
    void Start()
    {
        playerG = GameObject.Find("player");
        RB2D = GetComponentInParent<Rigidbody2D>();
        player = playerG.GetComponentInParent<RiasC>();
    }

    // Update is called once per frame
    void Update()
    {

        float hinput = Input.GetAxis("Horizontal");
        if(!player.movement){
            hinput = 0;
        }

        RB2D.AddForce(Vector2.right * player.speed * hinput);
        if(hinput > 0.1f){
            transform.localScale = new Vector3 (5.5f, 5.5f, 1f);
        }

        if(hinput < -0.1f){
            transform.localScale = new Vector3 (5.5f, 5.5f, 1f);
        }

          if (Input.GetKey(KeyCode.A))
        {
            player.despl = true;
        }

        else
        {
            player.despl = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.despl2 = true;
        }

        else
        {
            player.despl2 = false;
        }

        //para evitar congelamiento en el aire y para evitar friccion 

        if(player.TKSL == false)
        {
            if (player.despl2 == false)
            {
                if (player.despl == true)
                {
                    RB2D.constraints = RigidbodyConstraints2D.None;
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                    RB2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }

            if (player.despl == false)
            {
                if (player.despl2 == true)
                {
                    RB2D.constraints = RigidbodyConstraints2D.None;
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                    RB2D.constraints = RigidbodyConstraints2D.FreezePositionX;
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }

        }

        else
        {
            //para la tecla A
            if (player.despl == false)
            {
                if (player.despl2 == true)
                {
                    RB2D.constraints = RigidbodyConstraints2D.None;
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    RB2D.constraints = RigidbodyConstraints2D.FreezeAll;
                    RB2D.constraints = RigidbodyConstraints2D.None;
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }

            }
            if (player.despl == true)
            {

                RB2D.constraints = RigidbodyConstraints2D.None;
                RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
            // para la tecla D
            if (player.despl2 == false)
            {
                if (player.despl == true)
                {
                    RB2D.constraints = RigidbodyConstraints2D.None;
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    RB2D.constraints = RigidbodyConstraints2D.FreezeAll;
                    RB2D.constraints = RigidbodyConstraints2D.None;
                    RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                }

            }


        }

        if (player.despl2 == true)
        {

            RB2D.constraints = RigidbodyConstraints2D.None;
            RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    

    }

 
    void FixedUpdate()
    {

        if (player.salto)
        {
            RB2D.AddForce(Vector2.up * player.FDsalto, ForceMode2D.Impulse);
            player.salto = false;
        }
       
    }
}

 
