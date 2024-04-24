using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.magenta, 10f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log($"hit point : {hit.point.x}, {hit.point.y}");

                Vector2 projectile = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);

                Rigidbody2D firebullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
                firebullet.velocity = projectile;
            }

        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / t;
        float velocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y);

        Vector2 result = new Vector2(velocityX, velocityY);
        return result;
    }
}
