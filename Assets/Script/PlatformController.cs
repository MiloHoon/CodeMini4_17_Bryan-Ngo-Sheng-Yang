using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    float speed = 2.5f;
    float zPointA = 22.5f;
    float zPointB = 32.5f;
    float yPointA = 2.5f;
    float yPointB = 10f;

    bool isForwardZ = true;
    bool isForwardY = true;

    public GameObject Player;
    public GameObject MovingPlatformZ;
    public GameObject MovingPlatformY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Moving Platform (Z)
        if (PlayerController.totalCoins == 4)
        {
            if (MovingPlatformZ.transform.position.z < zPointB && isForwardZ)
            {
                MovingPlatformZ.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else if (MovingPlatformZ.transform.position.z > zPointA && !isForwardZ)
            {
                MovingPlatformZ.transform.Translate(Vector3.back * Time.deltaTime * speed);
            }
            else
            {
                isForwardZ = !isForwardZ;
            }
        }

        //Moving Platform (Y)
        if (PlayerController.totalCoins == 5)
        {
            if (MovingPlatformY.transform.position.y < yPointB && isForwardY)
            {
                MovingPlatformY.transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
            else if (MovingPlatformY.transform.position.y > yPointA && !isForwardY)
            {
                MovingPlatformY.transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            else
            {
                isForwardY = !isForwardY;
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        //Set Parent Under Player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Remove Parent Under Player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
