using System;
using UnityEngine;

public class Player : DestructableObject
{
    private void Awake()
    {
        DeathAction = () =>
        {
            GameManager.Instance.Paused = true;
        };
    }
}