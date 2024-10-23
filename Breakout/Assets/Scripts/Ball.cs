using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float vel;
    [SerializeField] float speedGainPerBlockHit = 1;
    [SerializeField] float velX;
    [SerializeField] float minY = -5.5f;
    [SerializeField] float howMuchBiggerCanBeX;
    public bool hasLaunched;
    Player player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hasLaunched = false;
        player.balls ++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !hasLaunched)
        {
            LaunchAddiction();
        }

        if (transform.position.y <= minY)
        {
            player.balls--;
            Destroy(gameObject);
        }

         // colocar depois do ajuste de ângulo

        // Ajuste do ângulo
        if (Mathf.Abs(rb.velocity.x) >= howMuchBiggerCanBeX * Mathf.Abs(rb.velocity.y) && rb.velocity.magnitude != 0)
        {
            rb.velocity = new Vector2(Mathf.Abs(rb.velocity.y) * Mathf.Sign(rb.velocity.x) * howMuchBiggerCanBeX, rb.velocity.y);
        }

        // Ajuste da rapidez
        rb.velocity = rb.velocity.normalized * vel;
    }

    public void LaunchAddiction()
    {
        rb.velocity = new Vector2(0, vel);
        hasLaunched = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            rb.velocity += Vector2.right * velX * (transform.position.x - collision.transform.position.x);
        }
    }

    public void SpeedAddiction()
    {
        vel += speedGainPerBlockHit;
        //Debug.Log("Vel: " + vel);
    }

    
}
