using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Player Var
    float speed = 5.0f;
    float canJump = 0f;

    int maxJump = 0;

    //GameObject Var
    static public int totalCoins;
    int potionLeft = 1;

    //Time Var
    float currentTime = 0.0f;
    float startingTime = 10.0f;
    bool timeTrigger = true;

    public Rigidbody PlayerRB;
    public Animator PlayerAnim;
    public GameObject TurningPlatform;
    public Text TimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
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
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            PlayerAnim.SetBool("isRunning", false);
        }

        //End Of Countdown
        if (currentTime <= 0)
        {
            TurningPlatform.transform.rotation = Quaternion.Euler(0, -90, 0);
            currentTime = 10.0f;
            timeTrigger = !timeTrigger;
        }
        //Time Countdown
        if (!timeTrigger)
        {
            TimeLeft.GetComponent<Text>().text = "Time Left : " + currentTime.ToString("0");
            currentTime -= 1 * Time.deltaTime;
        }

        //Character Jump
        Jumping();

        //Win Scene
        if (potionLeft == 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        //Lose Scene
        if (transform.position.y < -3)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void Jumping()
    {
        //Player Jump
        if (maxJump == 0 && Time.time > canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerRB.AddForce(Vector3.up * speed, ForceMode.Impulse);
                PlayerAnim.SetBool("isJumping", true);
                ++maxJump;
                canJump = Time.time + 1.7f;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //If Player Touch The Ground, Reset Jump Count
        if (collision.gameObject.CompareTag("Plane") || collision.gameObject.CompareTag("Box"))
        {
            PlayerAnim.SetBool("isJumping", false);
            maxJump = 0;
        }
        //Destroy Coin
        if (collision.gameObject.CompareTag("Coin"))
        {
            totalCoins++;
            Destroy(collision.gameObject);
        }
        //Trigger The Turning Plane
        if (timeTrigger)
        {
            if (collision.gameObject.CompareTag("Switch"))
            {
                TurningPlatform.transform.rotation = Quaternion.Euler(0, 0, 0);
                timeTrigger = !timeTrigger;
            }
        }
        //Go To Win Scene Line 63
        if (collision.gameObject.CompareTag("Potion"))
        {
            potionLeft = 0;
        }
    }
}