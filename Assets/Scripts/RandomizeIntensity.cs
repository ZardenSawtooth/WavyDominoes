using UnityEngine;
using System.Collections;

public class RandomizeIntensity: MonoBehaviour {

	// Use this for initialization
    [SerializeField]
    float startValue = 1.0f;

    [SerializeField]
    float endValue = 4.0f;


	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponent<Light>().intensity = Random.Range(startValue, endValue);
        
	}
}
