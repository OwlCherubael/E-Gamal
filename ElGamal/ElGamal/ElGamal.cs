using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElGamal
{
    class ElGamal
    {
        public string Encrypt(BigInteger p, int g, int y, string text)
        {
            List<int> mMass = new List<int>();
            BigInteger k;
            string result;
            int a, b, mj;
            byte[] textInIntList;
            textInIntList = TextToIntArray(text);
            //textInIntList[0] = 8;//вводное данное
            k = SessionKey();
            foreach (int i in textInIntList)
            {
                foreach(char j in i.ToString()){
                    a = (int)BigInteger.ModPow(g, k, p);
                    mj = (int)char.GetNumericValue(j);
                    b = (int)(BigInteger.ModPow((BigInteger.ModPow(y, k, p) * BigInteger.ModPow(mj, 1, p)), 1, p));
                    //b = (int)(BigInteger.ModPow((BigInteger.Multiply(BigInteger.Pow(y, (int)k), mj) * BigInteger.ModPow(mj, 1, p)), 1, p)); // неверно
                    mMass.Add(a);
                    mMass.Add(b);
                } 
            }
            result = ListIntToString(mMass);
            return result;
        }

        private string ListIntToString(List<int> mMass)
        {
            StringBuilder result = new StringBuilder();
            foreach(int i in mMass)
            {
                result.Append(i+" ");
            }
            return result.ToString();
        }

        private BigInteger SessionKey()
        {
            //Рандомн для BigInteger заполняя массив NextByte < p-1
            return 9;
        }

        public string Deencrypt(BigInteger p, BigInteger x, string chipher)
        {

            string text = "";
            string[] textArray;
            byte[] mass;
            textArray = chipher.Trim().Split(' ');
            mass = new byte[textArray.Length/2];
            int result;

            int j = 0, k= 0, a = 0, b;
            foreach (string i in textArray)
            {
                if(j%2 == 0)
                {
                    a = int.Parse(i);
                }
                if (j % 2 != 0)
                {
                    b = int.Parse(i);
                    result = (int)(BigInteger.ModPow((BigInteger.ModPow(b, 1, p) * BigInteger.ModPow(a, p - 1 - x, p)), 1, p));
                    //result = (int)(BigInteger.ModPow(BigInteger.Multiply(b,BigInteger.Pow(a, (int)(p-1-x))), x, p));
                    mass[k] = (byte)result;
                    
                    k++;
                }
                j++;
            }
            text = Encoding.ASCII.GetString(mass);
            return text;
        }

        private static byte[] TextToIntArray(string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }
    }
}
