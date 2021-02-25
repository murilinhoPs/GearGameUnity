using UnityEngine;

public class CheckRaycastCollision : MonoBehaviour
{
    static public RaycastHit2D CheckCollision(LayerMask layerToDetect)
    {
        Ray worldPointRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        var distance = worldPointRay.direction.z - worldPointRay.origin.z;

        RaycastHit2D hit = Physics2D.Raycast(worldPointRay.origin, worldPointRay.direction, distance, layerToDetect);

        Debug.DrawRay(worldPointRay.origin, worldPointRay.direction, Color.red);

        // if (hit)
        // {
        //     print("hit something: " + hit.transform.name);

        // }

        return hit;

    }
}
