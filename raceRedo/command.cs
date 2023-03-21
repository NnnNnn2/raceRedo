using PulsarModLoader.Chat.Commands.CommandRouter;

namespace raceRedo
{
    internal class command : ChatCommand
    {
        public override string[] CommandAliases()
        {
            return new string[] { "raceRedo", "redoRaces" };
        }

        public override string Description()
        {
            return "allows to replay races";
        }

        public override void Execute(string arguments)
        {
            if (PhotonNetwork.isMasterClient)
            {
                if (PLServer.Instance.CurrentCrewCredits >= 100000)
                {
                    PLServer.Instance.CurrentCrewCredits -= 100000;
                    PLServer.Instance.RacesWonBitfield = 0;
                    PLServer.Instance.RacesLostBitfield = 0;
                    PLServer.Instance.RacesStartedBitfield = 0;
                    PulsarModLoader.Utilities.Messaging.Echo(PhotonTargets.MasterClient,
                        "You can now participate in races again!");
                }
                else
                {
                    PulsarModLoader.Utilities.Messaging.Echo(PhotonTargets.MasterClient,
                        "You don't have enough credits to participate in races again! Credits required: 100 000 CR");
                }
            }
            else
            {
                PulsarModLoader.Utilities.Messaging.Echo(PhotonTargets.MasterClient,
                    $"Your crewmate ({PLNetworkManager.GetLocalPlayerName()}) tried using host-only command!");
                PulsarModLoader.Utilities.Messaging.Notification("You can't use this command! You are not a host!",
                    PLNetworkManager.Instance.LocalPlayer);
            }
        }
    }
}
