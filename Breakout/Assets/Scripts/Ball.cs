using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float vel;
    [SerializeField] float velX;
    [SerializeField] float minY = -5.5f;
    bool hasLaunched;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hasLaunched = false;
        player = FindObjectOfType<Player>();
        player.balls ++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !hasLaunched)
        {
            rb.velocity = new Vector2(0,vel);
            hasLaunched = true;
        }

        if (transform.position.y <= minY)
        {
            player.balls--;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            rb.velocity += Vector2.right * velX * (transform.position.x - collision.transform.position.x);
        }
    }

    
}
