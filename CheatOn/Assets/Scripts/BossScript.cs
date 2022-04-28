using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int speed;
    public Transform RightPoint;
    public Transform LeftPoint;
    public Transform player;
    public Transform BossLocation;
    public Switch Exit;
    public AudioClip PunchSound;
    public AudioClip HitSound;
    public AudioClip DeathSound;
  
    
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

        BossLocation.gameObject.SetActive(player.transform.position.y >= BossLocation.transform.position.y);
    }
    void Dead()
    {
        GetComponentInParent<AudioSource>().PlayOneShot(DeathSound);
        Exit.activated = true;
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Box"))
        {
            if (col.gameObject.transform.position.y > transform.position.y)
            {
                GetComponentInParent<AudioSource>().PlayOneShot(PunchSound);
                health--;
                if (health <= 0)
                    Dead();
            }
            Destroy(col.gameObject);
        }



    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Bullet") && (col.gameObject.GetComponent<BulletMove>().owner != "Enemy"))
        {
            GetComponentInParent<AudioSource>().PlayOneShot(HitSound);
            Destroy(col.gameObject);
        }
    }
}
