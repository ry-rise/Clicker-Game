using System;
using UnityEngine;

[Serializable] public class GameData
{
    #region Player
    [SerializeField] private int user;
    public int User { get { return user; } set { user = value; } }
    [SerializeField] private int money;
    public int Money { get { return money; } set { money = value; } }
    [SerializeField] private int cumulativeMoney;
    public int CumulativeMoney { get { return cumulativeMoney; } set { cumulativeMoney = value; } }
    //１秒間に増える総合スコア
    [SerializeField] private int totalIncrementSecond;
    public int TotalIncrementSecond { get { return totalIncrementSecond; } set { totalIncrementSecond = value; } }
    #region Item1
    //Item1の１秒間に増えるスコア
    public int Item1IncrementSecond { get; set; }
    //Item1の倍率
    public int Item1Multiple { get; set; }
    #endregion
    #endregion
    #region Settings
    [SerializeField] private int volume;
    public int Volume { get { return volume; } set { volume = value; } }

    #endregion
}
