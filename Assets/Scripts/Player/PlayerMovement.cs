using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _avatar;// 몸체
    [SerializeField] private Transform _aim; //카메라 홀더

    private Rigidbody _rigidbody; //몸체의 리지드 바디
    private PlayerStatus _playerStatus; // 플레이어 상태

    [Header("Mouse Config")]
    [SerializeField][Range(-90, 0)] private float _minPitch; // Y전용 카메라 최소각
    [SerializeField][Range(0, 90)] private float _maxPitch; //Y전용 카메라 최대각
    [SerializeField][Range(0, 5)] private float _mouseSensitivity = 1; // 마우스 민감도

    private Vector2 _currentRotation; //마우스 회전에 의한 현재 회전 상태

    private void Awake() => Init(); //게임 시작 시 초기화

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>(); //리지드 바디에서 정보 얻어와 _rigidbody 에 대입
        _playerStatus = GetComponent<PlayerStatus>(); // PlayerStatus에서 정보 얻어와 _playerStatus에 대입
    }

    public Vector3 SetMove(float moveSpeed) //이동 구현
    {
        Vector3 moveDirection = GetMoveDirection(); //방향 설정을 위해 GetMoveDirection 메서드에서 방향(return)을 받아옴.

        Vector3 velocity = _rigidbody.velocity; //현재 속도 저장
        velocity.x = moveDirection.x * moveSpeed; //좌우 이동
        velocity.z = moveDirection.z * moveSpeed; //전후 이동

        _rigidbody.velocity = velocity; //속도 적용

        return moveDirection; //방향 변환
    }

    public Vector3 SetAimRotation() //기본 상태 마우스 회전 설정
    {
        Vector2 mouseDir = GetMouseDirection(); //마우스 방향 설정

        //  *x축의 경우라면 제한을 걸 필요 없음*
        _currentRotation.x += mouseDir.x; //좌우 회전

        // *y축의 경우엔 각도 제한을 걸어야 함.*
        _currentRotation.y = Mathf.Clamp( 
            _currentRotation.y + mouseDir.y,
            _minPitch,
            _maxPitch
            );//y값 설정, y값은 minPitch, maxPitch로 제한을 걸어야 하기 때문에 이를 _currentRotation.y에 할당.

        // *캐릭터 오브젝트의 경우에는 Y축 회전만 반영*
        transform.rotation = Quaternion.Euler(0, _currentRotation.x, 0); //플레이어 전체 오브젝트는 y축만 반영

        // *에임의 경우 상하 회전 반영*
        Vector3 currentEuler = _aim.localEulerAngles; //카메라 홀더는 x축만 반영(상하 회전)
        _aim.localEulerAngles = new Vector3(_currentRotation.y, currentEuler.y, currentEuler.z); // 에임시 점시 적용된 값들의 X축을 _currentRotation.y의 값으로 대체(회전각인가?), 나머지 currentEuler값을 할당.

        // 회전 방향 반환 (앞 방향)
        Vector3 rotateDirVector = transform.forward; //현재 오브젝트의 정면 방향을 rotateDirVector 변수에 할당
        rotateDirVector.y = 0; // 변수의 y값은 0으로 고정
        return rotateDirVector.normalized; // 할당된 정면 방향을 nomalize 
    }

    public void SetAvatarRotation(Vector3 direction) //기본상태 캐릭터 회전 설정
    {
        if (direction == Vector3.zero) return; //캐릭터 방향값이 없다면 반환, 아무것도 하지 않음.

        Quaternion targetRotation = Quaternion.LookRotation(direction); // 오브젝트가 바라보는 방향의 값을 targetRotation으로 할당

        _avatar.rotation = Quaternion.Lerp(
            _avatar.rotation,
            targetRotation,
            _playerStatus.RotateSpeed * Time.deltaTime
            ); //캐릭터의 회전 설정, 몸체(_avatar.rotation)를 targetRotation방향으로, _playerStatus.RotateSpeed * Time.dletaTime 의 속도로 회전시킨다.
    }

    private Vector2 GetMouseDirection() //마우스 방향 설정을 위한 마우스 현재값 반환하기
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity; //마우스의 x축 이동 구현
        float mouseY = -Input.GetAxis("Mouse Y") * _mouseSensitivity; //마우스의 y축 이동 구현

        return new Vector2(mouseX, mouseY); //마우스 현재값을 반환
    }
    
    // *벡터 그림 (수업 후)*
    public Vector3 GetMoveDirection() //캐릭터 방향값 반환?
    {
        Vector3 input = GetInputDirection(); //입력받은 캐릭터의 방향값을 input에 할당

        Vector3 direction =
           (transform.right * input.x) + 
           (transform.forward * input.z); //카메라/플레이어 기준으로 방향 변환 

        return direction.normalized; // 방향값을 normalize
    }

    public Vector3 GetInputDirection() //간단한 이동 구현
    {
        float x = Input.GetAxisRaw("Horizontal"); //y축 이동
        float z = Input.GetAxisRaw("Vertical"); //x축 이동

        return new Vector3(x, 0, z); //이동값 반환
    }
}


















