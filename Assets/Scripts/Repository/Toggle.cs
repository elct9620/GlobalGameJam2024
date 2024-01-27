using System.Collections.Generic;

namespace Repository
{
    public class Toggle
    {
       private readonly Dictionary<string, bool> _toggles = new Dictionary<string, bool>(); 
       
       public bool Get(string name)
       {
           if (!_toggles.ContainsKey(name))
           {
               return false;
           }
           
           return _toggles[name];
       }
       
       public void Set(string name, bool value)
       {
           _toggles[name] = value;
       }
    }
}