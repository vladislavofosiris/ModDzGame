using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDZGame1
{
    class Program
    {
        static List<string> log = new List<string>();
        static void Main(string[] args)
        {         
            Player player = new Player(100, 100, 100, 50);
            player.CharacteristicChanged += WriteLog;
            var DictOfType = new Dictionary<ArtifactTypesEnum, int>
            {
                [ArtifactTypesEnum.AmulOfPwr] = 2,
                [ArtifactTypesEnum.FunfWthHlth] = 3,
                [ArtifactTypesEnum.FunfWthMn] = 4
            };

            player.Bag.Add(new FunfWthMn(player, "zzz", DictOfType.First(x => x.Key == ArtifactTypesEnum.FunfWthMn), 3));
            player.Bag.Add(new FunfWthHlt(player, "aaa", DictOfType.First(x => x.Key == ArtifactTypesEnum.FunfWthHlth), 5));
            player.Bag.Add(new AmulOfPwr(player, "qqq", DictOfType.First(x => x.Key == ArtifactTypesEnum.FunfWthMn), 4));

            StartGame(player).Wait();

            log.ForEach(x => Console.WriteLine(x));

            if (winner)
                Console.WriteLine("Winner");
            else
                Console.WriteLine("Loser");

            Console.WriteLine("Health points: " + player.Health);
            Console.WriteLine("Power points: " + player.Power);
            Console.WriteLine("Mn points: " + player.Mn);



            Console.ReadKey();
        }
        static public void WriteLog(object source, CharactericticEventArgs args)
        {
            log.Add(args.Message);
        }
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static CancellationToken token = cancelTokenSource.Token;
        static bool winner = true;
        static int quaOfDamage = 99;
        static int curAtmpGettingDamage = 0;
        static int damagePerIteration = 5;
       
        static async Task StartGame(Player player)
        {

           await MakeDamage(player);
            await UseArtifact(player);

        }

        static async Task MakeDamage(Player player)
        {

            while (quaOfDamage >= curAtmpGettingDamage)
            {

                if (player.Health <= 0
                    || player.Power <= 0
                    || player.Mn <= 0)
                {
                    cancelTokenSource.Cancel();
                }
                if (token.IsCancellationRequested)
                {
                    winner = false;
                    return;
                }

                player.Step(damagePerIteration);
                curAtmpGettingDamage++;

                await Task.Delay(100);
            }

        }

        static async Task UseArtifact(Player player)
        {
            while (quaOfDamage >= curAtmpGettingDamage)
            {

                if (player.Health <= 0 || player.Power <= 0 || player.Mn <= 0)
                {
                    cancelTokenSource.Cancel();
                }
                if (token.IsCancellationRequested)
                {
                    winner = false;
                    return;
                }

                int rndArtifact = new Random().Next(0, player.Bag.Count());
                //Console.WriteLine(rndArtifact);
                player.Bag[rndArtifact].Use();


                await Task.Delay(100);
            }
        }
    }
}




