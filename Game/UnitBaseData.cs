using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitanX
{
    public class UnitBaseData : MonoBehaviour
    {
        /// <summary>
        /// ʶ��ID
        /// </summary>
        public int ID { get; private set; }


        public int Level { get; private set; }



    }



    public enum PropertyType
    {
        /// <summary>
        /// ����ֵ
        /// </summary>
        Health = 0,
        /// <summary>
        /// ������
        /// </summary>
        Attack = 1,
        /// <summary>
        /// ħ������
        /// </summary>
        Magic = 2,
        /// <summary>
        /// ����
        /// </summary>
        Armor = 3,
        /// <summary>
        /// ħ��
        /// </summary>
        MagicArmor = 4,
        /// <summary>
        /// ������
        /// </summary>
        Cri = 5,
        /// <summary>
        /// �������˺�
        /// </summary>
        CriDmg = 6,
        /// <summary>
        /// ����������
        /// </summary>
        CriRes = 7,
        /// <summary>
        /// ���濹��
        /// </summary>
        StateRes = 8,
        /// <summary>
        /// ����͸(�ٷֱ�)
        /// </summary>
        IgPhysical = 9,
        /// <summary>
        /// ������͸(�ٷֱ�)
        /// </summary>
        IgMagic = 10,
        /// <summary>
        /// ��ǿ����Ч��
        /// </summary>
        StatePlug = 11,
        /// <summary>
        /// ��ȴ����,���60%
        /// </summary>
        CoolDown = 12,
        /// <summary>
        /// �����ٶ�
        /// </summary>
        AtkSpeedUp = 13,
        /// <summary>
        /// �����ӳ�(�ٷֱ�)
        /// </summary>
        AttackPlug = 14,
        /// <summary>
        /// �����ӳ�(�ٷֱ�)
        /// </summary>
        MagicPlug = 15,
        /// <summary>
        /// ���ӻ���
        /// </summary>
        IgArmor = 16,
        /// <summary>
        /// ����ħ��
        /// </summary>
        IgMagicArmor = 17,
        /// <summary>
        /// ��Ѫ
        /// </summary>
        LifeSteal = 18,
        /// <summary>
        /// ����Ѫ
        /// </summary>
        LifeStealRes = 19,
        /// <summary>
        /// �ƶ��ٶ�
        /// </summary>
        Speed = 20,
        /// <summary>
        /// ����
        /// </summary>
        Accuracy = 21,
        /// <summary>
        /// ����
        /// </summary>
        Dodge = 22,
        /// <summary>
        /// ��������
        /// </summary>
        MagicCri = 23,
        /// <summary>
        /// ���������˺�
        /// </summary>
        MagicCriDmg = 24,
        /// <summary>
        /// ������������
        /// </summary>
        MagicCriRes = 25,
        /// <summary>
        /// ������
        /// </summary>
        Heal = 26,
        /// <summary>
        /// ���Ƽӳ�
        /// </summary>
        HealPlug = 27,
        /// <summary>
        /// ��ǿ�ָ�Ч��
        /// </summary>
        OnHealPerc = 28,
        /// <summary>
        /// ��������
        /// </summary>
        Range = 29,
        /// <summary>
        /// ȼ�յֿ�
        /// </summary>
        BurnRes = 30,
        /// <summary>
        /// ��Եֿ�
        /// </summary>
        PalsyRes = 31,
        /// <summary>
        /// �ж��ֿ�
        /// </summary>
        PoisonRes = 32,
        /// <summary>
        /// ��ʪ�ֿ�
        /// </summary>
        DampRes = 33,
        /// <summary>
        /// ģ������
        /// </summary>
        Scale = 34,
        /// <summary>
        /// �˺����ƣ���ǰ�������ֵ�İٷֱȣ�
        /// </summary>
        HarmScope = 35,

    }
    /// <summary>
    /// װ��λ��
    /// </summary>
    public enum EquipPartType
    {

        /// <summary>
        ///ͷ
        /// </summary>
        Head = 1,
        /// <summary>
        /// ��
        /// </summary>
        Hand = 2,
        /// <summary>
        /// ��
        /// </summary>
        foot = 3

    }
    /// <summary>
    /// �˺���Դ
    /// </summary>
    public enum DmgSource
    {
        /// <summary>
        /// ��ͨ����
        /// </summary>
        DsAttack = 0,
        /// <summary>
        /// ����
        /// </summary>
        DsSkill = 1,
        /// <summary>
        /// buffЧ��
        /// </summary>
        DsBuff = 2,
    }

    /// <summary>
    /// �˺�����
    /// </summary>
    public enum DamageType
    {
        /// <summary>
        /// �����˺�
        /// </summary>
        DtPhysical = 0,
        /// <summary>
        /// ħ���˺�
        /// </summary>
        DtMagic = 1,
        /// <summary>
        /// ����
        /// </summary>
        DtHeal = 2,
    }


    public class Equip : UnitBaseData
    {
        /// <summary>
        ///װ����װ���Ĳ�λ
        /// </summary>
        public EquipPartType equipPartType { get; private set; }
    }
}