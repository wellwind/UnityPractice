using UnityEngine;

public class Spin : MonoBehaviour
{
    public void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            Mathf.Sin(Time.time * 2f) * 0.3f + 0.8f,
            transform.localPosition.z);
    }
}