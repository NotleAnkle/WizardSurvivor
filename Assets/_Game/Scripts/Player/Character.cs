using _Framework.Pool.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    [SerializeField] private Animator anim;
    [SerializeField]protected float speed = 5f;
    protected int hp = 3;

    public int HP => hp;
    protected bool isDamaging = false;

    private string currentAnimName;

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName && !isDamaging)
        {
            anim.ResetTrigger(animName);

            if (currentAnimName != null)
            {
                anim.ResetTrigger(currentAnimName);
            }

            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }

    public virtual void OnHit()
    {
        if(!isDamaging)
        {
            hp--;
            ChangeAnim(Constant.ANIM_HIT);
            isDamaging = true;
            if (hp <= 0)
            {
                OnDeath();
            }
            StartCoroutine(ResetHit());
        }
    }
    private IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(0.15f);
        isDamaging = false;
    }
    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
