using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int HP = 100;
    private Animator animator;
    [SerializeField] GameObject Drop;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void modifyHP(int x)
    {
        HP += x;

        if (HP <= 0)
        {
            if (animator != null)
                animator.SetBool("dead", true);
            else
                death();
        }
    }

    public void death()
    {
        Instantiate(Drop, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
