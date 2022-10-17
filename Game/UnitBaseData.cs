using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitanX
{
    public class UnitBaseData : MonoBehaviour
    {
        /// <summary>
        /// 识别ID
        /// </summary>
        public int ID { get; private set; }


        public int Level { get; private set; }



    }



    public enum PropertyType
    {
        /// <summary>
        /// 生命值
        /// </summary>
        Health = 0,
        /// <summary>
        /// 物理攻击
        /// </summary>
        Attack = 1,
        /// <summary>
        /// 魔法攻击
        /// </summary>
        Magic = 2,
        /// <summary>
        /// 护甲
        /// </summary>
        Armor = 3,
        /// <summary>
        /// 魔抗
        /// </summary>
        MagicArmor = 4,
        /// <summary>
        /// 物理暴击
        /// </summary>
        Cri = 5,
        /// <summary>
        /// 物理暴击伤害
        /// </summary>
        CriDmg = 6,
        /// <summary>
        /// 物理暴击抗性
        /// </summary>
        CriRes = 7,
        /// <summary>
        /// 负面抗性
        /// </summary>
        StateRes = 8,
        /// <summary>
        /// 物理穿透(百分比)
        /// </summary>
        IgPhysical = 9,
        /// <summary>
        /// 法术穿透(百分比)
        /// </summary>
        IgMagic = 10,
        /// <summary>
        /// 加强负面效果
        /// </summary>
        StatePlug = 11,
        /// <summary>
        /// 冷却缩减,最高60%
        /// </summary>
        CoolDown = 12,
        /// <summary>
        /// 攻击速度
        /// </summary>
        AtkSpeedUp = 13,
        /// <summary>
        /// 攻击加成(百分比)
        /// </summary>
        AttackPlug = 14,
        /// <summary>
        /// 法术加成(百分比)
        /// </summary>
        MagicPlug = 15,
        /// <summary>
        /// 忽视护甲
        /// </summary>
        IgArmor = 16,
        /// <summary>
        /// 忽视魔抗
        /// </summary>
        IgMagicArmor = 17,
        /// <summary>
        /// 吸血
        /// </summary>
        LifeSteal = 18,
        /// <summary>
        /// 抗吸血
        /// </summary>
        LifeStealRes = 19,
        /// <summary>
        /// 移动速度
        /// </summary>
        Speed = 20,
        /// <summary>
        /// 命中
        /// </summary>
        Accuracy = 21,
        /// <summary>
        /// 闪避
        /// </summary>
        Dodge = 22,
        /// <summary>
        /// 法术暴击
        /// </summary>
        MagicCri = 23,
        /// <summary>
        /// 法术暴击伤害
        /// </summary>
        MagicCriDmg = 24,
        /// <summary>
        /// 法术暴击抗性
        /// </summary>
        MagicCriRes = 25,
        /// <summary>
        /// 治疗量
        /// </summary>
        Heal = 26,
        /// <summary>
        /// 治疗加成
        /// </summary>
        HealPlug = 27,
        /// <summary>
        /// 加强恢复效果
        /// </summary>
        OnHealPerc = 28,
        /// <summary>
        /// 攻击距离
        /// </summary>
        Range = 29,
        /// <summary>
        /// 燃烧抵抗
        /// </summary>
        BurnRes = 30,
        /// <summary>
        /// 麻痹抵抗
        /// </summary>
        PalsyRes = 31,
        /// <summary>
        /// 中毒抵抗
        /// </summary>
        PoisonRes = 32,
        /// <summary>
        /// 潮湿抵抗
        /// </summary>
        DampRes = 33,
        /// <summary>
        /// 模型修正
        /// </summary>
        Scale = 34,
        /// <summary>
        /// 伤害限制（当前最大生命值的百分比）
        /// </summary>
        HarmScope = 35,

    }
    /// <summary>
    /// 装备位置
    /// </summary>
    public enum EquipPartType
    {

        /// <summary>
        ///头
        /// </summary>
        Head = 1,
        /// <summary>
        /// 手
        /// </summary>
        Hand = 2,
        /// <summary>
        /// 脚
        /// </summary>
        foot = 3

    }
    /// <summary>
    /// 伤害来源
    /// </summary>
    public enum DmgSource
    {
        /// <summary>
        /// 普通攻击
        /// </summary>
        DsAttack = 0,
        /// <summary>
        /// 技能
        /// </summary>
        DsSkill = 1,
        /// <summary>
        /// buff效果
        /// </summary>
        DsBuff = 2,
    }

    /// <summary>
    /// 伤害类型
    /// </summary>
    public enum DamageType
    {
        /// <summary>
        /// 物理伤害
        /// </summary>
        DtPhysical = 0,
        /// <summary>
        /// 魔法伤害
        /// </summary>
        DtMagic = 1,
        /// <summary>
        /// 治疗
        /// </summary>
        DtHeal = 2,
    }


    public class Equip : UnitBaseData
    {
        /// <summary>
        ///装备可装备的部位
        /// </summary>
        public EquipPartType equipPartType { get; private set; }
    }
}