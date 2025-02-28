using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    private float moveSpeed = 0.75f;

    [SerializeField] private SpriteRenderer nextImage;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // �̹��� ���� �Ÿ��̻� �������� ��ȯ���� ������ �̵��ϴ� ������ ����
        if (transform.position.x < -spriteRenderer.bounds.size.x)
        {
            transform.position = new Vector3(nextImage.bounds.size.x + (nextImage.transform.position.x * 0.5f) - 0.05f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
