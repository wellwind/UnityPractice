using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class BoyController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_ReplayButton;

    [SerializeField]
    private Text m_ScoreText;

    [SerializeField]
    private Text m_HighestScoreText;

    [SerializeField]
    private AudioSource m_JumpAudioSource;

    public PlatformerCharacter2D m_Charater;

    private bool isGameOver = false;
    private bool jump = false;
    private float speed;
    private int m_Score = 0;
    private int m_HighestScore;
    private Animator m_Animator;

    // Use this for initialization
    public void Start()
    {
        // m_Charater = GetComponent<PlatformerCharacter2D>();
        m_Animator = GetComponent<Animator>();
        speed = 0.5f;
        if (PlayerPrefs.HasKey("HighestScore"))
        {
            m_HighestScore = PlayerPrefs.GetInt("HighestScore");
            m_HighestScoreText.text = "歷史最高: " + m_HighestScore;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Application.isEditor)
        {
            if (!jump)
            {
                jump = Input.GetMouseButtonDown(0);
            }

            speed = Input.GetMouseButton(1) ? 1 : 0.5f;
        }

        if (!isGameOver)
        {
            if (FailureCheck.isFailure)
            {
                isGameOver = true;
                var colliders = GetComponentsInChildren<Collider2D>();
                foreach (var collider in colliders)
                {
                    collider.isTrigger = true;
                }
            }
        }
    }

    public void FixedUpdate()
    {
        if (jump && m_Animator.GetBool("Ground"))
        {
            m_JumpAudioSource.Play();
        }
        m_Charater.Move(isGameOver ? 0 : speed, false, jump);
        jump = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Score")
        {
            Destroy(other.gameObject);
            m_Score += 25;
            if (m_Score > m_HighestScore)
            {
                m_HighestScore = m_Score;
            }
            m_ScoreText.text = "目前分數: " + m_Score;
            m_HighestScoreText.text = "歷史最高: " + m_HighestScore;
        }

        if (other.name == "FallTrigger")
        {
            other.GetComponentInParent<Rigidbody2D>().isKinematic = false;
        }

        if (other.name == "Replay")
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            m_ReplayButton.SetActive(true);
            PlayerPrefs.SetInt("HighestScore", m_HighestScore);
        }
    }

    public void Jump()
    {
        if (Application.isMobilePlatform)
        {
            if (!jump)
            {
                jump = true;
            }
        }
    }

    public void SpeedUp()
    {
        if (Application.isMobilePlatform)
        {
            if (Application.isMobilePlatform)
            {
                speed = 1;
            }
        }
    }

    public void NormalSpeed()
    {
        if (Application.isMobilePlatform)
        {
            if (Application.isMobilePlatform)
            {
                speed = 0.5f;
            }
        }
    }
}