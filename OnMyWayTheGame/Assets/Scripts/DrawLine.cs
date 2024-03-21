using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public List<Vector2> linePos;
    private LineRenderer lineRender;
    private EdgeCollider2D edgeCollider;
    public GameObject lineMesh;
    Mesh mesh;

    private void Start()
    {
        mesh = new Mesh();
    }

    private void CreateLine()
    {
        GameObject newLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRender = newLine.GetComponent<LineRenderer>();
        edgeCollider = newLine.GetComponent<EdgeCollider2D>();
        linePos.Clear();
        linePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        linePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRender.SetPosition(0, linePos[0]);
        lineRender.SetPosition(0, linePos[1]);
        edgeCollider.points = linePos.ToArray();
    }

    private void UpdateLine()
    {
        linePos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRender.positionCount++;
        lineRender.SetPosition(lineRender.positionCount - 1, linePos[lineRender.positionCount - 1]);
        edgeCollider.points = linePos.ToArray();
    }

    private void LineCreated()
    {

        lineRender.BakeMesh(mesh, true);
        GameObject line = Instantiate(lineMesh, Vector2.zero, Quaternion.identity);
        line.GetComponent<MeshFilter>().mesh = mesh;
        line.GetComponent<EdgeCollider2D>().points = linePos.ToArray();
        Destroy(lineRender.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(linePos[linePos.Count - 1], newPosition) > .1f)
            {
                UpdateLine();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            LineCreated();
        }
    }
}
