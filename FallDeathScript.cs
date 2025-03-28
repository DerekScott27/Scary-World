using UnityEngine;

public class FallDeathScript : MonoBehaviour
{

  
    public float attackDamage = 25f;


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(attackDamage);
        }
    }

}
