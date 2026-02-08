using UnityEngine;

public class ShootRayCastF : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject shootPointPrefab;
    [SerializeField] GameObject hitPointPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;

        Debug.DrawRay(shootPoint.position, transform.right * 30f, Color.green);

        if (Physics.Raycast(shootPoint.position, transform.right, out hit, 50f))
        {
            Debug.DrawRay(shootPoint.position, transform.right * hit.distance, Color.red);
            Debug.Log("Ray hits " + hit.collider.name);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(shootPointPrefab, shootPoint.position, Quaternion.identity);
                Instantiate(hitPointPrefab, hit.point, Quaternion.identity);

                if (hit.collider.name == "Enemy")
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage();
                    }
                }
            }
        }
    }
}
