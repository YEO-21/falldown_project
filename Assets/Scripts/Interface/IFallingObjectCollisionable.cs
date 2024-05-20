
/// <summary>
/// ������Ʈ�� �浹 �������� ��Ÿ���� ���� �������̽��Դϴ�.
/// Falldown Ŭ�������� �÷��̾� ��ü�� ��ü���� ������ �ƴ�,
/// �κ������� �ʿ��� ��ɿ��� ������ �� �ֵ��� �ϱ� ���� ���˴ϴ�.
/// </summary>
public interface IFallingObjectCollisionable
{
    /// <summary>
    /// ������ ������Ʈ�� �����Ǵ� ��� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="damage">���� ���ط��� �����մϴ�.</param>
    void OnTrashObjectDetected(float damage);

    /// <summary>
    /// ����� ������Ʈ�� �����Ǵ� ��� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="recoveryHpValue">ü��ȸ������ �����մϴ�.</param>
    void OnFishObjectDetected(float recoveryHpValue);

    /// <summary>
    /// ������ �߰��մϴ�.
    /// </summary>
    /// <param name="score">���� ��ȭ���� �����մϴ�.</param>
    void AddScore(float score);

}
