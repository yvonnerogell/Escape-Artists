namespace Game.Models
{
    /// <summary>
    /// The player in the round, Monster or Character
    /// </summary>
    public enum SpecificCharacterTypeEnum
    {
        // Not Known
        Unknown = 0,

        // The Characters
        Student = 10,
        Parent = 11,

        // The Monsters
        Faculty = 20,
        Admin = 21,
    }
}