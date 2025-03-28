
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverMenu; // Assign this in the inspector
    

    public PlayerScript playerScript;

    public GameObject canvas; //making a slot for the Canvas in the inspector so i can place the specific Canvas in that slot, so then i can reference that canvas from code.

    private Canvas canvasComponent;   //using the built in Canvas function, create an object of it called canvasComponent.

    void Start()
    {
        // Initially, the game over canvas should be disabled
        gameOverMenu.SetActive(false);

        canvasComponent = canvas.GetComponent<Canvas>(); 

    }

    private void SetPlaneDistance()            //function to call the canvas.Getcomponent<canvas> method and set the value of plane distance to 40 (because the gameover ui disapears if it spawns immediately
    {
        canvasComponent.planeDistance = 40f;
    }

    private void Update()
    {
        if (playerScript.isPlayerDead == true)
        {

            gameOverMenu.SetActive(true);
            Invoke("SetPlaneDistance", 3f); //Using the invoke method to then call the SetPlaneDistance method, then 3f to give it 3 seconds for the UI plane distance to update.
        }

    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}


