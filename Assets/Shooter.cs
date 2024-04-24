using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.magenta, 10f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

            if(hit.collider != null )
            {
                target.transfrom.position = new Vector3(hit.point.x, hit.point.y);
                Debug.Log($"hit point : ({hit.point.x}, {hit.point.y}");

                Vector2 projectile = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);
                Rigidbody firedBullet = Instantiate(bulletPrefab,shootPoint.position,Quaternion.identity);
                firedBullet.velocity = projectile;

            }

        }
        
    }
}
