using UnityEngine;

public class Player : MonoBehaviour {
    public int User { get; set; }
    public int Money { get; set; }
    //１秒間に増える総合スコア
    public int TotalIncrementSecond { get; set; }
    #region Item1
    //Item1の１秒間に増えるスコア
    public int Item1IncrementSecond { get; set; }
    //Item1の倍率
    public int Item1Multiple { get; set; }
    #endregion

    #region Item2
    //Item2の１秒間に増えるスコア
    public int Item2IncrementSecond { get; set; }
    //Item2の倍率
    public int Item2Multiple { get; set; }
    #endregion

    private void Start()
    {
        Item1Multiple = 1;
    }
}
