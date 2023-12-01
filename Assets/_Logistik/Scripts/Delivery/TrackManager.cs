using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    public void Draw(Transform startPos, Transform endPos)
    {
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, startPos.position);
        lineRenderer.SetPosition(1, endPos.position);
    }

    public void Draw(Transform startPos, Transform middlePos, Transform endPos)
    {
        lineRenderer.positionCount = 3;

        lineRenderer.SetPosition(0, startPos.position);
        lineRenderer.SetPosition(1, middlePos.position);
        lineRenderer.SetPosition(2, endPos.position);
    }
}
