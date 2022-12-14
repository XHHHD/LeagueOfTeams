using System.Data;
using LeagueOfTeamsBusinessLogic.Models.Top;

namespace LeagueOfTeamsBusinessLogic.Models.Members
{
    internal class MemberNickGenerator
    {
        static Random random = new();

        static List<string> membersNicks = new List<string>()
        {
            "Abasid", "AbsolutelyWinner", "AccidentalGenius", "AcidGosling", "AdmiralTot", "AgentHercules", "AirportHobo", "AlleyFrog", "Alpha", "AlphaReturns", "Angel", "AngelsCreed", "ArsenicCoo", "AtomicBlastoid", "AutomaticSlicer", "Aspect", "Atilla", "Automatic", "Aero", "Albatross", "Arsenal", "Avenger", "Agrippa",
            "Basta", "BabyBrown", "BackBettBad", "BunnyBazooka", "BeardedAngler", "BeetleKing", "BettyCricket", "BitSentinel", "Bitmap", "BlacKitten", "Blister", "Blistered Outlaw", "Blitz", "BloodEater", "Bonzai", "BoomBeachLuvr", "BoomBlaster", "Bootleg Taximan", "Bowie", "Bowler", "Breadmaker", "Broomspun", "Buckshot", "Bug Blitz", "BugFire", "Bugger", "Ballistic", "Bender", "BigPapa", "BillyTheButcher", "Bruise", "Bowser", "BulletProof", "Bleed", "Breaker", "Bone", "Blood", "Bullet", "Bomber", "Boomslang", "Boar", "BlackMamba",
            "CarGo", "Cabbie", "CandyButcher", "CapitalF", "CaptainPeroxide", "CelticCharger", "CenturionSherman", "CerealKiller", "ChasmFace", "ChewChew", "ChicagoBlackout", "Cannon", "Clink", "Cobra", "Colt", "Crank", "Creep", "CobraBite", "Cocktail", "CollaterolDamage", "CommandX", "Commando", "Congo Wire", "CoolIris", "CoolWhip", "Cosmo", "CrashOverride", "CrashTest", "CrazyEights", "CrissCross", "CrossThread", "Cujo", "CupidDust", "Conqueror", "Cyrus", "Craniax", "Cut", "Cannon", "Carbine", "Claw", "Centerfire",
            "Dack", "Daemon", "Decay", "Diablo", "Doom", "Dracula", "Dragon", "Dissent", "Derange", "DaffyGirl", "DahliaBumble", "DaisyCraft", "Dancing Madman", "Dangle", "DanimalDaze", "DarkHorse", "DarksideOrbit", "DarlingPeacock", "DayHawk", "DesertHaze", "Desperado", "DevilBlade", "DevilChick", "Dexter", "DiamondGamer", "Digger", "DiscoPotato", "DiscoThunder", "DiscoMate", "DonStab", "DozKiller", "Dredd", "DriftDetector", "DriftManiac", "DropStone", "Dropkick", "DrugstoreCowboy", "DuckDuck", "Darko", "Deathstalker", "Demented", "Dutch", "Dux",
            "EarlofArms", "EasySweep", "EerieMizzen", "ElactixNova", "ElderPogue", "ElectricPlayer", "ElectricSaturn", "EmberRope", "Esquire", "ExoticAlpha", "EyeShooter",
            "Fabulous", "FastDraw", "FastLane", "FatherAbbot", "FenderBoyXXX", "FennelDove", "FeralMayhem", "FiendOblivion", "FifthHarmony", "FireFeline", "FireFish", "FireByMisFire", "FistWizard", "Fist", "Footslam", "Frenzy", "FireBred", "Furore", "Fury", "Fender", "Fester", "Fisheye", "Flack", "Falcon", "Fang",
            "Gash", "Gut", "Geronimo", "Glock", "Gatling", "Grizzly", "Grip", "Goshawk", "Gnaw", "Gargoyle", "Grave", "Gunner", "Graffy", "GGNext", "GoodGun",
            "Hash", "Hashtag", "Hurricane", "Hannibal", "HeadKnocker", "Hellcat", "Howitzer", "Hornet", "Hazzard", "HoHoHo", "Holliday", "HolyWar", "Hunter",
            "Indominus", "Ironclad", "IronHeart", "Ironsides", "IronCut", "Insurgent", "Ire", "Indigo", "Invader", "ImagineKitties", "IIICenturyFox", "IGGI", "IggyRock",
            "Jaguar", "Javelin", "Jawbone", "JesseJames", "Jaggernaut", "Judge", "JustLuck", "Jimbo", "Jeronimo", "JazzCat", "JoyClub", "Jinjer", "JinCooler",
            "K9", "Kneecap", "Kraken", "Kevlar", "Killer", "Knuckles", "Khan", "KnowWhoMySisterIs", "KannadianGringo", "Koala",
            "Lash","Lightning", "Leon", "Leonidas", "Lynch", "LeonStealer", "LionHorn", "LoveDealer", "LeafKicker", "Lollipop",
            "MadDog", "Maximus", "Matrix", "MadMax", "Madness", "Manic", "Mania", "Mortar", "MrBlonde", "Metapelet",
            "Napoleon", "Nail", "Ninja", "NachoMan", "NoEnclude", "NineInchPins", "NoMoneyNoHoney", "NastyJuice", "Nintendophob",
            "O'Doyle", "Overthrow", "OnlyForWin", "OnlyFax", "Offshore", "OfficerPants", "Origami", "ObjectShovel", "Oxigendo",
            "Panther", "PolarBee", "PoppyCoffee", "PoptartAK47", "Prometheus", "PsychoThinker", "Pusher", "Pursuit", "Psycho", "Photograph", "Punisher", "PutInHooyLow", "PopularOpinion", "PapaSeeYourArms", "PantsKeeper", "PanPan",
            "Queenkiller", "QuietPlace", "Questore",
            "Ranger", "Ratchet", "Reaper", "Rigs", "Ripley", "Roadkill", "Ronin", "Rubble", "Razor", "Ram", "Rimfire", "RacyLion", "RadioactiveMan", "RaidBucker", "RandoTank", "Ranger", "RedCombat", "RedRhino", "RedFeet", "RedFisher", "RedMouth", "ReedLady", "RenegadeSlugger", "RenoMonarch", "Returns", "RevengeOfOmega", "RiffRaff", "Roadblock", "RoarSweetie", "RockyHighway", "RollerTurtle", "RomanceGuppy", "Rooster", "RudeSniper", "Rage", "Rebellion",
            "Sasquatch", "Scar", "Shiver", "Skinner", "SkullCrusher", "Slasher", "Steelshot", "Surge", "Sythe", "Steel", "SteelForge", "SteelFoil", "SickRebellious Names", "Sabotage", "Subversion", "Schizo", "Savage", "Siddhartha", "Suleiman", "Slaughter", "Soleus", "Scalp", "Scab", "Socket", "Skeleton", "Sniper", "Siege", "StrikeEagle", "Snake", "Scorpion", "Sting", "SaintLaZBoy", "Sandbox", "ScareStone", "ScaryNinja", "ScaryPumpkin", "Scrapper", "Scrapple", "Screw", "Screwtape", "SealSnake", "ShadowBishop", "ShadowChaser", "SherwoodGladiator", "Shooter", "ShowMeSunset", "ShowMeUrguts", "SidewalkEnforcer", "SiennaPrincess", "SilverStone", "SirShove", "SkullCrusher", "SkyBully", "SkyHerald",
            "Trip", "Trooper", "Tweek", "Tito", "Titanium", "Tempest", "Terminator", "Thor", "Tooth", "Torque", "Torpedo", "Tomcat", "Tusk",
            "Upsurge", "Uprising", "Uproar", "Uploader",
            "Vein", "Void", "Vulture", "Viper", "Vehiclon", "Volt",
            "Wardon", "Wraith", "Wrath", "Wildcat", "Wolf", "Wolverine", "Wonwifter", "WTph",
            "XMasGift", "XSkull", "XavieL",
            "YellowMaster","YellowKaRaTeBelt", "YodaWasAShearedRat",
            "Zomboid", "Zorrotron", "Zero", "Zoltan", "Zak"
        };
        internal static string GenerateNewMemberNick()
        {
            HashSet<int> usedNamesID = new HashSet<int>();
            foreach (Member member in MembersTopManager.GetMembersTop())
            {
                if (membersNicks.IndexOf(member.MemberNick) != -1) usedNamesID.Add(membersNicks.IndexOf(member.MemberNick));
            }
            var notUsedInexes = Enumerable.Range(0, membersNicks.Count-1).Where(i => !usedNamesID.Contains(i));
            int randomNameIndexForNotUsedInexes = random.Next(0, 100 - usedNamesID.Count);
            return membersNicks[notUsedInexes.ElementAt(randomNameIndexForNotUsedInexes)];
        }
    }
}
