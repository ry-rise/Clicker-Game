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
    [SerializeField] private int _Item1IncrementSecond;
    public int Item1IncrementSecond { get { return _Item1IncrementSecond; } set { _Item1IncrementSecond = value; } }
    //Item1の倍率
    [SerializeField] private int _Item1Multiple;
    public int Item1Multiple { get { return _Item1Multiple; } set { _Item1Multiple = value; } }
    #endregion
    #region Item2
    //Item2の１秒間に増えるスコア
    [SerializeField] private int _Item2IncrementSecond;
    public int Item2IncrementSecond { get { return _Item2IncrementSecond; } set { _Item2IncrementSecond = value; } }
    //Item2の倍率
    [SerializeField] private int _Item2Multiple;
    public int Item2Multiple { get { return _Item2Multiple; } set { _Item2Multiple = value; } }
    #endregion
    #region Item3
    //Item3の１秒間に増えるスコア
    [SerializeField] private int _Item3IncrementSecond;
    public int Item3IncrementSecond { get { return _Item3IncrementSecond; } set { _Item3IncrementSecond = value; } }
    //Item3の倍率
    [SerializeField] private int _Item3Multiple;
    public int Item3Multiple { get { return _Item3Multiple; } set { _Item3Multiple = value; } }
    #endregion
    #region Item4
    //Item4の１秒間に増えるスコア
    [SerializeField] private int _Item4IncrementSecond;
    public int Item4IncrementSecond { get { return _Item4IncrementSecond; } set { _Item4IncrementSecond = value; } }
    //Item4の倍率
    [SerializeField] private int _Item4Multiple;
    public int Item4Multiple { get { return _Item4Multiple; } set { _Item4Multiple = value; } }
    #endregion
    #region Item5
    //Item5の１秒間に増えるスコア
    [SerializeField] private int _Item5IncrementSecond;
    public int Item5IncrementSecond { get { return _Item5IncrementSecond; } set { _Item5IncrementSecond = value; } }
    //Item5の倍率
    [SerializeField] private int _Item5Multiple;
    public int Item5Multiple { get { return _Item5Multiple; } set { _Item5Multiple = value; } }
    #endregion

    #endregion
    #region Store
    [SerializeField] private int[] storePrice;
    public int[] StorePrice { get { return storePrice; } set { storePrice = value; } }
    [SerializeField] private int[] storeQuantity;
    public int[] StoreQuantity { get { return storeQuantity; } set { storeQuantity = value; } }

    #endregion
    #region Upgrade
    [SerializeField] private int[] upgradePrice;
    public int[] UpgradePrice { get { return upgradePrice; } set { upgradePrice = value; } }
    [SerializeField] private int[] upgradeMultiple;
    public int[] UpgradeMultiple { get { return upgradeMultiple; } set { upgradeMultiple = value; } }

    #endregion
    #region Settings
    [SerializeField] private int volume;
    public int Volume { get { return volume; } set { volume = value; } }

    #endregion
}
