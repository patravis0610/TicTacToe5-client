using TMPro;
using UnityEngine;

public class ConfirmPanelController : PanelController 
{
    [SerializeField] private TMP_Text messageText; // 메시지 텍스트 컴포넌트

    // Confirm 버튼 클릭 시 호출되는 델리게이트(대리자) 선언
    public delegate void OnConfirmButtonClicked(); // 확인 버튼 클릭 델리게이트 선언
    private OnConfirmButtonClicked _onConfirmButtonClicked; // 델리게이트 인스턴스    

    //<summary>
    //Confirm Panel을 표시하는 메서드
    //</summary>
    public void Show(string message, OnConfirmButtonClicked onConfirmButtonClicked)
    {
        messageText.text = message; // 메시지 설정
        _onConfirmButtonClicked = onConfirmButtonClicked; // 델리게이트 설정
        base.show(); // 부모 클래스의 Show 메서드 호출

    }

    // <summary>
    // 확인버튼 클릭 시 호출되는 메서드    
    /// </summary>
    public void OnClickConfirmButton()
    {
        Hide(() =>
        {
            _onConfirmButtonClicked?.Invoke(); // 패널 숨기기 및 델리게이트 호출

            });
    }

    // <summary>
    // X 닫기버튼 클릭 시 호출되는 메서드
    // </summary>   
    public void OnClickCloseButton()
    {
        Hide();
    }
}
