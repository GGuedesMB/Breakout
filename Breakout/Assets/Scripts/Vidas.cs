using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Vidas : MonoBehaviour
{

    public static Vidas instance;

    [SerializeField] TextMeshProUGUI livesText;

    int startLives = 5;
    int currentLives;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentLives = startLives;
    }

    private void Update()
    {
        livesText.text = currentLives.ToString();
    }

    public int Lives()
    {
        return currentLives;
    }
    public void LifeLost()
    {
        currentLives--;
    }
    public void LifeReset()
    {
        currentLives = startLives;
    }
}
