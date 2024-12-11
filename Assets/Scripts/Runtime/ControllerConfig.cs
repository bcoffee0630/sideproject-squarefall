using UnityEngine;

[CreateAssetMenu(fileName = "ControllerConfig", menuName = "Other/ControllerConfig")]
public class ControllerConfig : ScriptableObject
{
    [SerializeField] private Vector2 leftLimit;
    [SerializeField] private Vector2 rightLimit;
    [SerializeField] private float speed;
    
    public Vector2 LeftLimit => leftLimit;
    public Vector2 RightLimit => rightLimit;
    public float Speed => speed;
}
