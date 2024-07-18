// 게임오버 추가 => curHP가 0이되면 end // GameOver(); 
// 상점 구현 // StoreScene
// 여관 구현 // InnScene
// 인벤토리 구현 
// 

using static TextRPG.Program;

namespace TextRPG
{
    internal class Program
    {
        enum Scene { Select, Confirm, Town, Forest, Swarm, Store, Inn }
        enum Job { Warrior = 1, Mage, Rogue }

        

        struct GameData
        {
            public bool running;
            public Scene scene;
            public string name;
            public Job job;
            public int curHP;
            public int maxHP;
            public int STR;
            public int INT;
            public int DEX;
            public int LUCK;
            public int gold;

            public List<string> Inventory;

        }
      
      
            
        

        static GameData data;

        static void Main(string[] args)
        {    
            Start();
          
            while (data.running)
            {
                Run();
            }

            End();
        }


        static void Start()
        {
            data = new GameData() { 
                
                running = true,
                Inventory = new List<string>()

            };
            

            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=           레전드 RPG             =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("    계속하려면 아무키나 누르세요    ");
            Console.ReadKey();
        }
     
        static void End()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=            게임 오버!            =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
            
        }
        static void GameOver() {
            if (data.curHP <= 0){ data.running = false; }
        }

        static void Run()
        {
            Console.Clear();

            switch (data.scene)
            {
                case Scene.Select:
                    SelectScene();
                    break;
                case Scene.Confirm:
                    ConfirmScene();
                    break;
                case Scene.Town:
                    TownScene();
                    break;
                case Scene.Forest:
                    ForestScene();
                    break;
                case Scene.Swarm:
                    SwarmScene();
                    break;
                case Scene.Store:
                    StoreScene();
                    break;
                case Scene.Inn:
                    InnScene();
                    break;
            }
        }

        static void PrintProfile()
        {
            Console.WriteLine("================================================");
            Console.WriteLine($"이름 : {data.name, -6} 직업 : {data.job, -6}");
            Console.WriteLine($"체력 : {data.curHP, +3} / {data.maxHP}");
            Console.WriteLine($"힘 : {data.STR,-3} 지력 : {data.INT,-3} 민첩 : {data.DEX,-3} 행운 : {data.LUCK,-3}");
            Console.WriteLine($"소지금 : {data.gold, +5} G");
            Console.WriteLine("==================보유 아이템===================");
            Console.WriteLine("");
            Console.WriteLine("");

            foreach (var item in data.Inventory)
            {
                Console.WriteLine($"- {item}");
            }

            Console.WriteLine("");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }
        // +5 ... 문자열 간격 조정 

        static void Wait(float seconds)
        {
            Thread.Sleep((int)(seconds * 500));
        }

        static void SelectScene()
        {
            Console.Write("캐릭터의 이름을 입력하세요 : ");
            data.name = Console.ReadLine();
            if (data.name == "")
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 도적");
            if (int.TryParse(Console.ReadLine(), out int select) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }
            else if (Enum.IsDefined(typeof(Job), select) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            switch ((Job)select)
            {
                case Job.Warrior:
                    data.job = Job.Warrior;
                    data.maxHP = 200;
                    data.curHP = data.maxHP;
                    data.STR = 16;
                    data.INT = 8;
                    data.DEX = 12;
                    data.LUCK = 0;
                    data.gold = 200;
                    break;
                case Job.Mage:
                    data.job = Job.Mage;
                    data.maxHP = 80;
                    data.curHP = data.maxHP;
                    data.STR = 6;
                    data.INT = 20;
                    data.DEX = 8;
                    data.LUCK = 0;
                    data.gold = 300;
                    break;
                case Job.Rogue:
                    data.job = Job.Rogue;
                    data.maxHP = 120;
                    data.curHP = data.maxHP;
                    data.STR = 10;
                    data.INT = 10;
                    data.DEX = 16;
                    data.LUCK = 1;
                    data.gold = 350;
                    break;
            }
            data.scene = Scene.Confirm;
        }

        static void ConfirmScene()
        {
            // Render
            Console.WriteLine("===================");
            Console.WriteLine($"이름 : {data.name}");
            Console.WriteLine($"직업 : {data.job}");
            Console.WriteLine($"체력 : {data.maxHP}");
            Console.WriteLine($"힘   : {data.STR}");
            Console.WriteLine($"지력 : {data.INT}");
            Console.WriteLine($"민첩 : {data.DEX}");
            Console.WriteLine($"행운 : {data.LUCK}");
            Console.WriteLine($"소지금 : {data.gold}");
            Console.WriteLine("===================");
            Console.WriteLine();
            Console.Write("이대로 플레이 하시겠습니까?(y/n)");

            // Input
            string input = Console.ReadLine();

            // Update
            switch (input)
            {
                case "Y":
                case "y":
                    Console.Clear();
                    Console.WriteLine("마을로 이동합니다...");
                    Wait(2);
                    data.scene = Scene.Town;
                    break;
                case "N":
                case "n":
                    data.scene = Scene.Select;
                    break;
                default:
                    data.scene = Scene.Confirm;
                    break;
            }
        }

        static void TownScene()
        {
            // Render
            PrintProfile();
            Console.WriteLine("따뜻한 마을이다. 사람들이 많다.");
            Console.WriteLine("어디로 이동하겠습니까?");
            Console.WriteLine("1. 여관");
            Console.WriteLine("2. 상점");
            Console.WriteLine("3. 마을 밖 숲");
            Console.WriteLine("4. 마을 뒤 늪");
            Console.Write("선택 : ");

            // Input
            string input = Console.ReadLine();

            // Update
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("여관으로 이동합니다...");
                    
                    Wait(2);
                    data.scene = Scene.Inn;
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("상점으로 이동합니다...");
                    
                    Wait(2);
                    data.scene = Scene.Store;
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("마을 밖 숲으로 이동합니다...");
                    Wait(2);
                    data.scene = Scene.Forest;
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("마을 뒤 늪으로 이동합니다.");
                    Wait(2);
                    data.scene = Scene.Swarm;
                    break;
            }
        }

