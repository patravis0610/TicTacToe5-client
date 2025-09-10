using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PanelController : MonoBehaviour
{
    // 팝업창 RectTransform 컴포넌트
    [SerializeField] private RectTransform panelRectTransform; // 패널의 RectTransform 컴포넌트

    //앞에 언더바를 넣는 이유는 private 멤버 변수임을 명시하기 위함입니다.
    //함수안에 넣는 지역 변수는 앞에 언더바를 넣지 않습니다.
    private CanvasGroup _backgroundCanvasGroup; // 배경 CanvasGroup 컴포넌트

    //panel이 hide될 때 해야할 동작
    public delegate void PanelControllerHideDelegate(); // 패널 숨김 델리게이트(대리자) 선언

    private void Awake()
    {
        // CanvasGroup 컴포넌트 가져오기
        _backgroundCanvasGroup = GetComponent<CanvasGroup>();
    }

    // <summary>
    //panel 표시
    // </summary>
    public void show()
    {
        _backgroundCanvasGroup.alpha = 0; // 배경 투명도 설정
        panelRectTransform.localScale = Vector3.zero; // 패널 크기 설정   

        _backgroundCanvasGroup.DOFade(1, 0.3f).SetEase(Ease.Linear); // 배경 페이드 인 애니메이션
        panelRectTransform.DOScale(1, 0.3f).SetEase(Ease.OutBack); // 패널 팝업 애니메이션
    }

    // <summary>
    //panel 숨기기
    // </summary>
    public void Hide(PanelControllerHideDelegate hideDelegate = null)
    {
        _backgroundCanvasGroup.alpha = 1; // 배경 투명도 설정
        panelRectTransform.localScale = Vector3.one; // 패널 크기 설정   

        _backgroundCanvasGroup.DOFade(0, 0.3f).SetEase(Ease.Linear); // 배경 페이드 인 애니메이션
        panelRectTransform.DOScale(0, 0.3f).SetEase(Ease.InBack)  // 패널 팝업 애니메이션
            .OnComplete(() =>
            {
                hideDelegate?.Invoke(); // 델리게이트가 null이 아니면 호출
                Destroy(gameObject); // 패널 오브젝트 파괴
            }); // 애니메이션 완료 후 패널 비활성화
    }
}
