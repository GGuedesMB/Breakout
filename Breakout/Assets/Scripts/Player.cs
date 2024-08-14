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
        (este que é positivo ao se multiplicar pelo Horizontal q é positivo para a direita)
        * vel (constante) * Horizontal * Time.tananana (para que se mova por segundo e nn por frame)*/
        transform.position += Vector3.right * x * vel * Time.deltaTime; 
        
    }
}
