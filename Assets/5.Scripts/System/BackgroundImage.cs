using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log(spriteRenderer.size.x);

        // �̹��� ���� �Ÿ��̻� �������� ��ȯ���� ������ �̵��ϴ� ������ ����
        if (transform.position.x < spriteRenderer.size.x)
        {
            transform.position = new Vector3(spriteRenderer.size.x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector2.left * 1.0f * Time.deltaTime);
        }
    }
}
