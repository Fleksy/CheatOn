using UnityEngine;

public class LadderScript : MonoBehaviour
{
    
   
   void  OnTriggerStay2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().gravityScale = 0;
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2 * Input.GetAxis("Vertical"));
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
