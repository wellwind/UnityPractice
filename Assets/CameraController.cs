using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Vector3 relativePosition;
    public GameObject player;

    void Start()
    {
        relativePosition = gameObject.transform.position - player.transform.position;
    }

    void Update()
    {
        gameObject.transform.position = player.transform.position + relativePosition;
    }
}
