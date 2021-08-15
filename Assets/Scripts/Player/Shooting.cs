using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject FireballPrefab;
    public Rigidbody2D rb;
    public int bulletforce = 35;
    [SerializeField]
    private int firecounter = 0;
    [SerializeField]
    private int firelimit = 5;
    // Update is called once per frame
    async void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            if (firecounter < firelimit)
            {
                Shoot();
                firecounter++;
            }
        if (Input.GetButtonUp("Fire1"))
            {
            if (firecounter >= firelimit)
            {
                await Task.Delay(500);
                firecounter--;
            }
        }
    }
    void Shoot() 
    {
        GameObject Fireball = Instantiate(FireballPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = Fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        Destroy(gameObject);
    }
}
