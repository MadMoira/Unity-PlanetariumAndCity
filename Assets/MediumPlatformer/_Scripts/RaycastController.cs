using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour {

    public LayerMask collisionLayerMask;

    public const float skinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    [HideInInspector] public float horizontalRaySpacing;
    [HideInInspector] public float verticalRaySpacing;

    public BoxCollider2D collider_;
    public RayCastOrigins origins;


    public virtual void Start()
    {
        collider_ = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }

    public void UpdateRaycastOrigins()
    {
        Bounds bounds = collider_.bounds;
        bounds.Expand(skinWidth * -2);

        origins.bottomleft = new Vector2(bounds.min.x, bounds.min.y);
        origins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        origins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        origins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    public void CalculateRaySpacing()
    {
        Bounds bounds = collider_.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    public struct RayCastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomleft, bottomRight;
    }
}
