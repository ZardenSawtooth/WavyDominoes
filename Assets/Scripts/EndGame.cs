using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public float fadeTime = 3.0f;

    public Image overlay;
    // Use this for initialization
    void Start () {
        overlay.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(FadeToBlack());
        }
    }

    private IEnumerator FadeToBlack()
    {
        overlay.gameObject.SetActive(true);
        overlay.color = Color.clear;

        float rate = 1.0f / fadeTime;

        float progress = 0.0f;

        while(progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.clear, Color.black, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("Level1");
    }
}
