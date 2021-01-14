

using System;

public class CCommonEnum
{
    public enum ELanguage
    {
        eNone = -1,
        eKorea,
        eEnglish,
        eLength
    }

    public enum EScene
    {
        eLogo,
        eLobby,
        eInGameLobby,
        eNormalStageMode,
        eWaveMode,
        eSkillCreate,
    }


    public enum EGameState
    {
        eNone,
        eGameLoad,
        eStartWait,
        ePlaying,
        eEnd,
    }


    public enum EProjectMode
    {
        eGameMod,
        eSkillCreateToolMod,
        eMapToolMod
    }

    public enum EProductMode
    {
        /// <summary>
        /// 개발 버전
        /// </summary>
        eLocalDevMode,
        /// <summary>
        /// 출시 준비 버전(실제 출시 버전이랑 동일, API key, SDK ID등은 테스트용으로 사용)
        /// </summary>
        eLocalDevProductMode,
        /// <summary>
        /// 상용화 버전
        /// </summary>
        eLocalProductMode,

    }

    public enum EBundleMode
    {
        eLocal,
        eLocalBundle,
        eAssetBundle,
    }

}


public static class CEntityEnum
{
    public enum EPlayerType
    {
        eNone,
        eMainPlayer,
        ePlayerAI,
        eEnemyAI,
    }

    public enum EEntityForce
    {
        eNone,
        eBlue,
        eRed
    }
}

public enum EDBType
{
    eNone,
    eJsonSave,
    eSQLiteDB,
}

public enum EGameModeType
{
    eNone,
    eNormalStageMode,
    eWaveMode,
}

public enum eEntityState
{
    None = 0,
    eSpawn,
    eIdle,
    eMove,
    eMoveToTarget,
    eDie,
    eAttack,
    eAirborn,
    eNockBack,
    eHit,

}


[Serializable]
/// <summary>
/// 타격후 움직임 처리
/// </summary>
public enum EHitMoveEvent
{
    eNone,
    eKnockBack,
    ePushBack, // 뒤로 밀리기만함
    eAirbornFall,
    eAirborn,
}

public enum EHitEvent
{
    eNone,
    eStun, // 스턴
    eStiffen // 경직
}


public enum EBuffeType
{
    eNone,
    eBuff,
    ePremiumBuff,
}

public enum EBuffEndState
{
    eNone,
    eIsNotRemoveAndHide
}

[Serializable]
public enum ESkillEventType
{
    eNone,
    eCreateProjectile,
    eRotateToTarget,
    eRotateToNearEnemy,
    eCameraShake,
    eEntityMove,
    eEffect,
}
public enum EActiveType
{
    eNormal,
    eActive,
    ePassive
}
public enum EActionType
{
    eProjectile, // 그냥 투사체 발사
    eNoneAnimeAction, //동작 없는 액
    eAnimAction, // 동작이 있는액션 
}

public enum ESkillConsumeType
{
    eNone,
}

public enum EProjectileEventType
{
    eCenterPushBack,
    eStun,
    eKnockdown

}
public enum EMoveType
{
    eNone,
    eStraight,
    eLower,
    // eArcAngle,
    eEnemyAttatch,
    eEnemyLower,
    //eNearEnemyAttatch,
    //eNearEnemyFollow,
    //eNearEnemyToNearEnemyMove,
    eCreatorAttatch,
    eCreatorAttatchFollow,
    //eCreatorFollow,
    eEnemyFollow,


}


public enum EMonsterGrade
{
    eNormal,
    eElite,
    eBoss,
}
[System.Flags]
public enum ESpawnAreaMonsterType
{
    eNone = 0,
    eAll = int.MaxValue,
    eNormal = 1 << 0,
    eElite = 1 << 1,
    eBoss = 1 << 2,
}

public enum EColliderType
{
    eSphere,
    eCube,
    eLine,
}

public enum ESortRange
{
    eNear, // 가까운
    eFar   // 먼
}


public enum EProductType
{
    eNone = 0,
    eConsumable,
    eNonConsumable,
    eSubscription
}

