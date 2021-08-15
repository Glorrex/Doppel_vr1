using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitEffect;
    public int Damage = 5;

    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        Enemy enemy = HitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            //enemy.TakeDamage(Damage);
        }
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .45f);
        Destroy(gameObject);
    }
}
