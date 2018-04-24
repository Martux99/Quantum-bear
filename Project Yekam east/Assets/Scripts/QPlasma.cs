using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QPlasma : MonoBehaviour {
    public bool direction; //La direccion a la que va el plasma
    public float tiempo; //El contandor de tiempo desde que inicio el script
    private float tiempoinicio; //El tiempo que tiene desde que empezo el juego, en negativo
    public GameObject plasmaCuantico; //El objeto plasma cuantico
    public GameObject plasma1; //El objeto real de plasma 1
    public GameObject plasma2; //"" 2
    private Vector3 lugar; //Es el lugar a donde se movera el plasma cuando choca con una plataforma antes de entrar a pantalla
    public Vector3 SpaceDownLeft;
    public Vector3 SpaceUpLeft;
    public Vector3 SpaceUpRight;
    public Vector3 Reaparicion;//El lugar donde aparecera la primer copia
    public Vector3 Reaparicion1;// ""la segunda copia
    void Start()
    {
        tiempoinicio = -Time.time;
        if (plasmaCuantico.transform.position.x > 1)
        {
            direction = false;
        }
        else
        {
            direction = true;
        }
    }
    void Update()
    {
        tiempo = Time.time+tiempoinicio;
        if (direction == true)
        {
            plasmaCuantico.transform.Translate(Vector3.right * Time.deltaTime * 1);
        }
        else
        {
            plasmaCuantico.transform.Translate(Vector3.left * Time.deltaTime * 1);
        }
        if (tiempo > 3)
        {
            Destroy(plasmaCuantico);
            SpaceDownLeft = Camera.main.ScreenToWorldPoint(new Vector3());
            SpaceUpLeft = new Vector3(SpaceDownLeft.x, SpaceDownLeft.y + 10, SpaceDownLeft.z);
            SpaceUpRight = new Vector3(SpaceDownLeft.x + 5.5f, SpaceDownLeft.y + 10, SpaceDownLeft.z);

            float tupac = Random.Range(SpaceUpLeft.x, SpaceDownLeft.x+1);
            float eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
            Reaparicion = new Vector3(tupac, eminem, 0);

            tupac = Random.Range(SpaceUpLeft.x, SpaceDownLeft.x);
            eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
            Reaparicion1 = new Vector3(tupac, eminem, 0);
            Instantiate(plasma1, Reaparicion, Quaternion.identity);
            Instantiate(plasma2, Reaparicion1, Quaternion.identity);

            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            Destroy(plasmaCuantico);
        }
        if (collision.gameObject.tag == "Ground")
        {
            if (plasmaCuantico.transform.position.x < -2)
            {
                lugar = new Vector3(plasmaCuantico.transform.position.x, plasmaCuantico.transform.position.y + 1, plasmaCuantico.transform.position.z);
                plasmaCuantico.transform.position = lugar;
            }
            if (plasmaCuantico.transform.position.x > 2)
            {
                lugar = new Vector3(plasmaCuantico.transform.position.x, plasmaCuantico.transform.position.y + 1, plasmaCuantico.transform.position.z);
                plasmaCuantico.transform.position = lugar;
            }
            else if (plasmaCuantico.transform.position.x < 2 && plasmaCuantico.transform.position.x > -2)
            {
                Destroy(plasmaCuantico);
            }
        }
    }
}
