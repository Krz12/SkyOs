using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class Run : Command
    {
        public Run(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            try
            {
                FileStream runfs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(Kernel.path+ args[0]).GetFileStream();

                if (runfs.CanRead)
                {
                    Byte[] data = new Byte[256];
                    runfs.Read(data, 0, data.Length);
                    string code = Encoding.ASCII.GetString(data);
                    StringBuilder builder = new StringBuilder();
                    List<string> LZP = new List<string>();
                    List<LZPC> lzp = new List<LZPC>();
                    List<string> PZN = new List<string>();
                    List<pzn> pznu = new List<pzn>();
                    int ssn;
                    string ssns;
                    string @do = code;
                    string left = code;
                    int indexofdot = 0;
                    for (int i = 0; i == 0;)
                    {
                        if (left.Contains(";"))
                        {
                            indexofdot = left.IndexOf(";");
                        }
                        else
                        {
                            i = 1;
                        }
                        int leftLenght = left.Length;
                        @do = left.Remove(indexofdot, leftLenght - indexofdot);
                        @do = @do + ";";
                        left = left.Remove(0, indexofdot + 1);
                        if (@do == "ver 0.1;")
                        {
                            Console.WriteLine("Debug: Program Version 0.1");
                        }
                        else
                        {
                            if (@do == "ver 0.2;")
                            {
                                Console.WriteLine("Debug: Program Version 0.2");
                                Console.WriteLine("Debug: Changing Sa version!");
                            }
                        }
                        if (@do == "debug;")
                        {
                            Console.WriteLine("Debug worked!");
                            foreach (var i1 in lzp)
                            {
                                Console.WriteLine("Debug: VarribleID: " + i1.PZN + " Varrible value: " + i1.PZV);
                            }
                        }
                        if (@do.Contains("App.Title"))
                        {
                            string cn = "App.Title";
                            int cnl = cn.Length + 1;
                            @do = @do.Remove(0, cnl);
                            int @dol = @do.Length;
                            @do = @do.Remove(dol - 1, 1);
                            Console.WriteLine(@do);
                        }
                        if (@do.Contains("Console.WriteLine"))
                        {
                            string cn = "Console.WriteLine";
                            int cnl = cn.Length + 1;
                            @do = @do.Remove(0, cnl);
                            int @dol = @do.Length;
                            @do = @do.Remove(dol - 1, 1);
                            Console.WriteLine(@do);
                        }
                        if (@do.Contains("string.create"))
                        {
                            string cn = "string.create";
                            int cnl = cn.Length + 1;
                            @do = @do.Remove(0, cnl);
                            int @dol = @do.Length;
                            @do = @do.Remove(dol - 1, 1);
                            lzp.Add(new LZPC { PZN = @do, PZV = "0" });
                        }
                        if (@do.Contains("string.set"))
                        {
                            string cn = "string.set";
                            int cnl = cn.Length + 1;
                            @do = @do.Remove(0, cnl);
                            int @dol = @do.Length;
                            @do = @do.Remove(dol - 1, 1);
                            string back = @do;
                            cnl = @do.IndexOf(","); //
                            dol = @do.Length;
                            @do = @do.Remove(cnl, dol - cnl); //1?
                            ssn = int.Parse(@do);
                            ssns = @do;
                            //Value
                            @do = back;
                            cnl = @do.IndexOf(",");
                            @do = @do.Remove(0, dol - cnl);
                            lzp.Insert(ssn - 1, new LZPC { PZN = ssns, PZV = @do });
                            lzp.RemoveAt(ssn);
                        }
                        if (@do.Contains("string.math.+"))
                        {
                            string cn = "string.math.+";
                            int cnl = cn.Length + 1;
                            @do = @do.Remove(0, cnl); //np: var:1+num:2;
                            int @dol = @do.Length;
                            @do = @do.Remove(dol - 1, 1);
                            //np: var:2=var:1+num:2
                            string back = @do; //save: var:1+num:2
                                               ////////////////////////////////////////////////
                            ///Zamiana zmiennych na liczby//////////////////
                            if (@do.Contains("var:"))
                            {
                                foreach (var i2 in lzp)
                                {
                                    string var1 = i2.getV();
                                }
                                Console.WriteLine();
                                cn = "var:";
                                cnl = @do.IndexOf("v");
                                @do = @do.Remove(cnl, 4); // z: var:1+num:2 do: 1+num:2


                            }
                            cnl = @do.IndexOf("+"); // cnl = miejsce plusa
                            dol = @do.Length;
                            @do = @do.Remove(cnl, dol - cnl);
                            ssn = int.Parse(@do);
                            ssns = @do;
                            //Value
                            @do = back;
                            cnl = @do.IndexOf(",");
                            @do = @do.Remove(0, dol - cnl);
                            lzp.Insert(ssn - 1, new LZPC { PZN = ssns, PZV = @do });
                            lzp.RemoveAt(ssn);
                            if (@do == "end;")
                            {
                                i = 1;
                            }
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Unable to read file! Not open for reading.");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("");
            }
            return "";
        }
        public class LZPC
        {
            public string PZN;
            public string PZV;
            public string getV()
            {
                return this.PZV;
            }
        }
        public class pzn
        {
            public string PZN;
        }
    }
}
