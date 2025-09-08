using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour
{
    // �˾�â RectTransform ������Ʈ
    [SerializeField] private RectTransform panelRectTransform; // �г��� RectTransform ������Ʈ

    //�տ� ����ٸ� �ִ� ������ private ��� �������� ����ϱ� �����Դϴ�.
    //�Լ��ȿ� �ִ� ���� ������ �տ� ����ٸ� ���� �ʽ��ϴ�.
    private CanvasGroup _backgroundCanvasGroup; // ��� CanvasGroup ������Ʈ

    private void Awake()
    {
        // CanvasGroup ������Ʈ ��������
        _backgroundCanvasGroup = GetComponent<CanvasGroup>();
    }

    // <summary>
    //panel ǥ��
    // </summary>
    public void show()
    {
         _backgroundCanvasGroup.alpha = 0; // ��� ���� ����
        panelRectTransform.localScale = Vector3.zero; // �г� ũ�� ����   

        _backgroundCanvasGroup.DOFade(1, 0.3f).SetEase(Ease.Linear); // ��� ���̵� �� �ִϸ��̼�
        panelRectTransform.DOScale(1, 0.3f).SetEase(Ease.OutBack); // �г� �˾� �ִϸ��̼�
    }

    // <summary>
    //panel �����
    // </summary>
    public void Hide()
    {
        _backgroundCanvasGroup.alpha = 1; // ��� ���� ����
        panelRectTransform.localScale = Vector3.one; // �г� ũ�� ����   

        _backgroundCanvasGroup.DOFade(0, 0.3f).SetEase(Ease.Linear); // ��� ���̵� �� �ִϸ��̼�
        panelRectTransform.DOScale(0, 0.3f).SetEase(Ease.InBack); // �г� �˾� �ִϸ��̼�
    }

    internal void Show()
    {
        throw new NotImplementedException();
    }
}
