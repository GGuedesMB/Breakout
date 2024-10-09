using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEsphere : MonoBehaviour
{
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        shield = GameObject.Find("Shield");
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            int randomPower = Random.Range(0, 10);
            Debug.Log("number: " + randomPower);
            BiggerPaddle();
        }
    }
    private void Shield()
    {
        shield.SetActive(true);
    }
    private void BiggerPaddle()
    {
        FindAnyObjectByType<Player>().gameObject.transform.localScale += new Vector3(3, 0, 0);
    }
}