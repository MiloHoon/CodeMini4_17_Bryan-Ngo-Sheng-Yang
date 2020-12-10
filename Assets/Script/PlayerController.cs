using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;
    float gravityMoldifier = 2.0f;

    int maxJump = 0;

    public Rigidbody PlayerRB;
    public Animator PlayerAnim;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityMoldifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Character Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerAnim.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            PlayerAnim.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            PlayerAnim.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            PlayerAnim.SetBool("isRunning", true);
        }
        //Character Jump
        Jumping();
    }

    private void Jumping()
    {
        //Player Jump
        if (maxJump == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerRB.AddForce(Vector3.up * speed * gravityMoldifier, ForceMode.Impulse);
                //PlayerAnim.SetBool("isJumping", true);
                ++maxJump;
            }
        }
    }
}
