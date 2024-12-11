using UnityEngine;

[CreateAssetMenu(fileName = "FallSquareConfig", menuName = "Other/FallSquareConfig")]
public class FallSquareConfig : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    public float Speed => speed;
    public float RotateSpeed => rotateSpeed;
}
