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
    public GameObject Cuantico;//El plasma cuantico
    public GameObject largePlasmax;
    public GameObject largePlasmay;
    Vector3 position;
    public float quanticTime = 15f;
    public float time = 3f;
    public float greatTime = 30f;
    private void Awake()
    {
        /*
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.AutoRotation;*/
    }
    void Start ()
    {
        StartCoroutine(Generacion());
        StartCoroutine(GeneracionCuantica());
        StartCoroutine(GeneracionGrande());
    }
	void FixedUpdate ()
    {
        
    }
    IEnumerator Generacion()
    {
        while (true)
        {
            int brandom = Random.Range(0, 2);
            if (brandom == 0)
            {
                yield return new WaitForSeconds(time);
                Triangulacion();
                float eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
                position = new Vector3(-3, eminem, 0);
                Instantiate(plasma, position, Quaternion.identity);
            }
            if (brandom == 1)
            {
                yield return new WaitForSeconds(time);
                Triangulacion();
                float eminem = Random.Range(SpaceUpRight.y, SpaceDownLeft.y);
                position = new Vector3(3, eminem, 0);
                Instantiate(plasma, position, Quaternion.identity);
            }
        }
    }
    IEnumerator GeneracionCuantica()
    {
        while (true)
        {
            int brandom = Random.Range(-1, 2);
            if (brandom == 0)
            {
                yield return new WaitForSeconds(quanticTime);
                Triangulacion();
                float eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
                position = new Vector3(-3, eminem, 0);
                Instantiate(Cuantico, position, Quaternion.identity);
            }
            if (brandom == 1)
            {
                yield return new WaitForSeconds(quanticTime);
                Triangulacion();
                float eminem = Random.Range(SpaceUpRight.y, SpaceDownLeft.y);
                position = new Vector3(3, eminem, 0);
                Instantiate(Cuantico, position, Quaternion.identity);
            }
        }
    }
    IEnumerator GeneracionGrande()
    {
        while (true)
        {
            int brandom = Random.Range(-1, 2);
            if (brandom == 0)
            {
                yield return new WaitForSeconds(greatTime);
                Triangulacion();
                float eminem = Random.Range(SpaceUpLeft.x, SpaceUpRight.x);
                position = new Vector3(eminem, SpaceDownLeft.y+5, 0);
                Instantiate(largePlasmay, position, Quaternion.identity);
                
            }
            if (brandom == 1)
            {
                yield return new WaitForSeconds(greatTime);
                Triangulacion();
                float eminem = Random.Range(SpaceUpLeft.y, SpaceDownLeft.y);
                position = new Vector3(0, eminem, 0);
                Instantiate(largePlasmax, position, Quaternion.identity);
            }
        }
    }
    void Triangulacion()
    {
        SpaceDownLeft = Camera.main.ScreenToWorldPoint(new Vector3());
        SpaceUpLeft = new Vector3(SpaceDownLeft.x, SpaceDownLeft.y + 10, SpaceDownLeft.z);
        SpaceUpRight = new Vector3(SpaceDownLeft.x + 5.5f, SpaceDownLeft.y + 10, SpaceDownLeft.z);
    }
}
