using System.Collections.Generic;
using System;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The specific Item enum type.  
    /// </summary>
    public enum ItemTypeEnum
    {
        // Not specified
        Unknown = 0,

        // Memorize your homework.
        IndexCards = 5,

        // Forget about your mistakes.
        PencilEraser = 10,

        // Reference course literature effectively.
        Textbooks = 15,

        // Keep track of the most crucial things to know.
        Notebook = 20,

        // Avoid doing math in your head. 
        Calculator = 25, 

        // Get your textbooks for free.
        LibraryCard = 30, 

        // Don't run out of fuel. 
        FoodCourtCard = 35, 

        // Complete your assignments faster with a laptop. 
        Laptop = 40, 

        // Get expert homework help. 
        PrivateTutor = 45, 

        // Get some financial help.
        FinancialAid = 50, 

        // Pay your way through college. 
        Tuition = 55, 

        // The cap will help you feel closer to graduation!
        GraduationCapAndRobe = 60,

        // A diploma is the (almost) final step before graduation.
        Diploma = 65
    }

}