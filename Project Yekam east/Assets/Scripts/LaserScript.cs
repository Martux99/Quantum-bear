using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {
    public bool direction;
    public GameObject position;
    Vector3 posicion;
    void Start ()
    {
		if (position.transform.position.x > 1)
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
            position.transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
        else
        {
            position.transform.Translate(Vector3.left * Time.deltaTime * 3);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            Destroy(position);
        }
        if (collision.gameObject.tag == "Ground")
        {
            if (position.transform.position.x < -2)
            {
                posicion = new Vector3(position.transform.position.x, position.transform.position.y + 1, position.transform.position.z);
                position.transform.position = posicion;
            }
            if (position.transform.position.x > 2)
            {
                posicion = new Vector3(position.transform.position.x, position.transform.position.y + 1, position.transform.position.z);
                position.transform.position = posicion;
            }
            else if (position.transform.position.x < 2 && position.transform.position.x > -2)
            {
                Destroy(position);
            }
        }
    }
}
