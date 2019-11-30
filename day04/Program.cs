using System;
using System.Security.Cryptography;
using System.Text;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "yzbqklnj";

            Part1(input);
        }   

        static void Part1(string input)
        {
            using (MD5 md5hash = MD5.Create())
            {
                var done = false;
                int n = 0;
                while (!done)
                {
                    n++;
                    string hash = GetMd5Hash(md5hash, string.Concat(input, n));
                    //System.Console.WriteLine(hash);
                    if (hash.StartsWith("00000")) {
                        done = true;
                        //System.Console.WriteLine(string.Concat(input, n));
                        //System.Console.WriteLine(hash);
                    }
                }
                System.Console.WriteLine($"Part 1: {n}");
                
            }
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
