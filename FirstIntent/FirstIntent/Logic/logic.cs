using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FirstIntent.Logic
{
    class logic
    {
        public void startActivity()
        {
            String text_to_encrypt, encrypt_key;
            Console.WriteLine("Introduce el texto a cifrar");
            text_to_encrypt = Console.ReadLine();
            Console.WriteLine("Introduce la llave, debe ser entero");
            encrypt_key = Console.ReadLine();
            while (!ValidateInteger(encrypt_key))
            {
                Console.WriteLine("Por favor introduce una llave válida");
                encrypt_key = Console.ReadLine();
            }
            CesarsEncryptation(Convert.ToInt32(encrypt_key), text_to_encrypt);
        }
        public void CesarsEncryptation(int key, String text)
        {
            String encrypted_text = "";
            byte[] text_to_bytes = Encoding.ASCII.GetBytes(text);
            for(int i = 0; i < text_to_bytes.Length; i++)
            {
                int ascii_index = (Convert.ToInt32(text_to_bytes[i]) + key) % 255;
                if (ascii_index > 255)
                    ascii_index -= 255;
                text_to_bytes[i] = BitConverter.GetBytes(ascii_index )[0];
            }
            encrypted_text = Encoding.ASCII.GetString(text_to_bytes);
            Console.WriteLine(encrypted_text);
            CesarsDecryptation(key, encrypted_text);
        }
        public void CesarsDecryptation(int key, String text)
        {
            String desencrypted_text = "";
            byte[] text_to_bytes = Encoding.ASCII.GetBytes(text);
            for (int i = 0; i < text_to_bytes.Length; i++)
            {
                int ascii_index = (Convert.ToInt32(text_to_bytes[i]) - key) % 255;
                if (ascii_index < 0)
                    ascii_index += 255;
                text_to_bytes[i] = BitConverter.GetBytes(ascii_index)[0];
            }
            desencrypted_text = Encoding.ASCII.GetString(text_to_bytes);
            Console.WriteLine(desencrypted_text);
            Console.ReadLine();
        }
        /*public Boolean ValidateText(String text)
        {
            Regex rx = new Regex(@"^[a-zñüáéíóú ]+$", RegexOptions.IgnoreCase);
            if (rx.IsMatch(text))
                return true;
            return false;
        }*/
        public Boolean ValidateInteger(String number)
        {
            Regex rx = new Regex(@"^[0-9]+$", RegexOptions.Compiled);
            if (rx.IsMatch(number))
                return true;
            return false;
        }
    }
}
