namespace Command
{
    public class Toggle
    {
        private Repository.Toggle _toggle;
        
        public Toggle(Repository.Toggle toggle)
        {
            _toggle = toggle;
        }
        
        public bool IsLocked(string name)
        {
            return _toggle.Get(name);
        }
        
        public void Unlock(string name)
        {
            _toggle.Set(name, false);
        }
    }
}