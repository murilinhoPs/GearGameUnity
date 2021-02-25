using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearContainerGame : MonoBehaviour
{
    public bool IsOccupied;

    public int Direction = 1;

    public bool CanRotate;

    void Start()
    {

    }

    void Update()
    {
        if (transform.childCount == 0)
        {
            SetIsOccupied(false);
        }

        if (CanRotate)
            RotateGear();
    }

    void RotateGear()
    {
        var gearTransform = transform.GetChild(0).transform;

        gearTransform.RotateAround(transform.position, new Vector3(0, 0, Direction), 180 * Time.deltaTime);
    }

    public void SetIsOccupied(bool isOccupied) =>
        this.IsOccupied = isOccupied;
}
