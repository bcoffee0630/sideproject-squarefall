using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableGenerator : MonoBehaviour
{
    [SerializeField] private FallSquare point;
    [SerializeField] private FallSquare damage;
    
    [Header("Time")]
    [SerializeField] private float timeBetweenSpawns;
    
    [Header("Generate")]
    [SerializeField] private Vector2 generateTopLeft;
    [SerializeField] private Vector2 generateTopRight;
    [SerializeField] private Vector2 generateBottomLeft;
    [SerializeField] private Vector2 generateBottomRight;
    
    [Header("Destination")]
    [SerializeField] private Vector2 destinationTopLeft;
    [SerializeField] private Vector2 destinationTopRight;
    [SerializeField] private Vector2 destinationBottomLeft;
    [SerializeField] private Vector2 destinationBottomRight;
    
    private const float GENERATE_POINT_PERCENTAGE = 0.4f;
    
    #region Gizmos

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(generateTopLeft, generateTopRight);
        Gizmos.DrawLine(generateTopRight, generateBottomRight);
        Gizmos.DrawLine(generateBottomRight, generateBottomLeft);
        Gizmos.DrawLine(generateBottomLeft, generateTopLeft);
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(destinationTopLeft, destinationTopRight);
        Gizmos.DrawLine(destinationTopRight, destinationBottomRight);
        Gizmos.DrawLine(destinationBottomRight, destinationBottomLeft);
        Gizmos.DrawLine(destinationBottomLeft, destinationTopLeft);
    }

    #endregion

    #region Unity methods

    private void OnEnable()
    {
        Player.OnPlayerDeath += StopGenerate;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= StopGenerate;
    }

    private void Start()
    {
        InvokeRepeating(nameof(Generate), 0.5f, timeBetweenSpawns);
    }

    #endregion

    private Vector2 GetRandomGeneratePosition()
    {
        var y = (generateTopLeft.y + generateBottomLeft.y) / 2;
        var x = Random.Range(generateTopLeft.x, generateTopRight.x);
        return new Vector2(x, y);
    }

    private Vector2 GetRandomDestinationPosition()
    {
        var y = (destinationTopLeft.y + destinationBottomLeft.y) / 2;
        var x = Random.Range(destinationTopLeft.x, destinationTopRight.x);
        return new Vector2(x, y);
    }

    private void Generate()
    {
        var generatePosition = GetRandomGeneratePosition();
        var destinationPosition = GetRandomDestinationPosition();
        var square = Random.value < GENERATE_POINT_PERCENTAGE ? point : damage;
        var squareInstance = Instantiate(square, transform);
        squareInstance.Initialize(generatePosition, destinationPosition);
    }

    private void StopGenerate()
    {
        CancelInvoke(nameof(Generate));
    }
}
