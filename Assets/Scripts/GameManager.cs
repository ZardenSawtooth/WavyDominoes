using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    int PilesToppled = 0;
    public Light finalLight;
    public bool gameEndFlag = false;
    public int PileToppled
    {
        set { PilesToppled++; }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(PilesToppled > 2)
        {
            finalLight.gameObject.SetActive(true);
            gameEndFlag = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
		
	}
}
