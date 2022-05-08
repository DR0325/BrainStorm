using System;
using UnityEngine;

public class Enemy : DestructableObject
{
    private void Awake()
    {
        DeathAction = () =>
        {
            --GameManager.Instance.EnemiesCount;
        };
    }
}