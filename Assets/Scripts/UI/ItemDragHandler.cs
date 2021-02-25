using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject gearInstance;
    public LayerMask layerToDetect;
    private Canvas canvas;
    private Vector3 collisionTransform;
    private RaycastHit2D receivedRaycast;
    private GraphicRaycaster graphicRaycaster;

    public void OnBeginDrag(PointerEventData eventData)
    {
        print(eventData.used);
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;

        if (!canvas)
        {
            canvas = GetComponentInParent<Canvas>();
            graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();
        }

        transform.parent.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0) / transform.lossyScale.x;

        receivedRaycast = CheckRaycastCollision.CheckCollision(layerToDetect);

        if (receivedRaycast)
            collisionTransform = receivedRaycast.transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (collisionTransform != Vector3.zero)
        {
            var instantiatedGear = Instantiate(gearInstance, collisionTransform, Quaternion.identity);

            instantiatedGear.transform.SetParent(receivedRaycast.transform);

            receivedRaycast.transform.GetComponent<GearContainerGame>().SetIsOccupied(true);

            gameObject.SetActive(false);
        }

        transform.localPosition = Vector3.zero;
    }
}
