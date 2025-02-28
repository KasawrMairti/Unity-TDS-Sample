using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    private void OnEnable()
    {
        ObjectManager.Instance.playerBoxs.AddBox(this);
    }
}
