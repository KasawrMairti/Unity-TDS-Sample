using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{

    private void Awake()
    {
        ObjectManager.Instance.SetPlayer(this);
    }

    public void Damaged()
    {
        throw new System.NotImplementedException();
    }
}
