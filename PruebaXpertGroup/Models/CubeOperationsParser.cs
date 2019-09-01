using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaXpertGroup.Models
{
    public class CubeOperationsParser
    {

        private long t;
        private long m;
        private Cube cube = null;


        public CubeOperationsParser()
        {

        }       

        public string SetTestCases(string number)
        {
            string ret = "";
            try
            {
                t = Convert.ToInt64(number);
                m = -1;
                cube = null;
                ret = "";
            }
            catch (Exception e)
            {
                ret = "[ERROR] " + e.Message;
            }
            return ret;
        }

        public string BeginNewTestCase(string n, string m)
        {
            string ret = "";
            try
            {
                long ni = Convert.ToInt64(n);
                this.m = Convert.ToInt64(m);
                cube = new Cube(ni);

                ret = "";
            }
            catch (Exception e)
            {
                ret = "[ERROR] " + e.Message;
            }
            return ret;
        }

        public string ExecuteUpdate(string x, string y, string z, string w)
        {
            string ret = "";
            try
            {
                cube.Update(Convert.ToInt64(x), Convert.ToInt64(y), Convert.ToInt64(z), Convert.ToInt64(w));
                ret = "";
            }
            catch (Exception e)
            {
                ret = "[ERROR] " + e.Message;
            }
            return ret;
        }

        public string ExecuteQuery(string x1, string y1, string z1, string x2, string y2, string z2)
        {
            string ret = "";
            try
            {
                ret = cube.Query(Convert.ToInt64(x1), Convert.ToInt64(y1), Convert.ToInt64(z1), Convert.ToInt64(x2), Convert.ToInt64(y2), Convert.ToInt64(z2)).ToString();
            }
            catch (Exception e)
            {
                ret = "[ERROR] " + e.Message;
            }
            return ret;
        }

        public string ParseLine(string line)
        {
            string outS = null;

            string[] words = line.Split(' ');

            if (words.Length == 1)
            {
                if (words[0] == "exit") return null;

                outS = SetTestCases(words[0]);
            }
            else if (words.Length == 2)
            {
                outS = BeginNewTestCase(words[0], words[1]);
            }
            else if (words.Length > 2)
            {
                if (words[0] == "UPDATE")
                {
                    outS = ExecuteUpdate(words[1], words[2], words[3], words[4]);
                }
                else if (words[0] == "QUERY")
                {
                    outS = ExecuteQuery(words[1], words[2], words[3], words[4], words[5], words[6]);
                }
                else
                {
                    outS = "[ERROR] Not recognizable";
                }
            }

            return outS;
        }


        public string ParseCode (string code)
        {
            string ret = "";
            if (code != null && !(code.Trim() == ""))
            {
                using (TextReader sr = new StringReader(code))
                {
                    string l = sr.ReadLine();
                    while (l != null)
                    {
                        string s = ParseLine(l);

                        if (s == null)
                        {
                            Environment.Exit(0);
                        }
                        else if (s.Trim() == "")
                        {
                        }
                        else
                        {
                            ret = ret + s + "\n";
                        }

                        l = sr.ReadLine();
                    }
                }
            }
            return ret;
        }
    }
}
