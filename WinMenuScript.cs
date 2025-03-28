using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuScript : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject canvas;
    private Canvas canvasComponent;
    public PlayerScript playerScript;
    private void SetPlaneDistance()            //function to call the canvas.Getcomponent<canvas> method and set the value of plane distance to 40 (because the gameover ui disapears if it spawns immediately
    {
        
        canvasComponent.planeDistance = 40f;
    }
    public void YouWin()
    {
        winMenu.SetActive(true);
        Invoke("SetPlaneDistance", 3f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winMenu.SetActive(false);
        canvasComponent = canvas.GetComponent<Canvas>();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
