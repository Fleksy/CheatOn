using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    
    public float speed = 3f;

    public Transform[] waypoints;
    private int ArrayIndex =0 ;



    void Update()
    {

        
        transform.position = Vector2.MoveTowards(transform.position, waypoints[ArrayIndex].transform.position, speed * Time.deltaTime);
        CheckWayPoint();

    }

    void CheckWayPoint()
    {
        if (Vector2.Distance(transform.position, waypoints[ArrayIndex].transform.position) < 0.1f)
        {
            if (ArrayIndex + 1 == waypoints.Length)
            {
                ArrayIndex = 0;
            }
            else
            {
                ArrayIndex++;
            }

        }
    }
}
