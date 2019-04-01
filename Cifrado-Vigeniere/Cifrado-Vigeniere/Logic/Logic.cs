using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrado_Vigeniere.Logic
{
    class Logic
    {
        private const int ascii_length = 256;
        char[,] matrix = new char[ascii_length, ascii_length];
        public void startActivity()
        {
            CreateMatrix();
            String text_to_encrypt, encrypt_key;
            Console.WriteLine("Introduce el texto a cifrar");
            text_to_encrypt = Console.ReadLine();

            Console.WriteLine("Introduce la llave para descifrar");
            encrypt_key = Console.ReadLine();

            Console.WriteLine(EncryptText(text_to_encrypt, encrypt_key));
            Console.ReadLine();
        }
        public void CreateMatrix()
        {   
            int i, k, c;
            for (i = 0; i < ascii_length; i++)
            {
                c=0;
                for(k = i; k < ascii_length; k++)
                {
                    matrix[i, c] = Convert.ToChar(k);
                    c++;
                }
                for( k = 0 ; k < i; k++)
                {
                    matrix[i, c] = Convert.ToChar(k);
                    c++;
                }
            }
        }
        public String EncryptText(String text, String key){
            int key_length = key.Length,
                text_length = text.Length,
                text_index = 0,
                key_index = 0;
            String encrypted_text = "";
            char [] key_array = key.ToCharArray(),
                    text_array = text.ToCharArray();
            for(int text_position = 0; text_position < text_length; text_position ++){
                for(int i = 0; i< key_length; i++){
                    text_index = Convert.ToInt32(BitConverter.GetBytes(text_array[text_position])[0]);
                    key_index = Convert.ToInt32(BitConverter.GetBytes(key_array[i])[0]);
                    Console.WriteLine(text_index+", "+key_index+"     "+ matrix[text_index, key_index]);
                    encrypted_text += matrix[text_index, key_index];
                    text_position ++;
                }
            }
            return encrypted_text;
        }
    }
}
