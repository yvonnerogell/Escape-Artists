using Game.GameRules;

namespace Game.Models
{
    /// <summary>
    /// Characters
    /// 
    /// Derive from BasePlayerModel
    /// </summary>
    public class CharacterModel : BasePlayerModel<CharacterModel>
    {
        //TODO: Add new Character Varaibles
        public SpecificCharacterTypeEnum SpecificCharacterTypeEnum { get; set; }
        /// <summary>
        /// Default character
        /// 
        /// Gets a type, guid, name and description
        /// </summary>
        public CharacterModel()
        {
            PlayerType = PlayerTypeEnum.Character;
            CharacterTypeEnum = CharacterTypeEnum.Student;
            SpecificCharacterTypeEnum = SpecificCharacterTypeEnum.SmartyPants;
            Guid = Id;
            Name = null;
            Description = null;
            Level = 1;
            ImageURI = null;
            ExperienceTotal = 0;
            ExperienceRemaining = LevelTableHelper.LevelDetailsList[Level + 1].Experience - 1;
            Feet = null;
            PrimaryHand = null;
            OffHand = null;
            RightFinger = null;
            LeftFinger = null;
            Necklace = "None";
            Head = "None";

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

            // helper for figuring out which image based on CharacterSpecific type
            UpdateImageURI(newData);


            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;

            // Difficulty = newData.Difficulty;

            Speed = newData.Speed;
            Defense = newData.Defense;
            Attack = newData.Attack;

            ExperienceTotal = newData.ExperienceTotal;
            ExperienceRemaining = newData.ExperienceRemaining;
            CurrentHealth = newData.CurrentHealth;
            MaxHealth = newData.MaxHealth;

            if (newData.Head != "None")
            {
                Head = newData.Head;
            }

            if (newData.Necklace != "None")
            {
                Necklace = newData.Necklace;
            }

            if (newData.PrimaryHand != "None")
            {
                PrimaryHand = newData.PrimaryHand;
            }

            if (newData.OffHand != "None")
            {
                OffHand = newData.OffHand;
            }

            if (newData.RightFinger != "None")
            {
                RightFinger = newData.RightFinger;
            }

            if (newData.LeftFinger != "None")
            {
                LeftFinger = newData.LeftFinger;
            }

            if (newData.Feet != "None")
            {
                Feet = newData.Feet;
            }

            if (newData.UniqueDropItem != "None")
            {
                UniqueDropItem = newData.UniqueDropItem;
            }

            // Update the Job
            //Job = newData.Job;

            return true;
        }

        public void UpdateImageURI(CharacterModel newData)
        {
            switch (newData.SpecificCharacterTypeEnum)
            {

                case SpecificCharacterTypeEnum.SmartyPants:
                    ImageURI = "student.png";
                    break;

                case SpecificCharacterTypeEnum.Overachiever:
                    ImageURI = "student.png";
                    break;

                case SpecificCharacterTypeEnum.InternationalStudent:
                    ImageURI = "student.png";
                    break;

                case SpecificCharacterTypeEnum.Prodigy:
                    ImageURI = "student.png";
                    break;

                case SpecificCharacterTypeEnum.SecondCareer:
                    ImageURI = "student.png";
                    break;

                case SpecificCharacterTypeEnum.Slacker:
                    ImageURI = "student.png";
                    break;

                case SpecificCharacterTypeEnum.Procrastinator:
                    ImageURI = "student.png";
                    break;

                case SpecificCharacterTypeEnum.HelicopterParent:
                    ImageURI = "parent.png";
                    break;

                case SpecificCharacterTypeEnum.CoolParent:
                    ImageURI = "parent.png";
                    break;

                case SpecificCharacterTypeEnum.Unknown:
                default:
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