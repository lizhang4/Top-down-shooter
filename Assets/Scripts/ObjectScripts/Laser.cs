using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserDistance = 100f;
    public Transform laserFirePoint;
    public LineRenderer lineRenderer;
    public Vector2 fireDirection;

    public LayerMask hitLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser() ;
    }

    void ShootLaser() {
        if (Physics2D.Raycast(transform.position, transform.right)) {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right, laserDistance, hitLayer);
            Draw2DRay(transform.position, hit2D.point);

        }
        else {
            //Draw2DRay(transform.position, transform.right* laserDistance);

            Debug.Log("2");
        }
        
        

    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos) {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
