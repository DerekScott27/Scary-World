using UnityEngine;

public class BossWeaponScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 10f;
    public BossScript bossScript;

    public void bFire()
    {
        GameObject Dust = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector2 forceDirection = bossScript.isFacingRight ? firePoint.right : -firePoint.right;
        Dust.GetComponent<Rigidbody2D>().AddForce(forceDirection * fireForce, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(Dust.GetComponent<Collider2D>(), bossScript.bossCollider);
    }
}
