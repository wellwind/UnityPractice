using System.Collections;
using UnityEngine;

public class FailureCheck : MonoBehaviour
{
    public static bool isFailure = false;

    // Use this for initialization
    private void Start()
    {
        isFailure = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            isFailure = true;
            Rigidbody2D r = GetComponentInParent<Rigidbody2D>();
            Vector3 moveDirection = r.velocity.normalized;
            r.AddForce(moveDirection * -1 * 500);
        }
        else
        {
            if (name == "Head")
            {
                isFailure = true;
            }
        }
    }
}