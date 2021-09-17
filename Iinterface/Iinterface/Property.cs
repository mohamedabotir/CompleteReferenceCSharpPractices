using System;
using System.Collections.Generic;
using System.Text;

namespace Iinterface
{
    interface IData { 
    string value {

            set { }
        }
        string display {

            get { return ""; }
 }

    }
    class Property:IData
    {
        string informations;
       public string value {
            set {
                informations = value;
            }
        }


       public string display {
            get { return informations; }
                
        }

    }
}
