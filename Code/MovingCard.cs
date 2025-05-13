using UnityEngine;
using DG.Tweening;

public class MovingCard : MonoBehaviour
{
    [SerializeField] private float spinPower = 360f;
    
    /// <summary>
    /// Cards moving to the table
    /// </summary>
    /// <param name="moveDuration">Target Transform</param>
    /// <param name="rotateDuration">move duration</param>
    /// <param name="ease"></param>
    public void Move(Transform moveTrm, float moveDuration, float rotateDuration, Ease ease)
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMove(moveTrm.position, moveDuration).SetEase(ease))
            .Join(transform.DORotate(new Vector3(0, 0, spinPower), rotateDuration, RotateMode.FastBeyond360).SetEase(ease));
    }

    public void StopDOTween()
    {
        DOTween.KillAll();
    }
}
