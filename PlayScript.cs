using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public GameObject Canvas;
    

    public void gameOfficial()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
