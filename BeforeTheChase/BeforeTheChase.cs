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
            Vector3 plrPos3 = player.Character.Position;
            Vector2 plrPos2 = new Vector2(plrPos3.X, plrPos3.Y);

            float plrMph = player.Character.CurrentVehicle.Speed * (float)2.237;

            float speedingBy = OverSpeedLimit(plrPos2, plrMph);

            if (player.WantedLevel == 0 && player.Character.IsInVehicle() && speedingBy > 10)
            {
                Ped[] loadedPeds = World.GetAllPeds();
                int numPeds = loadedPeds.Length;
                Ped plrPed = player.Character;

                foreach (Ped p in loadedPeds)
                {
                    Yield();

                    int pType = Function.Call<int>(Hash.GET_PED_TYPE, p.Handle);
                    bool pCanSee = Function.Call<bool>
                        (
                        Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY,
                        p.Handle,
                        plrPed.CurrentVehicle.Handle
                        );


                    if (pCanSee)
                    {
                        Random rand = new Random();
                        double randNum = rand.NextDouble();

                        bool inFront = Function.Call<bool>
                       (
                       Hash.HAS_ENTITY_CLEAR_LOS_TO_ENTITY_IN_FRONT,
                       p.Handle,
                       plrPed.CurrentVehicle.Handle
                       );

                        if (inFront)
                        {
                            randNum = randNum / 2;
                        }

                        if (randNum / speedingBy < .0001)
                        {
                            UI.Notify("Reported going " + speedingBy + " over the speed limit");
                            player.WantedLevel = 1;
                        }


                        break;

                    }
                }
            }

        }

        public float OverSpeedLimit(Vector2 pedPosition, float speed)
        {
            int speedlimit = 0;
            string street = World.GetStreetName(pedPosition).Replace(" ", String.Empty);

            if (street == "JoshuaRd")
            {
                speedlimit = 50;
            }
            else if (street == "EastJoshuaRoad")
            {
                speedlimit = 50;
            }
            else if (street == "MarinaDr")
            {
                speedlimit = 35;
            }
            else if (street == "AlhambraDr")
            {
                speedlimit = 35;
            }
            else if (street == "NilandAve")
            {
                speedlimit = 35;
            }
            else if (street == "ZancudoAve")
            {
                speedlimit = 35;
            }
            else if (street == "ArmadilloAve")
            {
                speedlimit = 35;
            }
            else if (street == "AlgonquinBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "MountainViewDr")
            {
                speedlimit = 35;
            }
            else if (street == "ChollaSpringsAve")
            {
                speedlimit = 35;
            }
            else if (street == "PanoramaDr")
            {
                speedlimit = 40;
            }
            else if (street == "LesbosLn")
            {
                speedlimit = 35;
            }
            else if (street == "CalafiaRd")
            {
                speedlimit = 30;
            }
            else if (street == "NorthCalafiaWay")
            {
                speedlimit = 30;
            }
            else if (street == "CassidyTrail")
            {
                speedlimit = 25;
            }
            else if (street == "SeaviewRd")
            {
                speedlimit = 35;
            }
            else if (street == "GrapeseedMainSt")
            {
                speedlimit = 35;
            }
            else if (street == "GrapeseedAve")
            {
                speedlimit = 35;
            }
            else if (street == "JoadLn")
            {
                speedlimit = 35;
            }
            else if (street == "UnionRd")
            {
                speedlimit = 40;
            }
            else if (street == "O'NeilWay")
            {
                speedlimit = 25;
            }
            else if (street == "SenoraFwy")
            {
                speedlimit = 65;
            }
            else if (street == "CatfishView")
            {
                speedlimit = 35;
            }
            else if (street == "GreatOceanHwy")
            {
                speedlimit = 60;
            }
            else if (street == "PaletoBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "DuluozAve")
            {
                speedlimit = 35;
            }
            else if (street == "ProcopioDr")
            {
                speedlimit = 35;
            }
            else if (street == "CascabelAve")
            {
                speedlimit = 30;
            }
            else if (street == "ProcopioPromenade")
            {
                speedlimit = 25;
            }
            else if (street == "PyriteAve")
            {
                speedlimit = 30;
            }
            else if (street == "FortZancudoApproachRd")
            {
                speedlimit = 25;
            }
            else if (street == "BarbarenoRd")
            {
                speedlimit = 30;
            }
            else if (street == "InesenoRoad")
            {
                speedlimit = 30;
            }
            else if (street == "WestEclipseBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "PlayaVista")
            {
                speedlimit = 30;
            }
            else if (street == "BayCityAve")
            {
                speedlimit = 30;
            }
            else if (street == "DelPerroFwy")
            {
                speedlimit = 65;
            }
            else if (street == "EqualityWay")
            {
                speedlimit = 30;
            }
            else if (street == "RedDesertAve")
            {
                speedlimit = 30;
            }
            else if (street == "MagellanAve")
            {
                speedlimit = 25;
            }
            else if (street == "SandcastleWay")
            {
                speedlimit = 30;
            }
            else if (street == "VespucciBlvd")
            {
                speedlimit = 40;
            }
            else if (street == "ProsperitySt")
            {
                speedlimit = 30;
            }
            else if (street == "SanAndreasAve")
            {
                speedlimit = 40;
            }
            else if (street == "NorthRockfordDr")
            {
                speedlimit = 35;
            }
            else if (street == "SouthRockfordDr")
            {
                speedlimit = 35;
            }
            else if (street == "MarathonAve")
            {
                speedlimit = 30;
            }
            else if (street == "BoulevardDelPerro")
            {
                speedlimit = 35;
            }
            else if (street == "CougarAve")
            {
                speedlimit = 30;
            }
            else if (street == "LibertySt")
            {
                speedlimit = 30;
            }
            else if (street == "BayCityIncline")
            {
                speedlimit = 40;
            }
            else if (street == "ConquistadorSt")
            {
                speedlimit = 25;
            }
            else if (street == "CortesSt")
            {
                speedlimit = 25;
            }
            else if (street == "VitusSt")
            {
                speedlimit = 25;
            }
            else if (street == "AgujaSt")
            {
                speedlimit = 25;
            }
            else if (street == "GomaSt")
            {
                speedlimit = 25;
            }
            else if (street == "MelanomaSt")
            {
                speedlimit = 25;
            }
            else if (street == "PalominoAve")
            {
                speedlimit = 35;
            }
            else if (street == "InventionCt")
            {
                speedlimit = 25;
            }
            else if (street == "ImaginationCt")
            {
                speedlimit = 25;
            }
            else if (street == "RubSt")
            {
                speedlimit = 25;
            }
            else if (street == "TugSt")
            {
                speedlimit = 25;
            }
            else if (street == "GingerSt")
            {
                speedlimit = 30;
            }
            else if (street == "LindsayCircus")
            {
                speedlimit = 30;
            }
            else if (street == "CalaisAve")
            {
                speedlimit = 35;
            }
            else if (street == "Adam'sAppleBlvd")
            {
                speedlimit = 40;
            }
            else if (street == "AltaSt")
            {
                speedlimit = 40;
            }
            else if (street == "IntegrityWay")
            {
                speedlimit = 30;
            }
            else if (street == "SwissSt")
            {
                speedlimit = 30;
            }
            else if (street == "StrawberryAve")
            {
                speedlimit = 40;
            }
            else if (street == "CapitalBlvd")
            {
                speedlimit = 30;
            }
            else if (street == "CrusadeRd")
            {
                speedlimit = 30;
            }
            else if (street == "InnocenceBlvd")
            {
                speedlimit = 40;
            }
            else if (street == "DavisAve")
            {
                speedlimit = 40;
            }
            else if (street == "LittleBighornAve")
            {
                speedlimit = 35;
            }
            else if (street == "RoyLowensteinBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "JamestownSt")
            {
                speedlimit = 30;
            }
            else if (street == "CarsonAve")
            {
                speedlimit = 35;
            }
            else if (street == "GroveSt")
            {
                speedlimit = 30;
            }
            else if (street == "BrougeAve")
            {
                speedlimit = 30;
            }
            else if (street == "CovenantAve")
            {
                speedlimit = 30;
            }
            else if (street == "DutchLondonSt")
            {
                speedlimit = 40;
            }
            else if (street == "SignalSt")
            {
                speedlimit = 30;
            }
            else if (street == "ElysianFieldsFwy")
            {
                speedlimit = 50;
            }
            else if (street == "PlaicePl")
            {
                speedlimit = 30;
            }
            else if (street == "ChumSt")
            {
                speedlimit = 40;
            }
            else if (street == "ChupacabraSt")
            {
                speedlimit = 30;
            }
            else if (street == "MiriamTurnerOverpass")
            {
                speedlimit = 30;
            }
            else if (street == "AutopiaPkwy")
            {
                speedlimit = 35;
            }
            else if (street == "ExceptionalistsWay")
            {
                speedlimit = 35;
            }
            else if (street == "LaPuertaFwy")
            {
                speedlimit = 60;
            }
            else if (street == "NewEmpireWay")
            {
                speedlimit = 30;
            }
            else if (street == "GreenwichPkwy")
            {
                speedlimit = 35;
            }
            else if (street == "KortzDr")
            {
                speedlimit = 30;
            }
            else if (street == "BanhamCanyonDr")
            {
                speedlimit = 40;
            }
            else if (street == "BuenVinoRd")
            {
                speedlimit = 40;
            }
            else if (street == "Route68")
            {
                speedlimit = 55;
            }
            else if (street == "ZancudoGrandeValley")
            {
                speedlimit = 40;
            }
            else if (street == "ZancudoBarranca")
            {
                speedlimit = 40;
            }
            else if (street == "GalileoRd")
            {
                speedlimit = 40;
            }
            else if (street == "MtVinewoodDr")
            {
                speedlimit = 40;
            }
            else if (street == "MarloweDr")
            {
                speedlimit = 40;
            }
            else if (street == "MiltonRd")
            {
                speedlimit = 35;
            }
            else if (street == "KimbleHillDr")
            {
                speedlimit = 35;
            }
            else if (street == "NormandyDr")
            {
                speedlimit = 35;
            }
            else if (street == "HillcrestAve")
            {
                speedlimit = 35;
            }
            else if (street == "HillcrestRidgeAccessRd")
            {
                speedlimit = 35;
            }
            else if (street == "NorthSheldonAve")
            {
                speedlimit = 35;
            }
            else if (street == "LakeVinewoodDr")
            {
                speedlimit = 35;
            }
            else if (street == "LakeVinewoodEst")
            {
                speedlimit = 35;
            }
            else if (street == "BaytreeCanyonRd")
            {
                speedlimit = 40;
            }
            else if (street == "NorthConkerAve")
            {
                speedlimit = 35;
            }
            else if (street == "WildOatsDr")
            {
                speedlimit = 35;
            }
            else if (street == "WhispymoundDr")
            {
                speedlimit = 35;
            }
            else if (street == "DidionDr")
            {
                speedlimit = 35;
            }
            else if (street == "CoxWay")
            {
                speedlimit = 35;
            }
            else if (street == "PicturePerfectDrive")
            {
                speedlimit = 35;
            }
            else if (street == "SouthMoMiltonDr")
            {
                speedlimit = 35;
            }
            else if (street == "CockingendDr")
            {
                speedlimit = 35;
            }
            else if (street == "MadWayneThunderDr")
            {
                speedlimit = 35;
            }
            else if (street == "HangmanAve")
            {
                speedlimit = 35;
            }
            else if (street == "DunstableLn")
            {
                speedlimit = 35;
            }
            else if (street == "DunstableDr")
            {
                speedlimit = 35;
            }
            else if (street == "GreenwichWay")
            {
                speedlimit = 35;
            }
            else if (street == "GreenwichPl")
            {
                speedlimit = 35;
            }
            else if (street == "HardyWay")
            {
                speedlimit = 35;
            }
            else if (street == "RichmanSt")
            {
                speedlimit = 35;
            }
            else if (street == "AceJonesDr")
            {
                speedlimit = 35;
            }
            else if (street == "LosSantosFreeway")
            {
                speedlimit = 65;
            }
            else if (street == "SenoraRd")
            {
                speedlimit = 40;
            }
            else if (street == "NowhereRd")
            {
                speedlimit = 25;
            }
            else if (street == "SmokeTreeRd")
            {
                speedlimit = 35;
            }
            else if (street == "ChollaRd")
            {
                speedlimit = 35;
            }
            else if (street == "Cat-ClawAve")
            {
                speedlimit = 35;
            }
            else if (street == "SenoraWay")
            {
                speedlimit = 40;
            }
            else if (street == "PalominoFwy")
            {
                speedlimit = 60;
            }
            else if (street == "ShankSt")
            {
                speedlimit = 25;
            }
            else if (street == "MacdonaldSt")
            {
                speedlimit = 35;
            }
            else if (street == "Route68Approach")
            {
                speedlimit = 55;
            }
            else if (street == "VinewoodParkDr")
            {
                speedlimit = 35;
            }
            else if (street == "VinewoodBlvd")
            {
                speedlimit = 40;
            }
            else if (street == "MirrorParkBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "GloryWay")
            {
                speedlimit = 35;
            }
            else if (street == "BridgeSt")
            {
                speedlimit = 35;
            }
            else if (street == "WestMirrorDrive")
            {
                speedlimit = 35;
            }
            else if (street == "NikolaAve")
            {
                speedlimit = 35;
            }
            else if (street == "EastMirrorDr")
            {
                speedlimit = 35;
            }
            else if (street == "NikolaPl")
            {
                speedlimit = 25;
            }
            else if (street == "MirrorPl")
            {
                speedlimit = 35;
            }
            else if (street == "ElRanchoBlvd")
            {
                speedlimit = 40;
            }
            else if (street == "OlympicFwy")
            {
                speedlimit = 60;
            }
            else if (street == "FudgeLn")
            {
                speedlimit = 25;
            }
            else if (street == "AmarilloVista")
            {
                speedlimit = 25;
            }
            else if (street == "LaborPl")
            {
                speedlimit = 35;
            }
            else if (street == "ElBurroBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "SustanciaRd")
            {
                speedlimit = 45;
            }
            else if (street == "SouthShamblesSt")
            {
                speedlimit = 30;
            }
            else if (street == "HangerWay")
            {
                speedlimit = 30;
            }
            else if (street == "OrchardvilleAve")
            {
                speedlimit = 30;
            }
            else if (street == "PopularSt")
            {
                speedlimit = 40;
            }
            else if (street == "BuccaneerWay")
            {
                speedlimit = 45;
            }
            else if (street == "AbattoirAve")
            {
                speedlimit = 35;
            }
            else if (street == "VoodooPlace")
            {
                speedlimit = 30;
            }
            else if (street == "MutinyRd")
            {
                speedlimit = 35;
            }
            else if (street == "SouthArsenalSt")
            {
                speedlimit = 35;
            }
            else if (street == "ForumDr")
            {
                speedlimit = 35;
            }
            else if (street == "MorningwoodBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "DorsetDr")
            {
                speedlimit = 40;
            }
            else if (street == "CaesarsPlace")
            {
                speedlimit = 25;
            }
            else if (street == "SpanishAve")
            {
                speedlimit = 30;
            }
            else if (street == "PortolaDr")
            {
                speedlimit = 30;
            }
            else if (street == "EdwoodWay")
            {
                speedlimit = 25;
            }
            else if (street == "SanVitusBlvd")
            {
                speedlimit = 40;
            }
            else if (street == "EclipseBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "GentryLane")
            {
                speedlimit = 30;
            }
            else if (street == "LasLagunasBlvd")
            {
                speedlimit = 40;
            }
            else if (street == "PowerSt")
            {
                speedlimit = 40;
            }
            else if (street == "MtHaanRd")
            {
                speedlimit = 40;
            }
            else if (street == "ElginAve")
            {
                speedlimit = 40;
            }
            else if (street == "HawickAve")
            {
                speedlimit = 35;
            }
            else if (street == "MeteorSt")
            {
                speedlimit = 30;
            }
            else if (street == "AltaPl")
            {
                speedlimit = 30;
            }
            else if (street == "OccupationAve")
            {
                speedlimit = 35;
            }
            else if (street == "CarcerWay")
            {
                speedlimit = 40;
            }
            else if (street == "EastbourneWay")
            {
                speedlimit = 30;
            }
            else if (street == "RockfordDr")
            {
                speedlimit = 35;
            }
            else if (street == "AbeMiltonPkwy")
            {
                speedlimit = 35;
            }
            else if (street == "LagunaPl")
            {
                speedlimit = 30;
            }
            else if (street == "SinnersPassage")
            {
                speedlimit = 30;
            }
            else if (street == "AtleeSt")
            {
                speedlimit = 30;
            }
            else if (street == "SinnerSt")
            {
                speedlimit = 30;
            }
            else if (street == "SupplySt")
            {
                speedlimit = 30;
            }
            else if (street == "AmarilloWay")
            {
                speedlimit = 35;
            }
            else if (street == "TowerWay")
            {
                speedlimit = 35;
            }
            else if (street == "DeckerSt")
            {
                speedlimit = 35;
            }
            else if (street == "TackleSt")
            {
                speedlimit = 25;
            }
            else if (street == "LowPowerSt")
            {
                speedlimit = 35;
            }
            else if (street == "ClintonAve")
            {
                speedlimit = 35;
            }
            else if (street == "FenwellPl")
            {
                speedlimit = 35;
            }
            else if (street == "UtopiaGardens")
            {
                speedlimit = 25;
            }
            else if (street == "CavalryBlvd")
            {
                speedlimit = 35;
            }
            else if (street == "SouthBoulevardDelPerro")
            {
                speedlimit = 35;
            }
            else if (street == "AmericanoWay")
            {
                speedlimit = 25;
            }
            else if (street == "SamAustinDr")
            {
                speedlimit = 25;
            }
            else if (street == "EastGalileoAve")
            {
                speedlimit = 35;
            }
            else if (street == "GalileoPark")
            {
                speedlimit = 35;
            }
            else if (street == "WestGalileoAve")
            {
                speedlimit = 35;
            }
            else if (street == "TongvaDr")
            {
                speedlimit = 40;
            }
            else if (street == "ZancudoRd")
            {
                speedlimit = 35;
            }
            else if (street == "MovieStarWay")
            {
                speedlimit = 35;
            }
            else if (street == "HeritageWay")
            {
                speedlimit = 35;
            }
            else if (street == "PerthSt")
            {
                speedlimit = 25;
            }
            else if (street == "ChianskiPassage")
            {
                speedlimit = 30;
            }
            else if (street == "LolitaAve")
            {
                speedlimit = 35;
            }
            else if (street == "MeringueLn")
            {
                speedlimit = 35;
            }
            else if (street == "StrangewaysDr")
            {
                speedlimit = 30;
            }

            return speed - speedlimit;
        }
    }


}
