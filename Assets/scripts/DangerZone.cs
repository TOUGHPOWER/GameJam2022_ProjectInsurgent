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

    private List<GameObject>    targets = new List<GameObject>();


    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < hitTags.Length; i++)
        {
            if (collision.gameObject.tag == hitTags[i])
            {
                if (animator != null)
                    animator.SetTrigger("hit");
                else
                    hit();
                lastObgectHit = collision.gameObject;

                GameObject temp;
                GameObject gameObject1 = targets.Find(temp => temp == collision.gameObject);
                if (gameObject1 == null)
                    targets.Add(collision.gameObject);
                hited = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        targets.Remove(collision.gameObject);
    }


    public void hit()
    {
        foreach(GameObject temp in targets)
        {
            if (temp.tag == hitTags[0])
            {
                if (temp.GetComponent<Health>() != null)
                    temp.GetComponent<Health>().modifyHP(-Damage);
                else
                    temp.GetComponent<Player_controller>().Hp.modifyHP(-Damage);
            }
        }

        
        if (DestroyOnImpact && !waitForAnimation)
            Destroy(gameObject);

    }

    public void destry()
    {
        Destroy(gameObject);
    }
}
