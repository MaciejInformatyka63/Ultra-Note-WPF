using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Stub : IChargeur
    {
        public Bouquin ChargeurBouquin(string chemin)
        {
            Bouquin bouquin = new Bouquin();
            bouquin.AjouterUneNote(new Note("Mon super document", "<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"> <Paragraph>Un méga super document avec plein de super mots !!</Paragraph></FlowDocument>"));
            bouquin.AjouterUneNote(new Note("Nouveau document", "<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"> <Paragraph>Bienvenue dans UltraNotes !</Paragraph></FlowDocument>"));
            bouquin.AjouterUneNote(new Note("Cours de maths n°1", "<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"> <Paragraph>Les suites : les suites doivent se suivre, sinon ce ne sont pas des suites. Incroyable !</Paragraph></FlowDocument>"));
            bouquin.AjouterUneNote(new Note("Cours de maths n°2", "<FlowDocument PagePadding=\"5, 0, 5, 0\" AllowDrop=\"True\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph TextAlignment=\"Center\"><Run FontFamily=\"Rockwell\" FontWeight=\"Bold\" FontSize=\"18\">Les arbres pondérés</Run></Paragraph><Paragraph><Run xml:lang=\"fr-fr\">U</Run>n abre pondéré n'est pas un chêne</Paragraph></FlowDocument>"));
            return bouquin;
        }
    }
}
