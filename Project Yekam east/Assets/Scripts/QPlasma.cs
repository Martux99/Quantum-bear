using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QPlasma : MonoBehaviour {
    public bool direction;
    public float quanticTime = 2f;
    public GameObject position;
    public GameObject plasma1;
    public GameObject plasma2;
    Vector3 lugar;
    public float tiempo;
    public Vector3 SpaceDownLeft;
    public Vector3 SpaceUpLeft;
    public Vector3 SpaceUpRight;
    public Vector3 SpaceDownRight;
    public Vector3 Reaparicion;
    public Vector3 Reaparicion1;
    public Sprite plasmasprite;
    public Sprite plasmasprite1;
    float tiempoinicio;
    void Start()
    {
        tiempoinicio = -Time.time;
        if (position.transform.position.x > 1)
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
        Debug.Log(tiempo);
        if (direction == true)
        {
            position.transform.Translate(Vector3.right * Time.deltaTime * 1);
        }
        else
        {
            position.transform.Translate(Vector3.left * Time.deltaTime * 1);
        }
        if (tiempo > 3)
        {
            Destroy(position);
            SpaceDownLeft = Camera.main.ScreenToWorldPoint(new Vector3());
            SpaceUpLeft = new Vector3(SpaceDownLeft.x, SpaceDownLeft.y + 10, SpaceDownLeft.z);
            SpaceUpRight = new Vector3(SpaceDownLeft.x + 5.5f, SpaceDownLeft.y + 10, SpaceDownLeft.z);
            SpaceDownRight = new Vector3(SpaceDownLeft.x + 5.5f, SpaceDownLeft.y, SpaceDownLeft.z);

            float tupac = Random.Range(SpaceUpLeft.x, SpaceDownRight.x+1);
            float eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
            Reaparicion = new Vector3(tupac, eminem, 0);
            Instantiate(plasma1, Reaparicion, Quaternion.identity);
           // Instantiate(plasmasprite, Reaparicion, Quaternion.identity);

            tupac = Random.Range(SpaceUpLeft.x, SpaceDownLeft.x);
            eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
            Reaparicion1 = new Vector3(tupac, eminem, 0);
            Instantiate(plasmasprite1, Reaparicion1, Quaternion.identity);
           // Instantiate(plasma2, Reaparicion1, Quaternion.identity);
           // StartCoroutine(GeneracionCuantica());
        }
    }
    IEnumerator GeneracionCuantica()
    {
        Destroy(plasmasprite);
        Destroy(plasmasprite1);
        yield return new WaitForSeconds(quanticTime);
        
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
