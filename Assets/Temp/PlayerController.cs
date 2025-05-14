using UnityEngine;

namespace PHG_test
{
    /// <summary>
    // <Movement �׽�Ʈ������ ������ Ŭ�����Դϴ�.
    // �ش� ��Ʈ �����Ͻô� ���� �����Ͻð� �۾� ��  Movement ȣ�� ���� �޼��� ���� �����ø� �����ϼŵ� �˴ϴ�.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public PlayerMovement _movement;
        public PlayerStatus _status;
        private void Update()
        {
            MoveTest();

            //IsAiming ����� �׽�Ʈ �ڵ�
            _status.IsAming.Value = Input.GetKey(KeyCode.Mouse1);
        }
        //�Ʒ� �޼��忡 ���� �ҽ��ڵ�� ���� ������� ����մϴ�.
        public void MoveTest()
        {
            //(ȸ�� ���� ��)���� ȸ���� ���� ���� ��ȯ
            Vector3 camRotateDir = _movement.SetAimRotation();

            float moveSpeed;
            if (_status.IsAming.Value) moveSpeed = _status.WalkSpeed;
            else moveSpeed = _status.RunSpeed;

            Vector3 moveDir = _movement.SetMove(moveSpeed);
            _status.IsMoving.Value = (moveDir != Vector3.zero);

            //��ü�� ȸ��
            Vector3 avatarDir;
            if (_status.IsAming.Value) avatarDir = camRotateDir;
            else avatarDir = moveDir;

            _movement.SetAvatarRotation(avatarDir);

        }
    }
}
