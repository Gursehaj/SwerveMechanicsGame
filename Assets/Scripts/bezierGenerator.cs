using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bezierGenerator : MonoBehaviour
{
    [SerializeField]
    int resolution;
    [SerializeField]
    Slider res;
    [SerializeField]
    Vector3[] linePoints;
    [SerializeField]
    Text pointsLable;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        res.minValue = 1f;
        res.maxValue = 100f;
        res.wholeNumbers = true;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    pointsLable.text = res.value.ToString();
    //    Vector3[] bezPoints = getBezierPoints();
    //    drawBezier(bezPoints);
    //}

    //Vector3[] getBezierPoints()
    //{
    //    //for (int p =0, i = 0; i < points.Length; i++)
    //    //{
    //        for (int t = 0; t < res.value; t++)
    //        {
    //            var newT = t / res.maxValue;
    //            points[t] = linePoints[/*i +*/ 1] + Mathf.Pow((1 - newT), 2) * (linePoints[/*i*/0] - linePoints[/*i + */1]) + Mathf.Pow(newT, 2) * (linePoints[/*i +*/ 2] - linePoints[/*i +*/ 1]);
    //            p++; 
    //        }
    //    //}
    //    return points;
    //}

    void drawBezier(Vector3[] points)
    {
        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }

    private void OnDrawGizmos()
    {
        foreach (var item in linePoints)
        {
            Gizmos.DrawSphere(item, 0.1f);
        }
    }
}
