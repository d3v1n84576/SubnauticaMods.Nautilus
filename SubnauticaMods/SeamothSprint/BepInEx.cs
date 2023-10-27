﻿

namespace Ramune.SeamothSprint
{
    [BepInDependency("com.snmodding.nautilus")]
    [BepInPlugin(GUID, Name, Version)]
    [BepInProcess("Subnautica.exe")]
    public class SeamothSprint : BaseUnityPlugin
    {
        public static Config config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();
        public static SeamothSprint Instance;
        public static ManualLogSource logger => Instance.Logger;
        public static readonly Harmony harmony = new(GUID);
        public const string GUID = "com.ramune.SeamothSprint";
        public const string Name = "Seamoth Sprint";
        public const string Version = "1.0.1";

        public void Awake()
        {
            Utilities.Initialize(harmony, Logger, Name, Version);
        }
    }
}