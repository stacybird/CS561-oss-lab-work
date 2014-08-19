using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LandisTextToXML
{
    class Program
    {
        private static string currentFile;
        private static string baseDirectory;
        static void Main(string[] args)
        {
            /// make this more generic to get the context of the current directory from the program
            baseDirectory = "C:\\landis-ii svn\\Century-succession\\trunk\\tests\\v6.0-3.0\\";
            currentFile = "Scenario.txt";
            String[] input = File.ReadAllLines(baseDirectory + currentFile);

            /// format of XML should match that of the output XML files.  
            /// all XML begins with the LandisMetadata root node.
            /// structure seems to vary by extension, need to find more of a common thread for the format.
            XElement landisMetadata =
                new XElement("LandisMetadata",
                    new XElement("input",
                        new XElement (currentFile,
                            from item in input
                            select new XElement("Line", item)
                        )
                    )
                );


            ///write out the xml when done
            landisMetadata.Save("myXmlOutput.xml");


        }
    }
}
