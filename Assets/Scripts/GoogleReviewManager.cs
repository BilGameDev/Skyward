using System.Collections;
using System.Collections.Generic;
using Google.Play.Review;
using UnityEngine;

public class GoogleReviewManager : MonoBehaviour
{
    private ReviewManager _reviewManager;
    PlayReviewInfo _playReviewInfo;
    void Start()
    {
        _reviewManager = new ReviewManager();
    }

    public void AskReview()
    {
        StartCoroutine(RequestViewObject());
    }

    IEnumerator RequestViewObject()
    {
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
    }
}
