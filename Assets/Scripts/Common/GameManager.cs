using UnityEngine;
using UnityEngine.SceneManagement;

// Main 화면에서 게임화면으로 넘어가는 역할(씬 전환), 유일한 싱글턴 개체
public class GameManager : Singleton<GameManager> // Singleton<T>를 상속받음             
{
    [SerializeField] private GameObject confirmPanel; // Confirm Panel 게임 오브젝트
    //Main Scene에서 선택한 게임 타입
    private Constants.GameType _gametype; //게임 타입을 저장하는 변수

    //panel을 띄우기 위한 Canvas 정보
    private Canvas _canvas; //캔버스 컴포넌트

    //<summary>
    //Main에서 Game 씬으로 전환시 호출되는 메서드  
    //</summary>
    public void ChangeToGameScene(Constants.GameType gametype) 
    {
        _gametype = gametype; //게임 타입 저장
        //0 : 싱글플레이, 1: 듀얼플레이, 2: 멀티플레이
        SceneManager.LoadScene("Game"); //씬 전환
    }

    //<summary>
    //Game 씬에서 Main 씬으로 전환시 호출되는 메서드
    //</summary>
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Main"); //씬 전환  
    }

    //<summary>
    //Confirm Panel을 띄우는 메서드
    //</summary>
    //<param name="message"></param>
    public void OpenConfirmPanel(string message,
        ConfirmPanelController.OnConfirmButtonClicked onConfirmButtonClicked)//확인 버튼 클릭 델리게이트
    {
        if(_canvas != null) //씬에 Canvas 컴포넌트가 없을 때
        {
           var confirmPanelObject = Instantiate(confirmPanel, _canvas.transform); //Confirm Panel 생성
            confirmPanelObject.GetComponent<ConfirmPanelController>()
                .Show(message, onConfirmButtonClicked); //Confirm Panel 표시
        }
    }


    // Singleton<T>의 추상 메서드 구현
    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode) //F12키 클릭 LoadSceneMode 자세히
    {
        //TODO: 씬이 전환될 때 처리할 함수
        
        _canvas = FindFirstObjectByType<Canvas>(); //씬에 있는 Canvas 컴포넌트 찾기   
    }
}
