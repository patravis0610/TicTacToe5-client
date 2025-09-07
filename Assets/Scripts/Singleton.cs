using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Singleton<T> : MonoBehaviour where T : Component //T는 컴포넌트 타입이어야함
{
    private static T _instance; //싱글턴 인스턴스를 저장하는 정적 변수   
    //인스턴스 프로퍼티: get과 set값 사용
    public static T Instance //싱글턴 인스턴스에 접근하는 정적 프로퍼티
    {
        get //get만 선언해서 값을 읽어나감 
        {
            if (_instance == null) //_instance가 null이면
            {
                _instance = FindFirstObjectByType<T>(); //씬에서 T타입의 컴포넌트를 찾아서 _instance에 할당
                if (_instance == null) //씬에 T타입의 컴포넌트가 없으면
                {
                    GameObject obj = new GameObject(); //새 게임오브젝트 생성
                    obj.name = typeof(T).Name; //게임오브젝트 이름을 T타입의 이름으로 설정
                    _instance = obj.AddComponent<T>(); //T타입의 컴포넌트를 추가하고 _instance에 할당
                }
            }
            return _instance; //_instance 반환
        }
    }

    private void Awake()    //오브젝트가 활성화될 때 호출되는 메서드
    {
        if (_instance == null) //이미 게임메니저가 만들어진 상태
        {
            _instance = this as T; //현재 오브젝트를 T타입으로 변환하여 _instance에 할당ㄴ
            DontDestroyOnLoad(gameObject); //씬이 바뀌어도 파괴되지 않음    
            //씬 전환시 호출되는 액션 메서드 할당
            SceneManager.sceneLoaded += OnSceneLoad;    //씬이 로드될 때 호출되는 메서드 등록


        }
        else //이미 게임메니저가 만들어진 상태
        {
            Destroy(gameObject); //또다른 게임 메니저가  생성된 상태 -지우기
        }
    }
    protected abstract void OnSceneLoad(Scene scene, LoadSceneMode mode); //씬이 로드될 때 호출되는 추상 메서드

}


