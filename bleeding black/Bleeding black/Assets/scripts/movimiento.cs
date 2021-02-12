using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private GameObject playerG;
    public RiasC player; 
  
    // Start is called dtbefore the first frame update
    void Start()
    {
        playerG = GameObject.Find("Player");
        RB2D = GetComponentInParent<Rigidbody2D>();
        player = playerG.GetComponentInParent<RiasC>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        
        Animation.SetFloat("speed", Mathf.Abs(RB2D.velocity.x));
        Animation.SetBool("player.TKSL", player.TKSL);

        */
        float hinput = Input.GetAxis("Horizontal");
        if(!player.movement){
            hinput = 0;
        }

                
        if (Input.GetKey(KeyCode.W) && player.TKSL)
        {
            player.salto = true;
        }

        //player.MV[1] = player.speed
        RB2D.AddForce(Vector2.right * player.speed * hinput);
        if(hinput > 0.1f){
            transform.localScale = new Vector3 (-5.5f, 5.5f, 1f);
        }

        if(hinput < -0.1f){
            transform.localScale = new Vector3 (5.5f, 5.5f, 1f);
        }
        

        if(RB2D.velocity.x > player.maxspeed){
            RB2D.velocity = new Vector2(player.maxspeed, RB2D.velocity.y);
        }

        player.despl[0] = (Input.GetKey(KeyCode.A)) ? true : false ;
        player.despl[1] = (Input.GetKey(KeyCode.D)) ? true : false ;


        //para evitar congelamiento en el aire 

        if(player.TKSL == false)
        {
            if (player.despl[1] == false)
            {
                if (player.despl[0] == true)
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

            if (player.despl[0] == false)
            {
                if (player.despl[1] == true)
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
            if (player.despl[0] == false)
            {
                if (player.despl[1] == true)
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
            if (player.despl[0] == true)
            {

                RB2D.constraints = RigidbodyConstraints2D.None;
                RB2D.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
            // para la tecla D
            if (player.despl[1] == false)
            {
                if (player.despl[0] == true)
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

        if (player.despl[1] == true)
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

 
