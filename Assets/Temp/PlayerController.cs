using UnityEngine;

namespace PHG_test
{
    /// <summary>
    // <Movement 테스트용으로 구현한 클래스입니다.
    // 해당 파트 구현하시는 분은 참고하시고 작업 후  Movement 호출 관련 메서드 정리 끝나시면 삭제하셔도 됩니다.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public PlayerMovement _movement;
        public PlayerStatus _status;
        private void Update()
        {
            MoveTest();

            //IsAiming 변경용 테스트 코드
            _status.IsAming.Value = Input.GetKey(KeyCode.Mouse1);
        }
        //아래 메서드에 적힌 소스코드와 같은 방식으로 사용합니다.
        public void MoveTest()
        {
            //(회전 수행 후)좌위 회전에 대한 벡터 반환
            Vector3 camRotateDir = _movement.SetAimRotation();

            float moveSpeed;
            if (_status.IsAming.Value) moveSpeed = _status.WalkSpeed;
            else moveSpeed = _status.RunSpeed;

            Vector3 moveDir = _movement.SetMove(moveSpeed);
            _status.IsMoving.Value = (moveDir != Vector3.zero);

            //몸체의 회전
            Vector3 avatarDir;
            if (_status.IsAming.Value) avatarDir = camRotateDir;
            else avatarDir = moveDir;

            _movement.SetAvatarRotation(avatarDir);

        }
    }
}
