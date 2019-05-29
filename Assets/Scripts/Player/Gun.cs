using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectile;
    public GameObject firePoint;

    public int bulletsShots;
    public bool shotgun;
    public float spread;
    public float cooldown;

    private float vertical;
    private float horizontal;

    private float timer;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (horizontal < 0)
            transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (vertical < 0)
            transform.rotation = Quaternion.Euler(0, 0, 270);
        else if (vertical > 0)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        timer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (timer >= cooldown)
        {
            if (shotgun)
            {
                StartCoroutine(ShotgunShoot());
            }
            if (bulletsShots == 0)
                Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);

            timer = 0;
        }
    }

    IEnumerator ShotgunShoot()
    {
        for (int i = 0; i < bulletsShots; i++)
        {
            yield return new WaitForSeconds(0);
            Instantiate(projectile, firePoint.transform.position, Quaternion.Euler(0, 0, firePoint.transform.eulerAngles.z + Random.Range(-spread, spread)));
        }

    }
}
