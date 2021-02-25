using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GearDragHandler : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector2 mousePosition;

    private Vector3 collisionTransform;
    private RaycastHit2D receivedRaycast;

    public LayerMask layerMask;

    void Start()
    {
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;

        receivedRaycast = CheckRaycastCollision.CheckCollision(layerMask);
    }

    void OnMouseUp()
    {
        if (receivedRaycast)
        {
            var container = receivedRaycast.transform.GetComponent<GearContainerGame>();

            if (container.IsOccupied)
            {
                ResetPosition();
                return;
            }

            transform.SetParent(receivedRaycast.transform);
            ResetPosition();

            container.SetIsOccupied(true);
        }
        else
            ResetPosition();

    }

    void ResetPosition() => transform.localPosition = Vector3.zero;
}
