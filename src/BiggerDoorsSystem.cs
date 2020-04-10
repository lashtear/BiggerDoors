using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

[assembly: ModInfo("BiggerDoors",
    Description = "Bigger and better doors",
	Website     = "https://github.com/lashtear/BiggerDoors",
	Authors     = new []{ "Chime" })]

namespace BiggerDoors {
    public class BiggerDoorsSystem : ModSystem {
        public static string MOD_ID = "biggerdoors";
        public override bool AllowRuntimeReload => false; // we add blocks

        // Client
		public ICoreClientAPI CApi { get; private set; }
		public IClientNetworkChannel CChannel { get; private set; }
		
		// Server
		public ICoreServerAPI SApi { get; private set; }
		public IServerNetworkChannel SChannel { get; private set; }

        public override void Start(ICoreAPI api) {
            api.RegisterBlockClass("biggerdoor", typeof(BiggerDoorBlock));
        }

        public override void StartClientSide(ICoreClientAPI api) {
            CApi     = api;
			CChannel = api.Network.RegisterChannel(MOD_ID);
        }

        public override void StartServerSide(ICoreServerAPI api) {
			SApi     = api;
			SChannel = api.Network.RegisterChannel(MOD_ID);
        }
    }
}