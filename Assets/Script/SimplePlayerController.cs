using UnityEngine;

    public class SimplePlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 10f;
        // 水平速度限制
        public float horizontalSpeedLimit = 6f;
        // 上升速度限制
        public float UpSpeedLimit = 6f;
        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
            }
        }
        void FixedUpdate()
        {
            if (alive)
                Jump();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }

        // 角色移动
        void Jump()
        {
            float move = 0f;
            // float jump = 0f;
            // 获取到跳跃的输入
            if ((Input.GetButton("Jump") || Input.GetAxisRaw("Vertical") > 0))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
                move = 0;
                // jump = jumpPower;
            } 
            // 水平向右则往左飞
            if(Input.GetAxisRaw("Horizontal") < 0)
            {
                isJumping = true;
                anim.SetBool("isJump", true);
                move = movePower;
                transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                // jump = jumpPower / 2;
            }
            // 水平向左则往右飞
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                isJumping = true;
                anim.SetBool("isJump", true);
                move = -movePower;
                transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
                // jump = jumpPower / 2;
            }
            if (!isJumping)
            {
                return;
            }

            // Vector2 jumpVelocity = new Vector2(move, jumpPower);
            // 改变速度使其飞行
            rb.velocity = new Vector2(rb.velocity.x + move, rb.velocity.y + jumpPower);
            // rb.AddForce(jumpVelocity, ForceMode2D.Force);
            // 设置速度限制
            if(rb.velocity.y > UpSpeedLimit)
            {
                rb.velocity = new Vector2(rb.velocity.x, UpSpeedLimit);
            }
            if(rb.velocity.x > horizontalSpeedLimit)
            {
                rb.velocity = new Vector2(horizontalSpeedLimit, rb.velocity.y);
            }
            if(rb.velocity.x < -horizontalSpeedLimit)
            {
                rb.velocity = new Vector2(-horizontalSpeedLimit, rb.velocity.y);
            }

            // rb.velocity = jumpVelocity;

            isJumping = false;
        }

        // 播放攻击动画
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack");
            }
        }

        // 播放受击动画
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }

        // 播放死亡动画
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("die");
                alive = false;
            }
        }

        // 死亡后重新开始
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
