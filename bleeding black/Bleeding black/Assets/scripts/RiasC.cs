using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
  public class RiasC : MonoBehaviour
    {
   
        //variables de control
       public int[] vcontrol = new int[2] {2, 3};
       public int dinero;
       public bool cdm;
       public bool Cdv;


        //variales de movimiento
  
        //variables de desplazamiento para congelar constrains
        public bool[] despl = new bool[2] {true, true};
        public float maxspeed = 5f;
        public float speed = 0f;
        public float FDsalto = 0f;
        public bool salto;
        public bool movement = true;
        public bool TKSL;




    }
