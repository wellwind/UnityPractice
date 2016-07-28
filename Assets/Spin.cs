using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);
        var tmpPosition = transform.position;
        transform.position = new Vector3(
            tmpPosition.x,
            Mathf.Sin(Time.time*2f)*0.3f + 0.8f,
            tmpPosition.z);
    }
}
