using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("Enemy Path")]
    public Transform StartPoint;
    public Transform[] Path;

    [Header("Optional Path otherwise Leave Empty")]
    public Transform SecondStartPoint;
    public Transform[] SecondPath;

    public int currency;

    [Header("Attributes")]
    [SerializeField] public GameObject[] hearts;

    public int heartIndex = 4;

    private void Awake()
    {
        main = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        currency = 200;   

        if (SecondStartPoint == null)
        {
            SecondStartPoint = StartPoint;
            SecondPath = Path;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (heartIndex < 0)
            SceneManager.LoadScene("GameOver");
    }

    public void IncreaseCurrency(int money)
    {
        currency += money;
    }

    public bool Spend(int money)
    {
        if (money > currency)
        {
            Debug.Log("You're broke, get your money up!");
            return false;
        } 
        else
        {
            currency -= money;
            return true;
        }
    }

    public void ReduceHealth()
    {
        Destroy(hearts[heartIndex--]);
    }
}