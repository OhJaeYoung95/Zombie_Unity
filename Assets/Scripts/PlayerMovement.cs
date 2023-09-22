using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도


    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    private Vector3 direction;

    public LayerMask layerMask;
    private Camera worldCam;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        worldCam = Camera.main;
    }

    private void Update()
    {
        var forward = worldCam.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        var right = worldCam.transform.right;
        right.y = 0f;
        right.Normalize();

        direction = forward * playerInput.move;
        direction += right * playerInput.rotate;

        direction = new Vector3(playerInput.rotate, 0f, playerInput.move);
        if (direction.magnitude > 1f)
        {
            direction.Normalize();
        }

        playerAnimator.SetFloat("Move", direction.magnitude);
    }
    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate() {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        Move();
        Rotate();

    }



    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move() {

        var position = playerRigidbody.position;
        position += direction * moveSpeed *Time.deltaTime;
        playerRigidbody.MovePosition(position);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate() {
        //var rotation = playerRigidbody.rotation;
        //rotation *= Quaternion.Euler(Vector3.up * playerInput.rotate * rotateSpeed * Time.deltaTime);
        //playerRigidbody.MoveRotation(rotation);

        Ray ray = worldCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, layerMask))
        {
            Vector3 lookPoint = hitInfo.point;
            lookPoint.y = transform.position.y;
            var look = lookPoint - playerRigidbody.position;
            playerRigidbody.MoveRotation(Quaternion.LookRotation(look.normalized));

            //transform.LookAt(lookPoint);
        }


    }
}