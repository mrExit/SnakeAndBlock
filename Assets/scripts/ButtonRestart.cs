using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonRestart : MonoBehaviour
{
    
    public void RestartLevel()
    {
        Debug.Log(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
    }
}
