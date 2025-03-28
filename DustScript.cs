using UnityEngine;

public class DustScript : MonoBehaviour
{
    private float damageAmount = 25f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(damageAmount);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "TileMap")
        {
            Destroy(gameObject);
        }
    }
}
