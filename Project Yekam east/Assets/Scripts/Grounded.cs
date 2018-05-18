using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {
        
    public Animator Y_Animation;
    PlayerMovement jugador;
    private void Start()
    {
        jugador = GetComponentInParent<PlayerMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
            jugador.grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
            jugador.grounded = false;
        }
    }


}
