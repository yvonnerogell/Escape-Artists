using System.Collections.Generic;
using System;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The specific Character enum type.  
    /// </summary>
    public enum SpecificCharacterTypeEnum
    {
        // Not specified
        Unknown = 0,

        // Smarty pants is smart, has special ability and extra Head item location
        SmartyPants = 10,

        // Overacheiver works hard and extra Head and Necklace item location
        Overachiever = 15,

        // International Student is multi-cultured, has special ability and extra Head item location
        InternationalStudent = 20,

        // Prodigy Student is smart, has special ability and extra Head item location
        Prodigy = 25,

        // Second Career has real life experience, has special ability and Head and Necklace item location.
        SecondCareer = 30,
        
        // Slacker likes to chill and has extra Head and Necklace item location
        Slacker = 35,

        // Procrastinator likes to wait, has special ability and extra Head item location
        Procrastinator = 40,

        // Helicopter Parent likes to control and has special ability
        HelicopterParent = 45,

        // Cool Parent likes to relax and has special ability
        CoolParent = 50
    }

}