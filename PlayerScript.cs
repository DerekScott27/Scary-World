using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float Health, maxHealth = 100f;

    public GameOverScript gameOverScript;


    public GameObject canvas;
    public bool isPlayerDead = false;
    public WinMenuScript winMenuScript;
    public bool isDoorOpened = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = maxHealth;
    }

    private void Update()
    {
        if (isPlayerDead == true)
        {
            gameOverScript.gameOverMenu.SetActive(true);
            
        }

        
       
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            Invoke("DestroyPlayer", 1f);
            isPlayerDead = true;
            //Destroy(gameObject);
        }
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);

       
          
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float damageAmount = collision.gameObject.GetComponent<EnemyScript>().attackDamage;

            TakeDamage(damageAmount);
        }

        if (collision.gameObject.tag == "Boss")
        {
            float damageAmount = collision.gameObject.GetComponent<BossScript>().attackDamage;

            TakeDamage(damageAmount);
        }

        if (collision.gameObject.tag == "Door")
        {
            winMenuScript.YouWin();
            isDoorOpened = true;
        }

    }

}
