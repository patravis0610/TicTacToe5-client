using TMPro;
using UnityEngine;

public class ConfirmPanelController : PanelController 
{
    [SerializeField] private TMP_Text messageText; // 메시지 텍스트 컴포넌트

    //<summary>
    //Confirm Panel을 표시하는 메서드
    //</summary>
    public void Show(string message)
    {
        messageText.text = message; // 메시지 설정
        base.Show(); // 부모 클래스의 Show 메서드 호출

    }

    // <summary>
    // 확인버튼 클릭 시 호출되는 메서드    
    /// </summary>
    public void OnClickConfirmButton()
    {
        Hide();
    }

    // <summary>
    // X 닫기버튼 클릭 시 호출되는 메서드
    // </summary>   
    public void OnClickCloseButton()
    {
        Hide();
    }
}
