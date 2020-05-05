using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;
using GTA.Native;
using System.Windows.Forms;
using System.Drawing;

namespace BeforeTheChase
{
    public class BeforeTheChase : Script
    {
        public BeforeTheChase()
        {
            Tick += OnTick;
        }

        public void OnTick(object sender, EventArgs e)
        {
            Player player = Game.Player;

            if (player.WantedLevel == 0 && player.Character.IsInVehicle())
            {

                Vector3 plrPos3 = player.Character.Position;
                Vector2 plrPos2 = new Vector2(plrPos3.X, plrPos3.Y);

                float plrMph = player.Character.CurrentVehicle.Speed * (float)2.237;

                float speedingBy = OverSpeedLimit(plrPos2, plrMph);
                Ped[] loadedPeds = World.GetAllPeds();
                int numPeds = loadedPeds.Length;
                Ped plrPed = player.Character;
                

                int seen = PedCanSeePlayersVehicle(loadedPeds, player);

                if (seen > 0)
                {

                    Random rand = new Random();

                    if (player.WantedLevel == 0 && speedingBy > 10)
                    {
                        int wantedThresh = Function.Call<int>(Hash.GET_WANTED_LEVEL_THRESHOLD, 1);

                        if (seen == 2)
                        {
                            UI.Notify("Cop saw you going " + speedingBy + " over the speed limit");
                            player.WantedLevel = 1;
                            // TO-DO: See if there's a REPORT_CRIME param for cop reporting (not a "citizens report")
                            Function.Call(Hash.REPORT_CRIME, player.Handle, 4, wantedThresh);

                        }
                        else if (rand.NextDouble() / speedingBy < .01)
                        {
                            UI.Notify("Reported going " + speedingBy + " over the speed limit");
                            Function.Call(Hash.REPORT_CRIME, player.Handle, 4, wantedThresh);
                        }

                    }

                    if (player.WantedLevel == 0 && DrivingOnWrongSide())
                    {
                        int wantedThresh = Function.Call<int>(Hash.GET_WANTED_LEVEL_THRESHOLD, 1);

                        if (seen == 2)
                        {
                            UI.Notify("Cop saw you driving on the wrong side of the road");
                            Function.Call(Hash.REPORT_CRIME, player.Handle, 3, wantedThresh); // Reckless driving
                        }
                        else if (rand.NextDouble() < .05)
                        {
                            UI.Notify("Ped reported you driving on the wrong side of the road");
                            Function.Call(Hash.REPORT_CRIME, player.Handle, 3, wantedThresh); // Reckless driving
                        }
                    }
                }
            }

        }

