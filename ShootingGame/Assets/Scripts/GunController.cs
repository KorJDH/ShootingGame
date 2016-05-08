using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public Transform weaponHold;    //총기를 붙잡는 위치
    public Gun StartingGun;         //처음 시작 무기
    Gun equippedGun; //현재 장착중인 총
    
    void Start()
    {
        if (StartingGun != null)
        {
            EquipGun(StartingGun);
        }
    }
    
    public void EquipGun(Gun gunToEquip)
    {   //이미 장착한 Gun 이 있다면 파괴
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip , weaponHold.position, weaponHold.rotation) as Gun;      //객체 복사 (Clone)

        //총 오브젝트가 플레이어를 따라 움직이도록 weaponHold의 자식으로 넣는다.
        //parent를 따라 움직인다   parent : weaponHold(GameObject)
        equippedGun.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }

    }
}
