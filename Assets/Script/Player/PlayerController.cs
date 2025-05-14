using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PHG_Origin
{
    public class PlayerController : MonoBehaviour
    {
       // public bool IsControlActivate { get; set; } = true;
       // private PlayerStatus _status;
       // private PlayerMovement _movement;
       // [SerializeField] private KeyCode _aimKey = KeyCode.Mouse1;
       //
       // [SerializeField] private GameObject _aimCamera;
       // private GameObject _mainCamera;
       // private void Awake() => Init();
       // private void OnEnable() => SubscribeEvents();
       // private void Update()
       // {
       //     HandlePlayerControl();
       //     MoveTest();
       // }
       // private void OnDisable() => UnSubscribeEvents();
       //
       //
       //
       // private void Init()
       // {
       //     _status = GetComponent<PlayerStatus>();
       //     _movement = GetComponent<PlayerMovement>();
       //     _mainCamera = Camera.main.gameObject;
       // }
       // private void HandlePlayerControl()
       // {
       //     if (!IsControlActivate) return;
       //     HandleMovement();
       //     HandleAiming();
       // }
       // private void HandleMovement()
       // {
       //     // TODO : Movement 병합시 기능 추가예정
       // }
       //
        //private void HandleAiming()
        //{
        //    _status.IsAming.Value = Input.GetKey(_aimKey);
        //
        //}
        //
        //public void SubscribeEvents()
        //{
        //    _status.IsAming.Subscribe(value => SetActivateAimCamera(value));
        //
        //}
        //
        //public void UnSubscribeEvents()
        //{
        //    _status.IsAming.Unsubscribe(value => SetActivateAimCamera(value));
        //}

        //private void SetActivateAimCamera(bool value)
        //{
        //    _aimCamera.SetActive(value);
        //    _mainCamera.SetActive(!value);
        //}
        //아래 메서드에 적힌 소스코드와 같은 방식으로 사용합니다.
        //public void MoveTest()
        //{
        //    //(회전 수행 후)좌위 회전에 대한 벡터 반환
        //    Vector3 camRotateDir = _movement.SetAimRotation();
        //
        //    float moveSpeed;
        //    if (_status.IsAming.Value) moveSpeed = _status.WalkSpeed;
        //    else moveSpeed = _status.RunSpeed;
        //
        //    Vector3 moveDir = _movement.SetMove(moveSpeed);
        //    _status.IsMoving.Value = (moveDir != Vector3.zero);
        //
        //    //몸체의 회전
        //    Vector3 avatarDir;
        //    if (_status.IsAming.Value) avatarDir = camRotateDir;
        //    else avatarDir = moveDir;
        //
        //    _movement.SetAvatarRotation(avatarDir);
        //
        //}
    }
}
