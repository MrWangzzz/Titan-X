using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TitanX { 
public class UnitMono : UnitBaseData
{
    public Camp Camp { get; private set; }
    /// <summary>
    /// ���м���
    /// </summary>
    public Dictionary<int, SkillMono> Skills { get; private set; }
    /// <summary>
    /// ����buff
    /// </summary>
    public Dictionary<int, BuffMono> Buffs { get; private set; }
    /// <summary>
    /// ����װ��
    /// </summary>
    public Dictionary<int, Equip> Equips { get; private set; }

    /// <summary>
    /// ��ʼ��
    /// </summary>
    public void Init()
    {
        Skills = new Dictionary<int, SkillMono>();
        Buffs = new Dictionary<int, BuffMono>();
        Equips = new Dictionary<int, Equip>();
    }

    public void Attack(UnitMono target) 
    {
       var at= AtackActionFactory.CreatAtack(this,target);
    }

    public void OnDeath() 
    {
       
    }

}


public static class UnitMonoSystem 
{
    /// <summary>
    /// ��Ӽ���(���д˼���ʱ�滻)
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sk"></param>
    public static void AddSkill(this UnitMono um, int id, SkillMono sk)
    {
        if (um.Skills.ContainsKey(id))
        {
            if (sk.Level < um.Skills[id].Level) { return; }
            um.Skills[id] = sk;
        }
        else
        {
            um.Skills.Add(id, sk);
        }
    }
    /// <summary>
    /// ���Buff(���д˼���ʱ�滻)
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sk"></param>
    public static void AddBuff(this UnitMono um, int id, BuffMono sk)
    {
        if (um.Buffs.ContainsKey(id))
        {
            if (sk.Level < um.Skills[id].Level) { return; }
            um.Buffs[id] = sk;
        }
        else
        {
            um.Buffs.Add(id, sk);
        }
    }
    /// <summary>
    /// ���װ��(���д˼���ʱ�滻)
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sk"></param>
    public static void AddEquip(this UnitMono um,int id, Equip sk)
    {
        if (um.Equips.ContainsKey(id))
        {
            // if (sk.Level < Skills[id].Level) { return; }
            um.Equips[id] = sk;
        }
        else
        {
            um.Equips.Add(id, sk);
        }
    }
}

public enum Camp
{
    None = 0,
    Player = 1,
    Enemy = 2
}
}