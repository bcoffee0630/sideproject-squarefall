using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject visual;
    [SerializeField] private ParticleSystem particle;
    
    public static event Action OnPlayerDeath;
    
    private Controller _controller;
    
    private bool _isDead;
    private bool IsDead
    {
        get => _isDead;
        set
        {
            _isDead = value;
            visual.SetActive(!_isDead);
            if (_isDead)
                OnPlayerDeath?.Invoke();
        }
    }

    #region Unity methods

    private void OnEnable()
    {
        Damage.OnDamaged += Damaged;
    }

    private void OnDisable()
    {
        Damage.OnDamaged -= Damaged;
    }

    private void Start()
    {
        _controller = GetComponent<Controller>();
    }

    private void Update()
    {
        if (_controller && !IsDead)
            _controller.Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ICollectable collectable))
            collectable.Collect();
    }

    #endregion

    private void Damaged()
    {
        IsDead = true;
        particle.Play();
    }
}