        static void ForestScene()
        {
            Console.WriteLine("적막한 숲입니다.");
            Wait(1);
            Console.WriteLine("갑작스럽게 당신 앞에 슬라임이 나타났습니다.");
            Wait(1);
            Console.WriteLine();
            Console.WriteLine("당신의 행동을 선택해주세요");
            Console.WriteLine("1. 슬라임을 공격한다.(힘)");
            Console.WriteLine("2. 슬라임을 주시하며 공격마법을 시전한다.(지력)");
            Console.WriteLine("3. 슬라임이 눈치채지 못하게 뒤로 접근하여 공격한다.(민첩)");
            Console.Write("선택 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (data.STR > 14)
                    {
                        Console.WriteLine("당신의 공격은 슬라임에게 치명적이었습니다!");
                        Wait(1);
                        Console.WriteLine("슬라임이 쓰러졌습니다!");
                        Wait(1);
                        Console.WriteLine("100 골드를 얻었습니다!");
                        Wait(1);
                        data.gold += 100;
                    }
                    else
                    {
                        Console.WriteLine("당신의 공격은 슬라임에게 무의미 했습니다!");
                        Wait(1);
                        Console.WriteLine("슬라임이 반격했습니다!");
                        Wait(1);
                        Console.WriteLine("30의 체력 피해를 받았습니다!");
                        Wait(1);
                        data.curHP -= 30;
                    }
                    break;
                case "2":
                    if (data.INT > 12)
                    {
                        Console.WriteLine("당신의 마법은 슬라임에게 치명적이었습니다!");
                        Wait(1);
                        Console.WriteLine("슬라임이 쓰러졌습니다!");
                        Wait(1);
                        Console.WriteLine("100 골드를 얻었습니다!");
                        Wait(1);
                        data.gold += 100;
                        Console.WriteLine("마법을 사용하여 체력 5 소모되었습니다.");
                        data.curHP -= 5;
                    }
                    else
                    {
                        Console.WriteLine("당신의 공격은 슬라임에게 무의미 했습니다!");
                        Wait(1);
                        Console.WriteLine("슬라임이 반격했습니다!");
                        Wait(1);
                        Console.WriteLine("30의 체력 피해를 받았습니다!");
                        Wait(1);
                        data.curHP -= 30;
                    }
                    break;
                case "3":
                    Console.WriteLine("당신은 슬라임의 뒤로 재빠르게 접근했습니다!");
                    Wait(1);
                    Console.WriteLine("하지만 슬라임은 앞뒤 구분이 되지 않았습니다.");
                    Wait(1);
                    Console.WriteLine("슬라임이 반격했습니다!");
                    Wait(1);
                    Console.WriteLine("30의 체력 피해를 받았습니다!");
                    Wait(1);
                    data.curHP -= 30;
                   // Console.WriteLine($"당신의 현재 체력은 {data.curHP}입니다.");
                    Wait(1);
                    break;
                default:
                    break;
            }
            GameOver();
            Console.Clear();
            Console.WriteLine("마을로 돌아갑니다...");
            Wait(2);
            data.scene = Scene.Town;
        }

