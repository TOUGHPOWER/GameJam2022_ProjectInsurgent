using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] bool       DestroyOnImpact = true;
    [SerializeField] int        Damage = 10;
    [SerializeField] string[]   hitTags;
    private Animator            animator;
    private GameObject          lastObgectHit;
    public bool                 hited;
    [SerializeField] bool       waitForAnimation = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        for (int i = 0; i < hitTags.Length; i++)
        {
            if (collision.gameObject.tag == hitTags[i])
            {
                if (animator != null)
                    animator.SetTrigger("hit");
                else
                    hit();
                lastObgectHit = collision.gameObject;
                hited = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == lastObgectHit.name)
            lastObgectHit = null;
    }

    public void hit()
    {
        if (lastObgectHit.tag == hitTags[0])
        {
            if(lastObgectHit.GetComponent<Health>()!= null)
                lastObgectHit.GetComponent<Health>().modifyHP(-Damage);
            else
                lastObgectHit.GetComponent<Player_controller>().Hp.modifyHP(-Damage);
        }
        if (DestroyOnImpact && !waitForAnimation)
            Destroy(gameObject);
    }

    public void destry()
    {
        Destroy(gameObject);
    }
}
