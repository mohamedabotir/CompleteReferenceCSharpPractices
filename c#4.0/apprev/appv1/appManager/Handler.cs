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
        public int Lines { get; set; }
        private int countLetter { get; set; }
        public int Spaces { get; set; }
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
                if ((char)temp == ' ')
                    Spaces++;
                else if(temp == 0X0D) {
                    Lines++;
                    continue;
                }
                else
                countLetter ++;

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
        public string getLetterValue()
    {
        return "LetterNumbers:"+countLetter+" spacesNumber:"+Spaces+" Lines:"+Lines;
    }
    }
    
}
