using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _vehicleSprite;
    [SerializeField] private float timeToDeliver;

    [Header("Animation")]
    [SerializeField] public Animator _sonarFX;

    [Header("Vehicle Data")]
    [SerializeField] private List<Vehicle> vehicles = new List<Vehicle>();

    public void SetEffect(bool isActive) => _sonarFX.gameObject.SetActive(isActive);
    public float GetTimeDeliver => timeToDeliver;

    public void GetVehicle(string name, bool isFlipX, bool isFlipY)
    {
        Vehicle vehicle = vehicles.First(v => v.Name.ToLower() == name.ToLower());
        CheckFacing(isFlipX, isFlipY, vehicle);
    }

    private void CheckFacing(bool isFlipX, bool isFlipY, Vehicle vehicle)
    {
        if (isFlipY) _vehicleSprite.sprite = vehicle.UpSprite;
        else _vehicleSprite.sprite = vehicle.DownSprite;

        if (isFlipX) _vehicleSprite.flipX = true;
        else _vehicleSprite.flipY = false;
    }

    public void Move(Transform startPosition, Transform endPosition)
    {
        transform.position = startPosition.position;
        transform.DOMove(endPosition.position, timeToDeliver);
    }
}

[Serializable]
public struct Vehicle
{
    public string Name;
    public Sprite UpSprite;
    public Sprite DownSprite;
}
