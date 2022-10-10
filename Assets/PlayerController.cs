using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private CharacterController controller;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float gravity = 10f;

    [SerializeField]
    private float jumpForce = 10f;

    private Animator anim;
    private float verticalVelocity;

    [SerializeField]
    private Text distanceText;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveVector;

        //x
        moveVector.x = Input.GetAxis("Horizontal") * moveSpeed;

        //z
        moveVector.z = moveSpeed;

        //y
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            } 
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
        anim.SetBool("Grounded", controller.isGrounded);

        distanceText.text = ((int)transform.position.z).ToString();
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius && hit.gameObject.tag == "Obstacle" && controller.velocity.z <= 0.1f)
        {
            PlayerPrefs.SetInt("Score", (int)transform.position.z);
            if((int)transform.position.z > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", (int)transform.position.z);
            }
            SceneManager.LoadScene("MainMenu");
        }
    }
}
