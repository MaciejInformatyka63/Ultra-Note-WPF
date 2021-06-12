using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Modele;

namespace DataContractPersistance
{
    public class DataContractPers : IPersistanceBouquin
    {
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");

        public DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(Note),
                                                                        new DataContractSerializerSettings() 
                                                                        { 
                                                                            PreserveObjectReferences = true 
                                                                        });

        public IEnumerable<Note> ChargeDonnées()
        {   
            List<Note> notes = new List<Note>();

            foreach (var ficNote in Directory.EnumerateFiles(FilePath))
            {
                if(!File.Exists(ficNote))
                {
                    throw new FileNotFoundException("le fichier n'éxiste pas");
                }
                Note note;
                using (Stream s = File.OpenRead(ficNote))
                {
                    note = Serializer.ReadObject(s) as Note;
                    notes.Add(note);
                }
            }
            
            return notes;
        }

        public void SauvegardeDonnées(IEnumerable<Note> notes)
        {
            if(!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            var settings = new XmlWriterSettings() { Indent = true };
            foreach(Note n in notes)
            {
                using(TextWriter tw = File.CreateText(Path.Combine(FilePath, n.Nom)))
                {
                    using(XmlWriter writer = XmlWriter.Create(tw,settings))
                    {
                        Serializer.WriteObject(writer, n);
                    }
                }
            }
        }

    }
}
