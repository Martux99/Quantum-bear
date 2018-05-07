using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public GameObject cube;
    public Transform player;
    public Transform Kodak;
    public Rigidbody2D rbd2;
    public Vector3 hector;
    public Vector3 whereto;

    public bool grounded = false;
    public bool direccion = true;
    public bool notouch=true;
    public bool pelon = true;
    public bool gas = true;
    public float tiempoinicio;
    public float tiempo;
    public int cuenta;

	void FixedUpdate ()
    {
        //Vector3 cannon = new Vector3(0, player.position.y+3.7f, -10);
        if (player.position.y > Kodak.position.y+2)
        {
            Kodak.Translate(Vector3.up* Time.deltaTime * 5);
        }
        if (player.position.y < Kodak.position.y-3.7f)
        {
            Kodak.Translate(Vector3.down * Time.deltaTime * 8.5f);
        }
        cuenta = Input.touchCount;
        if (cuenta > 0)
        {
            if (gas == true)
            {
                tiempoinicio = -Time.time;
                gas = false;
            }
            tiempo = Time.time + tiempoinicio;
            if (tiempo < 10)
            {
                player.Translate(Vector3.up * Time.deltaTime * 5);
            }
            Touch touch = (Input.GetTouch(0));
            if (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10)).x < 0)
            {
                direccion = false;
            }
            if (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10)).x > 0)
            {
                direccion = true;
            }
            if (pelon == true)
            {
                hector= Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
                pelon = false;
            }
            whereto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
            if (whereto.x > hector.x + 1)
            {
                whereto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
                direccion = true;
                pelon = true;
            }
            if (whereto.x < hector.x - 1)
            {
                whereto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                direccion = false;
                pelon = true;
            }
            notouch = false;
            if (direccion==false && (cube.transform.position.x > new Vector3(-2.4f,0,0).x && cuenta<2))
            {
                Debug.Log("izquierda");
                player.Translate(Vector3.left * Time.deltaTime * 3f);
            }
            else if (direccion==true && (cube.transform.position.x < new Vector3(2.4f, 0, 0).x && cuenta<2))
            {
                Debug.Log("derecha");
                player.Translate(Vector3.right * Time.deltaTime * 3f);
            }

            
        }
        if (cuenta==0  && grounded==false)
            {
                player.Translate(Vector3.down * Time.deltaTime * 9);
                notouch = true;
            }
        if (cuenta == 0 && grounded == true)
        {
            gas = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
