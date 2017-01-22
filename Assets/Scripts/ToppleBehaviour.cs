using UnityEngine;
using System.Collections;

public class ToppleBehaviour : MonoBehaviour {
    
    Vector3 force = new Vector3(100.0f, 0, 100.0f);
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionExit(Collision col)
    {

        if(col.gameObject.tag == "Player")
        {
            float cosAngle = Vector3.Dot(col.gameObject.transform.forward.normalized, gameObject.transform.forward.normalized);
            force = new Vector3 ( force.x * transform.forward.x, force.y * transform.forward.y, force.z * transform.forward.z) ;


            //if (Mathf.Approximately(cosAngle, 1.0f) || Mathf.Approximately(cosAngle, -1.0f))
             if (compareWithinApprox(cosAngle, 1.0f, 0.1f) || compareWithinApprox(cosAngle, -1.0f, 0.1f))
            {
                gameObject.GetComponent<Rigidbody>().AddForceAtPosition(force, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z));
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(transform.position.x, col.transform.position.y, transform.position.z);
        }
    }

    bool compareWithinApprox(float a, float b, float errorValue)
    {
        //Debug.Log("a = " + a + " b = " + b);
        //Debug.Log("comparison = " + (Mathf.Abs(a) - Mathf.Abs(b)));
        if (Mathf.Abs(a - b) < errorValue)
        {
            return true;
        }
        return false;
    }
}
