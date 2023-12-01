using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TrackManager _track;
    [SerializeField] private VehicleManager _vehicle;
    [SerializeField] private DestinationPosition _destinationPos;
    [SerializeField] private Delivery _delivery;

    [Header("Map")]
    [SerializeField] private Transform _startPosSmallMap;
    [SerializeField] private Transform _startPosLargeMap;
    [SerializeField] private GameObject _smallMap, _largeMap;

    [Header("Delivery")]
    private Transform _startPosDelivery;
    private Transform _endPosDelivery;

    public void SetTrack() => _track.Draw(_startPosDelivery, _endPosDelivery);
    private void SetDestination() => _endPosDelivery = _destinationPos.GetDestination(_delivery.Destination);
    private void SetVehicle() => _vehicle.GetVehicle(_delivery.Vehicle.ToString(), IsFlipX(), IsFlipY());
    public void Deliver() => _vehicle.Move(_startPosDelivery, _endPosDelivery);

    private void Start()
    {
        SetMap();
        SetDestination();
        SetTransportation();
        SetTrack();
        Deliver();
    }

    public void SetMap()
    {
        switch (_delivery.Vehicle)
        {
            case Transportation.MOTORCYCLE:
            case Transportation.VAN:
            case Transportation.TRUCK:
                _startPosDelivery = _startPosSmallMap;
                _largeMap.SetActive(false);
                _smallMap.SetActive(true);
                break;

            case Transportation.SHIPS:
            case Transportation.PLANE:
                _startPosDelivery = _startPosLargeMap;
                _smallMap.SetActive(false);
                _largeMap.SetActive(true);
                break;
        }
    }

    public void SetTransportation()
    {
        switch (_delivery.Vehicle)
        {
            case Transportation.MOTORCYCLE:
                SetVehicle();
                break;
            case Transportation.VAN:
                SetVehicle();
                break;
            case Transportation.TRUCK:
                SetVehicle();
                break;
            case Transportation.PLANE:
                SetVehicle();
                break;
            case Transportation.SHIPS:
                SetVehicle();
                break;
        }
    }

    public bool IsFlipX()
    {
        Vector3 startPos = _startPosDelivery.position;
        Vector3 endPos = _endPosDelivery.position;

        var distance = endPos.x - startPos.x;

        if (distance < 0) return false;
        else return true;
    }

    public bool IsFlipY()
    {
        Vector3 startPos = _startPosDelivery.position;
        Vector3 endPos = _endPosDelivery.position;

        var distance = endPos.y - startPos.y;

        if (distance < 0) return false;
        else return true;
    }
}

[Serializable]
public struct Delivery
{
    public Transportation Vehicle;
    public float GoodsAmount;
    public string Destination;
}
