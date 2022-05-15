using System;
using UnityEngine;

public abstract class DestructableObject : MonoBehaviour 
{
    /// <summary>
    /// Callback delegate that just handles destruction of game object
    /// </summary>
    protected delegate void DeathActionDelegate();
    
    protected float _health;
    protected float _maxHealth;
    /// <summary>
    /// Action that occurs when a destructable object's health reaches zero
    /// </summary>
    protected DeathActionDelegate DeathAction;
    
    public float Health
    {
        get => _health;
        set
        {
            _health = Mathf.Min(value, _maxHealth);
            if (_health <= 0.0f)
            {
                DeathAction();
            }
        }
    }
    
}
