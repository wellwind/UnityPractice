using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
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


    {
        Speed = 5;
        score = 0;
        rigidBody = GetComponent<Rigidbody>();
        winText.text = String.Empty;
        scoreText.text = String.Empty;
        restartButton.SetActive(false);
    }

    {
        rigidBody.AddForce(new Vector3(0, -0.001f, 0));
        scoreText.text = String.Format("Score: {0}", score);
    }

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
