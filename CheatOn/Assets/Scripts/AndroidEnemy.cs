
using UnityEngine;

public class AndroidEnemy : Enemy
{
    public Transform RightPoint;
    public Transform LeftPoint;
   
   

    void Update()
    {


        if (transform.position.x >= RightPoint.position.x)
        {

            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if (transform.position.x <= LeftPoint.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

   
}