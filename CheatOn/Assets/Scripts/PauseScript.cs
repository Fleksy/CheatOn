using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public Transform SetMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Resume(); };
    }
    // Start is called before the first frame update
    public void Resume()
    {
        gameObject.SetActive(false);
        
        Time.timeScale = 1;

    }
    public void Settings()
    {
        SetMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Skip()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
