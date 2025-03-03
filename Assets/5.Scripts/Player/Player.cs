using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject hpPanel;
    [SerializeField] private Slider slider;

    [SerializeField] private float hpMax;
    private float hp;

    [SerializeField] private Transform playerGun;
    [SerializeField] private GameObject bulletPrefabs;
    private List<PlayerBullet> bullets = new List<PlayerBullet>();
    private Vector2 targetPos = Vector2.zero;
    [SerializeField] private float attackCoolTimeMax = 0.5f;
    private float attackCoolTime = 0.0f;
    private Vector3 nearPos = Vector3.zero;

    private void Awake()
    {
        ObjectManager.Instance.SetPlayer(this);

        hp = hpMax;
    }

    public void Damaged(float damaged)
    {
        if (!hpPanel.activeSelf)
            hpPanel.SetActive(true);

        hp -= damaged;

        if (hp > 0) slider.value = hp / hpMax;
        else
        {
            slider.value = 0.0f;

            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        float angle = Mathf.Atan2(nearPos.y - transform.position.y, nearPos.x - transform.position.x) * Mathf.Rad2Deg;

        playerGun.transform.rotation = Quaternion.Lerp(playerGun.transform.rotation, Quaternion.Euler(0.0f, 0.0f, angle - 30.0f), Time.deltaTime * 10.0f);
        

        if (attackCoolTime < attackCoolTimeMax)
        {
            attackCoolTime += Time.deltaTime;
            return;
        }
        else attackCoolTime = 0.0f;

        nearPos = new(100.0f, 100.0f);
        float lastDistance = float.MaxValue;
        bool IsAttack = false;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 8.0f, Vector2.zero, float.MaxValue, LayerMask.GetMask("FirstLine") | LayerMask.GetMask("SecondLine") | LayerMask.GetMask("ThirdLine"));
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.CompareTag("Zombie"))
            {
                if (Vector2.Distance(nearPos, hit.transform.position) < lastDistance)
                {
                    lastDistance = Vector2.Distance(nearPos, hit.transform.position);
                    nearPos = hit.transform.position;
                }

                IsAttack = true;
            }
        }

        

        if (!IsAttack) return;

        bool isActive = false;
        foreach (PlayerBullet bullet in bullets)
        {
            if (!bullet.gameObject.activeSelf)
            {
                isActive = true;

                bullet.gameObject.SetActive(true);
                bullet.SetDir(transform.position, (nearPos - transform.position).normalized);

                return;
            }
        }

        if (isActive) return;

        PlayerBullet bulletObj = Instantiate(bulletPrefabs).GetComponent<PlayerBullet>();
        bullets.Add(bulletObj);
        bulletObj.transform.parent = transform;
        bulletObj.transform.position = playerGun.transform.position;
        bulletObj.SetDir(transform.position, (nearPos - transform.position).normalized);
    }
}
