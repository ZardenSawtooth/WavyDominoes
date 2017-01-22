using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStructureCollapse : MonoBehaviour {
    int initiaCount = 4;
    int count = 0;
    public Light lightIndicator;
    public GameObject GameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       if(count > 0)
        {
            //turn off light
            lightIndicator.gameObject.SetActive(false);
            GameManager.GetComponent<GameManager>().PileToppled = 1;
        }

       
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            count++;
        }
    }
}
