using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 relativePosition;
    public GameObject player;

    public void Start()
    {
        relativePosition = gameObject.transform.position - player.transform.position;
    }

    public void Update()
    {
        gameObject.transform.position = player.transform.position + relativePosition;
    }
}