using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
public class SandClock : MonoBehaviour
{
    [SerializeField] private Image fillTopImage;
    [SerializeField] private Image fillBottomImage;
    [SerializeField] private Image sandDotsImage;
    [SerializeField] private RectTransform sandPyramidRect;
    [SerializeField] private TextMeshProUGUI roundText;

    [Space(30f)]
    public float roundDuration = 10f;
    public int totalRounds = 3;

    private int currentRound = 0;
    private float defaultSandPyramidYPos;

    // Events
    [HideInInspector] public UnityAction onAllRoundsCompleted;
    [HideInInspector] public UnityAction<int> onRoundStart;
    [HideInInspector] public UnityAction<int> onRoundEnd;

    private void Awake()
    {
        SetRoundText(totalRounds);

        defaultSandPyramidYPos = sandPyramidRect.anchoredPosition.y;

        sandDotsImage.DOFade(0f, 0f);
    }
    
    public void Begin()
    {
        ++currentRound;

        // Round start event
        if(onRoundStart != null)
        {
            onRoundStart.Invoke(currentRound);
        }        

        sandDotsImage.DOFade(1f, 0.8f);

        sandDotsImage.material
            .DOOffset(Vector2.down*-roundDuration, roundDuration)
            .From(Vector2.zero)
            .SetEase(Ease.Linear);

        // Scale Pyramid
        sandPyramidRect.DOScaleY(1f, roundDuration / 3f).From(0f);
        sandPyramidRect.DOScaleY(0f, roundDuration / 1.5f).SetDelay(roundDuration / 3f).SetEase(Ease.Linear);

        sandPyramidRect.anchoredPosition = Vector2.up * defaultSandPyramidYPos;
        sandPyramidRect.DOAnchorPosY(0f, roundDuration).SetEase(Ease.Linear);

        ResetClock();

        roundText.DOFade(1f, 0.8f);

        fillTopImage
            .DOFillAmount(0, roundDuration)
            .SetEase(Ease.Linear)
            .OnUpdate(OnTimeUpdate)
            .OnComplete(OnRounTimeComplete);
    }

    private void OnTimeUpdate()
    {
        fillBottomImage.fillAmount = 1f - fillTopImage.fillAmount;
    }

    private void OnRounTimeComplete()
    {
        // Round end event
        if(onRoundEnd != null)
        {
            onRoundEnd.Invoke(currentRound);
        }  

        sandDotsImage.DOFade(0f, 0f);        

        if(currentRound < totalRounds)
        {
            roundText.DOFade(0f, 0f);

            transform
                .DORotate(Vector3.forward * 180f, 0.8f, RotateMode.FastBeyond360)
                .From(Vector3.zero)
                .SetEase(Ease.InOutBack)
                .OnComplete(() => {
                    SetRoundText(totalRounds - currentRound);
                    Begin();
                });
        }
        else
        {
            // All rounds completed
            if(onAllRoundsCompleted != null)
            {
                onAllRoundsCompleted.Invoke();
            }

            SetRoundText(0);

            transform
                .DOShakeScale(0.8f, 0.3f, 10, 90f, true);
        }
    }

    private void SetRoundText(int value)
    {
        roundText.text = value.ToString();
    }

    public void ResetClock()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        fillTopImage.fillAmount = 1f;
        fillBottomImage.fillAmount = 0f;
    }
}
