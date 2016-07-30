using System.Collections;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "End")
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}