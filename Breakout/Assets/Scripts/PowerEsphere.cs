using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEsphere : MonoBehaviour
{
    GameObject ball;
    [SerializeField] GameObject instantiableBall;
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        shield = GameObject.Find("Shield");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            int randomPower = Random.Range(0, 3);
            Debug.Log("number: " + randomPower);
            //Destroy(gameObject);
            if(randomPower == 0)
            {
                Shield();
            }
            else if(randomPower == 1)
            {
                BiggerPaddle();
            }
            else if(randomPower == 2)
            {
                DoubleDuo();
            }
        }
    }
    private void Shield()
    {
        shield.transform.position = new Vector3(0,shield.transform.position.y, 0);
    }
    private void BiggerPaddle()
    {
        FindAnyObjectByType<Player>().gameObject.transform.localScale += new Vector3(3, 0, 0);
    }
    private void DoubleDuo()
    {   
        ball = Instantiate(instantiableBall, gameObject.transform.position, gameObject.transform.rotation);
        Debug.Log(ball);
        ball.GetComponent<Ball>().LaunchAddiction();
    }
}