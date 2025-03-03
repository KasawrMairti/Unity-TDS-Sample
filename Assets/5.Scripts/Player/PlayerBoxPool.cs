using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBoxPool : MonoBehaviour
{
    [SerializeField] private int boxCount = 4;
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private Transform boxPivots;

    public List<PlayerBox> playerBox { get; private set; }

    private Player player;

    private void Awake()
    {
        ObjectManager.Instance.SetPlayerBoxPool(this);

        playerBox = new List<PlayerBox>();
    }

    private void Start()
    {
        player = ObjectManager.Instance.player;

        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < boxCount; i++)
        {
            GameObject obj = Instantiate(boxPrefab);
            playerBox.Add(obj.GetComponent<PlayerBox>());
            obj.transform.parent = boxPivots.transform;
            obj.transform.position = boxPivots.transform.position + (Vector3.up * 1.75f * i);
        }
        player.transform.position = boxPivots.transform.position + (Vector3.up * 1.75f * (boxCount));
    }
}
