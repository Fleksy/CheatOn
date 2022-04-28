using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform box;
    public Transform enemy;
    public Transform vitaminca;
    public Transform[] points = new Transform[3];
    System.Random rnd = new System.Random();
    public double reload;
    public double reloadtime = 2;


    void Update()
    {
        if (reload > 0)
        {
            reload -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Player") && (reload <= 0))
        {
            int n = rnd.Next(4);
            int k = rnd.Next(100);
            if (k <= 50)
            {
                Instantiate(box, points[n].transform.position + new Vector3(rnd.Next(-5, 5), 1, 0), transform.rotation);
            }
            else if ((k > 50) && (k < 71))
            {
                Instantiate(vitaminca, points[n].transform.position + new Vector3(rnd.Next(-5, 5), 1, 0), transform.rotation);
            }
            else if (k > 80)
            {
                Transform robot = Instantiate(enemy, points[n].transform.position + new Vector3(rnd.Next(-5, 5), 1, 0), transform.rotation);
                if (transform.position.x < robot.transform.position.x)
                    robot.transform.eulerAngles = new Vector3(0, 180, 0);

            }

            reload = reloadtime;


        }

    }
}
