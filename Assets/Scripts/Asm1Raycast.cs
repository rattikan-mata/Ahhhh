using UnityEngine;

public class Asm1RayCast : MonoBehaviour
{
    [SerializeField] Transform shootPoint;

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

        Debug.DrawRay(shootPoint.position, transform.forward * 10f, Color.green);

        if (Physics.Raycast(shootPoint.position, transform.forward, out hit, 10f))
        {
            Debug.DrawRay(shootPoint.position, transform.forward * 10f, Color.red);
            Debug.Log("Ray hits " + hit.collider.name);

            if (hit.collider.CompareTag("Star"))
            {
                Renderer rdr = hit.collider.GetComponent<Renderer>();
                if (rdr != null)
                {
                    rdr.material.color = Color.red;
                }
            }

            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
            }
        }
    }
}
