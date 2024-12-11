using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class TouchController : Controller
{
    private int _touchAxis; // -1:left // 1:right
    private float _beginTouchTime;
    private Vector2 _beginTouchPosition;

    private const float SWIPE_THERSHOULD = 0.3f;
    
    #region Unity methods

    private void OnEnable()
    {
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
        EnhancedTouch.Touch.onFingerUp += OnFingerUp;
    }

    private void OnDisable()
    {
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        EnhancedTouch.Touch.onFingerUp -= OnFingerUp;
    }

    #endregion

    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        _beginTouchTime = Time.time;
        _beginTouchPosition = finger.screenPosition;
    }

    private void OnFingerUp(EnhancedTouch.Finger finger)
    {
        if ((Time.time - _beginTouchTime) > SWIPE_THERSHOULD)
            return;
        if (finger.screenPosition.x < _beginTouchPosition.x)
            _touchAxis = -1;
        else if (finger.screenPosition.x > _beginTouchPosition.x)
            _touchAxis = 1;
        else
            _touchAxis = 0;
    }
    
    public override void Move()
    {
        if (config == null)
            return;
        var destination = Vector2.right * _touchAxis * Time.deltaTime * config.Speed;
        if (IsDestinationReachLimit((Vector2)transform.position + destination))
            return;
        transform.Translate(destination);
    }
}
