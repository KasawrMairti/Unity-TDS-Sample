using UnityEngine;

public class Zombie : MonoBehaviour, IDamagable
{
    [SerializeField] private float moveSpeed = 1.0f;
    private int lineCur;

    private Rigidbody2D rigidBody;
    private Animator animator;

    // Zombie Status

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        lineCur = Random.Range(0, 3);

        if (lineCur == 0) gameObject.layer = LayerMask.NameToLayer("FirstLine");
        else if (lineCur == 1) gameObject.layer = LayerMask.NameToLayer("SecondLine");
        else if (lineCur == 2) gameObject.layer = LayerMask.NameToLayer("ThirdLine");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = new(transform.position.x, transform.position.y, transform.position.y / 100f);

        rigidBody.AddForce(Vector2.left * moveSpeed, ForceMode2D.Force);
        rigidBody.velocity = rigidBody.velocity.x < -moveSpeed ? rigidBody.velocity : new(-moveSpeed, rigidBody.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Zombie"))
        {

        }
    }

    public void Damaged()
    {
        
    }
}
