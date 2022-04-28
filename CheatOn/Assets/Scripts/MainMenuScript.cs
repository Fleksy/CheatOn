using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Transform SetMenu;
    public Transform Tutorial;
    public void StartGame()
    {
        SceneManager.LoadScene("level1");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) {  Back(); };
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SetMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void TutorialButton()
    {
       Tutorial.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Back()
    {
        Tutorial.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

}
