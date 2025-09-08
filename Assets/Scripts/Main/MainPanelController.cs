using UnityEngine;
//��ư������ �޼��� �����
public class MainPanelController : MonoBehaviour
{
    public void OnClickSinglePlayButton() //�̱� �÷��� ��ư Ŭ���� ȣ��Ǵ� �޼���
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.SinglePlay); //�̱��� �ν��Ͻ� ����
    }

    public void OnClickDualPlayButton()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.DualPlay); 
    }

    public void OnClickMultiPlayButton()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.MultiPlay);
    }

    public void OnClickSettingsButton()
    {
        
    }
}
