using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 0.5f;

    Rigidbody rb;
    public CameraController mainCameraController;
    public GameObject[] FractureItems;

    public float jumpForce = 5f; // Zýplama kuvveti
    public float maxSpeed = 5f; // Maksimum hýz deðeri

    private bool canJump = true; // Zýplama izni
    private bool isMoov = true;

    GameManager gameManager;

    public GameObject Restart;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isMoov = true;
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        if (mainCameraController.isCamActive == true)
        {
            MoveBall();
        }


        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else
        {
            isMoov = true;
        }
        // E tuþuna basýlý kaldýðý sürece topun hýzýný 2 katýna çýkar
        if (Input.GetKey(KeyCode.E))
        {
            speed = 2f;
        }
        else
        {
            // E tuþu býrakýldýðýnda topun hýzýný eski haline getir
            speed = 0.5f;
        }

        if (gameManager.health == 0)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            speed = 0f;
            canJump = false;
            isMoov = false;
            Restart.SetActive(true);
        }

    }

    private void Jump()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        canJump = false;
        isMoov = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    public void MoveBall()
    {
        if (isMoov == true)
        {
            float hzInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(hzInput, 0f, vInput);
            rb.AddForce(move * speed);
        }
        // Topun hýzýný sýnýrla
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

    }
}