public enum EItemType
{
    eNone = 0,
    //------------------------------
    eWeapon,
    eArmor,
    eAccessory,
    //------------------------------
    eSkillRune,
    //------------------------------
    eItem,
    eCredit,
    eCredit_Cash,

    ePackageItem,
    eRandomPackageItem,
    eAds,
    eAdsFree,
    ePreminumBuff,

    eOther,
    eLength
}

public enum InventoryType
{
    eNone,
    eEquipItem,
    eNonEquipItem,
}

public enum EEquipType
{
    eNone = -1,
    eOneHand = 0,
    eSwordShield = 1,
    eKatana = 2,
    eAxe = 3,
    eHammer = 4,
    eSpear = 5,
    eStaff = 6,
    eDualHand = 7,
    eKnife = 8,
    eBow = 9,
    eHelmet = 10,
    eArmor = 11,
    eShoes = 12,
    eAmulet = 13,
    eRing = 14,
}

public enum EStateType
{
    eNone = 1,
    eAddModifiyMoveSpeed,
    eAddModifiyMultipleAtkSpeed,
    eAddModifiyMultipleAtkPower,
}

public enum EAttributeCalculatType
{
    eNone,
    eAddition,
    eMultiple
}

public enum EAttributeValueType
{
    eNone,
    eInteger,
    eFloat,
}

public enum EOptionType
{
    eNone = 0,
    //---------------------------
    /// <summary>
    /// 체력
    /// </summary>
    eHealth_Abs,
    //---------------------------
    /// <summary>
    /// 마력
    /// </summary>
    eMana_Abs,
    //---------------------------
    /// <summary>
    /// 방어력
    /// </summary>
    eDefence_Abs,
    //---------------------------
    /// <summary>
    /// 이속
    /// </summary>
    eMoveSpeed_Abs,
    //---------------------------
    /// <summary>
    /// 공격력
    /// </summary>
    eAttackDamage_Abs,
    //---------------------------
    /// <summary>
    /// 공격 거리
    /// </summary>
    eAttackRange_Abs,
    //---------------------------
    /// <summary>
    /// 공격 속도
    /// </summary>
    eAttackSpeed_Abs,
    //---------------------------
    /// <summary>
    /// 크리티컬 찬스(%)
    /// </summary>
    eCriticalChance_Multi,
    //---------------------------
    /// <summary>
    /// 크리티컬 데미지(%)
    /// </summary>
    eCriticalDamage_Multi,
    //---------------------------
    /// <summary>
    /// 초당 체력 회복
    /// </summary>
    eHPGen_Abs,
    //---------------------------
    /// <summary>
    /// 초당 마력 회복
    /// </summary>
    eMPGen_Abs,
    //---------------------------
    /// <summary>
    /// 피흡(%)
    /// </summary>
    eHPLeech_Multi,
    //---------------------------
    /// <summary>
    /// 마나 소모 감소량(%)
    /// </summary>
    eMPReduce_Multi,
    //---------------------------
    /// <summary>
    /// 시전 대기시간 감소량(%)
    /// </summary>
    eCooltimeReduce_Multi,
    //---------------------------
    /// <summary>
    /// 일반 공격력 증가(%)
    /// </summary>
    eNormalATK_Multi,
    //---------------------------
    /// <summary>
    /// 일반 공격력 증가(%)
    /// </summary>
    eSkillDamageUp_Multi,
    //---------------------------
    /// <summary>
    /// 연계 스킬 공격력 증가(%)
    /// </summary>
    eSkillDamageUp1_Multi,
    //---------------------------
    /// <summary>
    /// 연계 스킬2 공격력 증가(%)
    /// </summary>
    eSkillDamageUp2_Multi,
    //---------------------------
    /// <summary>
    /// 스킬1 공격력 증가(%)
    /// </summary>
    eSkillDamageUp3_Multi,
    //---------------------------
    /// <summary> 
    /// 스킬2 공격력 증가(%)
    /// </summary>
    eSkillDamageUp4_Multi,
    //---------------------------
    /// <summary>
    /// 경험치 보너스
    /// </summary>
    eExpBonus_Multi,
    //---------------------------
    /// <summary>
    /// 올스텟 보너스
    /// </summary>
    eAllStatBonus_Multi,
    //---------------------------
    /// <summary>
    /// 보상 보너스
    /// </summary>
    eRewardBonus_Multi,
    //---------------------------
    eLength
}
public enum EItemDataResultMsg
{
    eNone = 0,
    eNewCreateItemData,
    eNotFoundData,
    eTableDataNull,
    eStackLimitOver,

}

