# HororEscapeRoom

스파르타 부트캠프 Unity 3D 숙련주차 팀 프로젝트
-

팀장 - 박현도

팀원 - 김성호, 박두산, 성기혁

프로젝트 기간 : 24.10.31 ~ 24.11.07 (7일)

장르 : 공포, 퍼즐, 탈출

**구현 범위**

팀장 박현도

-
-

팀원 김성호

-
-

팀원 박두산

1. 플레이어 컨트롤
   - InputSystem에서 사용되는 가능한 모든 조작은 이 스크립트에서 처리하도록 했음
   - OnMove, OnLook, OnInteract, OnSprint 등등
   - 이동 시 스크립트로 작성된 PlayerController는 계단에 약해서 Ray를 통해 이동 방향 Stair 레이어 감지 시
     RigidBody에 y값 벡터를 추가함으로써 부드럽게 올라가도록 구현
   - OnInteract는 event Action처리하여 구독하여 실행가능하게 처리함
     public void OnInteract(InputAction.CallbackContext context)
     {
       if (context.phase == InputActionPhase.Started)
       {
          Interaction?.Invoke();
       }
     }
     
2. 오디오 매니저
   -  오브젝트 풀링을 이용하여 동시에 최대 5개의 효과음이 실행 가능하도록 제작
   -  매니저의 싱글톤은 싱글톤 제너릭을 사용하여 상속 후 필요한 부분만 구현하여 제작

3. 아이템데이터 SO파일 제작
   - 크게 ItemData, InteractableData, AnimatedData로 구분하여 아이템과 상호작용, 애니메이션을 구분함
   - 각각의 타입도 상속을 통해 사용되는 오브젝트의 공통점을 생각해 코드의 재사용성을 고려함
   - 생각보다 각각의 오브젝트의 상호작용 방향이 전부 달라서 재사용성이 낮은 편 (다음에는 Object들을 상속하고 Data는 최대한 간단한 데이터만으로)
   - SO파일은 빌드 시의 세팅이 저장되어 변경되는 값은 최대한 제거함

4. 상호작용
   - IInteractable 인터페이스를 이용하여 상호작용이 가능한 모든 오브젝트에 상속을 통해 상호작용이 용이하게 함
   - GetPrompt()를 통해 정보를 얻고 Interact()를 통해 상호작용
   - TryGetComponent와 GetType() == typeof()를 사용해 인터페이스로 받아온 데이터를 분류 가능케 함

5. 강당 퍼즐
   - 4종류의 색이 랜덤하게 출력되고 그 순서를 기억해서 입력하여 출력과 입력이 같다면 성공으로 제작
   - 총 4회 진행되며 진행 중에는 문이 잠궈지고 틀렸다면 다시 처음부터 4회 진행
   - 약한 점프스케어 추가
  

팀원 성기혁

-
-



























 
Sound Effect from <a href="https://pixabay.com/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=47561">Pixabay</a>

Sound Effect by <a href="https://pixabay.com/users/u_wq5g39nvop-29650515/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=252488">u_wq5g39nvop</a> from <a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=252488">Pixabay</a>

Sound Effect by <a href="https://pixabay.com/users/hasin2004-46173687/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=247415">Hasin Amanda</a> from <a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=247415">Pixabay</a>
