using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileManager
{
    interface IBehavior
    {
        void search(string word);
        string getFileInfo(string path);
        void countWord();
        void countLetters();
    }
}
