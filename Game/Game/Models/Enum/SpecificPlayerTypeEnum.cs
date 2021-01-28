namespace Game.Models
{
    /// <summary>
    /// The player in the round, Monster or Character
    /// </summary>
    public enum SpecificPlayerTypeEnum
    {
        // Not Known
        Unknown = 0,

        // The Characters
        Student = 10,
        Parent = 11,

        // The Monster
        Faculty = 20,
        Admin = 21,
    }
}