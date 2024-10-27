namespace NEO_TWEWY_Randomizer
{
    public enum AttackHitTargetType : int
    {
        EnemyOnly = 1,
        PartyOnly = 2,
        SelfOnly = 4,
        EnemyAndParty = 3,
        All = 7,
        Invalid = -1,
    }
}
