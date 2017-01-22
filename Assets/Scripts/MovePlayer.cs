using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

    #region Set in editor;

    public float jumpDuration = 0.5f;
    public float jumpDistance = 1;

    #endregion Set in editor;

    private int currentMoveDirection = 0;

    public int MoveDirection
    {
        get { return currentMoveDirection; }    
    }

    private bool jumping = false;
    private float jumpStartVelocityY;
    public float currentForward;
    
    public Animator characterAnimator;

	// Use this for initialization
	void Start () {
        jumpStartVelocityY = -jumpDuration * Physics.gravity.y / 2;
        currentForward = transform.rotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (jumping)
        {
            characterAnimator.SetBool("jump", true);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, currentForward, 0);
            StartCoroutine(Jump(transform.forward * jumpDistance));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, - currentForward , 0);
            StartCoroutine(Jump(transform.forward * jumpDistance));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, currentForward +90, 0);
            StartCoroutine(Jump(transform.forward * jumpDistance));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, currentForward -90, 0);
            StartCoroutine(Jump(transform.forward * jumpDistance));
        }
        else
        {
            characterAnimator.SetBool("jump", false);
        }

        
            
   
	}


    private IEnumerator Jump(Vector3 direction)
    {
        jumping = true;
        Vector3 startPoint = transform.position;
        Vector3 targetPoint = startPoint + direction;
        float time = 0;
        float jumpProgress = 0;
        float velocityY = jumpStartVelocityY;
        float height = startPoint.y;

        while (jumping)
        {
            jumpProgress = time / jumpDuration;

            if (jumpProgress > 1)
            {
                jumping = false;
                jumpProgress = 1;
            }

            Vector3 currentPos = Vector3.Lerp(startPoint, targetPoint, jumpProgress);
            currentPos.y = height;
            transform.position = currentPos;

            //Wait until next frame.
            yield return null;

            height += velocityY * Time.deltaTime;
            velocityY += Time.deltaTime * Physics.gravity.y;
            time += Time.deltaTime;
        }
        //manually set to target point
       // transform.position = targetPoint;
        yield break;
    }
}
