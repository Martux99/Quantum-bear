using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {
    public bool direction;//La direccion a la que se dirige el plasma
    public GameObject Plasma; //Es el objeto del plasma
    Vector3 posicion; //Es la posicion donde se genera el plasma en casos especiales
    void Start ()
    {
		if (Plasma.transform.position.x > 1)
        {
            direction = false;
        }
        else
        {
            direction = true;
        }
	}
	void Update ()
    {
		if (direction == true)
        {
            Plasma.transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
        else
        {
            Plasma.transform.Translate(Vector3.left * Time.deltaTime * 3);
        }
        if (Plasma.transform.position.x < -4 || Plasma.transform.position.x > 4)
        {
            Destroy(Plasma);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            Destroy(Plasma);
        }
        if (collision.gameObject.tag == "Ground")
        {
            if (Plasma.transform.position.x < -2)
            {
                posicion = new Vector3(Plasma.transform.position.x, Plasma.transform.position.y + 1, Plasma.transform.position.z);
                Plasma.transform.position = posicion;
            }
            if (Plasma.transform.position.x > 2)
            {
                posicion = new Vector3(Plasma.transform.position.x, Plasma.transform.position.y + 1, Plasma.transform.position.z);
                Plasma.transform.position = posicion;
            }
            else if (Plasma.transform.position.x < 2 && Plasma.transform.position.x > -2)
            {
                Destroy(Plasma);
            }
        }
    }
}
