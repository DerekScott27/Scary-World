using UnityEngine;

public class Weapon : MonoBehaviour
{
   
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 10f;
    public PlayerMovement playerMovement;




    public void Fire()
    {
        GameObject bark = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector2 forceDirection = playerMovement.isFacingRight ? firePoint.right : -firePoint.right;
        bark.GetComponent<Rigidbody2D>().AddForce(forceDirection * fireForce, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(bark.GetComponent<Collider2D>(), playerMovement.playerCollider);
    }

}


/*public void Fire(Collider2D playerCollider)
{
    GameObject bark = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    bark.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    Physics2D.IgnoreCollision(bark.GetComponent<Collider2D>(), playerCollider);
}

}

/*public void Fire()
{
    GameObject Bark = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Bark.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);


}
// Start is called once before the first execution of Update after the MonoBehaviour is created

}
*/