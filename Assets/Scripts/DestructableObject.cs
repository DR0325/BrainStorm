using System;
using UnityEngine;

public abstract class DestructableObject : MonoBehaviour 
{
    /// <summary>
    /// Callback delegate that just handles destruction of game object
    /// </summary>
    protected delegate void DeathActionDelegate();
    
    private float _health;
    private float _maxHealth;
    /// <summary>
    /// Action that occurs when a destructable object's health reaches zero
    /// </summary>
    protected DeathActionDelegate DeathAction;
    
    public float Health
    {
        get => _health;
        set
        {
            _health = Mathf.Max(value, _maxHealth);
            if (_health <= 0.0f)
            {
                DeathAction();
            }
        }
    }
    
}
