using UnityEngine;

public abstract class FallSquare : MonoBehaviour
{
    [SerializeField] protected FallSquareConfig config;
    
    private Vector2 _generatePosition;
    private Vector2 _destinationPosition;

    private const float DISTANCE_TO_DESTINATION = 0.3f;
    
    public void Initialize(Vector2 generatePosition, Vector2 destinationPosition)
    {
        _generatePosition = generatePosition;
        _destinationPosition = destinationPosition;
    }

    private bool IsDestinationReached()
    {
        var distance = Vector2.Distance(transform.position, _destinationPosition);
        return distance <= DISTANCE_TO_DESTINATION;
    }

    protected abstract void OnDestinationReached();

    #region Unity methods

    private void Start()
    {
        transform.position = _generatePosition;
    }

    private void Update()
    {
        if (IsDestinationReached())
        {
            OnDestinationReached();
            return;
        }

        transform.position =
            Vector2.MoveTowards(transform.position, _destinationPosition, Time.deltaTime * config.Speed);
        var eulerAngles = transform.eulerAngles;
        eulerAngles.z -= Time.deltaTime * config.RotateSpeed;
        transform.eulerAngles = eulerAngles;
    }

    #endregion
}
