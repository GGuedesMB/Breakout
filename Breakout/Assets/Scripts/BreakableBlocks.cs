using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlocks : MonoBehaviour
{
    [SerializeField] int life;
    Player player;

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
                player.blocks--;
                Destroy(gameObject);
            }
        }
    }

}
