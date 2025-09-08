using TMPro;
using UnityEngine;

public class ConfirmPanelController : PanelController 
{
    [SerializeField] private TMP_Text messageText; // �޽��� �ؽ�Ʈ ������Ʈ

    //<summary>
    //Confirm Panel�� ǥ���ϴ� �޼���
    //</summary>
    public void Show(string message)
    {
        messageText.text = message; // �޽��� ����
        base.Show(); // �θ� Ŭ������ Show �޼��� ȣ��

    }

    // <summary>
    // Ȯ�ι�ư Ŭ�� �� ȣ��Ǵ� �޼���    
    /// </summary>
    public void OnClickConfirmButton()
    {
        Hide();
    }

    // <summary>
    // X �ݱ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    // </summary>   
    public void OnClickCloseButton()
    {
        Hide();
    }
}
