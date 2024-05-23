using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("4 different directions")]
    [SerializeField] private Sprite[] upAnimation;
    [SerializeField] private Sprite[] downAnimation;
    [SerializeField] private Sprite[] rightAnimation;
    [SerializeField] private Sprite[] leftAnimation;

    [Header("Starting directions")]
    [SerializeField] private Sprite[] sprites;

    [Header("Control physics")]
    [SerializeField] private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer color;
    private int spriteIndex = 0;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed;
    [SerializeField] public float health;
    public Vector3 pivotOffset;
    public float curHealth;

    //Made this one public for testing
    [SerializeField] public Transform healthBar;

    [SerializeField] private int worth;

    private int pathIndex = 0;
    private Transform pathTarget;

    private Transform[] path;

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = healthBar.GetComponent<SpriteRenderer>();
        curHealth = health;

        if (Random.Range(0, 2) == 0)
            path = LevelManager.main.Path;
        else
            path = LevelManager.main.SecondPath;

        
    }

    protected void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    protected void Update()
    {
        HealthBarChange();
        if (Vector2.Distance(pathTarget.position, transform.position) <= 0.05f)
        {
            pathIndex += 1;
            

            if (pathIndex == path.Length)
            {
                LevelManager.main.ReduceHealth();
                Spawner.onEnemyDestroyed.Invoke();
                Destroy(gameObject);
                return;
            }

            pathTarget = path[pathIndex];

            Vector2 directionToNextPoint = (pathTarget.position - transform.position).normalized;

            if (Mathf.Abs(directionToNextPoint.x) > Mathf.Abs(directionToNextPoint.y))
            {
                if (directionToNextPoint.x > 0)
                {
                    // Move Right
                    sprites = rightAnimation;
                }
                else
                {
                    // Move Left
                    sprites = leftAnimation;
                }
            }
            else
            {
                if (directionToNextPoint.y > 0)
                {
                    // Move Up
                    sprites = upAnimation;
                }
                else
                {
                    sprites = downAnimation;
                    // Move Down
                }
            }
        }
    }

    private void HealthBarChange()
    {
        float healthpercentage = curHealth / health;
        if (healthpercentage <= 0f)
        {
            Spawner.onEnemyDestroyed.Invoke();
            LevelManager.main.IncreaseCurrency(worth); // Currency System
            Destroy(gameObject);
            return;
        }
        else if (healthpercentage <= 0.25f)
        {
            color.color = Color.red;
        }
        else if (healthpercentage <= 0.5f)
        {
            color.color = Color.yellow;
        }
    }

    protected void Start()
    {
        pathTarget = LevelManager.main.Path[pathIndex];
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    protected void FixedUpdate()
    {
        Vector2 direction = (pathTarget.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        healthBar.transform.localScale = new Vector3(healthBar.localScale.x - (damage / health), 0.1f, 1f);
    }
}