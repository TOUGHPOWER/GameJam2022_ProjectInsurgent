using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int HP = 100;
    [SerializeField] int maxHP = 100;
    private Animator animator;
    [SerializeField] GameObject Drop;

    private void Start()
    {
        animator = GetComponent<Animator>();
        HP = maxHP;
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

        if(HP > maxHP)
            HP = maxHP;

        if (x < 0 && animator != null)
            animator.SetTrigger("hurt");
    }

    public void death()
    {
        Instantiate(Drop, transform);
        Destroy(gameObject);
    }
}
