using UnityEngine;

public class MovePlatScript : MonoBehaviour
{
    public float speed = 3f;

    public Transform[] waypoints;
    private int ArrayIndex = 0;


    void Update()
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
        transform.position = Vector2.MoveTowards(transform.position, waypoints[ArrayIndex].transform.position, speed * Time.deltaTime);


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (((col.gameObject.tag == "Player") || (col.gameObject.tag == "Box") || (col.gameObject.tag == "Enemy")) && (col.transform.position.y > transform.position.y))
            col.transform.parent = transform;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "Box") || (col.gameObject.tag == "Enemy"))
            col.transform.parent = null;
    }
}