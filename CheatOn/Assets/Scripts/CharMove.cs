using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class CharMove : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int speed;
    [SerializeField] public int jumpheight;
    double invulnerability = 0;
    public PauseScript Pause_Panel;
    Rigidbody2D rgbd;
    bool is_ground = false;
    HUD_Script HUD_Panel;
    Animator anim;
    public AudioClip HitSound;
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        HUD_Panel = FindObjectOfType<HUD_Script>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) { Time.timeScale = 0; Pause_Panel.gameObject.SetActive(true); };
        if (is_ground)
        {
            if (Input.GetButton("Horizontal")) { Run(); };
            if (Input.GetButtonDown("Jump")) { Jump(); }

        }
        if (invulnerability > 0)
            invulnerability -= Time.deltaTime;
        Animator();
    }

    void Run()
    {
        if (Input.GetAxis("Horizontal") >= 0)
        {
            rgbd.velocity = new Vector2(speed, rgbd.velocity.y);
            if (transform.eulerAngles.y == 180)
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            rgbd.velocity = new Vector2(-speed, rgbd.velocity.y);
            if (transform.eulerAngles.y == 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
    void Jump()
    {
        rgbd.AddForce(Vector2.up * jumpheight, ForceMode2D.Impulse);
    }
    void GetDamage(int num)
    {
        health -= num;
        if (health > 5)
            health = 5;
        HUD_Panel.Resize(health);
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GetDamage(-7);
        }
    }

    void Animator()
    {
        anim.SetBool("is_run", rgbd.velocity.x != 0);
        if (Input.GetButtonDown("Jump") && (is_ground))
            anim.SetBool("is_jump", true);
        else
            anim.SetBool("is_jump", false);
    }
    void OnTriggerStay2D(Collider2D col)
    {

        switch (col.gameObject.tag)
        {
            case "Platform":
                {
                    if (col.transform.position.y < transform.position.y)
                    {
                        if (Input.GetAxis("Horizontal") == 0)
                            rgbd.velocity = new Vector2(0, rgbd.velocity.y);
                        is_ground = true;
                    }
                }
                break;
            case "Box":
                {
                    if (col.transform.position.y < transform.position.y)
                    {
                        if (Input.GetAxis("Horizontal") == 0)
                            rgbd.velocity = new Vector2(0, rgbd.velocity.y);
                        is_ground = true;
                    }
                }
                break;
            case "Ladder":
                {
                    is_ground = true;
                }
                break;
            case "Vitaminka":
                {
                    GetDamage(-2);
                    print("-");
                    Destroy(col.gameObject);
                }
                break;
            case "Code":
                {
                    Destroy(col.gameObject);
                    print("+");
                    HUD_Panel.Collect();

                }
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        switch (col.tag)
        {
            case "Platform":
                is_ground = false;
                break;
            case "Box":
                is_ground = false;
                break;
            case "Ladder":
                {
                    is_ground = false;
                }
                break;
            case "Enemy":
                {
                    if (!((col.gameObject.name == "Robot_Android") && (!(is_ground) && (transform.position.y - col.transform.position.y > 1))))
                        if (invulnerability <= 0)
                        {
                            GetDamage(1);
                            invulnerability = 1;
                        }
                }
                break;

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.tag)
        {
            case "Portal":
                {
                    HUD_Panel.EndOfScene();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                break;
            case "DeadZone":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case "Bullet":
                {
                    if (col.GetComponent<BulletMove>().owner == "Enemy")
                    {
                        GetComponent<AudioSource>().PlayOneShot(HitSound);
                        GetDamage(col.GetComponent<BulletMove>().damage);
                        Destroy(col.gameObject);
                    }


                }
                break;


            case "Enemy":
                {
                    if (col.gameObject.name == "Robot_Android")
                        if (!(is_ground) && (transform.position.y - col.transform.position.y > 1))
                            Destroy(col.gameObject);
                        else
                            rgbd.AddForce(Vector2.up * 2 + (transform.eulerAngles.y == 0 ? Vector2.left : Vector2.right) * 2, ForceMode2D.Impulse);
                    else


                        rgbd.AddForce(Vector2.up * 3f + (transform.eulerAngles.y == 0 ? Vector2.left : Vector2.right) * 3f, ForceMode2D.Impulse);
                }
                break;
            case "Batut":
                {
                    if (rgbd.velocity.x == 0)
                        rgbd.velocity = new Vector2(2, rgbd.velocity.y);
                    rgbd.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
                }
                break;
            case "Ladder":
                {
                    is_ground = true;
                }
                break;
            case "Box":
                {
                    is_ground = true;
                }
                break;
            case "Platform":
                {
                    is_ground = true;
                }
                break;
        }

    }



}



