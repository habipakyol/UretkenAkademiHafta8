using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int health = 100;

    public TextMeshProUGUI healthText;

    BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        ballController = GetComponent<BallController>();
        healthText.text = "HEALTH: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NegativeHealth()
    {
        health -= 10;
    }

    public void NegativeHealth2()
    {
        health -= 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Negative"))
        {
            NegativeHealth();
            healthText.text = "HEALTH: " + health.ToString();
        }

        if (collision.gameObject.CompareTag("Slime"))
        {
            ballController.jumpForce = 100f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Negative"))
        {
            NegativeHealth2();
            healthText.text = "HEALTH: " + health.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
