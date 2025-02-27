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

        // 이미지 일정 거리이상 지나가면 순환시켜 무한정 이동하는 느낌을 구현
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
