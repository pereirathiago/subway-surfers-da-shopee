using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    public float speed;
    public float jumpHeight;
    private float jumpVelocity;
    public float gravity;

    public float horizontalSpeed;
    private bool isMovingLeft;
    private bool isMovingRight;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward * speed;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpVelocity = jumpHeight;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x <3f && !isMovingRight){
                isMovingRight = true;
                StartCoroutine(RightMove());
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -3f && !isMovingLeft){
                isMovingLeft = true;
                StartCoroutine(LeftMove());
            }
        }
        else
        {
            jumpVelocity -= gravity;
        }

        direction.y = jumpVelocity;

        controller.Move(direction * Time.deltaTime);
    }

    IEnumerator LeftMove()
    {
        for (float i = 0; i < 20; i += 0.15f)
        {
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
            yield return null;
        }
        isMovingLeft = false;
    }

    IEnumerator RightMove()
    {
        for (float i = 0; i < 20; i += 0.15f)
        {
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingRight=false;
    }
}
