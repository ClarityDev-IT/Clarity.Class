using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clarity.Email
{
    class Program
    {
        static void Main(string[] args)
        {
            Enviar();


        }

        public static void Enviar()
        {
            string[] ls_files = new string[2]; 

            ls_files[0] = @"c:\temp\update articoli.txt";
            ls_files[1] = @"c:\temp\estrazione.php";

            Email email = new Email();
            email.SendMail("lnsiqueira@gmail.com", "lnsiqueira@gmail.com", "smtp.gmail.com", 25, "coealphaville@gmail.com", "coealphaville19", "Subject", "Body", ls_files);

        }
    }
}
