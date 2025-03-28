


using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] float Health;

    private float lastShotTime = 0f;
   
    
    private float cooldownPeriod = 0.5f;
    public BossWeaponScript bossWeapon;
    public float attackDamage = 25f;
    public float speed = 50f;
    public float patrolDistance = 2f;
    public float patrolDuration = 2f;

    public bool isFacingRight = true;
    private bool movingRight = true;
    private float timer = 60f;
    private float horizontal;
    private float targetPosition;
    public Collider2D bossCollider;

    void Start()
    {
        Health = 500f;
        
        transform.localScale = new Vector2(5, 5);
        targetPosition = transform.position.x + patrolDistance;

        speed = 20f;
        patrolDistance = 15f;
        patrolDuration = 2;

        bossWeapon = GetComponentInChildren<BossWeaponScript>();

    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
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
            if (movingRight)
            {
                targetPosition = transform.position.x + patrolDistance;
            }
            else
            {
                targetPosition = transform.position.x - patrolDistance;
            }
        }
       
        horizontal = movingRight ? -1f : 1f;
        
        Flip();
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }

        if (Time.time - lastShotTime >= cooldownPeriod)
        {
            bossWeapon.bFire();
            lastShotTime = Time.time;
        }

    }

}