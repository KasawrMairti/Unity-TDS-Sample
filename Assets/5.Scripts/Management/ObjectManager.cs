using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : GameManager<ObjectManager>
{
    public Player player { get; private set; }
    public PlayerBoxPool playerBoxs { get; private set; }
    public ZombieSpawn zombies { get; private set; }

    public void SetPlayer(Player player) { this.player = player; }
    public void SetPlayerBoxPool(PlayerBoxPool playerBoxPool) { this.playerBoxs = playerBoxPool; }
    public void SetZombieSpawn(ZombieSpawn zombieSpawn) { this.zombies = zombieSpawn; }
}
