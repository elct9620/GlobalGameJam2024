using NUnit.Framework;
using Command;
using ToggleRepository = Repository.Toggle;

namespace Tests.Command
{
    public class TestToggle
    {
        private Toggle _toggle;
        private ToggleRepository _toggleRepository;
        
        [SetUp] public void Setup()
        {
           _toggleRepository = new ToggleRepository();
           _toggle = new Toggle(_toggleRepository);
        }
        
        [Test] public void Test_IsLocked()
        {
            Assert.AreEqual(false, _toggle.IsLocked("Test"));
        }
        
        [Test] public void Test_Unlock()
        {
            _toggle.Unlock("Test");
            Assert.AreEqual(false, _toggle.IsLocked("Test"));
        }
    }
}