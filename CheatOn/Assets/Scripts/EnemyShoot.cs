using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public BulletMove bulletEnemy;
    [SerializeField] public double reloadtime = 0.4;
    [SerializeField] public double reload;
    Animator ShootAnim;
    public AudioClip ShootSound;
    public Transform BulletPos;
    void Start()
    {
        reload = 0;
        ShootAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Physics2D.Raycast(BulletPos.transform.position, (transform.eulerAngles.y == 180 ? Vector2.left : Vector2.right), 15 * (gameObject.name == "Boss" ? 20 : 1)))
            if (Physics2D.Raycast(BulletPos.transform.position, (transform.eulerAngles.y == 180 ? Vector2.left : Vector2.right), 15 * (gameObject.name == "Boss" ? 20 : 1)).collider.gameObject.tag == "Player")
            {

                if (reload <= 0)

                    ShootAnim.SetBool("is_shoot", true);

                else

                    reload -= Time.deltaTime;
            }
    }
    void Fire()
    {

        GetComponentInParent<AudioSource>().PlayOneShot(ShootSound);
        reload = reloadtime;
        BulletMove NewBullet = Instantiate(bulletEnemy, BulletPos.position, transform.rotation) as BulletMove;
        NewBullet.owner = "Enemy";
        ShootAnim.SetBool("is_shoot", false);

    }

}
