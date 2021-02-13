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

        public bool AbilityUsedInCurrentRound { get; set; } = false;

        public AbilityEnum SpecialAbility { get; set; } = AbilityEnum.None;

        public bool Graduated { get; set; } = false;

        public CharacterModel()
        {
            Name = "";
            Description = "";
            PlayerType = PlayerTypeEnum.Character;
            CharacterTypeEnum = CharacterTypeEnum.Student;
            SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SmartyPants;
            Guid = Id;
            Level = 1;
            ImageURI = "smarty_pants_character.png";
            GPA = 0;
            ExperienceTotal = 0;
            ExperienceRemaining = LevelTableHelper.LevelDetailsList[Level + 1].Experience - 1;
            UpdateItemsBasedOnCharacterType(SpecificCharacterTypeEnum);


            // Default to unknown, which is no special job
            //Job = CharacterJobEnum.Unknown; 
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

            PlayerType = newData.PlayerType;
            if (PlayerType == PlayerTypeEnum.Character)
            {
                CharacterTypeEnum = newData.CharacterTypeEnum;
            }

            // Updates each Character by SpecificMonsterType Enum 
            if (CharacterTypeEnum == CharacterTypeEnum.Student && SpecificCharacterTypeEnumHelper.GetStudentList.Contains(newData.SpecificCharacterTypeEnum.ToMessage()))
            {
                SpecificCharacterTypeEnum = newData.SpecificCharacterTypeEnum;
            }

            if (CharacterTypeEnum == CharacterTypeEnum.Parent && SpecificCharacterTypeEnumHelper.GetParentList.Contains(newData.SpecificCharacterTypeEnum.ToMessage()))
            {
                SpecificCharacterTypeEnum = newData.SpecificCharacterTypeEnum;
            }

            // helper for figuring out which image based on CharacterSpecific type
            UpdateImageURI(newData);

            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            GPA = newData.GPA;

            // Difficulty = newData.Difficulty;

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

            // Update the Job
            //Job = newData.Job;

            return true;
        }

        /// <summary>
        /// Given the inputted Character, updates the image URI based on the SpecificCharacterTypeEnum. 
        /// </summary>
        /// <param name="newData">Character to update</param>
        public List<ItemModel> UpdateItemsBasedOnCharacterType(SpecificCharacterTypeEnum characterType)
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
                    item.Add(Calculator);
                    LeftFinger = Calculator.Id;
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
        /// Given the inputted Character, updates the image URI based on the SpecificCharacterTypeEnum. 
        /// </summary>
        /// <param name="newData">Character to update</param>
        public void UpdateImageURI(CharacterModel newData)
        {
            switch (newData.SpecificCharacterTypeEnum)
            {

                case SpecificCharacterTypeEnum.SmartyPants:
                    ImageURI = Constants.SpecificCharacterTypeSmartyPantsImageURI;
                    break;

                case SpecificCharacterTypeEnum.Overachiever:
                    ImageURI = Constants.SpecificCharacterTypeOverachieverImageURI;
                    break;

                case SpecificCharacterTypeEnum.InternationalStudent:
                    ImageURI = Constants.SpecificCharacterTypeInternationalStudentImageURI;
                    break;

                case SpecificCharacterTypeEnum.Prodigy:
                    ImageURI = Constants.SpecificCharacterTypeProdigyImageURI;
                    break;

                case SpecificCharacterTypeEnum.SecondCareer:
                    ImageURI = Constants.SpecificCharacterTypeSecondCareerImageURI;
                    break;

                case SpecificCharacterTypeEnum.Slacker:
                    ImageURI = Constants.SpecificCharacterTypeSlackerImageURI;
                    break;

                case SpecificCharacterTypeEnum.Procrastinator:
                    ImageURI = Constants.SpecificCharacterTypeProcrastinatorImageURI;
                    break;

                case SpecificCharacterTypeEnum.HelicopterParent:
                    ImageURI = Constants.SpecificCharacterTypeHelicopterParentImageURI;
                    break;

                case SpecificCharacterTypeEnum.CoolParent:
                    ImageURI = Constants.SpecificCharacterTypeCoolParentImageURI;
                    break;

                case SpecificCharacterTypeEnum.Unknown:
                default:
                    ImageURI = Constants.SpecificCharacterTypeDefaultImageURI;
                    break;
            }
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
           // myReturn += " , a " + Job.ToMessage();
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