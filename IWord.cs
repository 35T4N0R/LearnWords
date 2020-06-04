using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTProj
{
    public interface IWord
    {
        string content { get; set; }
        string lang { get; set; }
        public void AddTranslate(IWord word);
    }
}
