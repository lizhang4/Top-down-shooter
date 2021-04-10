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

    private RaycastHit2D hit2D;
    float startTime;
    void Start()
    {
        ShootLaser() ;
        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        Draw2DRay(transform.position, hit2D.point);
        if(startTime + 1f <Time.time) {
            Destroy(gameObject);
        }
    }

    void ShootLaser() {
            hit2D = Physics2D.Raycast(transform.position, transform.right, laserDistance, hitLayer);
            //Draw2DRay(transform.position, hit2D.point);

        
        
        

    }
    

    void Draw2DRay(Vector2 startPos, Vector2 endPos) {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
