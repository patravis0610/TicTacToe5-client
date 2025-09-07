using UnityEngine;
using UnityEngine.SceneManagement;

// Main ȭ�鿡�� ����ȭ������ �Ѿ�� ����(�� ��ȯ), ������ �̱��� ��ü
public class GameManager : Singleton<GameManager> // Singleton<T>�� ��ӹ���             
{
    //Main Scene���� ������ ���� Ÿ��
    private Constants.GameType _gametype; //���� Ÿ���� �����ϴ� ����
    //<summary>
    //Main���� Game ������ ��ȯ�� ȣ��Ǵ� �޼���  
    //</summary>
    public void ChangeToGameScene(Constants.GameType gametype) 
    {
        _gametype = gametype; //���� Ÿ�� ����
        //0 : �̱��÷���, 1: ����÷���, 2: ��Ƽ�÷���
        SceneManager.LoadScene("Game"); //�� ��ȯ
    }

    //<summary>
    //Game ������ Main ������ ��ȯ�� ȣ��Ǵ� �޼���
    //</summary>
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Main"); //�� ��ȯ  
    }

    // Singleton<T>�� �߻� �޼��� ����
    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        //TODO: ���� ��ȯ�� �� ó���� �Լ�
        
    }
}
