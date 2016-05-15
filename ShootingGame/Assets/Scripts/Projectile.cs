using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public LayerMask collisionMask; //어떤 오브젝트, 어떤 레이어가 발사체와 충돌할지 결정할 수 있다
    float speed = 10;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

	void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
	}

    void CheckCollisions (float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; //ray와 충돌한 오브젝트의 정보를 담기 위한 자료

        //QueryTriggerInteraction 으로 우리가 트리거 콜라이더들과 충돌할지 안할지 정할 수 있음
        if (Physics.Raycast(ray, out hit, moveDistance,collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);   //충돌
        }

    }

    //충돌했을때 
    void OnHitObject(RaycastHit hit)
    {
        print(hit.collider.gameObject.name);
        GameObject.Destroy(gameObject);

    }
}
