using _Framework.Event.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Rigidbody2D rb;

    private float horizontal, verticle;

    // Update is called once per frame
    void Update()
    {

        if (joystick.Direction != Vector2.zero)
        {
            Move();
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeAnim(Constant.ANIM_IDLE);
        }
    }

    public override void OnHit()
    {
        base.OnHit();
        this.PostEvent(EventID.OnPlayerHit);
    }

    public override void OnDeath()
    {
        base.OnDeath();
    }

    private void Move()
    {
        horizontal = joystick.Horizontal;
        transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));

        Vector2 inputDirection = joystick.Direction;
        bool isMove = false;

        if (inputDirection.y > 0.5f)
        {
            ChangeAnim(Constant.ANIM_WALK_UP);
            isMove = true;
        }
        else if (inputDirection.y < -0.5f)
        {
            ChangeAnim(Constant.ANIM_WALK_DOWN);
            isMove = true;
        }

        if (Mathf.Abs(inputDirection.x) > 0.5f && !isMove)
        {
            ChangeAnim(Constant.ANIM_WALK_SIDE);
            isMove = true;
        }

        if (isMove)
        {
            rb.velocity = inputDirection * speed;
        }
    }

}
