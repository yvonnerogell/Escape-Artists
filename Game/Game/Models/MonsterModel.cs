using Game.GameRules;

namespace Game.Models
{
    /// <summary>
    /// The Monsters in the Game
    /// 
    /// Derives from BasePlayer Model just like Character
    /// </summary>
    public class MonsterModel : BasePlayerModel<MonsterModel>
    {
        // The specific monster type for this monster
        public SpecificMonsterTypeEnum SpecificMonsterTypeEnum { get; set; }

        // Unique Drop Item for Monsters
        public string UniqueDropItem { get; set; } = null;

        /// <summary>
        /// Constructor to create a new MonsterModel.
        /// </summary>
        public MonsterModel()
        {
            PlayerType = PlayerTypeEnum.Monster;
            MonsterTypeEnum = MonsterTypeEnum.Faculty;
            SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.TeachingAssistant;
            Guid = Id;
            Name = "";
            Description = "";
            Attack = 1;
            Difficulty = DifficultyEnum.Average;
            UniqueDropItem = null;
            ImageURI = Constants.SpecificMonsterTypeDefaultImageURI;
            ExperienceTotal = 0;
            ExperienceRemaining = LevelTableHelper.LevelDetailsList[Level + 1].Experience - 1;

        }

        /// <summary>
        /// Make a copy
        /// </summary>
        /// <param name="data"></param>
        public MonsterModel(MonsterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public override bool Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return false;
            }

            PlayerType = newData.PlayerType;
            MonsterTypeEnum = newData.MonsterTypeEnum;
            SpecificMonsterTypeEnum = newData.SpecificMonsterTypeEnum;
            SpecificMonsterTypeEnum = newData.SpecificMonsterTypeEnum;
            
            ImageURI = SpecificMonsterTypeEnumHelper.ToImageURI(SpecificMonsterTypeEnum);
            Guid = newData.Guid;
            Name = newData.Name;
            Description = newData.Description;

            Difficulty = newData.Difficulty;

            //Speed = newData.Speed;
            //Defense = newData.Defense;
            Attack = newData.Attack;

            ExperienceTotal = newData.ExperienceTotal;
            ExperienceRemaining = newData.ExperienceRemaining;
            //CurrentHealth = newData.CurrentHealth;
            //MaxHealth = newData.MaxHealth;

            Head = newData.Head;
            Necklace = newData.Necklace;
            PrimaryHand = newData.PrimaryHand;
            OffHand = newData.OffHand;
            RightFinger = newData.RightFinger;
            LeftFinger = newData.LeftFinger;
            Feet = newData.Feet;
            UniqueDropItem = newData.UniqueDropItem;

            //Job = newData.Job;

            return true;
        }

        /// <summary>
        /// Given the inputed Monster, updates the image URI based on the SpecificMonsterTypeEnum. 
        /// </summary>
        /// <param name="newData">Character to update</param>
        public ItemModel DropItemBasedOnCharacterType(SpecificMonsterTypeEnum monsterType)
        {
            ItemModel uniqueDrop = null;
            switch (monsterType)
            {
                case SpecificMonsterTypeEnum.TeachingAssistant:
                    uniqueDrop = new ItemModel(ItemTypeEnum.IndexCards);
                    UniqueDropItem = uniqueDrop.Id;
                    break;

                case SpecificMonsterTypeEnum.AdjunctFaculty:
                    UniqueDropItem = null;
                    break;

                case SpecificMonsterTypeEnum.AssistantProfessor:
                    uniqueDrop = new ItemModel(ItemTypeEnum.Laptop);
                    UniqueDropItem = uniqueDrop.Id;
                    break;

                case SpecificMonsterTypeEnum.AssociateProfessor:
                    uniqueDrop = new ItemModel(ItemTypeEnum.Textbooks);
                    UniqueDropItem = uniqueDrop.Id;
                    break;

                case SpecificMonsterTypeEnum.Professor:
                    UniqueDropItem = null;
                    break;

                case SpecificMonsterTypeEnum.HRAdministrator:
                    uniqueDrop = new ItemModel(ItemTypeEnum.FinancialAid);
                    UniqueDropItem = uniqueDrop.Id;
                    break;

                case SpecificMonsterTypeEnum.RegistrationAdministrator:
                    UniqueDropItem = null;
                    break;

                case SpecificMonsterTypeEnum.GraduationOfficeAdministrator:
                    uniqueDrop = new ItemModel(ItemTypeEnum.GraduationCapAndRobe);
                    UniqueDropItem = uniqueDrop.Id;
                    break;
            }
            return uniqueDrop;
        }

        /// <summary>
        /// Helper to combine the attributes into a single line, to make it easier to display the item as a string
        /// </summary>
        /// <returns></returns>
        public override string FormatOutput()
        {
            var myReturn = Name;
            myReturn += " , " + Description;
            //myReturn += " , a " + Job.ToMessage();
            myReturn += " , Difficulty : " + Difficulty.ToString();
            myReturn += " , Total Experience : " + ExperienceTotal;
            myReturn += " , Items : " + ItemSlotsFormatOutput();
            myReturn += " , Damage : " + GetDamageTotalString;

            return myReturn;
        }
    }
}