        public bool DrivingOnWrongSide()
        {
            int time = Function.Call<int>(Hash.GET_TIME_SINCE_PLAYER_DROVE_AGAINST_TRAFFIC, Game.Player.Handle);

            if (time < 1000)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int PedCanSeePlayersVehicle(Ped[] peds, Player player)
        {
            int returnVal = 0;
            foreach (Ped p in peds)
            {
                Yield();

                int pType = Function.Call<int>(Hash.GET_PED_TYPE, p.Handle);
                bool pCanSee = Function.Call<bool>
                    (
                    Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY,
                    p.Handle,
                    player.Character.CurrentVehicle.Handle
                    );

                if (pCanSee)
                {
                    returnVal = 1;
                }


            }

            return returnVal;
        }

        public float OverSpeedLimit(Vector2 pedPosition, float speed)
        {
            int speedLimit = 0;
            string street = World.GetStreetName(pedPosition).Replace(" ", String.Empty);

            switch (street)
            {
                case "JoshuaRd":
                case "EastJoshuaRoad":
                case "ElysianFieldsFwy":
                    speedLimit = 50;
                    break;
                case "MarinaDr":
                case "AlhambraDr":
                case "NilandAve":
                case "ZancudoAve":
                case "ArmadilloAve":
                case "AlgonquinBlvd":
                case "MountainViewDr":
                case "ChollaSpringsAve":
                case "LesbosLn":
                case "SeaviewRd":
                case "GrapeseedMainSt":
                case "GrapeseedAve":
                case "JoadLn":
                case "CatfishView":
                case "PaletoBlvd":
                case "DuluozAve":
                case "ProcopioDr":
                case "WestEclipseBlvd":
                case "NorthRockfordDr":
                case "SouthRockfordDr":
                case "BoulevardDelPerro":
                case "PalominoAve":
                case "CalaisAve":
                case "LittleBighornAve":
                case "RoyLowensteinBlvd":
                case "CarsonAve":
                case "AutopiaPkwy":
                case "ExceptionalistsWay":
                case "GreenwichPkwy":
                case "MiltonRd":
                case "KimbleHillDr":
                case "NormandyDr":
                case "HillcrestAve":
                case "HillcrestRidgeAccessRd":
                case "NorthSheldonAve":
                case "LakeVinewoodDr":
                case "LakeVinewoodEst":
                case "NorthConkerAve":
                case "WildOatsDr":
                case "WhispymoundDr":
                case "DidionDr":
                case "CoxWay":
                case "PicturePerfectDrive":
                case "SouthMoMiltonDr":
                case "CockingendDr":
                case "MadWayneThunderDr":
                case "HangmanAve":
                case "DunstableLn":
                case "DunstableDr":
                case "GreenwichWay":
                case "GreenwichPl":
                case "HardyWay":
                case "RichmanSt":
                case "AceJonesDr":
                case "SmokeTreeRd":
                case "ChollaRd":
                case "Cat-ClawAve":
                case "MacdonaldSt":
                case "VinewoodParkDr":
                case "MirrorParkBlvd":
                case "GloryWay":
                case "BridgeSt":
                case "WestMirrorDrive":
                case "NikolaAve":
                case "EastMirrorDr":
                case "MirrorPl":
                case "LaborPl":
                case "ElBurroBlvd":
                case "AbattoirAve":
                case "MutinyRd":
                case "SouthArsenalSt":
                case "ForumDr":
                case "MorningwoodBlvd":
                case "EclipseBlvd":
                case "HawickAve":
                case "OccupationAve":
                case "RockfordDr":
                case "AbeMiltonPkwy":
                case "AmarilloWay":
                case "TowerWay":
                case "DeckerSt":
                case "LowPowerSt":
                case "ClintonAve":
                case "FenwellPl":
                case "CavalryBlvd":
                case "SouthBoulevardDelPerro":
                case "EastGalileoAve":
                case "GalileoPark":
                case "WestGalileoAve":
                case "ZancudoRd":
                case "MovieStarWay":
                case "HeritageWay":
                case "LolitaAve":
                case "MeringueLn":
                    speedLimit = 35;
                    break;
                case "PanoramaDr":
                case "UnionRd":
                case "VespucciBlvd":
                case "SanAndreasAve":
                case "BayCityIncline":
                case "Adam'sAppleBlvd":
                case "AltaSt":
                case "StrawberryAve":
                case "InnocenceBlvd":
                case "DavisAve":
                case "DutchLondonSt":
                case "ChumSt":
                case "BanhamCanyonDr":
                case "BuenVinoRd":
                case "ZancudoGrandeValley":
                case "ZancudoBarranca":
                case "GalileoRd":
                case "MtVinewoodDr":
                case "MarloweDr":
                case "BaytreeCanyonRd":
                case "SenoraRd":
                case "SenoraWay":
                case "VinewoodBlvd":
                case "ElRanchoBlvd":
                case "PopularSt":
                case "DorsetDr":
                case "SanVitusBlvd":
                case "LasLagunasBlvd":
                case "PowerSt":
                case "MtHaanRd":
                case "ElginAve":
                case "CarcerWay":
                case "TongvaDr":
                    speedLimit = 40;
                    break;
                case "CalafiaRd":
                case "NorthCalafiaWay":
                case "CascabelAve":
                case "PyriteAve":
                case "BarbarenoRd":
                case "InesenoRoad":
                case "PlayaVista":
                case "BayCityAve":
                case "EqualityWay":
                case "RedDesertAve":
                case "SandcastleWay":
                case "ProsperitySt":
                case "MarathonAve":
                case "CougarAve":
                case "LibertySt":
                case "GingerSt":
                case "LindsayCircus":
                case "IntegrityWay":
                case "SwissSt":
                case "CapitalBlvd":
                case "CrusadeRd":
                case "JamestownSt":
                case "GroveSt":
                case "BrougeAve":
                case "CovenantAve":
                case "SignalSt":
                case "PlaicePl":
                case "ChupacabraSt":
                case "MiriamTurnerOverpass":
                case "NewEmpireWay":
                case "KortzDr":
                case "SouthShamblesSt":
                case "HangerWay":
                case "OrchardvilleAve":
                case "VoodooPlace":
                case "SpanishAve":
                case "PortolaDr":
                case "GentryLane":
                case "MeteorSt":
                case "AltaPl":
                case "EastbourneWay":
                case "LagunaPl":
                case "SinnersPassage":
                case "AtleeSt":
                case "SinnerSt":
                case "SupplySt":
                case "ChianskiPassage":
                case "StrangewaysDr":
                    speedLimit = 30;
                    break;
                case "CassidyTrail":
                case "O'NeilWay":
                case "ProcopioPromenade":
                case "FortZancudoApproachRd":
                case "MagellanAve":
                case "ConquistadorSt":
                case "CortesSt":
                case "VitusSt":
                case "AgujaSt":
                case "GomaSt":
                case "MelanomaSt":
                case "InventionCt":
                case "ImaginationCt":
                case "RubSt":
                case "TugSt":
                case "NowhereRd":
                case "ShankSt":
                case "NikolaPl":
                case "FudgeLn":
                case "AmarilloVista":
                case "CaesarsPlace":
                case "EdwoodWay":
                case "TackleSt":
                case "UtopiaGardens":
                case "AmericanoWay":
                case "SamAustinDr":
                case "PerthSt":
                    speedLimit = 25;
                    break;
                case "SenoraFwy":
                case "DelPerroFwy":
                case "LosSantosFreeway":
                    speedLimit = 65;
                    break;
                case "GreatOceanHwy":
                case "LaPuertaFwy":
                case "PalominoFwy":
                case "OlympicFwy":
                    speedLimit = 60;
                    break;
                case "Route68":
                case "Route68Approach":
                    speedLimit = 55;
                    break;
                case "SustanciaRd":
                case "BuccaneerWay":
                    speedLimit = 45;
                    break;
                default:
                    speedLimit = 999;
                    break;
            }

            return speed - speedLimit;

        }
    }
}


