using UnityEngine;
//버튼마다의 메서드 만들기
public class MainPanelController : MonoBehaviour
{
    public void OnClickSinglePlayButton() //싱글 플레이 버튼 클릭시 호출되는 메서드
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.SinglePlay); //싱글턴 인스턴스 접근
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
