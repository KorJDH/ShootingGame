using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent)) ]
public class Enemy : MonoBehaviour {

    NavMeshAgent pathfinder;    //길찾기 관리
    Transform target;

	void Start () {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }
	
	void Update () {
        //업데이트 때마다 경로지정을 하게되면 적이 많아질경우 값비싼 처리가된다. 
        //타이머로 고정된 간격마다 하게 수정
        //pathfinder.SetDestination(target.position);
	}

    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;  //반복 속도 1초

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
