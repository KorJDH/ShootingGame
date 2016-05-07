using UnityEngine;
using System.Collections;

//Rigidbody를 사용해서 충돌(collision)에 영향을 받도록 설계
[RequireComponent(typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

    Vector3 velocity;
    Rigidbody myRigidbody;

	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
	
	}
	

    //************플레이어의 움직임  구현 ************
    /*FixedUpdate 메소드안에서 Rigidbody를 움직여야 한다.
     정기적이고 짧게 반복적으로 실행되야 하기 때문 . 그래야 다른 오브젝트 밑으로 끼어 들어가지 않는다
     (프레임 저하가 발생해도 프레임에 시간의 가중치를 곱해 실행되어 이동속도를 유지할 수 있음 )
    */
    public void FixedUpdate()
    {
        //AddForce메소드 말고 간단히 MovePosition 메소드를 사용한다
        //fixedDeltaTime : 메소드가 호출된 시간 간격
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;

    }


    //************Player가 마우스 움직임에따라 회전하는부분 구현 ************
    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x,transform.position.y,lookPoint.z  );
        transform.LookAt(heightCorrectedPoint);


    }

}
