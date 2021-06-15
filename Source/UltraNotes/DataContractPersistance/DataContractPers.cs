using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Modele;

namespace DataContractPersistance
{
    /// <summary>
    /// Cette classe contient des méthodes pour lire et écrire des données dans des fichiers éxistants ou créer par ces mêmes méthodes
    /// </summary>
    public class DataContractPers : IPersistanceBouquin
    {
        /// <summary>
        /// Propriété qui représente le chemin du répertoire qui contient les fichiers/notes
        /// </summary>
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
        /// <summary>
        /// Propriété qui définit le type de l'élément que l'on veut persister,
        /// les settings permettent de donner un "ID" au proriétés du type de l'élément spécifié précedemment
        /// </summary>
        public DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(Note),
                                                                        new DataContractSerializerSettings() 
                                                                        { 
                                                                            PreserveObjectReferences = true 
                                                                        });
        /// <summary>
        /// Propriété qui définit le type de l'élément que l'on veut persister,
        /// les settings permettent de donner un "ID" au proriétés du type de l'élément spécifié précedemment
        /// </summary>
        public DataContractSerializer SerializerParam { get; set; } = new DataContractSerializer(typeof(Parametres),
                                                                        new DataContractSerializerSettings()
                                                                        {
                                                                            PreserveObjectReferences = true
                                                                        });

        public IEnumerable<Note> ChargeDonnees()
        {   
            List<Note> notes = new List<Note>();

            // on teste si le dossier existe, sinon on le crée
            if (!Directory.Exists(FilePath)) Directory.CreateDirectory(FilePath);
            // on récupère dans une variable chaque fichier contenu dans le répertoire correspondant à FilePath
            foreach (var ficNote in Directory.EnumerateFiles(FilePath))
            {
                if(!File.Exists(ficNote))
                {
                    throw new FileNotFoundException("le fichier n'éxiste pas");
                }
                if (!ficNote.Equals(Path.Combine(FilePath, "parametres.xml")))
                {
                    Note note;
                    // on ouvre le fichier dans un flux..
                    using (Stream s = File.OpenRead(ficNote))
                    {
                        //..puis on déserialise et interprète l'objet déserialisé comme une Note
                        note = Serializer.ReadObject(s) as Note;
                        if (note.StylesUtilisateur != null) note.StylesUtilisateur = new List<Style>(note.StylesUtilisateur);
                        else note.StylesUtilisateur = new List<Style>();
                        notes.Add(note);
                    }
                }
            }
            
            return notes;
        }

        public void SauvegardeNote(Note note)
        {
            // on teste si le dossier existe, sinon on le crée
            if (!Directory.Exists(FilePath)) Directory.CreateDirectory(FilePath);
            // paramètres qui indiquent que le fichier devra être indenté
            var settings = new XmlWriterSettings() { Indent = true };

            // on crée un fichier à l'emplacement spécifié par le chemin donné..
            using(TextWriter tw = File.CreateText(Path.Combine(FilePath, note.Nom)))
            {
                using(XmlWriter writer = XmlWriter.Create(tw,settings))
                {
                    //..puis on écrit une des instances de Note de la collection passée en paramêtre dans ce fichier
                    Serializer.WriteObject(writer, note);
                }
            }
        }

        public void SauvegardeDonnees(IEnumerable<Note> notes)
        {
            // on sauvegarde chaque notes
            foreach(Note n in notes)
            {
                SauvegardeNote(n);
            }
        }

        public Parametres ChargerParametres()
        {
            // on crée l'objet parametre qu'on va renvoyer
            Parametres param;

            // on teste si le dossier existe, sinon on le crée
            if (!Directory.Exists(FilePath)) Directory.CreateDirectory(FilePath);

            // on teste si le fichier existe, sinon on le crée
            if (!File.Exists(Path.Combine(FilePath, "parametres.xml")))
            {
                param = new Parametres();
            }
            else
            {
                // on ouvre le fichier dans un flux..
                using (Stream s = File.OpenRead(Path.Combine(FilePath, "parametres.xml")))
                {
                    //..puis on déserialise et interprète l'objet déserialisé comme un Parametres
                    try
                    {
                        param = SerializerParam.ReadObject(s) as Parametres;
                        if (param is null) return new Parametres();
                    }
                    catch (XmlException e)
                    {
                        return new Parametres();
                    }
                    
                }
            }

            // on revoie l'objet param;
            return param;
        }

        public void SauverParametres(Parametres param)
        {
            // on définie le chemin vers le fichier des paramètres
            string ParamPath = Path.Combine(FilePath, "parametres.xml");

            // on teste si le dossier existe, sinon on le crée
            if (!Directory.Exists(FilePath)) Directory.CreateDirectory(FilePath);
            // pareil pour le fichier parametres
            if (!File.Exists(ParamPath)) File.Create(ParamPath);
            // paramètres qui indiquent que le fichier devra être indenté
            var settings = new XmlWriterSettings() { Indent = true };

            // on crée un fichier à l'emplacement spécifié par le chemin donné..
            using (TextWriter tw = File.CreateText(ParamPath))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    //..puis on écrit une des instances de Note de la collection passée en paramêtre dans ce fichier
                    SerializerParam.WriteObject(writer, param);
                }
            }
        }
    }
}
