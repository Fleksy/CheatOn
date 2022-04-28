using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int speed;
    public AudioClip HitSound;
    public AudioClip DeathSound;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (col.GetComponent<BulletMove>().owner == "character")
            {
                GetComponentInParent<AudioSource>().PlayOneShot(HitSound);
                Destroy(col.gameObject);
                health--;
                if (health <= 0)
                {
                    GetComponentInParent<AudioSource>().PlayOneShot(DeathSound);
                    Destroy(gameObject);
                 
                }
            }

        }
        if ((col.gameObject.tag == "Box"))
        {
            if (col.gameObject.transform.position.y > transform.position.y)
                Destroy(gameObject);
            else
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y == 180 ? 0 : 180, 0);
        }
    } 
}
