using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private float m_SpeedFactor = 1;

    private GameObject m_Player;
    private Vector3 m_PlayerLastPosition;

    // Use this for initialization
    private void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_PlayerLastPosition = m_Player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 deltaPosition = m_Player.transform.position - m_PlayerLastPosition;
        transform.Translate(deltaPosition.x * m_SpeedFactor, 0, 0);
        m_PlayerLastPosition = m_Player.transform.position;
    }
}