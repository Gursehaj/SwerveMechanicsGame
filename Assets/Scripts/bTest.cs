using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bTest : MonoBehaviour
{
    Vector3[] rawPoints = new Vector3[3];
    LineRenderer lineRenderer;
    Vector3[] bezPoints;
    [SerializeField]
    float resolution;
    //[SerializeField]
    //Text resLabel;
    int bezPointsSize;

    //private void Awake()
    //{
    //    resolution.minValue = 0;
    //    resolution.maxValue = 10;
    //    resolution.wholeNumbers = true;
    //}
    // Start is called before the first frame update

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        rawPoints = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(2,0,2)
        };
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Total time intervals are: { 1 / resolution}");
        bezPointsSize = int.Parse((1 / resolution).ToString());
        Debug.Log($"Total bez points are : {bezPointsSize}");
        bezPoints = new Vector3[bezPointsSize + 1];
        getBezPoints();
        drawBezier();
    }

    void getBezPoints()
    {
        int i = 0;
        for (float t = 0; t <= 1; t += resolution)
        {
            Debug.Log($"Value of t is: {t}");
            var val = rawPoints[1] + Mathf.Pow((1 - t), 2) * (rawPoints[0] - rawPoints[1]) + Mathf.Pow(t, 2) * (rawPoints[2] - rawPoints[1]);
            Debug.Log($"Bez point position is: {val}");
            bezPoints[i] = val;
            i++;
        }
        Debug.Log($"i value is: {i}");
    }

    void drawBezier()
    {
        lineRenderer.positionCount = bezPointsSize+1;
        lineRenderer.SetPositions(bezPoints);
    }

    //private void OnDrawGizmos()
    //{
    //    foreach (var item in rawPoints)
    //    {
    //        Gizmos.DrawSphere(item, 0.1f);
    //    }
    //}
}
