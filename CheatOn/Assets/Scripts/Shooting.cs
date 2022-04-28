using UnityEngine;

public class Shooting : MonoBehaviour
{


    public AudioClip ShootSound;
    [SerializeField] public BulletMove bullet;
    Animator ShootAnim;

    [SerializeField] public double reloadtime = 0.4;

    double reload;

    void Start()
    {
        reload = 0;
        ShootAnim = GetComponent<Animator>();
       
        
    }


    void Update()
    {
        if (reload <= 0)
        {
            
            if (Input.GetButtonDown("Fire1") && (Time.timeScale == 1))
            {
                
                ShootAnim.SetBool("is_shoot", true);
              

            }
            


        }


        else
        {
            reload -= Time.deltaTime;

        }

    }

    void Fire()
    {


        GetComponent<AudioSource>().PlayOneShot(ShootSound);
        reload = reloadtime;
        BulletMove NewBullet = Instantiate(bullet, GetComponentInChildren<Transform>().position, transform.rotation) as BulletMove;
        NewBullet.owner = "character";
        ShootAnim.SetBool("is_shoot", false);


    }
    
}
