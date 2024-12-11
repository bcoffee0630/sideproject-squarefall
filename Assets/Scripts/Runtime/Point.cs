using System;

public class Point : FallSquare, ICollectable
{
    public static Action OnPointCollected;
    
    public void Collect()
    {
        OnPointCollected?.Invoke();
        Destroy(gameObject);
    }

    protected override void OnDestinationReached()
    {
        Destroy(gameObject);
    }
}
