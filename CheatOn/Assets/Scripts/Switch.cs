using UnityEngine;

public class Switch : MonoBehaviour
{
    public Transform Platform;
    public Transform FinalPos;
    public bool activated;
    void Update()
    {
        if (activated)
        {
            Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, FinalPos.transform.position, 10 * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        activated = col.gameObject.tag == "Player";
        if(activated)
            GetComponent<SpriteRenderer>().flipX = true;
       
    }

}
