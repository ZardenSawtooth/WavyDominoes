using System.Collections;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    #region Set in editor;

    public float jumpDuration = 1.0f;
    public float jumpDistance = 3;

    #endregion Set in editor;

    private bool jumping = false;
    private float jumpStartVelocityY;

    private void Start()
    {
        // For a given distance and jump duration
        // there is only one possible movement curve.
        // We are executing Y axis movement separately,
        // so we need to know a starting velocity.
        jumpStartVelocityY = -jumpDuration * Physics.gravity.y / 2;
    }

    private void Update()
    {
        if (jumping)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Warning: this will actually move jumpDistance forward
            // and jumpDistance to the side.
            // If you want to move jumpDistance diagonally, use:
            // Vector3 forwardAndLeft = (transform.forward - transform.right).normalized * jumpDistance;
            Vector3 forwardAndLeft = (transform.forward - transform.right) * jumpDistance;
            StartCoroutine(Jump(forwardAndLeft));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 forwardAndRight = (transform.forward + transform.right) * jumpDistance;
            StartCoroutine(Jump(forwardAndRight));
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

        transform.position = targetPoint;
        yield break;
    }
}