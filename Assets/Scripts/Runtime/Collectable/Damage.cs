using System;

public class Damage : FallSquare, ICollectable
{
    public static Action OnDamaged;
    
    public void Collect()
    {
        OnDamaged?.Invoke();
        Destroy(gameObject);
    }

    protected override void OnDestinationReached()
    {
        Destroy(gameObject);
    }
}
