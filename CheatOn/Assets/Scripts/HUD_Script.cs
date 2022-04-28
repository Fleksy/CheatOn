using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD_Script : MonoBehaviour
{
    Transform LifePanel;
    Transform[] hearts = new Transform[5];
    Transform CodePanel;
    int point;
    public static int PointAtStart;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            PointAtStart = 0;
        point = PointAtStart;
        LifePanel = transform.GetChild(0);

        for (int i = 0; i < 5; i++)
        {
            hearts[i] = LifePanel.transform.GetChild(i);
        }
        CodePanel = transform.GetChild(1);
        CodePanel.GetComponent<Text>().text = $"{point}";


    }


    public void Resize(int num)
    {

        for (int i = 0; i < 5; i++)
        {
            hearts[i].gameObject.SetActive(i < num);
        }
    }
    public void Collect()
    {
        point++;
        CodePanel.GetComponent<Text>().text = $"{point}";

    }
    public void EndOfScene()
    {
        PointAtStart = point;
    }

}
