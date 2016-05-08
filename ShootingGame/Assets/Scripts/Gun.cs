using UnityEngine;
using System.Collections;

//총구 화염이 나올 위치를 알아야한다.
public class Gun : MonoBehaviour {

    public Transform  muzzle;       //총구 위치
    public Projectile projectile;   //발사체
    public float msBetweenShots = 100;    //연사력 ( 격발 사이의 간격. 밀리초)
    public float muzzleVelocity= 35;        //총알이 발사되는 순간의 총알 속력

    float nextShotTime;

    public void Shoot()
    {
        if(Time.time > nextShotTime) {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = (Projectile)Instantiate(projectile, muzzle.position, muzzle.rotation);
            newProjectile.SetSpeed(muzzleVelocity);
        }
    }
}
