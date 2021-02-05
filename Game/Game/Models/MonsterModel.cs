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
        public SpecificMonsterTypeEnum SpecificMonsterTypeEnum { get; set; }

        /// <summary>
        /// Set Type to Monster
        /// 
        /// Set Name and Description
        /// </summary>
        public MonsterModel()
        {
            PlayerType = PlayerTypeEnum.Monster;
            MonsterTypeEnum = MonsterTypeEnum.Faculty;
            SpecificMonsterTypeEnum = SpecificMonsterTypeEnum.TeachingAssistant;
            Guid = Id;
            Name = null;
            Description = null;
            Attack = 1;
            Difficulty = DifficultyEnum.Average;
            UniqueDropItem = null;
            Items = null;
            ImageURI = null;
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
            if (PlayerType == PlayerTypeEnum.Monster)
            {
               MonsterTypeEnum = newData.MonsterTypeEnum;
            }

            // TODO: change this check for each monster for images and MonsterType. (i.e. dication, case states or methods). 
            if (MonsterTypeEnum == MonsterTypeEnum.Faculty && SpecificMonsterTypeEnumHelper.GetFacultyList.Contains(newData.SpecificMonsterTypeEnum.ToMessage()))
            {
                SpecificMonsterTypeEnum = newData.SpecificMonsterTypeEnum;
            }

            UpdateImageURI(newData);

            if (MonsterTypeEnum == MonsterTypeEnum.Administrator && SpecificMonsterTypeEnumHelper.GetAdministratorList.Contains(newData.SpecificMonsterTypeEnum.ToMessage()))
            {
                SpecificMonsterTypeEnum = newData.SpecificMonsterTypeEnum;
                // helper for figuring out which image based on CharacterSpecific type
                UpdateImageURI(newData);
            }

            Guid = newData.Guid;
            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            ImageURI = newData.ImageURI;

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
        /// Helper to combine the attributes into a single line, to make it easier to display the item as a string
        /// </summary>
        /// <returns></returns>
        public override string FormatOutput()
        {
            var myReturn = Name;
            myReturn += " , " + Description;
            //myReturn += " , a " + Job.ToMessage();
            myReturn += " , Level : " + Level.ToString();
            myReturn += " , Difficulty : " + Difficulty.ToString();
            myReturn += " , Total Experience : " + ExperienceTotal;
            myReturn += " , Items : " + ItemSlotsFormatOutput();
            myReturn += " , Damage : " + GetDamageTotalString;

            return myReturn;
        }

        /// <summary>
        /// assigns a specific Image for each Monster
        /// </summary>
        /// <param name="newData"></param>
        public void UpdateImageURI(MonsterModel newData)
        {
            switch (newData.SpecificMonsterTypeEnum)
            {

                case SpecificMonsterTypeEnum.TeachingAssistant:
                    ImageURI = "squid.jpg";
                    break;

                case SpecificMonsterTypeEnum.AdjunctFaculty:
                    ImageURI = "squid.jpg";
                    break;

                case SpecificMonsterTypeEnum.AssistantProfessor:
                    ImageURI = "squid.jpg";
                    break;

                case SpecificMonsterTypeEnum.AssociateProfessor:
                    ImageURI = "squid.jpg";
                    break;

                case SpecificMonsterTypeEnum.Professor:
                    ImageURI = "squid.jpg";
                    break;

                case SpecificMonsterTypeEnum.HRAdministrator:
                    ImageURI = "squid.jpg";
                    break;

                case SpecificMonsterTypeEnum.RegistrationAdministrator:
                    ImageURI = "squid.jpg";
                    break;

                case SpecificMonsterTypeEnum.GraduationOfficeAdministrator:
                    ImageURI = "squid.jpg";
                    break;



            }
        }
    }
}