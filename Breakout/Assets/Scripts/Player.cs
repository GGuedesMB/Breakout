using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        /* Vai somar o transform ao novo vetor para a direita 
        (este que � positivo ao se multiplicar pelo Horizontal q � positivo para a direita)
        * vel (constante) * Horizontal * Time.tananana (para que se mova por segundo e nn por frame)*/
        transform.position += Vector3.right * x * vel * Time.deltaTime; 
        if (transform.position.x <= -8.4 )
        {
            transform.position = new Vector3(-8.4f , -3.5f , 1);
        }
        if (transform.position.x >= 8.4)
        {
            transform.position = new Vector3(8.4f, -3.5f, 1);
        }
        //Lembrar de fazer ela ir de um lado para o outro
    }
}
