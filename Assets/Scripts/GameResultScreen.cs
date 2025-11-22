using System.Collections;
using TMPro;
using UnityEngine;

public class GameResultScreen : Singleton<GameResultScreen>
{
    [Header("References")]
    [SerializeField]
    CanvasGroup gameScreenParent;

    [SerializeField]
    RectTransform panel;

    [Header("Review references")]

    [SerializeField]
    TextMeshProUGUI reviewMessage;

    [SerializeField]
    TextMeshProUGUI reviewTitle;


    [Header("Configuration")]

    [SerializeField]
    CoroutineAnimation opacityReveal;

    [SerializeField]
    CoroutineAnimation movementReveal;

    [SerializeField]
    float upwardsDistanceMovement = 200;

    [SerializeField]
    Review review;

    private void Start()
    {
        gameScreenParent.gameObject.SetActive(false);
    }

    [EasyButtons.Button]
    public void BeginEndScreen()
    {
        StartCoroutine(GameResultCoroutine());
    }

    IEnumerator GameResultCoroutine()
    {
        gameScreenParent.alpha = 0;

        string title;
        string message;
        if (Random.value < 0.33f)
        {
            title = review.neutralTitle;
            message = review.neutralReview;

        }
        else if (Random.value > 0.5f)
        {
            title = review.positiveTitle;
            message = review.positiveReview;
        }
        else
        {
            title = review.negativeTitle;
            message = review.negativeReview;
        }

        reviewMessage.text = message;
        reviewTitle.text = title;

        gameScreenParent.gameObject.SetActive(true);

        opacityReveal.Play(this, (i) => { gameScreenParent.alpha = i; });

        Vector2 initialPosition = panel.anchoredPosition;
        panel.anchoredPosition += Vector2.down * upwardsDistanceMovement;
        movementReveal.MoveTo(this, panel, initialPosition);

        while (!opacityReveal.IsFinished && !movementReveal.IsFinished)
            yield return null;

        ScreenEffectController.instance.Apply("blur");

        //TODO: ver que tal me ha ido

    }
}

