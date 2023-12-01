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
    private Transform _middlePosDelivery;
    private Transform _endPosDelivery;

    private bool _isSmallMap;

    private void SetVehicle()
    {
        _vehicle.GetVehicle(_delivery.GetVehicle,
            IsFlip(_startPosDelivery.position.x, _endPosDelivery.position.x),
            IsFlip(_startPosDelivery.position.y, _endPosDelivery.position.y)
        );
    }

    private void SetVehicle(string vehicleName, Transform start, Transform end)
    {
        _vehicle.GetVehicle(vehicleName,
            IsFlip(start.position.x, end.position.x),
            IsFlip(start.position.y, end.position.y)
        );
    }

    private void Start()
    {
        SetMap();

        if (_delivery.Vehicle == Transportation.SHIPS) StartCoroutine(ShipsDelivery());
        else DefaultDelivery();
    }

    private void DefaultDelivery()
    {
        _endPosDelivery = _destinationPos.GetDestination(_delivery.Destination, _isSmallMap);
        SetTransportation();
        _track.Draw(_startPosDelivery, _endPosDelivery);
        _vehicle.Move(_startPosDelivery, _endPosDelivery);
    }

    public IEnumerator ShipsDelivery()
    {
        _middlePosDelivery = _destinationPos.GetDestination("Jakarta", _isSmallMap);
        _endPosDelivery = _destinationPos.GetDestination(_delivery.Destination, _isSmallMap);

        SetVehicle("Van", _startPosDelivery, _middlePosDelivery);
        _track.Draw(_startPosDelivery, _middlePosDelivery, _endPosDelivery);
        _vehicle.Move(_startPosDelivery, _middlePosDelivery);

        yield return new WaitForSeconds(2f);
        SetVehicle();
        _vehicle.Move(_middlePosDelivery, _endPosDelivery);
    }

    public void SetMap()
    {
        switch (_delivery.Vehicle)
        {
            case Transportation.MOTORCYCLE:
            case Transportation.VAN:
            case Transportation.TRUCK:
                _isSmallMap = true;
                _startPosDelivery = _startPosSmallMap;
                _largeMap.SetActive(false);
                _smallMap.SetActive(true);
                break;

            case Transportation.SHIPS:
            case Transportation.PLANE:
                _isSmallMap = false;
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

    // public bool IsFlipX()
    // {
    //     Vector3 startPos = _startPosDelivery.position;
    //     Vector3 endPos = _endPosDelivery.position;

    //     var distance = endPos.x - startPos.x;

    //     if (distance < 0) return false;
    //     else return true;
    // }

    // public bool IsFlipY()
    // {
    //     Vector3 startPos = _startPosDelivery.position;
    //     Vector3 endPos = _endPosDelivery.position;

    //     var distance = endPos.y - startPos.y;

    //     if (distance < 0) return false;
    //     else return true;
    // }

    public bool IsFlip(float start, float end)
    {
        var distance = end - start;
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

    public string GetVehicle => Vehicle.ToString();
}
