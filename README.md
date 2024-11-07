# HororEscapeRoom

스파르타 부트캠프 Unity 3D 숙련주차 팀 프로젝트
-

팀장 - 박현도

팀원 - 김성호, 박두산, 성기혁

프로젝트 기간 : 24.10.31 ~ 24.11.07 (7일)

장르 : 공포, 퍼즐, 탈출

**구현 범위**

팀장 박현도

1. 퀵슬롯
      - 아이템 추가시 Slots[] 에 ItemData 의 값을 저장
      - 아이템 수량 전체 소모시 SortItemInSlot메서드에서 다음 칸의 ItemData를 앞배열로 저장
      - 플레이어가 아이템 장착시 장착 아이템 슬롯을 확인시켜주는 CurEquipShow 메서드를 통하여 아이템슬롯 칸 확대및 축소
      - 휠 업&다운 또는 키보드 숫자버튼을 입력받아 그 값에 대응되는 Slots[]의 데이터에 접근
2. 장비 아이템
      - 마우스 클릭에 대하여 InputAction 을 등록하고, 각 아이템의 용도에 맞는 메서드를 호출하여 사용
4. 아이템
      - 각 용도에 맞게 Interface를 상속받아 대응되는 Interactable Object에 사용가능하게끔 설계
        
팀원 김성호
1. Hint UI
      - Hint아이템 추가시 HintsButton과 Panel에 ItemData 의 값을 인덱스에 저장하는 기능
      - ItemData에서 힌트인지를 체크한후 힌트인경우 해당 오브젝트를 enable한후 저장
        
2. 직소퍼즐
      - 그림과 알맞게 퍼즐조각을 배치하도록 제작
      - 플레이어가 마우스드래그를 통해 퍼즐을 옯기로 퍼즐과 퍼즐의 위치가 50이내로 일치할경우 자동 스냅되도록 제작
      - 게임시작시 퍼즐조각들은 캔버스 기준 300*300이내의 랜덤한 위치로 이동하여 섞이도록 제작
  
3. ESC UI
      - ESC를 누를경우 일시정지후 UI버튼 선택

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

1. 세이브로드매니저
   - 데이터를 저장 및 로드하는 기능을 관리하는 오브젝트
   - 특정 형식의 데이터 모음을 만들어서 그에 맞는 정보를
   - 게임에서 불러와 저장하거나 맞는 위치에 정보를 넣어주는 역할


2. 퀘스트 매니저
   - 퀘스트목록 및 관련 정보를 갖고있는 오브젝트.
   - 특정 상황에 호출되면 진행상황이 변하는 함수가 있고
   - 진행상황에 따라 questUI를 변경하기도 한다.

3. 아이템 매니저
   - 맵상에 존재하는 아이템들 관련 정보를 갖고있는 오브젝트.
   - 저장 및 로드할때 중요한 아이템 정보를 보내줘 
   - 아이템이 저장시 정보와 로드시 정보를 같게 만들어줌.

4. 키패드
   - 문을 열 때 비밀번호를 통해 잠금을 해제하는 경우 사용되는 오브젝트.
   - 각 버튼별로 해당하는 숫자가 있고 이전에 정해놓은 수와
   - 입력받은 수가 같으면 문의 잠금을 해제하는 함수를 호출.

5. 초기 UI
   - MainScene의 초기 UI를 담당함. 
   - 간단하게 틀만 잡았었음. 



























 
Sound Effect from <a href="https://pixabay.com/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=47561">Pixabay</a>

Sound Effect by <a href="https://pixabay.com/users/u_wq5g39nvop-29650515/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=252488">u_wq5g39nvop</a> from <a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=252488">Pixabay</a>

Sound Effect by <a href="https://pixabay.com/users/hasin2004-46173687/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=247415">Hasin Amanda</a> from <a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=247415">Pixabay</a>
