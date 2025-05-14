using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _avatar;// ��ü
    [SerializeField] private Transform _aim; //ī�޶� Ȧ��

    private Rigidbody _rigidbody; //��ü�� ������ �ٵ�
    private PlayerStatus _playerStatus; // �÷��̾� ����

    [Header("Mouse Config")]
    [SerializeField][Range(-90, 0)] private float _minPitch; // Y���� ī�޶� �ּҰ�
    [SerializeField][Range(0, 90)] private float _maxPitch; //Y���� ī�޶� �ִ밢
    [SerializeField][Range(0, 5)] private float _mouseSensitivity = 1; // ���콺 �ΰ���

    private Vector2 _currentRotation; //���콺 ȸ���� ���� ���� ȸ�� ����

    private void Awake() => Init(); //���� ���� �� �ʱ�ȭ

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>(); //������ �ٵ𿡼� ���� ���� _rigidbody �� ����
        _playerStatus = GetComponent<PlayerStatus>(); // PlayerStatus���� ���� ���� _playerStatus�� ����
    }

    public Vector3 SetMove(float moveSpeed) //�̵� ����
    {
        Vector3 moveDirection = GetMoveDirection(); //���� ������ ���� GetMoveDirection �޼��忡�� ����(return)�� �޾ƿ�.

        Vector3 velocity = _rigidbody.velocity; //���� �ӵ� ����
        velocity.x = moveDirection.x * moveSpeed; //�¿� �̵�
        velocity.z = moveDirection.z * moveSpeed; //���� �̵�

        _rigidbody.velocity = velocity; //�ӵ� ����

        return moveDirection; //���� ��ȯ
    }

    public Vector3 SetAimRotation() //�⺻ ���� ���콺 ȸ�� ����
    {
        Vector2 mouseDir = GetMouseDirection(); //���콺 ���� ����

        //  *x���� ����� ������ �� �ʿ� ����*
        _currentRotation.x += mouseDir.x; //�¿� ȸ��

        // *y���� ��쿣 ���� ������ �ɾ�� ��.*
        _currentRotation.y = Mathf.Clamp( 
            _currentRotation.y + mouseDir.y,
            _minPitch,
            _maxPitch
            );//y�� ����, y���� minPitch, maxPitch�� ������ �ɾ�� �ϱ� ������ �̸� _currentRotation.y�� �Ҵ�.

        // *ĳ���� ������Ʈ�� ��쿡�� Y�� ȸ���� �ݿ�*
        transform.rotation = Quaternion.Euler(0, _currentRotation.x, 0); //�÷��̾� ��ü ������Ʈ�� y�ุ �ݿ�

        // *������ ��� ���� ȸ�� �ݿ�*
        Vector3 currentEuler = _aim.localEulerAngles; //ī�޶� Ȧ���� x�ุ �ݿ�(���� ȸ��)
        _aim.localEulerAngles = new Vector3(_currentRotation.y, currentEuler.y, currentEuler.z); // ���ӽ� ���� ����� ������ X���� _currentRotation.y�� ������ ��ü(ȸ�����ΰ�?), ������ currentEuler���� �Ҵ�.

        // ȸ�� ���� ��ȯ (�� ����)
        Vector3 rotateDirVector = transform.forward; //���� ������Ʈ�� ���� ������ rotateDirVector ������ �Ҵ�
        rotateDirVector.y = 0; // ������ y���� 0���� ����
        return rotateDirVector.normalized; // �Ҵ�� ���� ������ nomalize 
    }

    public void SetAvatarRotation(Vector3 direction) //�⺻���� ĳ���� ȸ�� ����
    {
        if (direction == Vector3.zero) return; //ĳ���� ���Ⱚ�� ���ٸ� ��ȯ, �ƹ��͵� ���� ����.

        Quaternion targetRotation = Quaternion.LookRotation(direction); // ������Ʈ�� �ٶ󺸴� ������ ���� targetRotation���� �Ҵ�

        _avatar.rotation = Quaternion.Lerp(
            _avatar.rotation,
            targetRotation,
            _playerStatus.RotateSpeed * Time.deltaTime
            ); //ĳ������ ȸ�� ����, ��ü(_avatar.rotation)�� targetRotation��������, _playerStatus.RotateSpeed * Time.dletaTime �� �ӵ��� ȸ����Ų��.
    }

    private Vector2 GetMouseDirection() //���콺 ���� ������ ���� ���콺 ���簪 ��ȯ�ϱ�
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity; //���콺�� x�� �̵� ����
        float mouseY = -Input.GetAxis("Mouse Y") * _mouseSensitivity; //���콺�� y�� �̵� ����

        return new Vector2(mouseX, mouseY); //���콺 ���簪�� ��ȯ
    }
    
    // *���� �׸� (���� ��)*
    public Vector3 GetMoveDirection() //ĳ���� ���Ⱚ ��ȯ?
    {
        Vector3 input = GetInputDirection(); //�Է¹��� ĳ������ ���Ⱚ�� input�� �Ҵ�

        Vector3 direction =
           (transform.right * input.x) + 
           (transform.forward * input.z); //ī�޶�/�÷��̾� �������� ���� ��ȯ 

        return direction.normalized; // ���Ⱚ�� normalize
    }

    public Vector3 GetInputDirection() //������ �̵� ����
    {
        float x = Input.GetAxisRaw("Horizontal"); //y�� �̵�
        float z = Input.GetAxisRaw("Vertical"); //x�� �̵�

        return new Vector3(x, 0, z); //�̵��� ��ȯ
    }
}


















