using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public  int speed = 10;
    public string owner;
   
    void Start()
    {
        
        Destroy(gameObject, 10);

    }

    
    void Update()
    {
        transform.Translate(UnityEngine.Vector2.right * speed * Time.deltaTime);
    
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Platform") || (col.gameObject.tag == "Box"))
        {
            Destroy(gameObject);
        }
    }
  
}
