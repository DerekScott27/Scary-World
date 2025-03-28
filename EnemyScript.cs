

using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float Health, maxHealth = 100f;
    public float attackDamage = 25f;
    public float speed = 15f;
    public float patrolDuration = 4f;
    private bool movingRight = true;
    private float timer = 0f;

    public Vector2 initialScale = new Vector2(1.5026f, 1.97121f); // Set the initial scale
    private Vector2 directionalScale = new Vector2(-1, 1); // Initial directional scale

    void Start()
    {
        Health = maxHealth;
        transform.localScale = initialScale; // Set initial scale
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bark")
        {
            float damageAmount = collision.gameObject.GetComponent<Bark>().damageAmount;
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(attackDamage);
        }
    }

    void Update()
    {
        

        timer += Time.deltaTime;

        if (timer >= patrolDuration)
        {
            movingRight = !movingRight;
            timer = 0f;

            // Only set the local scale when the direction changes
            if (movingRight)
            {
                directionalScale = new Vector2(-1, 1); // Face Right
            }
            else
            {
                directionalScale = new Vector2(1, 1); // Face left
            }

            // Apply both initial scale and directional scale
            transform.localScale = initialScale * directionalScale;
        }

        // Move the enemy
        if (movingRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

    }
}