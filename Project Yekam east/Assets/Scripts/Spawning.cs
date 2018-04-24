using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public Vector3 SpaceDownLeft;
    public Vector3 SpaceUpLeft;
    public Vector3 SpaceUpRight;
    public Vector3 SpaceDownRight;
    public GameObject plasma;
    public GameObject Cuantico;
    Vector3 position;
    float quanticTime = 2f;
    float time = 5f;
    void Start ()
    {
        StartCoroutine(Generacion());
        StartCoroutine(GeneracionCuantica());
    }
	void FixedUpdate ()
    {
        SpaceDownLeft = Camera.main.ScreenToWorldPoint(new Vector3());
        SpaceUpLeft = new Vector3(SpaceDownLeft.x , SpaceDownLeft.y+10, SpaceDownLeft.z);
        SpaceUpRight = new Vector3(SpaceDownLeft.x +5.5f, SpaceDownLeft.y+10, SpaceDownLeft.z);
        SpaceDownRight = new Vector3(SpaceDownLeft.x+5.5f, SpaceDownLeft.y , SpaceDownLeft.z);
    }
    IEnumerator Generacion()
    {
        while (true)
        {
            int brandom = Random.Range(0, 2);
            if (brandom == 0)
            {
                yield return new WaitForSeconds(time);
                float eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
                position = new Vector3(-3, eminem, 0);
                Instantiate(plasma, position, Quaternion.identity);
            }
            if (brandom == 1)
            {
                yield return new WaitForSeconds(time);
                Debug.Log("Brandom1");
                float eminem = Random.Range(SpaceUpRight.y, SpaceDownRight.y);
                position = new Vector3(3, eminem, 0);
                Instantiate(plasma, position, Quaternion.identity);
            }
        }
    }
    IEnumerator GeneracionCuantica()
    {
        while (true)
        {
            int brandom = Random.Range(0, 2);
            if (brandom == 0)
            {
                yield return new WaitForSeconds(quanticTime);
                float eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
                position = new Vector3(-3, eminem, 0);
                Instantiate(Cuantico, position, Quaternion.identity);
            }
            if (brandom == 1)
            {
                yield return new WaitForSeconds(quanticTime);
                Debug.Log("Brandom1");
                float eminem = Random.Range(SpaceUpRight.y, SpaceDownRight.y);
                position = new Vector3(3, eminem, 0);
                Instantiate(Cuantico, position, Quaternion.identity);
            }
        }
    }
}
