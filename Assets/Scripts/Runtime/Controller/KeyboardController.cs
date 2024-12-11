using UnityEngine;

public class KeyboardController : Controller
{
    public override void Move()
    {
        if (config == null)
            return;
        var destination = Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime * config.Speed;
        if (IsDestinationReachLimit((Vector2)transform.position + destination))
            return;
        transform.Translate(destination);
    }
}
