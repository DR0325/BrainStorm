using System;
using UnityEngine;

public class Enemy : DestructableObject
{
    public int _experienceGain;
	public float attackTime;
	//Enemy properties
	[Range(100f,1000f)]
	public float enemyPower;

	private void Awake()
    {
        DeathAction = () =>
        {
            --GameManager.Instance.enemiesCount;
            GameManager.Instance.QtyExperience += _experienceGain;
        };
    }
}