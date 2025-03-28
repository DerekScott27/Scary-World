using UnityEngine;

public class Health : MonoBehaviour
{

    public int MaxHealth = 100;  //making max health variable setting it to 100

    public int CurrentHealth; //maknig current health variable 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;  //starts the program setting current health equal to max health
  
    }

    public void TakeDamage(int damage)  // creates a method TakeDamage that returns our outputs nothing (with the void prefix)
    {                                         //with the integer called damage being the parameter, or the thing that the function affects

         //In the EnemyAttack script i will make, that is where we set the damage amount.
        
        CurrentHealth -= damage;   //the -= decreases the value of the CurrenthHealth variable and then reassigns it

        if (CurrentHealth <= 0) //creates the if statement saying if currenthelth <= 0, run the function called Die
        {
            Die();
        }
    }

    void Die()  //creates the die function which destroys a gameobject
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
