using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumMovement : MonoBehaviour {
    int brandom; //Determina a donde ira el objeto
    Vector3 lugar; //Es el lugar a donde se mueve el objeto en casos especificos
    public float waitTime = 1f; //tiempo para que inicien a moverse las copias
    public bool Movimiento = false; //El booleano indica si esta activo el objeto
    public GameObject plasma;// Es el objeto de plasma
    public BoxCollider2D colli; //El colisionador de las copias
    private void Awake()
    {
        StartCoroutine(GeneracionCuantica());
        colli.enabled = false;
    }
    IEnumerator GeneracionCuantica()
    {
        yield return new WaitForSeconds(waitTime);
        Movimiento = true;
        
    }
    void Start ()
    {

        brandom = Random.Range(0, 2);
        if (plasma.transform.position.x < -1.5f && brandom == 0)
        {
            plasma.transform.position = new Vector3(0, plasma.transform.position.y, 0);
        }
        if (plasma.transform.position.x > 1.5 && brandom == 1)
        {
            
            plasma.transform.position = new Vector3(0, plasma.transform.position.y, 0);
        }
    }
	void Update ()
    {
		if (brandom == 0 && Movimiento == true)
        {
            colli.enabled = true;
            plasma.transform.Translate(Vector3.left * Time.deltaTime * 3);
        }
        if (brandom == 1 && Movimiento == true)
        {
            colli.enabled = true;
            plasma.transform.Translate(Vector3.right * Time.deltaTime * 3);
        }
        if (plasma.transform.position.x < -4 || plasma.transform.position.x > 4)
        {
            Destroy(plasma);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            Destroy(plasma);
        }
        if (collision.gameObject.tag == "Ground")
        {
            if (plasma.transform.position.x < -2)
            {
                lugar = new Vector3(plasma.transform.position.x, plasma.transform.position.y + 1, plasma.transform.position.z);
                plasma.transform.position = lugar;
            }
            if (plasma.transform.position.x > 2)
            {
                lugar = new Vector3(plasma.transform.position.x, plasma.transform.position.y + 1, plasma.transform.position.z);
                plasma.transform.position = lugar;
            }
            else if (plasma.transform.position.x < 2 && plasma.transform.position.x > -2)
            {
                Destroy(plasma);
            }
        }
    }
}
