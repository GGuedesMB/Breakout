using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] float vel = 5;
    [SerializeField] float maxX = 8.9f;
    public int balls;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        /* Vai somar o transform ao novo vetor para a direita 
        (este que é positivo ao se multiplicar pelo Horizontal q é positivo para a direita)
        * vel (constante) * Horizontal * Time.tananana (para que se mova por segundo e nn por frame)*/
        transform.position += Vector3.right * x * vel * Time.deltaTime; 
        if (transform.position.x < -maxX )
        {
            transform.position = new Vector3(maxX , transform.position.y, 1);
        }
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(-maxX, transform.position.y, 1);
        }
        if (balls == 0)
        {
            SceneManager.LoadScene(0);
        }

        //Lembrar de fazer ela ir de um lado para o outro
    }
}
