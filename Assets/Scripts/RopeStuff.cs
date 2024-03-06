using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeStuff : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject Player1;
    public GameObject Player2;

    private void Start()
    {
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        lineRenderer.SetPosition(0, Player1.transform.position);
        lineRenderer.SetPosition(1, Player2.transform.position);
    }
}
