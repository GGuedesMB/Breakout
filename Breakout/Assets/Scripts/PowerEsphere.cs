using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEsphere : MonoBehaviour
{
    Player player;
    [SerializeField] GameObject instantiableBall;
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        shield = GameObject.Find("Shield");
        shield.SetActive(false);
        player = FindObjectOfType<Player>();
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
    private void DoubleDuo()
    {
        player.balls++;
        Instantiate(instantiableBall, gameObject.transform.position, gameObject.transform.rotation);
    }
}