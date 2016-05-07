using UnityEngine;
using System.Collections;


//스크립트를 오브젝트에 더할 때 PlayerController 스크립트 또한 무조건 붙어있을걸 강요한다.
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour {

    public float moveSpeed = 5;
    PlayerController controller;
    Camera viewCamera;

	void Start () {
        //PlayerController와 Player 스크립트가 같은 오브젝트에 붙어있는걸 전제로 한다.
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
	    
	}
	
	void Update () {

        //************플레이어의 움직임  구현 ************
        //Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));//기본 스무딩 적용하지 않음

        //normarlized : 방향을 가리키는 단위벡터로 만드는 연산
        //moveVelocity를 PalyerController 로 전달해서 물리적인 부분들을 처리할 수 있도록
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);


        //************Player가 마우스 움직임에따라 회전하는부분 구현 ************
        //ScreenPointToRay : 화면상에서 위치를 반환해주는 메소드
        //마우스 위치를 넣었으므로  화면상에서 마우스의 위치를 가져온다.
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        
        //카메라에서 이 위치를 통과한 레이가 돌아오려면 무한정뻗어나가는걸 방지하기위해 
        //Plane으로 레이가 돌아올 수 있게끔 받아줘야한다
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        //groundPlane 과 ray 의 충돌을 감지   True일경우 ray가 바닥과 교차한것
        //out : 변수를 참조로 전달한다. ( 충돌시 카메라에서 부터 ray가 plane에 충돌한 지점까지의 거리를 반환 )
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);  //거리를넣으면 좌표를 반환
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
           
        }




    }
}
