using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public Transform MainMenu;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) { MainMenu.gameObject.SetActive(true); gameObject.SetActive(false); };
    }
}
