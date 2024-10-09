using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlocks : MonoBehaviour
{
    [SerializeField] int life;
    Player player;
    [SerializeField] GameObject powerSphere;
    //[SerializeField] Max

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.blocks ++; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            collision.gameObject.GetComponent<Ball>().SpeedAddiction();
            life--;
            if(life <= 0)
            {
                int randy = UnityEngine.Random.Range(0, 12);
                if (randy > 5 && randy <= 8 ) 
                {
                    Instantiate(powerSphere, gameObject.transform.position, gameObject.transform.rotation);
                    Debug.Log("buff:" + randy);
                }
                else if (randy > 8)
                {
                    Debug.Log("debuff:" + randy);
                }
                else
                {
                    Debug.Log("nothing:" + randy);
                }
                player.blocks--;
                Destroy(gameObject);
            }
        }
    }

}
