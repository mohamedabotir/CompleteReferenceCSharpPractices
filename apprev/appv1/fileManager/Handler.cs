using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileManager
{
    class Handler : IBehavior
    {
        private int countLetter { get; set; }
        private int temp { get; set; }
        private string path { get; set; }
        FileStream file;
       public Handler(string path) {
            file = new FileStream(path,FileMode.Open,FileAccess.Read);
            countLetter = 0;
            temp = 0;
        }
        public void countLetters()
        {
            do
            {
                temp = file.ReadByte();
                if (temp == -1) break;
                countLetter += temp;

            } while (true);
        }

        public void countWord()
        {
            throw new NotImplementedException();
        }

        public string getFileInfo(string path)
        {
            throw new NotImplementedException();
        }

        public void search(string word)
        {
            throw new NotImplementedException();
        }
        public int getLetterValue()
    {
        return countLetter;
    }
    }
    
}
