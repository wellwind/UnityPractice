using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlaneController : MonoBehaviour
{
    public float MoveHorizontal;
    public float MoveVertical;

    public GameObject GoWalls;
    public GameObject GoStars;

    private float angleHorizontal;
    private float angleVertical;
    private float rotationLimit;

    // Use this for initialization
    {
        rotationLimit = 30;
    }

    // Update is called once per frame
    {
        MoveHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal") * -1;
        MoveVertical = CrossPlatformInputManager.GetAxisRaw("Vertical");

        angleHorizontal = getRotationAngle(angleHorizontal, MoveHorizontal);
        angleVertical = getRotationAngle(angleVertical, MoveVertical);

        gameObject.transform.eulerAngles
            = GoWalls.transform.eulerAngles
            = GoStars.transform.eulerAngles
            = new Vector3(angleVertical, 0, angleHorizontal);
    }

    private float getRotationAngle(float currentAngle, float rotationAngle)
    {
        currentAngle += rotationAngle;
        if (currentAngle > rotationLimit)
        {
            currentAngle = rotationLimit;
        }
        if (currentAngle < -1 * rotationLimit)
        {
            currentAngle = -1 * rotationLimit;
        }

        return currentAngle;
    }
}
