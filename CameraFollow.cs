using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 targetPoint = Vector3.zero;  //sets the targetPoint vector3 var at a value of 0

    public PlayerMovement player;

    public float moveSpeed;

    public PlayerScript playerScript;

    public GameObject gameOverMenu;

    private Vector3 deathPosition;

    public GameObject winMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        targetPoint = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }

    void LateUpdate()
    {
        targetPoint.x = player.transform.position.x;
        targetPoint.y = player.transform.position.y;

        if(targetPoint.y < 0)
        {
            targetPoint.y = 0;
        }
        //transform.position = targetPoint;

        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        deathPosition = transform.position;


        if (playerScript.isPlayerDead)
        {
            

            gameOverMenu.transform.position = deathPosition;

            gameOverMenu.SetActive(true);
        }

        if (playerScript.isDoorOpened == true)
        {
            winMenu.transform.position = new Vector3(212.4362f, -1.929863f, 0f);

        }
    }
   
 
        
    
}
