using System;
using UnityEngine;

[Serializable] public class GameData
{
    #region Player
    [SerializeField] private int user;
    public int User { get { return user; } set { value = user; } }
    [SerializeField] private int money;
    public int Money { get { return money; } set { value = money; } }
    [SerializeField] private int cumulativeMoney;
    public int CumulativeMoney { get { return cumulativeMoney; }set { value = cumulativeMoney; } }
    //１秒間に増える総合スコア
    [SerializeField] private int totalIncrementSecond;
    public int TotalIncrementSecond { get {return totalIncrementSecond; } set {value=totalIncrementSecond; } }
    #region Item1
    //Item1の１秒間に増えるスコア
    public int Item1IncrementSecond { get; set; }
    //Item1の倍率
    public int Item1Multiple { get; set; }
    #endregion
    #endregion
    #region Settings
    #endregion
    public GameData()
    {
        user = 0;
        money = 0;
        cumulativeMoney = 0;
        totalIncrementSecond = 0;
    }
}
