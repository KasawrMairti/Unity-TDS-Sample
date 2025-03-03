using UnityEngine;

public class Zombie : MonoBehaviour, IDamagable
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float jumpSpeed = 5.0f;
    private string maskCur = "";
    private int lineCur;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private GameObject targetObj;

    // Zombie Status
    private bool zombieCollision = false;
    private float jumpCooltimeMax = 1.0f;
    private float jumpCooltime = 0.0f;
    private bool playerCollision = false;
    private Vector3 lastAtkPos = Vector3.zero;

    [SerializeField] private float hpMax = 5.0f;
    private float hp;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        hp = hpMax;
    }

    private void OnEnable()
    {
        lineCur = Random.Range(0, 3);

        if (lineCur == 0) maskCur = "FirstLine";
        else if (lineCur == 1) maskCur = "SecondLine";
        else if (lineCur == 2) maskCur = "ThirdLine";

        gameObject.layer = LayerMask.NameToLayer(maskCur);
    }

    private void FixedUpdate()
    {
        animator.SetBool("IsAttacking", playerCollision);

        if (playerCollision) return;

        Move();
        Jump();
    }

    private void Move()
    {
        transform.position = new(transform.position.x, transform.position.y, transform.position.y / 100f);

        rigidBody.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
        rigidBody.velocity = new Vector2(Mathf.Max(-moveSpeed, rigidBody.velocity.x), rigidBody.velocity.y);
    }

    private void Jump()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 0.55f, LayerMask.GetMask(maskCur));
        gameObject.layer = LayerMask.NameToLayer(maskCur);
        if (hit.collider != null && (hit.collider.CompareTag("Zombie") || hit.collider.CompareTag("Truck")))
        {
            if (jumpCooltime > jumpCooltimeMax)
            {
                jumpCooltime = 0.0f;

                rigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
            else jumpCooltime += Time.fixedDeltaTime;
        }
    }

    private void OnAttack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3.up * 0.5f), Vector2.left, 0.75f, LayerMask.GetMask("Player"));
        if (hit.collider != null && hit.collider.CompareTag("Hero"))
        {
            if (hit.collider.TryGetComponent<IDamagable>(out var obj))
            {
                obj.Damaged(1.0f);

                UIManager.Instance.TextEnable(lastAtkPos, Random.Range(1.0f, 2.0f).ToString("F1"), Color.red);
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Hero"))
        {
            playerCollision = true;
            targetObj = collision.gameObject;
            lastAtkPos = collision.contacts[0].point;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Hero")) 
            playerCollision = false;
    }

    public void Damaged(float damaged)
    {
        hp -= damaged;

        if (hp <= 0)
        {
            playerCollision = false;
            gameObject.SetActive(false);
        }
    }
}
