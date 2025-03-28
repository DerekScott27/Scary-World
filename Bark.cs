using UnityEngine;

public class Bark : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damageAmount = 25f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(damageAmount);

            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "TileMap")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<BossScript>().TakeDamage(damageAmount);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Door")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bark")
        {
            Destroy(gameObject);
        }

    }
    


}
