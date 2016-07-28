using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    public float MoveHorizontal;
    public float MoveVertical;
    public float Speed;

    // compoments
    public Rigidbody rigidBody { get; set; }

    // UI
    public Text scoreText;
    public Text winText;
    public GameObject restartButton;

    private int score;

    void Start()
    {
        Speed = 5;
        score = 0;
        rigidBody = GetComponent<Rigidbody>();
        winText.text = String.Empty;
        scoreText.text = String.Empty;
        restartButton.SetActive(false);
    }

    void FixedUpdate()
    {
        MoveHorizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        MoveVertical = CrossPlatformInputManager.GetAxisRaw("Vertical");

        rigidBody.AddForce(new Vector3(MoveHorizontal, 0, MoveVertical) * Speed);

        scoreText.text = String.Format("Score: {0}", score);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("star"))
        {
            other.gameObject.SetActive(false);
            ++score;
            if (score >= 12)
            {
                winText.text = "You Win!!";
                restartButton.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene");
    }
}
