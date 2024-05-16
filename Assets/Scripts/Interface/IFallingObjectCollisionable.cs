
/// <summary>
/// 오브젝트와 충돌 가능함을 나타내기 위한 인터페이스입니다.
/// Falldown 클래스에서 플레이어 객체의 전체적인 접근이 아닌,
/// 부분적으로 필요한 기능에만 접근할 수 있도록 하기 위해 사용됩니다.
/// </summary>
public interface IFallingObjectCollisionable
{
    /// <summary>
    /// 쓰레기 오브젝트가 감지되는 경우 호출됩니다.
    /// </summary>
    /// <param name="damage">가할 피해량을 전달합니다.</param>
    void OnTrashObjectDetected(float damage);

    /// <summary>
    /// 물고기 오브젝트가 감지되는 경우 호출됩니다.
    /// </summary>
    /// <param name="recoveryHpValue">체력회복량을 전달합니다.</param>
    void OnFishObjectDetected(float recoveryHpValue);

    /// <summary>
    /// 점수를 추가합니다.
    /// </summary>
    /// <param name="score">점수 변화량을 전달합니다.</param>
    void AddScore(float score);

}
