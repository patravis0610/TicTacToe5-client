using UnityEngine;
using UnityEngine.SceneManagement;

// Main ȭ�鿡�� ����ȭ������ �Ѿ�� ����(�� ��ȯ), ������ �̱��� ��ü
public class GameManager : Singleton<GameManager> // Singleton<T>�� ��ӹ���             
{
    [SerializeField] private GameObject confirmPanel; // Confirm Panel ���� ������Ʈ
    //Main Scene���� ������ ���� Ÿ��
    private Constants.GameType _gametype; //���� Ÿ���� �����ϴ� ����

    //panel�� ���� ���� Canvas ����
    private Canvas _canvas; //ĵ���� ������Ʈ

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

    //<summary>
    //Confirm Panel�� ���� �޼���
    //</summary>
    //<param name="message"></param>
    public void OpenConfirmPanel(string message,
        ConfirmPanelController.OnConfirmButtonClicked onConfirmButtonClicked)//Ȯ�� ��ư Ŭ�� ��������Ʈ
    {
        if(_canvas != null) //���� Canvas ������Ʈ�� ���� ��
        {
           var confirmPanelObject = Instantiate(confirmPanel, _canvas.transform); //Confirm Panel ����
            confirmPanelObject.GetComponent<ConfirmPanelController>()
                .Show(message, onConfirmButtonClicked); //Confirm Panel ǥ��
        }
    }


    // Singleton<T>�� �߻� �޼��� ����
    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode) //F12Ű Ŭ�� LoadSceneMode �ڼ���
    {
        //TODO: ���� ��ȯ�� �� ó���� �Լ�
        
        _canvas = FindFirstObjectByType<Canvas>(); //���� �ִ� Canvas ������Ʈ ã��   
    }
}
