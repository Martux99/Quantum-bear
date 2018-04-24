using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumMovement : MonoBehaviour {
    int brandom;
    public GameObject position;
    Vector3 lugar;
	void Start ()
    {
        brandom = Random.Range(0, 2);
        if (position.transform.position.x < -1.5f && brandom == 0)
        {
            position.transform.position = new Vector3(0, position.transform.position.y, 0);
        }
        if (position.transform.position.x > 1.5 && brandom == 1)
        {
            position.transform.position = new Vector3(0, position.transform.position.y, 0);
        }
    }
	void Update ()
    {
		if (brandom == 0)
        {
            position.transform.Translate(Vector3.left * Time.deltaTime * 3);
        }
        if (brandom == 1)
        {
            position.transform.Translate(Vector3.right * Time.deltaTime * 3);
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
                lugar = new Vector3(position.transform.position.x, position.transform.position.y + 1, position.transform.position.z);
                position.transform.position = lugar;
            }
            if (position.transform.position.x > 2)
            {
                lugar = new Vector3(position.transform.position.x, position.transform.position.y + 1, position.transform.position.z);
                position.transform.position = lugar;
            }
            else if (position.transform.position.x < 2 && position.transform.position.x > -2)
            {
                Destroy(position);
            }
        }
    }
}
