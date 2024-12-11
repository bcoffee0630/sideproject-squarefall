using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField] protected ControllerConfig config;

    #region Gizmos

    private void OnDrawGizmos()
    {
        if (config == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(config.LeftLimit, config.RightLimit);
        Gizmos.DrawWireSphere(config.LeftLimit, 0.1f);
        Gizmos.DrawWireSphere(config.RightLimit, 0.1f);
    }

    #endregion

    protected bool IsDestinationReachLimit(Vector2 pos)
    {
        return pos.x <= config.LeftLimit.x || pos.x >= config.RightLimit.x;
    }
    
    public abstract void Move();
}
