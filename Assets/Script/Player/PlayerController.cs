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
       //     // TODO : Movement ���ս� ��� �߰�����
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
        //�Ʒ� �޼��忡 ���� �ҽ��ڵ�� ���� ������� ����մϴ�.
        //public void MoveTest()
        //{
        //    //(ȸ�� ���� ��)���� ȸ���� ���� ���� ��ȯ
        //    Vector3 camRotateDir = _movement.SetAimRotation();
        //
        //    float moveSpeed;
        //    if (_status.IsAming.Value) moveSpeed = _status.WalkSpeed;
        //    else moveSpeed = _status.RunSpeed;
        //
        //    Vector3 moveDir = _movement.SetMove(moveSpeed);
        //    _status.IsMoving.Value = (moveDir != Vector3.zero);
        //
        //    //��ü�� ȸ��
        //    Vector3 avatarDir;
        //    if (_status.IsAming.Value) avatarDir = camRotateDir;
        //    else avatarDir = moveDir;
        //
        //    _movement.SetAvatarRotation(avatarDir);
        //
        //}
    }
}
