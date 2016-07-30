using System.Collections;
using UnityEngine;

public class CreateNext : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_ObstacleWays;

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
            if (other.transform.root.name.IndexOf("ObstWay") != -1)
            {
                int index = Random.Range(0, m_ObstacleWays.Length);
                GameObject cloneObstacleWay = Instantiate<GameObject>(m_ObstacleWays[index]);
                cloneObstacleWay.name = m_ObstacleWays[index].name;
                cloneObstacleWay.transform.position = other.transform.position;// + new Vector3(Random.Range(1, 2 + 1), 0, 0);
            }
            else
            {
                GameObject clone = Instantiate<GameObject>(other.transform.root.gameObject);
                clone.name = other.transform.root.name;
                clone.transform.position = other.transform.position - new Vector3(0.5f, 0, 0);
            }

            //GameObject clone = Instantiate<GameObject>(other.transform.root.gameObject);
            //clone.name = other.transform.root.name;
            //clone.transform.position = other.transform.position;
            //int index = Random.Range(0, m_ObstacleWays.Length);
            //GameObject cloneObstacleWay = Instantiate<GameObject>(m_ObstacleWays[index]);
            //cloneObstacleWay.name = m_ObstacleWays[index].name;
            //cloneObstacleWay.transform.position = other.transform.position + new Vector3(Random.Range(1, 2 + 1), 0, 0);
        }
    }
}