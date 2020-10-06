using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Filhantering
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Bird bird1 = new Bird();
            XmlSerializer serializer = new XmlSerializer(typeof(Bird));

            if(File.Exists("Bird.xml") == false)
            {
                System.Console.WriteLine("What is your birds name?");
                bird1.name = Console.ReadLine();

                System.Console.WriteLine("What color is your bird?");
                bird1.color = Console.ReadLine();

                System.Console.WriteLine("What gender is your bird?");
                bird1.gender = Console.ReadLine();

                FileStream file = File.Open(@"Bird.xml", FileMode.OpenOrCreate);
                serializer.Serialize(file, bird1);
                file.Close();

            }
            else
            {
                System.Console.WriteLine("There seems to be an existing description of your bird, do you want to 'view' it or 'delete' it?");
                string answer = Console.ReadLine();
                if (answer == "view")
                {
                    FileStream file = File.Open(@"Bird.xml", FileMode.OpenOrCreate);
                    bird1 = (Bird) serializer.Deserialize(file);
                    System.Console.WriteLine("Your birds name is " + bird1.name + ".");
                    System.Console.WriteLine("Your birds color is " + bird1.color + ".");
                    System.Console.WriteLine("Your birds gender is " + bird1.gender + ".");                    
                    System.Console.WriteLine("Cool huh?");
                    file.Close();
                    Console.ReadLine();
                }
                else if (answer == "delete")
                {
                    File.Delete(@"Bird.xml");
                }
                else
                {
                    System.Console.WriteLine("I don't understand.");
                    answer = Console.ReadLine();
                }
                
                
            }

            



            /*
            Platform myPlatform = new Platform();

            myPlatform.width = 10;
            myPlatform.x = 5;
            myPlatform.y = 2;
            myPlatform.falling = true;

            XmlSerializer serializer = new XmlSerializer(typeof(Platform)); //skapar en serialiserare

            FileStream file = File.Open("platforms.xml", FileMode.OpenOrCreate); 

            file.Close(); //om vi inte stänger filen kommer inga andra program kunna ändra filen innan vårt program stängs ner.

            serializer.Serialize(file, myPlatform);

            Console.ReadLine();
            */



            // File.WriteAllText("text.txt", "Sexy fucker");

            // string n = File.ReadAllText("text.txt");

            // string[] nonsens = {"bla", "blo", "blä"};

            // File.WriteAllLines("nonsens.txt", nonsens);

            // string o = File.ReadAllText("nonsens.txt");

            // System.Console.WriteLine(n);
            // System.Console.WriteLine(o);
            // Console.ReadLine();

        }
    }
}
