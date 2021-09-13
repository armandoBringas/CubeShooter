using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 2f;
    public float timeSeries = 10f;
    public float timeBullets = 0.1f;
    public float bulletQuantity = 5; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BulletShoot", 0f, timeSeries);
    }

    void BulletShoot()
    {
        StartCoroutine(ShootingCoroutine());
    }

    IEnumerator ShootingCoroutine()
    {
        transform.position += speed * Time.deltaTime * transform.forward;

        int i = 0;
        while (i < bulletQuantity)
        {
            GameObject bullet = Instantiate(this.gameObject, transform);
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(-2f, -2f, 0f);
            Destroy(bullet, 0.05f);
            yield return new WaitForSeconds(timeBullets);
            i++;
        }
        
    }
}
