using Game.GameRules;
using System.Collections.Generic;

namespace Game.Models
{
    /// <summary>
    /// Characters
    /// 
    /// Derive from BasePlayerModel
    /// </summary>
    public class CharacterModel : BasePlayerModel<CharacterModel>
    {

        // SpecificCharacterTypeEnum for this Character (e.g. Procrastinator, Helicopter Parent, etc.)
        public SpecificCharacterTypeEnum SpecificCharacterTypeEnum { get; set; }

        // Character GPA
        public int GPA { get; set; } = 0;

        // Variable indicating if special ability has been used in a given round.
        public bool AbilityUsedInCurrentRound { get; set; } = false;

        // Character's special ability. This is pre-determined based on SpecificCharacterType
        public AbilityEnum SpecialAbility { get; set; } 

        // Variable indicating if Character has graduated or not (i.e. reached level 20)
        public bool Graduated { get; set; } = false;

        /// <summary>
        /// Default Character constructor
        /// </summary>
        public CharacterModel()
        {
            Name = "Bobbet";
            Description = "";
            PlayerType = PlayerTypeEnum.Character;
            CharacterTypeEnum = CharacterTypeEnum.Student;
            SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SmartyPants;
            Guid = Id;
            Level = 1;
            ImageURI = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum);
            GPA = 0;
            ExperienceTotal = 0;
            ExperienceRemaining = LevelTableHelper.LevelDetailsList[Level + 1].Experience - 1;
            SpecialAbility = SpecificCharacterTypeEnumHelper.ToAbility(SpecificCharacterTypeEnum);

        }

        /// <summary>
        /// Create a copy; in this version, the player is initialized with body parts and 
        /// corresponding items unless the user picks "None" explicitly
        /// </summary>
        /// <param name="data"></param>
        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public override bool Update(CharacterModel newData)
        {
            if (newData == null)
            {
                return false;
            }
    
            CharacterTypeEnum = newData.CharacterTypeEnum;
            SpecificCharacterTypeEnum = newData.SpecificCharacterTypeEnum;

            // helper for figuring out which image based on CharacterSpecific type
            ImageURI = SpecificCharacterTypeEnumHelper.ToImageURI(SpecificCharacterTypeEnum);

            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            GPA = newData.GPA;

            Speed = newData.Speed;
            Defense = newData.Defense;
            Attack = newData.Attack;

            ExperienceTotal = newData.ExperienceTotal;
            ExperienceRemaining = newData.ExperienceRemaining;
            CurrentHealth = newData.CurrentHealth;
            MaxHealth = newData.MaxHealth;

            Head = newData.Head;
            Necklace = newData.Necklace;
            PrimaryHand = newData.PrimaryHand;
            OffHand = newData.OffHand;
            RightFinger = newData.RightFinger;
            LeftFinger = newData.LeftFinger;
            Feet = newData.Feet;

            Graduated = newData.Graduated;
            SpecialAbility = newData.SpecialAbility;
            AbilityUsedInCurrentRound = newData.AbilityUsedInCurrentRound;

            Job = newData.Job;

            return true;
        }

        /// <summary>
        /// Given SpecificCharacterTypeEnum return the items
        /// </summary>
        /// <param name="newData">Character to update</param>
        public List<ItemModel> ItemsBasedOnCharacterType(SpecificCharacterTypeEnum characterType)
        {
            List<ItemModel> item = new List<ItemModel>();
            switch (characterType)
            {
                case SpecificCharacterTypeEnum.SmartyPants:
                    var pencil = new ItemModel(ItemTypeEnum.PencilEraser);
                    var indexcard = new ItemModel(ItemTypeEnum.IndexCards);
                    item.Add(pencil);
                    item.Add(indexcard);
                    PrimaryHand = pencil.Id;
                    RightFinger = indexcard.Id;
                    break;

                case SpecificCharacterTypeEnum.Overachiever:
                    var Textbooks = new ItemModel(ItemTypeEnum.Textbooks);
                    item.Add(Textbooks);
                    PrimaryHand = Textbooks.Id;
                    break;

                case SpecificCharacterTypeEnum.InternationalStudent:
                    var Notebook = new ItemModel(ItemTypeEnum.Notebook);
                    item.Add(Notebook);
                    PrimaryHand = Notebook.Id;
                    break;

                case SpecificCharacterTypeEnum.Prodigy:
                    var LibraryCard = new ItemModel(ItemTypeEnum.LibraryCard);
                    item.Add(LibraryCard);
                    Necklace = LibraryCard.Id;
                    break;

                case SpecificCharacterTypeEnum.SecondCareer:
                    var Laptop = new ItemModel(ItemTypeEnum.Laptop);
                    item.Add(Laptop);
                    PrimaryHand = Laptop.Id;
                    break;

                case SpecificCharacterTypeEnum.Slacker:
                    var Calculator = new ItemModel(ItemTypeEnum.Calculator);
                    var Skateboard = new ItemModel(ItemTypeEnum.Skateboard);
                    item.Add(Calculator);
                    item.Add(Skateboard);
                    LeftFinger = Calculator.Id;
                    Feet = Skateboard.Id;
                    break;

                case SpecificCharacterTypeEnum.Procrastinator:
                    var FoodCourtCard = new ItemModel(ItemTypeEnum.FoodCourtCard);
                    item.Add(FoodCourtCard);
                    Necklace = FoodCourtCard.Id;
                    break;

                case SpecificCharacterTypeEnum.HelicopterParent:
                    var Tuition = new ItemModel(ItemTypeEnum.Tuition);
                    item.Add(Tuition);
                    PrimaryHand = Tuition.Id;
                    break;

                case SpecificCharacterTypeEnum.CoolParent:
                    var PrivateTutor = new ItemModel(ItemTypeEnum.PrivateTutor);
                    item.Add(PrivateTutor);
                    Necklace = PrivateTutor.Id;
                    break;
            }
            return item;
        }

        /// <summary>
        /// Helper to combine the attributes into a single line, to make it easier to display the item as a string
        /// </summary>
        /// <returns></returns>
        public override string FormatOutput()
        {
            var myReturn = string.Empty;
            myReturn += Name;
            myReturn += " , " + Description;
            myReturn += " , Level : " + Level.ToString();
            myReturn += " , Total Experience : " + ExperienceTotal;
            myReturn += " , Attack :" + GetAttackTotal;
            myReturn += " , Defense :" + GetDefenseTotal;
            myReturn += " , Speed :" + GetSpeedTotal;
            myReturn += " , Items : " + ItemSlotsFormatOutput();
            myReturn += " , Damage : " + GetDamageTotalString;

            return myReturn;
        }
    }
}