using System.ComponentModel;

namespace Entity
{
    public enum PuzzleType
    {
       None,
       [Description("Boot Program")]
       BootProgram,
       [Description("Make Progress Advance")]
       LoadingScreen,
       [Description("Defeat the Boss")]
       GameScreen,
    }
}