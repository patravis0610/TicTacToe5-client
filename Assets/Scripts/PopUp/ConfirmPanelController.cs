using TMPro;
using UnityEngine;

public class ConfirmPanelController : PanelController 
{
    [SerializeField] private TMP_Text messageText; // �޽��� �ؽ�Ʈ ������Ʈ

    // Confirm ��ư Ŭ�� �� ȣ��Ǵ� ��������Ʈ(�븮��) ����
    public delegate void OnConfirmButtonClicked(); // Ȯ�� ��ư Ŭ�� ��������Ʈ ����
    private OnConfirmButtonClicked _onConfirmButtonClicked; // ��������Ʈ �ν��Ͻ�    

    //<summary>
    //Confirm Panel�� ǥ���ϴ� �޼���
    //</summary>
    public void Show(string message, OnConfirmButtonClicked onConfirmButtonClicked)
    {
        messageText.text = message; // �޽��� ����
        _onConfirmButtonClicked = onConfirmButtonClicked; // ��������Ʈ ����
        base.show(); // �θ� Ŭ������ Show �޼��� ȣ��

    }

    // <summary>
    // Ȯ�ι�ư Ŭ�� �� ȣ��Ǵ� �޼���    
    /// </summary>
    public void OnClickConfirmButton()
    {
        Hide(() =>
        {
            _onConfirmButtonClicked?.Invoke(); // �г� ����� �� ��������Ʈ ȣ��

            });
    }

    // <summary>
    // X �ݱ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    // </summary>   
    public void OnClickCloseButton()
    {
        Hide();
    }
}
