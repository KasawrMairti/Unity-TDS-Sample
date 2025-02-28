using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxPool : MonoBehaviour
{
    public List<PlayerBox> playerBox { get; private set; }

    private void Awake()
    {
        ObjectManager.Instance.SetPlayerBoxPool(this);

        playerBox = new List<PlayerBox>();
    }

    public void AddBox(PlayerBox box)
    {
        playerBox.Add(box);
    }
}
