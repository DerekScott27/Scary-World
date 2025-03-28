using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
 /*   private GameObject attackArea = default;  //creating the attack area variable/object based on the premade gameObject class.

    private bool attacking = false; //creating a boolean variable called attacking and setting its value to false by default

    private float timeToAttack = 0.25f; //creating a float variable called timeToAttack and setting its defualt time to 0.25float

    private float timer = 0f; //creating a float var called timer which is equal to 0

    private int damage = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   /* void Start()
    {
        attackArea = transform.GetChild(0).gameObject; //transform is a unity class that represents the positon,rotation and scale of a gameobject
                                      //.GetChild is a method/function within the transform class thatreturns the gmaeojbect to a spefiic value, in this case the value is 0.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))  //if statement using the input class and .getmousebuttondown method 0 is left mouse click
        {
            Attack(); //calling the attack function we made below
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemyComponent))
        { 
            enemyComponent.TakeDamage(25); 
        
        }
            
        Destroy(gameObject);
    }
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        DamageEnemy();
    }


    private void DamageEnemy()
    {
        Vector2 direction = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        Debug.DrawRay(transform.position, direction, Color.red);
        if (hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        else
        {
            Debug.LogError("Enemy doesn't have a Health component!");
        }
    }

    /*RaycastHit2D hit;                                             //1. Define a variable /object to store the RaycastHit2d (class) result in

    hit = Physics2D.Raycast(transform.position, transform.right); //2. hit = Physics2d class.Raycast object, setting position of the cast to the right

    Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);

    if (hit.collider != null)                                    //3. if hit variable.collider (collider being an object of hit and a property of the raycast2d struct)


    {
        hit.collider.gameObject.GetComponent<Health>().TakeDamage(damage); 
    }

    else
    {
        Debug.LogError("Enemy doesn't have a Health component!");
    }

    */
    //Overall the above line is saying

    //1. "Take the hit object, get the collider that was hit,

    //2. get the GameObject that the collider is attached to,

    //3. get the Health component attached to that GameObject,

    //4. and call the TakeDamage method on that Health component,

    //5. passing in the damage variable as an argument."

}
