using UnityEngine;

public class Player : MonoBehaviour {
    public float Score { get; set; }
    //１秒間に増える総合スコア
    public int TotalIncrementSecond { get; set; }
    #region Item1
    //Item1の１秒間に増えるスコア
    public int Item1IncrementSecond { get; set; }
    //Item1の倍率
    public int Item1Multiple { get; set; }
    #endregion

    private void Start()
    {
        Item1Multiple = 1;
    }
}
