using UnityEngine;
using UnityEngine.SceneManagement;

// Main 화면에서 게임화면으로 넘어가는 역할(씬 전환), 유일한 싱글턴 개체
public class GameManager : Singleton<GameManager> // Singleton<T>를 상속받음             
{
    //Main Scene에서 선택한 게임 타입
    private Constants.GameType _gametype; //게임 타입을 저장하는 변수
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

    // Singleton<T>의 추상 메서드 구현
    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //TODO: 씬이 전환될 때 처리할 함수
        
    }
}