        static void SwarmScene()
        {
            Console.WriteLine("축축한 냄새가 나는 지역입니다.");
            if (data.DEX <= 12)
            {
                Wait(1);
                Console.WriteLine("늪이 당신을 잡아당기며 몸이 지치는 것이 느껴집니다.");
                Wait(1);
                Console.WriteLine("체력이 10 감소했습니다.");
                data.curHP -= 10;
            }

            Wait(2);
            Console.WriteLine("늪을 건너는 중 이상하게 생긴 식물을 발견했습니다.");

            if (data.INT >= 12)
            {
                Wait(1);
                Console.WriteLine("당신은 식물이 약초라는 것을 알았습니다.");
                Wait(1);
                Console.WriteLine("약초를 습득했습니다!");
                data.Inventory.Add("신비한 약초");
                // inventory add
            }
            else
            {
                Wait(1);
                Console.WriteLine("당신은 식물에 대한 지식이 없습니다.");
                Wait(1);
                Console.WriteLine("지나쳐 버렸습니다...");
            }

            Wait(1);
            GameOver();
            Console.WriteLine("늪지를 지나 다시 마을로 돌아갑니다...");

            data.scene = Scene.Town;
        }

        static void StoreScene() {
            Console.WriteLine("아늑한 느낌의 오래된 상점입니다.");
            Wait(1);
            Console.WriteLine("무엇을 살건가?");
            Wait(1);
            Console.WriteLine();
            Console.WriteLine("구매할 아이템을 골라주세요.");
            Console.WriteLine("1.B.F 소드 : 힘+5  200g");
            Console.WriteLine("2.쓸데없이 커다란 지팡이: 지력+5   300g");
            Console.WriteLine("3.열정의 검:민첩,행운 + 2   250g");
            Console.WriteLine("4.행운의 동전: 행운 + 3  100g");
            Console.WriteLine("5.살게없네요..");
            Console.Write("선택 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (data.gold >= 200)
                    {
                        Console.WriteLine("이 칼은 꽤 쓸만하지!");
                        Wait(1);
                        Console.WriteLine("가져가게나.");
                        Wait(1);
                        Console.WriteLine("!!구매 성공!!");
                        Wait(1);
                        data.gold -= 200;
                        data.STR += 5;
                        data.Inventory.Add("B.F 소드");



                    }
                    else
                    {
                        Console.WriteLine("돈이 부족하다네...");
                        Wait(1);
                        Console.WriteLine("다음에 오게나...");
                        Wait(1);
                    }
                    break;
                case "2":
                    if (data.gold >= 300)
                    {
                        Console.WriteLine("이 지팡이는 꽤 쓸만하지!");
                        Wait(1);
                        Console.WriteLine("가져가게나.");
                        Wait(1);
                        Console.WriteLine("!!구매 성공!!");
                        Wait(1);
                        data.gold -= 300;
                        data.INT += 5;
                        data.Inventory.Add("쓸데없이 커다란 지팡이");


                    }
                    else
                    {
                        Console.WriteLine("돈이 부족하다네...");
                        Wait(1);
                        Console.WriteLine("다음에 오게나...");
                        Wait(1);
                    }
                    break;
                case "3":
                    if (data.gold >= 250)
                    {
                        Console.WriteLine("이 칼은 아주 날카롭다네!");
                        Wait(1);
                        Console.WriteLine("가져가게나.");
                        Wait(1);
                        Console.WriteLine("!!구매 성공!!");
                        Wait(1);
                        data.gold -= 250;
                        data.DEX += 2;
                        data.LUCK += 2;
                        data.Inventory.Add("열정의 검");




                    }
                    else
                    {
                        Console.WriteLine("돈이 부족하다네...");
                        Wait(1);
                        Console.WriteLine("다음에 오게나...");
                        Wait(1);
                    }
                    break;
                case "4":
                    if (data.gold >= 100)
                    {
                        Console.WriteLine("행운의 동전일세!");
                        Wait(1);
                        Console.WriteLine("당신의 여행에 행운이 가득하길....");
                        Wait(1);
                        Console.WriteLine("!!구매 성공!!");
                        Wait(1);
                        data.gold -= 100;
                        data.LUCK += 3;
                        data.Inventory.Add("행운의 동전");


                    }
                    else
                    {
                        Console.WriteLine("돈이 부족하다네...");
                        Wait(1);
                        Console.WriteLine("다음에 오게나...");
                        Wait(1);
                    }
                    break;
                case "5":
                    Console.WriteLine("다음에 올게요~");

                    break;
            

                default:
                    break;
            }
            Console.Clear();
            Console.WriteLine("마을로 돌아갑니다...");
            Wait(2);
            data.scene = Scene.Town;

        }

        static void InnScene()
        {
            Wait(1);
            Console.WriteLine("마음이 따뜻해지는 여관입니다.");
            Console.WriteLine("1.하루 쉬고가기 50g");
            Console.WriteLine("2.나가기");
            Console.Write("선택 : ");

            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    if(data.gold >= 50)
                    {
                        Console.WriteLine("당신은 푹신한 침대에 누워 잠이 들었다...");
                        Wait(1);
                        Console.WriteLine("체력이 전부 회복되었다!!");
                        data.curHP = data.maxHP;
                    }
                    else
                        Console.WriteLine("돈이 부족해....");
                    break;

            }
            Wait(1);
            Console.WriteLine("여관을 떠나 다시 마을로 돌아갑니다...");

            data.scene = Scene.Town;
        }
    }
}
