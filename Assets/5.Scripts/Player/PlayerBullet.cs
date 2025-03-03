using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;

    private Vector3 dir;

    private float timelimit = 0.0f;
    private float timelimitMax = 5.0f;

    private void OnEnable()
    {
        timelimit = 0.0f;
    }

    private void Update()
    {
        if (timelimit > timelimitMax) gameObject.SetActive(false);
        else timelimit += Time.deltaTime;

        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    public void SetDir(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;
        this.dir = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Zombie"))
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();

            float Damage = Random.Range(1.0f, 2.0f);

            zombie.GetComponent<IDamagable>().Damaged(Damage);
            UIManager.Instance.TextEnable(transform.position, Damage.ToString("F1"), Color.white);

            gameObject.SetActive(false);
        }
    }
}
