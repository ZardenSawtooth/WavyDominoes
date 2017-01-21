using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    
    [SerializeField]
    [Tooltip ("Add whom the camera should follow")]
    GameObject whomToFollow;

    [SerializeField]
    [Tooltip("Tweak this number to change camera follow speed")]
    float cameraSpeed = 2.0f;

    private bool turning = false;
    private bool turned = false;
    [SerializeField]
    private float turnTime = 0.25f;

    float direction = 0;

    Vector3 cameraOffset ; //
	// Use this for initialization
	void Start () {
        //sets is to world co-ordinates
        cameraOffset = transform.position;
        //calculates relative offset to player
        cameraOffset -= whomToFollow.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector3.Lerp ( transform.position , whomToFollow.transform.position + cameraOffset, Time.deltaTime * cameraSpeed );

        if(Input.GetKeyDown(KeyCode.Q))
        {
            turning = true;
            StartCoroutine(turn(-1));
            
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            turning = true;
            StartCoroutine(turn(1));
        }
        else if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
           turning = true;
           StartCoroutine(turn(0));
        }
	}

    private IEnumerator turn(float direction)
    {
        Quaternion targetRotation;
        float turnProgress = 0;
        float time = 0;
        if (direction == 1)
        {
            targetRotation = Quaternion.Euler(transform.rotation.x, 60.0f, transform.rotation.z);
        }
        else if( direction == -1)
        {
            targetRotation = Quaternion.Euler(transform.rotation.x, -60.0f, transform.rotation.z);
        }
        else
        {
            targetRotation = Quaternion.Euler(transform.rotation.x, 0.0f, transform.rotation.z);
        }
        while (turning)
        {
            turnProgress = time / turnTime;

            if (turnProgress > 1)
            {
                turning = false;
                turnProgress = 1;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnProgress);

            yield return null;

            time += Time.deltaTime;
        }
        yield break;
    }
}
