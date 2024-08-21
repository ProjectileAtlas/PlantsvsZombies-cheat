using ImGuiNET;
using ClickableTransparentOverlay;
using Swed32;

namespace plantsTrainer
{
    public class Program : Overlay
    {
        bool unlimitedsuns = false;
        IntPtr moduleBase;
        int sunAddress = 0x1F636;
        Swed swed = new Swed("popcapgame1");

        protected override void Render()
        {
            ImGui.Begin("Plants hack");
            ImGui.Checkbox("Never lose suns", ref unlimitedsuns);
            ImGui.End();
        }
        public void hackLogic()        {
            moduleBase = swed.GetModuleBase(".exe");
          while (true)
            {
                if (unlimitedsuns)
                {
                    swed.WriteBytes(moduleBase, sunAddress, "90 90 90 90 90 90");
                }
                else
                {
                    swed.WriteBytes(moduleBase,sunAddress,"89 B7 78 55 00 00");

                }
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Start Hacking....");
            Program program = new Program();
            program.Start().Wait();
            Thread hackThread = new Thread(program.hackLogic) { IsBackground = true };
            hackThread.Start();

        }

        }
    }
