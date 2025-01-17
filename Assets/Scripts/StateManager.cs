﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : IActorManagerInterface
{
    public float HP = 15.0f;
    public float HP_Max = 15.0f;

    [Header("第一状态")]
    public bool isGround;
    public bool isJump;
    public bool isFall;
    public bool isRoll;
    public bool isJab;
    public bool isAttack;
    public bool isHit;
    public bool isDie;
    public bool isBlocked;
    public bool isDefence;
    public bool isCounterBack;

    [Header("第二状态")]
    public bool isAllowDefence;
    public bool isImmortal;

    // Start is called before the first frame update
    void Start()
    {
        HP = HP_Max;
    }
    
    // Update is called once per frame
    void Update()
    {
        isGround = actorManager.actorController.CheckState("ground");
        isJump = actorManager.actorController.CheckState("jump");
        isFall = actorManager.actorController.CheckState("fall");
        isRoll = actorManager.actorController.CheckState("roll");
        isJab = actorManager.actorController.CheckState("jab");
        isAttack = actorManager.actorController.CheckStateTag("attackR") ||
                   actorManager.actorController.CheckStateTag("attackL");
        isHit = actorManager.actorController.CheckState("hit");
        isDie = actorManager.actorController.CheckState("die");
        isBlocked = actorManager.actorController.CheckState("block");
        //isDefence = actorManager.actorController.CheckState("defence1h", "Defence");
        isCounterBack = actorManager.actorController.CheckState("counterBack");

        isAllowDefence = isBlocked || isGround;
        isDefence = isAllowDefence && actorManager.actorController.CheckState("defence1h", "Defence");

        isImmortal = isRoll || isJab;
    }

    public void AddHP(float value)
    {
        HP += value;
        HP = Mathf.Clamp(HP, 0, HP_Max);
    }

    public void SetIsCounterBack()
    {
        
    }
}
