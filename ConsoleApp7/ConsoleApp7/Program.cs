using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4;
using Antlr4.StringTemplate;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ref: https://stackoverflow.com/questions/2325782/nested-loop-in-stringtemplate

            List<Source> sources = new List<Source> 
            {
                new Source
                {
                    Name = "S1",
                    ValueProperties = new List<ValueProperty>
                    {
                        new ValueProperty
                        {
                            PropertyName = "S1T1",
                            PropertyNameInJson = "s1t1"
                        },
                        new ValueProperty
                        {
                            PropertyName = "S1T2",
                            PropertyNameInJson = "s1t1"
                        },
                        new ValueProperty
                        {
                            PropertyName = "S1T3",
                            PropertyNameInJson = "s1t1"
                        }
                    }
                },
                new Source
                {
                    Name = "S2",
                    ValueProperties = new List<ValueProperty>
                    {
                        new ValueProperty
                        {
                            PropertyName = "S2T1",
                            PropertyNameInJson = "s1t1"
                        },
                        new ValueProperty
                        {
                            PropertyName = "S2T2",
                            PropertyNameInJson = "s1t1"
                        },
                        new ValueProperty
                        {
                            PropertyName = "S2T3",
                            PropertyNameInJson = "s1t1"
                        }
                    }
                }
            };

            var data = sources.Select(
                p => 
                {
                    return new
                    {
                        ClassNameReport = p.Name,
                        ValueProperties = p.ValueProperties
                    };
                });

            var s = File.ReadAllText(@"C:\Temp\Apps\ConsoleApp7\ConsoleApp7\test.st");
            var t = new Template(s);

            t.Add("methods", data);

            var x = t.Render();

            Console.WriteLine(x);
        }
    }
    /*
<
Sources:
 {
    Source|
    sourcename = <Source.Name>
    <
    Source.Documents:
     {
      Document|
      title <Document.Title>
     }
    >
 }
>

     * */

    public class ValueProperty
    {
        public string PropertyName { get; set; }
        public string PropertyNameInJson { get; set; }
    }

    public class Source
    {
        public string Name { get; set; }

        public List<ValueProperty> ValueProperties { get; set; }
    }

}
