using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Vida : MonoBehaviour {
	
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
		if (PlayerMovement.vida < 1)
        {
            //Invoke("Reload", 1);
        }
        
    }
    void Reload()
    {
        Debug.Log("asfg32423432");
        SceneManager.LoadScene("Level1");
    }
}
