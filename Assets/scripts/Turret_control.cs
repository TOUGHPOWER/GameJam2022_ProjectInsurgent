using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_control : MonoBehaviour
{
    private GameObject          player;
    private LineRenderer        laser;
    [SerializeField] Transform  laserPos;
    [SerializeField] Transform  gunPos;
    [SerializeField] bool       search = true;
    private float               targetx = 0;
    private float               targety = 0;
    [SerializeField] float      Cooldown = 5;
    private float               timer = 0;
    [SerializeField] GameObject projectile;
    private Animator            animator;
    void Start()
    {
        player = FindObjectOfType<Player_controller>().gameObject;
        laser = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (search)
        {
            targetx = player.transform.position.x;
            targety = player.transform.position.y;

            laser.SetPosition(0, laserPos.position);

            Vector2 dir = new Vector2(targetx - laserPos.position.x, targety - laserPos.position.y);

            RaycastHit2D hit = Physics2D.Raycast(laserPos.position, dir);

            
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            gunPos.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            if (hit.transform.tag == player.tag)
            {
                timer = Cooldown;
                search = false;
            }

            laser.SetPosition(1, new Vector3(hit.point.x, hit.point.y, -0.1f));
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                animator.SetTrigger("shoot");
        }


    }

    private void shoot()
    {
        search = true;
        Instantiate(projectile,gunPos.position, gunPos.rotation);
    }
}