public enum EParts
{
    eNone,
    /// <summary>
    /// 머리
    /// </summary>
    eHelmetParts,
    /// <summary>
    /// 목걸이 
    /// </summary>
    eNecklaceParts,
    /// <summary>
    /// 반지
    /// </summary>
    eRing_01Parts,
    /// <summary>
    /// 몸통 파츠
    /// </summary>
    eArmorParts,
    /// <summary>
    /// 신발
    /// </summary>
    eBootsParts,
    eWeaponParts,
    eShieldParts

}

public enum EItemGrade
{
    eNone = 0,
    eCommon,
    eUncommon,
    eMagic,
    eRare,
    eUnique,
}



public enum EAuthType
{
    eNone = 0,
    eGuest,
    eGoogle,
    
}

// 나중에는 1~x는 팝업 100~x XX 팝업  200 ~~ xx d윈도우 이런식으로 구분 해야할 듯.
public enum UIWindowKey
{
    //---------------------------------------
    // 기본으로 있어야 하는것들 Window
    None = 0,
    UIWindowLoading = 1,
    UIWindowLogoTitle = 2,
    //---------------------------------------
    UIWindowInGameLobby,
    UIWindowInGameStage,
    UIWindowInventory,
    UIWindowShop,

    //---------------------------------------
    // 기본으로 있어야 하는것들(팝업
    UIPopupSystemPopup = 1000,
    UIPopupSystemImagePopup,
    //---------------------------------------

    UIPopupItemInfo,
    UIPopupWaveModeResult,
    UIPopupInventoryDisassemble,
    UIPopupItemListInfo,
    UIPopupItemInfoViewer,
    UIPopupSystemOption,
    UIPopupEquipItemUpgradeInfo,
    UIPopupSkillUpgradeInfo,
    UIPopupSkillInfoViewer,
    UIPopupOptionMenu,
    UIPopupMoreGame,
    UIPopupNormalStage,
    UIPopupWaveStage,
}

[System.Flags]
public enum UIWindowMode
{
    None = 0,
    Base = 1 << 1 , // 가장 기본 UI, MainUI

    /// <summary>
    /// UI가 열릴때 이전 WindowMode가 WindowClose가 있다면 해당UI를 닫는다.
    /// </summary>
    WindowClose = 1<< 2,

    /// <summary>
    /// 이전 UI를 끄지않고 그 위에 출력
    /// </summary>
    WindowOverlay = 1 << 3,

    /// <summary>
    /// 이전 UI를 끄지않고 그 위에 출력
    /// </summary>
    WindowNonHideOverlay = 1 << 4,

}


[System.Flags]
public enum UIModule
{
    None = 0,
    UIModuleTitleBar = 1 << 1,
    UIModuleResourceBar = 1 << 2,
    
    /// <summary>
    /// 백그라운드 버튼을 만든다
    /// 메인 UI외 영역을 누르면 현UI를 닫는 기능
    /// </summary>
    UIModuleCloseBgBtn = 1<<3,

    UIModulePlayerInfo = 1 << 4,
    UIModuleBackClickBlock = 1 << 5,

}


public enum EComponetSystem
{
    eAnimationSystem,
    eMovementSystem,
    eControllerSystem,
    eAIControllerSystem,
    eModelSystem,
    ePartsSystem,
    eSkillSystem,
    eCCinemaSystem,
}

