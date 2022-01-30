using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour
{
    public float            Range = 20;
    public string           PlayerTag;
    public Transform        eyes;
    private Cop_Movement    Legs;
    public bool             meele = false;
    public float            ShootTimer = 5;
    private float           timer = 0;
    public GameObject       DamageZone;
    public bool             SeePlayer = false;
    private bool            Shoot = false;
    public GameObject       Bullet;
    public Transform        ShootingPoint;
    private Health          hp;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<BoxCollider2D>().size = new Vector2(Range, gameObject.GetComponentInChildren<BoxCollider2D>().size.y);
        Legs = GetComponent<Cop_Movement>();
        hp = GetComponent<Health>();
        timer = ShootTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is in line of ssight and within range stops andattacks
        if (!hp.isDead())
        {
            RaycastHit2D hit2D = Physics2D.Raycast(ShootingPoint.position, gameObject.transform.right, Range);
            if(hit2D.transform.tag == PlayerTag)
                SeePlayer = true;
            else
                SeePlayer = false;
            if (SeePlayer && timer <= 0)
            {
                Legs.move = false;
                attack();
                timer = ShootTimer;
            }
            else if (!SeePlayer)
            {
                Legs.move = true;
                print("test");
            }

            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
        }
        else
            Legs.move = false;
    }

    //attacks if it is a range enemy it shoots if not it doers an meele attack
    private void attack()
    {

        if (meele)
        {
            GetComponent<Animator>().SetTrigger("attack");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("shoot");
        }
    }

    public void MelleAttack()
    {
        DamageZone.gameObject.SetActive(true);
    }

    public void stopAttack()
    {
        DamageZone.gameObject.SetActive(false);
    }

    public void shoot()
    {
        Instantiate(Bullet, ShootingPoint.position, ShootingPoint.rotation);
        Shoot = false;
    }
}
